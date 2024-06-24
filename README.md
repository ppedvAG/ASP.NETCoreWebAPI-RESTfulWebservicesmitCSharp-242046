# ASP.NETCoreWebAPI-RESTfulWebservicesmitCSharp-242046
KursRepository zu Kurs ASP.NET Core Web API - RESTful Webservices mit C# der ppedv AG

## Modul 001 Einf�hrung WebAPI

- WheaterForecastAPI erstellt
- Projektstruktur erkl�rt

## Modul 003 Dependency Injection

- BusinessLogic Class Library Project erstellt
- Vehicle Demo Klassen
- Interface als Contract extrahiert
- In Program.cs mittels DI registriert
- GET Methode f�r den Controller geschrieben um Liste von zuf�lligen Fahrzeugen zu erhalten

## Modul 004 Routing

- Movie Database Api
- Controller mit CRUD Operationen
- Model constraints
- LAB: Movie DB erstellen

## Modul 005 EF Core

- Code First: VehicleFleet Datenbank
- Datenklasse mit Attriuten versetzt
- DbContext erzeugt
- Connection string erstellt
- Abh�ngigkeiten via DI registriert
- LAB: DB f�r Movie DB erstellen

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add myInitialScript --project myProject
dotnet ef database update --project myProject
```

- Db First: Northwind Datenbank
- EF Core Power Tools "Reverse Engineering"
- Controller erzeugen
- LAB: Daten von Northwind abfragen
	* Alle Bestellungen
	* Alle Bestellungen innerhalb eines Zeitraumes (Parameter: StartDate, EndDate)
	* Bestellungen pro Kunde (Parameter: CustomerID)
	* Kunden pro Land (Parameter: Country)
