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

Glavne odgovnornosti administratora su kreiranje i uredjivanje naloga instruktora, članarina i takmičenja.

### Kreiranje i uredjivanje naloga instruktora

Nakon usiješne prijave na sistem u ulozi administratora, prvo se prikazuje tabela instruktora. Moguće je dodati novog instruktora klikom na dugme Dodavanje Instruktora, otvara se prozor za Dodavanje instrukota, koji se sastoji od polja za ime, prezime, korisničko ime i lozinku, ukoliko želite da kreirate novog instruktora kliknete dugme Sačuvaj, ukoliko ne želite kliknete dugme Otkaži. Ukoliko želite da izmjenite podatke već postojećeg instruktora, potrebno je da ga odaberete u tabeli i kliknete dugme 
Izmjena instruktora. Nakon klika na dugme Izmjena instruktora, otvara se prozor za izmjenu, gdje su u poljima učitane vrijednosti odabranog instruktora, sva polja možete izmjeniti, ukoliko hoćete da sačuvate izmjene kliknite na dugme Sačuvaj, u suprotnom na dugme Otkaži.

U nastavku se nalazi prikaz aplikacije. 

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/fee249daf6d2049a7c13cd95b8a140d7318a6aad/photos/Screenshot%20(25).png)

<p align="center">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(37).png" alt="Izmjena instruktora" width="30%">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/fee249daf6d2049a7c13cd95b8a140d7318a6aad/photos/Screenshot%20(24).png" alt="Dodavanje instruktora" width="30%">

</p>

### Kreiranje i uredjivanje članarina

Ukoliko su u meni-u odabrane Članarine. Moguće je dodati novu članarinu klikom na dugme Dodavanje Članarine, otvara se prozor za Dodavanje Članarine, koji se sastoji od polja za naziv, cijena i trajanje, ukoliko želite da kreirate novu članarinu kliknete dugme Sačuvaj, ukoliko ne želite kliknete dugme Otkaži. Ukoliko želite da izmjenite podatke već postojeće članarine, potrebno je da je odaberete u tabeli i kliknete dugme Izmjena Članarine. Nakon klika na dugme Izmjena Članarine, otvara se prozor za izmjenu, gdje su u poljima učitane vrijednosti odabrane članarine, sva polja možete izmjeniti, ukoliko hoćete da sačuvate izmjene kliknite na dugme Sačuvaj, u suprotnom na dugme Otkaži.

U nastavku se nalazi prikaz aplikacije. 

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(36).png)

<p align="center">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(30).png" alt="Izmjena clanarine" width="30%">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(31).png" alt="Dodavanje clanarine" width="30%">

### Kreiranje i uredjivanje takmičenja

Ukoliko su u meni-u odabrane Takmičenja. Moguće je dodati novo takmičenje klikom na dugme Dodavanje Takmičenja, otvara se prozor za Dodavanje Takmičenja, koji se sastoji od polja za naziv, , ukoliko želite da kreirate novo takmičenje kliknete dugme Sačuvaj, ukoliko ne želite kliknete dugme Otkaži. Ukoliko želite da izmjenite podatke već postojećeg takmičenja, potrebno je da je odaberete u tabeli i kliknete dugme Izmjena Takmičenja. Nakon klika na dugme Izmjena Takmičenja, otvara se prozor za izmjenu, gdje su u poljima učitane vrijednosti odabranog takmičenja, sva polja možete izmjeniti, ukoliko hoćete da sačuvate izmjene kliknite na dugme Sačuvaj, u suprotnom na dugme Otkaži.

U nastavku se nalazi prikaz aplikacije. 

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(27).png)

<p align="center">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(29).png" alt="Izmjena clanarine" width="30%">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(28).png" alt="Dodavanje clanarine" width="30%">

## Instruktor

Glavne odgovnornosti instruktora su kreiranje i izmjena članova, evidencija treninga,takmičenja i članarina, kreiranje treninga.

### Kreiranje i izmjena članova

Nakon usiješne prijave na sistem u ulozi instruktora, prvo se prikazuje tabela članova. Moguće je dodati novog člana klikom na dugme Dodavanje Člana, otvara se prozor za Dodavanje člana, koji se sastoji od polja za ime, prezime, korisničko ime i datum rodjenja, ukoliko želite da kreirate novog člana kliknete dugme Sačuvaj, ukoliko ne želite kliknete dugme Otkaži. Ukoliko želite da izmjenite podatke već postojećeg člana, potrebno je da ga odaberete u tabeli i kliknete dugme 
Izmjena Člana. Nakon klika na dugme Izmjena Člana, otvara se prozor za izmjenu, gdje su u poljima učitane vrijednosti odabranog člana, sva polja možete izmjeniti, ukoliko hoćete da sačuvate izmjene kliknite na dugme Sačuvaj, u suprotnom na dugme Otkaži.

