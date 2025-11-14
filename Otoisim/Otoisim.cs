using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Otoisim
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "OtomatikIsim - AutoNamePlugin";
        public override string Author => "MadeBy atombombasi_55908";
        public override Version Version => new Version(1, 0, 0);

        private static readonly List<string> AssignedSCPs = new List<string>();
        private static readonly List<string> ScpsNeedingProtector = new List<string>();
        private static readonly HashSet<int> UsedDNumbers = new HashSet<int>();
        private static int _guardCount = 0;
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
                Log.Info($"D-Class isim atandı: {title}");
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
                    Log.Info($"Bilim Adamı SCP-{num} isim atandı: {title}");
                }
                else
                {
                    title = Config.HeadResearcherTitle.Replace("{nick}", originalNick);
                    Log.Info($"Baş Araştırmacı isim atandı: {title}");
                }
            }
            else if (role == RoleTypeId.FacilityGuard)
            {
                _guardCount++;

                if (_guardCount == 1)
                {
                    title = Config.ColonelTitle.Replace("{nick}", originalNick);
                    Log.Info($"Albay isim atandı: {title}");
                }
                else if (_guardCount == 2)
                {
                    title = Config.SergeantTitle.Replace("{nick}", originalNick);
                    Log.Info($"Çavuş isim atandı: {title}");
                }
                else
                {
                    if (ScpsNeedingProtector.Count > 0)
                    {
                        int idx = Rnd.Next(ScpsNeedingProtector.Count);
                        string num = ScpsNeedingProtector[idx];
                        ScpsNeedingProtector.RemoveAt(idx);
                        title = Config.ProtectorTitle.Replace("{num}", num).Replace("{nick}", originalNick);
                        Log.Info($"SCP-{num} Koruma isim atandı: {title}");
                    }
                    else
                    {
                        title = Config.CellGuardTitle.Replace("{nick}", originalNick);
                        Log.Info($"Koğuş Görevlisi isim atandı: {title}");
                    }
                }
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

        public string DClassPrefix { get; set; } = "D-{num} | {nick}";
        public string ColonelTitle { get; set; } = "Tesis Albayı | LV4 | {nick}";
        public string SergeantTitle { get; set; } = "Tesis Çavuşu | LV3.5 | {nick}";
        public string ResearcherTitle { get; set; } = "SCP-{num} Araştırmacısı | LV2 | {nick}";
        public string HeadResearcherTitle { get; set; } = "Baş Araştırmacısı | LV3 | {nick}";
        public string ProtectorTitle { get; set; } = "SCP-{num} Koruması | LV2 | {nick}";
        public string CellGuardTitle { get; set; } = "Koğuş Görevlisi | LV2.5 | {nick}";
    }
}