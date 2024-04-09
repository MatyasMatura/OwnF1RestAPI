# Toto je seznam věcí, které v API lze dělat.
Akce | Metoda | Endpoint | Vrací
--- | --- | --- | ---
Získat team podle názvu | GET | /api/teams/{Name} | Team - Ok; NotFound;
Získat seznam teamů podle parametrů | GET | /api/teams/?[points][wins][teamchampionships][carname] | Collection\<Team> - Ok;
Získat všechny drivery teamu | GET | /api/teams/{Name}/drivers | Collection\<Driver> - Ok; NotFound;
Změnit vlastnosti teamu | PUT | /api/teams/{Name} | Team - Ok; NotFound; BadRequest;
Změnit počet bodů teamu | PUT | /api/teams/{Name}/points + body | Team - Ok; NotFound; BadRequest;
Změnit počet výher teamu | PUT | /api/teams/{Name}/wins + body | Team - Ok; NotFound; BadRequest;
Změnit počet výher týmového šampionátu teamu | PUT | /api/teams/{Name}/teamchampionships + body | Team - Ok; NotFound; BadRequest;
Změnit název auta teamu | PUT | /api/teams/{Name}/carname + body | Team - Ok; NotFound; BadRequest;
Vytvořit nový team | POST | /api/teams + body | Created;
Smazat team | DELETE | /api/teams/{Name} | NoContent; NotFound;
Získat počet teamů v databázi  | GET | /api/teams/count | int - Ok;
Získat drivera podle názvu | GET | /api/drivers/{Name} | Driver - Ok; NotFound;
Získat seznam driverů podle parametrů | GET | /api/drivers/?[teamname][points][wins][podiums][titles] | Collection\<Driver> - Ok;
Změnit vlastnosti drivera | PUT | /api/drivers/{Name} | Driver - Ok; NotFound; BadRequest;
Změnit počet bodů drivera | PUT | /api/drivers/{Name}/points + body | Driver - Ok; NotFound; BadRequest;
Změnit počet výher drivera | PUT | /api/drivers/{Name}/wins + body | Driver - Ok; NotFound; BadRequest;
Změnit počet podií drivera | PUT | /api/drivers/{Name}/podiums + body | Driver - Ok; NotFound; BadRequest;
Změnit počet titulů drivera | PUT | /api/drivers/{Name}/titles + body | Driver - Ok; NotFound; BadRequest;
Změnit team drivera | PUT | /api/drivers/{Name}/teamname + body | Driver - Ok; NotFound; BadRequest;
Vytvořit nového drivera | POST | /api/drivers + body | Created; BadRequest;
Smazat drivera | DELETE | /api/drivers/{Name} | NoContent; NotFound;
Získat počet driverů v databázi  | GET | /api/drivers/count | int - Ok;