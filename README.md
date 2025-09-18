# SportClub Management 

A WPF .NET C# aplikacija za upravljanje sportskim klubom, sa SQLite bazom podataka (Entity Framework) i Material Design korisničkim interfejsom.

## Funkcionalnosti

### Autentifikacija i upravljanje korisnicima
- Dvostruki sistem uloga: Administrator i Instruktor
- Logovanje sa kontrolom pristupa na osnovu uloga

![image_alt](https://github.com/milanaivankovich/SportClub_hci/blob/5f2f548ffe1779b52d64993d17f1582aac03ee4e/photos/Screenshot%20(14).png)

### Mogućnosti administratora
- Upravljanje instruktorima (dodavanje/izmena)
- Upravljanje takmičenjima (kreiranje/izmena)
- Upravljanje članarinama (dodavanje/izmena)
- Podešavanje teme aplikacije
- Promjena ličnih podešavanja

![image_alt](https://github.com/milanaivankovich/SportClub_hci/blob/5f2f548ffe1779b52d64993d17f1582aac03ee4e/photos/Screenshot%20(22).png)

### Mogućnosti instruktora
- Upravljanje članovima (dodavanje/izmena)
- Evidencija prisustva na treningu
- Kreiranje novih treninga
- Prikaz i pretraga takmičenja
- Upravljanje učesnicima na takmičenjima
- Dodavanje članarina članovima
- Podešavanje ličnih postavki

![image_alt](https://github.com/milanaivankovich/SportClub_hci/blob/5f2f548ffe1779b52d64993d17f1582aac03ee4e/photos/Screenshot%20(15).png)

### Teme aplikacije
- Tamna tema (Dark)
- Svijetla tema (Light)
- Podrazumjevana tema (Default)
- Tema se pamti u bazi i primenjuje pri sledećem pokretanju aplikacije

## Instalacija i pokretanje

1. Preuzmite ili klonirajte repozitorijum 

```sh
git clone https://github.com/milanaivankovich/SportClub_hci.git
```

2. Otvorite solution fajl (.sln) u Visual Studio 2019 ili novijoj verziji
3. Restore-ujte NuGet pakete (Tools > NuGet Package Manager > Restore NuGet Packages)
4. Pokrenite aplikaciju (F5 ili Ctrl + F5)

## Uputstvo za korišćenje

### Logovanje
1. Pokrenite aplikaciju
2. Unesite korisničko ime i lozinku
   - Testni administrator: admin / admin
   - Testni instruktor: instructor / instructor

### Upravljanje članovima (instruktor)
1. Izaberite "Članovi" iz menija

#### Dodavanje novog člana
2. Kliknite "Dodaj člana" za unos novog člana
3. Popunite sve potrebne podatke
4. Kliknite "Sačuvaj"

#### Izmjena postojećeg člana
2. Izaberite iz tabele željenog člana
3. Kliknite "Izmjeni člana"
4. Izmjenite željene podatke
5. Kliknite "Sačuvaj"

### Evidencija prisustva (instruktor)
1. Izaberite "Prisustvo" iz menija
2. Izaberite željeni trening iz liste
3. Izaberite člana
4. Kliknite dugme "Dodaj člana"

### Upravljanje takmičenjima (administrator)
1. Izaberite "Takmičenja" iz menija

#### Dodavanje novog takmičenja
2. Kliknite "Dodaj takmičenje" za unos novog takmičenja
3. Popunite sve potrebne podatke
4. Kliknite "Sačuvaj"

#### Izmjena postojećeg takmičenja
2. Izaberite iz tabele željeno takmičenje
3. Kliknite "Izmjeni takmičenje"
4. Izmjenite željene podatke
5. Kliknite "Sačuvaj"

### Promjena teme
1. Izaberite "Podešavanja"
2. Iz padajućeg menija izaberite željenu temu (Dark, Light, Default)
3. Iz padajućeg menija izaberite željeni font
4. Tema će se automatski primjeniti i sačuvati za naredna pokretanja

## Baza podataka

Aplikacija koristi SQLite bazu podataka koja se automatski kreira pri prvom pokretanju. Baza se nalazi u folderu aplikacije pod nazivom "sportclub.db".

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/50de2f0756691f257358d627dcdb7739b213614e/photos/dbSportClub.png)

## Tehnologije

- .NET Framework 4.7.2+
- WPF (Windows Presentation Foundation)
- Entity Framework 6
- SQLite
- Material Design Theming
- MVVM pattern
