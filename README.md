
## Set-up
* Clone the repo
* Open the project on Visual studio 
* Go to Tools -> NuGet Package Manager -> Package Manager Console
* Run the following command on Package Manager Console
	*	Add-Migration 'InitialMigration'
	*	Update-Database -Migration 'InitialMigration'
* Compile and Run

* N.B: you need to replace the Server name in appsettings.json with yours
