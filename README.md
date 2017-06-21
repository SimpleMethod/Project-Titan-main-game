# Project Titan #
Sieciowy FPS wykorzystujący silnik renderujący Unity.
- - - -
## Lista elementów ##
1. Intro:
    1. Oddzielne odtwarzanie dźwięku i wideo synchronizowane ze sobą
2. Menu:
    1. W pełni zaprogramowane menu bez wsparcia zewnętrznych funkcji
    2. Zaprogramowane opcje ustawień dla silnika Unity
    3. Zabezpieczenie przed przeciążeniem
3. Tryb pojedynczego gracza:
    1. Wykorzystanie Nvidia HBAO+
    2. Wsparcie dla Nvidia Ansel
    3. Symulacja wiatru
    4. Licznik klatek na sekundę
    5. Wsparcie dla LOD
    6. Teselacja
4. Tryb wielu graczy:
   1. Możliwość stworzenia serwera, bycie klientem w jednej aplikacji
   2. Granie w sieci lokalnej
    3. Losowe miejsce odrodzenia postaci (w granicach mapy)
    4. Bonusy dodające/odejmujące życie albo amunicję
    5. Aktualizacja ilości zabójstw, śmierci oraz ilości punktów doświadczenia
5. Lista płac
    1. Pełne zaprogramowanie animacji przejść
    2. Algorytm sprawdza, czy animacja się zakończyła, jeżeli tak to wraca do menu
6. Funkcje
    1. Tworzenie pliku konfiguracyjnego
    2. Sprawdzanie identyfikatora użytkownika
    3. Algorytm umożliwiający zmianę języka dla użytkownika
    4. Haszowanie danych dla API
7. Prosta baza danych i mapa przycisków
8. Program generujący unikalny identyfikator użytkownika
    1. Pobranie numeru seryjnego CPU oraz płyty głównej
    2. Komunikacja dzięki socketowi między grą a programem identyfikującym
9. Webowe API
    1. Komunikacja zabezpieczona dzięki haszowaniu
    2. Użycie PHP z rozszerzeniem MySQLi
    3. Możliwość odczytu z bazy danych ilości zabójstw, śmierci oraz ilość punktów doświadczenia
    4. Możliwość dodania do bazy danych ilości zabójstw, śmierci oraz ilość punktów doświadczenia
- - - -
## Sposób kompilacji projektu ##
1. Należy zainstalować pakiet Visual Studio
2. Należy zainstalować silnik renderujący Unity
3. Po zaimportowaniu projektu należy do folderu **Plugins** biblioteki **Ansel** oraz **JsonNet**
4. Po udanej kompilacji należy przekopiować z folderu **Assets** folder **LanguageDataBase** i przenieść go do **ProjectTitan_Data**
- - - -
## Możliwe problemy ##
1. Po skompilowaniu brak interfejsu
    1. Nie został przekopiowany plik językowy
2. Nivida Ansel nie działa
    1. Należy w folderze ze sterownikiem odnaleźć NvCameraEnable.exe stworzyć skrót i dodać do niego `whitelisting-everything`
- - - -
Przykład działania technologii firmy Nvidia:
 ![picture alt](http://i.imgur.com/Dh1kqXo.png "Nvida <3")
- - - -
Całość projektu dostępna tutaj: https://github.com/SimpleMethod/-Retail-version-ProjectTitan-