U nastavku se nalazi prikaz aplikacije. 

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(38).png)

<p align="center">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(40).png" alt="Izmjena clanarine" width="30%">
  <img src="https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(39).png" alt="Dodavanje clanarine" width="30%">

 
### Evidencija treninga/prisustva i kreiranje novog treninga

Odabirom opcije Prisustvo u meni-u, učitava se prozor u kojem instruktor ima sljedeće mogućnosti:

 - odabirom treninga iz tabele da vidi prisutne članove
 - za odabrani trening iz tabele da doda člana iz padajućeg menia i klikom na dugme Dodaj člana na trening da se to sačuva
 - filtriranje treninga po datumu(kucanjem datuma u polju za datum) ili po tipu treninga(odabirom iz padajućeg menia)
 - kreiranje novog treninga klikom na dugme Novi trening, nakon čega se otvara prozor sa poljima naziv, tip treninga, datum i vrijeme 

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(41).png)
![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(42).png)
![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(43).png)

### Evidencija takmičenja

Odabirom opcije Takmičenje u meni-u, učitava se prozor u kojem instruktor ima sljedeće mogućnosti:

- pretražuje takmičenje po nazivu
- dodaje članove na spisak takmičara
- uklanja takičare sa spiska 

Da bi se sačuvale promjene koje, da li je član dodan ili uklonje sa spiska, potrebno je da se klikne dugme Sačuvaj promjene.


![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(44).png)

### Evidencija članarina i kreiranje nove članarine

Odabirom opcije Članarina u meni-u, učitava se prozor u kojem instruktor ima sljedeće mogućnosti:

- kreira novu članarinu klikom na dugme Nova članarina
- odabirom članarine iz tabele da se prikažu članovi koji imaju tu članarinu
- za odabranu članarinu da se doda član iz padajućeg menia, to da se sačuva potrebno je kliknuti na dugme Dodaj člana na članarinu

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(45).png)
![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/77a4ebb384724a6974347d52c2a0226863eaeff1/photos/Screenshot%20(46).png)
![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/2d99f92bab502508328572d1e2bc77f094cb8aa1/photos/Screenshot%20(31).png)

## Podešavanje korisničkog izgleda i izmjena lozinke

Podešavanje korisničkog izgleda aplikacije je isti za obe uloge u sistemu, isto tako je omogućena i promjena lozinke trenutno prijavljenog korisnika na sistem.

### Podešavanje korisničkog izgleda

Korisnku ima pravo izbora na tri teme (Default, Light i Dark), četiti raličita fonta i pet različitih veličina fonta. Odabir željene teme, fonta i velićine fonta vrši se selekcijom iz padajućeg menia. Sve odabrano se odmah primjenjuje na čitav sistem.

#### Default tema

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/fee249daf6d2049a7c13cd95b8a140d7318a6aad/photos/Screenshot%20(33).png)

#### Dark tema

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/fee249daf6d2049a7c13cd95b8a140d7318a6aad/photos/Screenshot%20(35).png)

#### Light tema

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/fee249daf6d2049a7c13cd95b8a140d7318a6aad/photos/Screenshot%20(34).png)


### Izmjena lozinke

Moguće je promjeniti lozinku, da bi to uradili prvo se unosi trenutna lozinka, nakon toga se unosi nova lozinka i potrebno je da se potvrdi nova lozinka. Promjenja lozinka ce biti zapamćena tek nakon što se klikne dugme PROMIJENI LOZINKU.

![image_uri](https://github.com/milanaivankovich/SportClub_hci/blob/fee249daf6d2049a7c13cd95b8a140d7318a6aad/photos/Screenshot%20(32).png)

## Odjava sa sistema

Odjava sa sistema vriše se klikom na dugme Odjavi me, koje se nalazi u gornjem desnom uglu. Klikom na to dugme odjavlje se sa sistema, trenutni prozor se gasi, a otvara se prozor za prijavu na sistem.

## Instalacija i pokretanje

1. Preuzmite ili klonirajte repozitorijum

```sh
git clone https://github.com/milanaivankovich/SportClub_hci.git
```

2. Otvorite solution fajl (.sln) u Visual Studio 2019 ili novijoj verziji
3. Restore-ujte NuGet pakete (Tools > NuGet Package Manager > Restore NuGet Packages)
4. Pokrenite aplikaciju (F5 ili Ctrl + F5)
