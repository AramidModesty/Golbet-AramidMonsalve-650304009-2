#Change the database to your own in the GolBet.Web/appsettings.json file
#there's a guide on how to do it in dbConfig
#Otherwise, there will be always an error
#Also, don't forget to turn on your database server

#Si eres parte del curso de bases de datos
# solo cambia el contenido del default connection appsettings.json por la siguiente linea:
# "Server= (localdb)\MSSQLLocalDB;Database=GolBetDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"


dotnet ef migrations add InitialDomain -p GolBet.Repositories -s GolBet.Web
dotnet ef database update -p GolBet.Repositories -s GolBet.Web