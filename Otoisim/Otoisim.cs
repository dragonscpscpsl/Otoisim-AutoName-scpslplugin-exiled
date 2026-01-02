using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OtomatikIsim
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "OtomatikIsim - AutoNamePlugin";
        public override string Author => "MadeBy atombombasi_55908";
        public override Version Version => new Version(1, 1, 0);

        private static readonly List<string> AssignedSCPs = new List<string>();
        private static readonly List<string> ScpsNeedingProtector = new List<string>();
        private static readonly HashSet<int> UsedDNumbers = new HashSet<int>();
        private static int _guardCount = 0;
        private static int _ntfCaptainCount = 0;
        private static int _chaosConscriptCount = 0;
        private static readonly Random Rnd = new Random();

        public override void OnEnabled()
        {
            Log.Info("OtomatikIsim plugin etkinleştirildi.");
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Player.Spawned += OnSpawned;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Info("OtomatikIsim plugin devre dışı bırakıldı.");
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Player.Spawned -= OnSpawned;
            base.OnDisabled();
        }

        private void OnRoundStarted()
        {
            AssignedSCPs.Clear();
            ScpsNeedingProtector.Clear();
            UsedDNumbers.Clear();
            _guardCount = 0;
            _ntfCaptainCount = 0;
            _chaosConscriptCount = 0;
            Log.Info("Round başladı. Otomatik isimler sıfırlandı.");
        }

        private void OnSpawned(SpawnedEventArgs ev)
        {
            Player player = ev.Player;
            if (player == null || !player.IsVerified) return;

            string originalNick = player.Nickname;
            RoleTypeId role = player.Role.Type;
            string title = null;

            if (role == RoleTypeId.ClassD)
            {
                int num;
                do
                {
                    num = Rnd.Next(1, 10000);
                } while (UsedDNumbers.Contains(num));
                UsedDNumbers.Add(num);
                title = Config.DClassPrefix.Replace("{num}", num.ToString()).Replace("{nick}", originalNick);
            }
            else if (role == RoleTypeId.Scientist)
            {
                var livingScpNums = Player.List
                    .Where(p => p.IsAlive && p.Role.Team == PlayerRoles.Team.SCPs)
                    .Select(p => p.Role.Type.ToString().Replace("Scp", ""))
                    .Distinct()
                    .ToList();

                var available = livingScpNums.Except(AssignedSCPs).ToList();

                if (available.Count > 0)
                {
                    int idx = Rnd.Next(available.Count);
                    string num = available[idx];
                    AssignedSCPs.Add(num);
                    ScpsNeedingProtector.Add(num);
                    title = Config.ResearcherTitle.Replace("{num}", num).Replace("{nick}", originalNick);
                }
                else
                {
                    title = Config.HeadResearcherTitle.Replace("{nick}", originalNick);
                }
            }
            // Facility Guard (Tesis Görevlileri)
            else if (role == RoleTypeId.FacilityGuard)
            {
                _guardCount++;

                if (_guardCount == 1)
                    title = Config.GuardColonelTitle.Replace("{nick}", originalNick); // Albay
                else if (_guardCount == 2)
                    title = Config.GuardSergeantTitle.Replace("{nick}", originalNick); // Çavuş
                else
                    title = Config.GuardNormalTitle.Replace("{nick}", originalNick); // Tesis Görevlisi (diğerleri)
            }
            // NTF (MTF)
            else if (role == RoleTypeId.NtfCaptain)
            {
                _ntfCaptainCount++;
                if (_ntfCaptainCount == 1)
                    title = Config.NtfCaptainTitle.Replace("{nick}", originalNick); // Kaptan
                else
                    title = Config.NtfLieutenantTitle.Replace("{nick}", originalNick); // Teğmen
            }
            else if (role == RoleTypeId.NtfSergeant || role == RoleTypeId.NtfSpecialist || role == RoleTypeId.NtfPrivate)
            {
                title = Config.NtfSoldierTitle.Replace("{nick}", originalNick); // Normal MTF Askeri
            }
            // Chaos Insurgency
            else if (role == RoleTypeId.ChaosConscript)
            {
                _chaosConscriptCount++;
                if (_chaosConscriptCount == 1)
                    title = Config.ChaosLeaderTitle.Replace("{nick}", originalNick); // Lider
                else
                    title = Config.ChaosSoldierTitle.Replace("{nick}", originalNick); // Normal Chaos Askeri
            }
            else if (role == RoleTypeId.ChaosRepressor || role == RoleTypeId.ChaosRifleman || role == RoleTypeId.ChaosMarauder)
            {
                title = Config.ChaosEliteTitle.Replace("{nick}", originalNick); // Elite Chaos
            }

            if (!string.IsNullOrEmpty(title))
            {
                player.DisplayNickname = title;
                if (Config.Debug)
                {
                    player.ShowHint($"<color=#00FF00>Otomatik isim: {title}</color>", 3);
                }
            }
        }
    }

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;

        // D-Class
        public string DClassPrefix { get; set; } = "D-{num} | {nick}";

        // Bilim Adamları
        public string ResearcherTitle { get; set; } = "SCP-{num} Araştırmacısı | LV2 | {nick}";
        public string HeadResearcherTitle { get; set; } = "Baş Araştırmacısı | LV3 | {nick}";

        // Tesis Görevlileri (FacilityGuard)
        public string GuardColonelTitle { get; set; } = "Tesis Albayı | LV4 | {nick}";      // 1. Guard
        public string GuardSergeantTitle { get; set; } = "Tesis Çavuşu | LV3.5 | {nick}";    // 2. Guard
        public string GuardNormalTitle { get; set; } = "Tesis Görevlisi | LV2 | {nick}";     // 3. ve sonrası

        // MTF (NTF)
        public string NtfCaptainTitle { get; set; } = "MTF Kaptanı | LV4 | {nick}";         // 1. NTF Captain
        public string NtfLieutenantTitle { get; set; } = "MTF Teğmeni | LV3.5 | {nick}";    // Diğer Captain'lar
        public string NtfSoldierTitle { get; set; } = "MTF Askeri | LV3 | {nick}";          // Sergeant/Specialist/Private

        // Chaos Insurgency
        public string ChaosLeaderTitle { get; set; } = "Chaos Lideri | LV4 | {nick}";       // 1. Chaos Conscript
        public string ChaosSoldierTitle { get; set; } = "Chaos Askeri | LV3 | {nick}";      // Diğer Conscript'lar
        public string ChaosEliteTitle { get; set; } = "Chaos Eliti | LV3.5 | {nick}";       // Repressor/Rifleman/Marauder
    }
}