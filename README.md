# Magankorhaz
SZT2

# Előkövetelmény

- GIT: https://git-scm.com/download/win
- Visual Studio 2013 (az Entity Manager elvileg már benne van a project-ben) (FONTOS: 2013-as VS legyen!)

# Adatbázis létrehozása és kezelése

1. Az "AdatbazisMentes" mappából másold be a két fájlt ide: C:\Users\<felhasználóneved> Innen fogja beolvasni a localdb az adatokat.
2. Indítsd el az project-et és próbáld ki. Elvileg egy "Sikeres csatlakozás" üzenetnek kell megjelennie és egy ListBox-nak egy adatsorral.

# Esetleges problémaelhárítás

1. View -> Server Explorer
2. Data Connections jobb klikk -> Add connection -> Microsoft SQL Server (SqlClient)
3. Server Name: (localdb)\v11.0
4. Ha a fenti sort beírtad, akkor aktívnak kell lennie ennek a mezőnek: "Select or enter database name"
5. Ott választ ki a "magankorhazDB"-t
6. OK és újrafuttatod a kódot

:)