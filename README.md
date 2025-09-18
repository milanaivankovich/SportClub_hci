# Sport Club

## Uvod
 Sport Club je WPF desktop aplikacija napravljena sa ciljem da olakša administraciju sportskog kluba. Aplikacija je namjenjna za korišćenje od strane administratora i instruktora, te u nastavku se nalazi upustvo za korišćenje aplikacije kako za administratora tako i za instruktora. Pored samog korisničkog upustva, nalaze se i koraci za instaliranje i pokretanje aplikacije.

 ## Pregled ključnih funkcionalnosti

 U nastavku su opisane osnovne funkcionalnosti aplikacije.

  ####  - Upravljanje korisničkim nalozima
   Jasno definisane uloge i kontrole pristupa doprinose većoj sigurnosti i pouzdanosti rada aplikacije.

  ####  - Centralizovano upravljanje članovima, članarinam, treninzima, takimičenjima
   Sistem podržava upravljanje upravljanje: članovima, članarinam, treninzima, takimičenjima. Omogućavajući pregled, dodavanje i uređivanje istih.

  ####  - Personalizacija
   Sistem podržava više vizuelnih tema i izmjenu profila korisnika, omogućavajući bolje podešavanje interfejsa prema individualnim potrebama.
  
## Uloge i autentifikacija
 SportClub ima jasno definisane korisničke uloge, što omogućava preciznu podjelu odgovornosti i sprječava neovlašćen pristup funkcijama sistema.

### Uloge u sistemu
SportClub podržava dva tima korisnka, odnosno postoje dvije uloge u sistemu:

#### 1. Administrator

- odgovoran je za kreiranje i uredjivanje naloga instruktora
- odgovoran je za kreiranje i uredjivanje članarina
- odgovoran je za kreiranje i uredjivanje takmičenja

#### 2. Instruktor

- odgovoran je za kreiranje i izmjenu članova
- vrši evidenciju prisustva na treninzima
- kreira novi trening
- prijavljuje članove na takmčenje
- vrši evidenciju članarina po članovima

### Prijava na sistem

Prijava na sistem je ista za obe uloge u sistemu. Prlikom prijave na sistem potrebno je da korisnik unese svoje kredencijale za prijavu na sistem, a to su korisničko ime i lozinka.
Nakon unesenih kredencijala, potrebno je da se klikne dugme PRIJAVI SE, ukoliko su kredencijali ispravni otvoriće se adektvatna prozor shodno ulozi korisnika u sistemu.

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/0dd309d938ddd8bd68316ff8fe4b09946e63dbf1/photos/Screenshot%20(14).png)

## Administrator

Glavne odgovnornosti administratora su kreiranje i uredjivanje naloga instrukora, članarina i takmičenja.

### Kreiranje i uredjivanje naloga instrukora

### Kreiranje i uredjivanje članarina

### Kreiranje i uredjivanje takmičenja

## Instruktor

Glavne odgovnornosti instruktora su kreiranje i izmjena članova, evidencija treninga,takmičenja i članarina, kreiranje treninga.

### Kreiranje i izmjena članova

### Evidencija treninga i kreiranje novog treninga

### Evidencija takmičenja

### Evidencija članarina i kreiranje nove članarine

## Podešavanje korisničkog izgleda i izmjena lozinke

Podešavanje korisničkog izgleda aplikacije je isti za obe uloge u sistemu, isto tako je omogućena i promjena lozinke trenutno prijavljenog korisnika na sistem.

### Podešavanje korisničkog izgleda

Korisnku ima pravo izbora na tri teme (Default, Light i Dark), četiti raličita fonta i šest različitih veličina fonta. Odabir željene teme, fonta i velićine fonta vrši se selekcijom iz padajućeg menia. Sve odabrano se odmah primjenjuje na čitav sistem.

#### Default tema

#### Light tema

#### Dark tema


### Izmjena lozinke

Moguće je promjeniti lozinku, da bi to uradili prvo se unosi trenutna lozinka, nakon toga se unosi nova lozinka i potrebno je da se potvrdi nova lozinka. Promjenja lozinka ce biti zapamćena tek nakon što se klikne dugme IZMJENI LOZINKU.

## Instalacija i pokretanje

1. Preuzmite ili klonirajte repozitorijum

```sh
git clone https://github.com/milanaivankovich/SportClub_hci.git
```

2. Otvorite solution fajl (.sln) u Visual Studio 2019 ili novijoj verziji
3. Restore-ujte NuGet pakete (Tools > NuGet Package Manager > Restore NuGet Packages)
4. Pokrenite aplikaciju (F5 ili Ctrl + F5)
