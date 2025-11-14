# Otoisim-AutoName-scpslplugin-exiled
Good For Roleplay
Roleplay için uyumlu
Exiled Plugin that Automatically changes your name. (Adınızı otomatik olarak değiştiren Exiled Eklentisi.)
# Needs (Gerekli) AdminTools
# Turkish (Türkçe)

🟧 SCPSL Otomatik İsim Plugini – Özellik Listesi

Bu plugin, oyuncuların rollerine göre otomatik ve dinamik isim (DisplayNickname) atayan gelişmiş bir isim sistemi sağlar. Tüm özellikler aşağıdadır:

🟩 ⭐ D-Class Özellikleri

Her D-Class için benzersiz rastgele numara (1–9999)

Numara round boyunca tekrar etmez

Format:

D-XXXX | OyuncuAdı

🟦 ⭐ Scientist (Bilim Adamı) Özellikleri

Yaşayan SCP'lerden birini rastgele seçer

Her SCP sadece bir araştırmacıya atanır

Format:

SCP-XXX Araştırmacısı | LV2 | OyuncuAdı


SCP kalmazsa otomatik:

Baş Araştırmacısı | LV3 | OyuncuAdı

🟨 ⭐ Facility Guard Özellikleri

Guard sayısına göre otomatik role isim verir:

1. Guard:
Tesis Albayı | LV4 | OyuncuAdı

2. Guard:
Tesis Çavuşu | LV3.5 | OyuncuAdı

3+ Guard:

Eğer SCP araştırmacıları varsa:

SCP-XXX Koruması | LV2 | OyuncuAdı


SCP kalmamışsa:

Koğuş Görevlisi | LV2.5 | OyuncuAdı

🟥 ⭐ Round Sistem Özellikleri

Round başladığında tüm listeler sıfırlanır:

Kullanılan D-Class numaraları

Atanmış SCP’ler

SCP koruma listesi

Guard sayısı

Her round temiz başlar, karışıklık olmaz.

🟪 ⭐ Debug / Yönetici Özellikleri

Debug modu açıksa oyuncuya isim atandığında HINT mesajı gösterir

Console log üzerinden tüm atanan isimler takip edilebilir

🟫 ⭐ Config ile Tam Özelleştirme

Plugin’deki tüm isim formatları config üzerinden değiştirilebilir:

D-Class formatı
Araştırmacı formatı
Baş araştırmacı formatı
Koruma formatı
Albay / Çavuş / Koğuş görevlisi formatı


İsteyen sunucu sahibi kendi stiline göre düzenleyebilir.

🟧 ⭐ Örnek Config
d_class_prefix: "D-{num} | {nick}"
colonel_title: "Tesis Albayı | LV4 | {nick}"
sergeant_title: "Tesis Çavuşu | LV3.5 | {nick}"
researcher_title: "SCP-{num} Araştırmacısı | LV2 | {nick}"
head_researcher_title: "Baş Araştırmacısı | LV3 | {nick}"
protector_title: "SCP-{num} Koruması | LV2 | {nick}"
cell_guard_title: "Koğuş Görevlisi | LV2.5 | {nick}"

🎉 Tamamen otomatik, stabil ve yönetici dostu!

# English(İngilizce) Translated on ChatGPT









🟧 SCPSL Automatic Name Plugin – Feature List

This plugin provides an advanced naming system that automatically assigns dynamic names (DisplayNickname) to players based on their roles. All features are listed below:

🟩 ⭐ D-Class Features

Each D-Class receives a unique random number (1–9999)

The number does not repeat during the round

Format:

D-XXXX | PlayerName


🟦 ⭐ Scientist Features

Randomly selects one of the living SCPs

Each SCP is assigned to only one researcher

Format:

SCP-XXX Researcher | LV2 | PlayerName


If no SCPs are left:

Head Researcher | LV3 | PlayerName


🟨 ⭐ Facility Guard Features

Automatically assigns names based on the number of Guards:

1st Guard:

Facility Colonel | LV4 | PlayerName


2nd Guard:

Facility Sergeant | LV3.5 | PlayerName


3rd+ Guard:

If there are SCP researchers:

SCP-XXX Protector | LV2 | PlayerName


If no SCPs are left:

Dormitory Guard | LV2.5 | PlayerName


🟥 ⭐ Round System Features

At the start of each round, all lists are reset:

Used D-Class numbers

Assigned SCPs

SCP protector list

Guard count

Every round begins clean and organized.

🟪 ⭐ Debug / Admin Features

If debug mode is enabled, a HINT message shows the assigned name to the player

All assigned names are logged in the server console

🟫 ⭐ Full Config Customization

All name formats in the plugin can be edited through the config:

D-Class format

Researcher format

Head Researcher format

Protector format

Colonel / Sergeant / Dormitory Guard format

Server owners can fully customize naming styles.

🟧 ⭐ Example Config

d_class_prefix: "D-{num} | {nick}"
colonel_title: "Facility Colonel | LV4 | {nick}"
sergeant_title: "Facility Sergeant | LV3.5 | {nick}"
researcher_title: "SCP-{num} Researcher | LV2 | {nick}"
head_researcher_title: "Head Researcher | LV3 | {nick}"
protector_title: "SCP-{num} Protector | LV2 | {nick}"
cell_guard_title: "Dormitory Guard | LV2.5 | {nick}"


🎉 Fully automatic, stable, and admin-friendly!
