#Change the database to your own in the GolBet.Web/appsettings.json file
#there's a guide on how to do it in dbConfig
#Otherwise, there will be always an error
#Also, don't forget to turn on your database server

#Cada vez que se realizen cambios al proyecto, es recomendado usar los siguientes comandos

dotnet ef migrations add InitialDomain -p GolBet.Repositories -s GolBet.Web
dotnet ef database update -p GolBet.Repositories -s GolBet.Web
