# Otoisim-AutoName-scpslplugin-exiled

Good For Roleplay Roleplay için uyumlu Exiled Plugin that Automatically changes your name. (Adınızı otomatik olarak değiştiren Exiled Eklentisi.)

# Needs (Gerekli) AdminTools




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
