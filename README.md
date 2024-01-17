# ZooAnimalManagementSystem
Simple implementation of zoo animal management system.
# Setup
First you need to build the project, then run following commands in the directory of the main project (ZooAnimalManagementSystem).
<br>
To initiate first migration and create database schema:
```
dotnet ef migrations add InitialMigration -o Data/Migrations
```
<br>
To build the database:

```
dotnet ef database update
```
<br>
These commands should be enough to start the project.

# Example flow

To complete the assignment task first of all you need to create the Animal and Enclosure entities. This can be easily done by using bulk endpoints for each entity.
For example to create all of the animals from the json file you can insert the json object into api/bulk/animals. After creating the Animal and Enclosure entities, to assign animals to enclosure we need to call api/transfer endpoint. After that to test the assignment of animals to enclosure and enclosure to animals we can call respective endpoints of get - api/animals or api/enclosure.


