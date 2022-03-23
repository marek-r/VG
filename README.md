**OPIS**

Generator kodów rabatowych (VG)

Zestaw znaków: **ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789**

Maksymalna ilość znaków: **20**

Maksymalna ilość kodów: **5.000.000** (Przetestowana)

1. **Prefix**: Zestaw znaków (max 8), który jest wstawiany przed wygenerowanym kodem. Znak ((`: dwukropek`) jest znakiem niedozwolonym w prefiksie.
2. Jeśli program wykryje istniejący plik (KodyRabatowe) z kodami to wyświetli zapytanie czy kontynuować generowanie kodów zgodnie z ustawieniami zawartymi w pliku i kolejnym numerem kodu (w takim przypadku bieżące ustawienia są ignorowane na rzecz ustawień zapisanych w pliku).
Powyższa funkcjonalność ma zastosowanie, gdy generujemy dużą ilość kodów (np. 50000) i z jakiegoś chcemy przerwać generowanie kodów, w takim przypadku można anulować generowanie kodów (Opcje->Anuluj generowanie kodów/wczytywanie pliku do listy), wtedy plik z kodami i ustawieniami jest zapisywany w katalogu roboczym.
  Po zaakceptowaniu kontynuacji generowania kodów w pierwszej kolejności:

    a. program ustawia zapisaną konfigurację kodów,

    b. następnie ładuje wygenerowane kody z pliku do listy,

    c. dalej z listy wcześniej wygenerowane kody ładowane są do okna programu,

    d. po załadowaniu wszystkich kodów generowane są nowe kody.  
    
    Jeśli proces generowania kodów zostanie anulowany, a okno generatora kodów nie zostało jeszcze zamknięte to uruchamiając 
    ponownie generowanie kodów, wygenerowane kody znajdują się w pamięci programu (na liście), w takim przypadku pomijane jest
    ładowanie wygenerowanych kodów z pliku co w przypadku dużej liczby kodów znacząco skraca czas kontynuacji generowania nowych kodów.

3. W przypadku generowania nowej listy kodów plik z dotychczas wygenerowanymi kodami zostanie nadpisany plikiem z nowymi ustawieniami i kodami.
**Ważne:** Linia konfiguracji jest weryfikowana, nie wolno modyfikować pliku KodyRabatowe.txt 

**Opcja Spakuj kody.**

Zaznaczenie tej opcji spowoduje spakowanie wygenerowanych kodów do katalogu Kody_rabatowe w katalogu głównym (roboczym) programu.
Kody generują się i zapisują do pliku z prefixem.

![](https://projekty.azurewebsites.net/screens/vc/vg.png)

**WYMAGANIA**

- Microsoft .NET Framework 4.8 (x86ix64)

**INSTALACJA**

Program nie jest podpisany komercyjnym certyfikatem.

Plik instalacyjny znajduje się pod [adresem](https://projekty.azurewebsites.net/VG/VG_instalacja.htm):
