#Change the database to your own in the GolBet.Web/appsettings.json file,
#there's a guide on how to do it in dbConfig.
#Otherwise, there will be always an error.
#Also, don't forget to turn on your database server

#Fun fact, you only have to specify the full path if you put the name of the seeder wrong.
# Same with the options.
#Don't forget to use this each time you change something inside the seeders

dotnet ef migrations add InitialDomain -p GolBet.Repositories -s GolBet.Web
dotnet ef migrations add IdentitySchema -p GolBet.Repositories -s GolBet.Web

# Finally update your database with the new entities from the migration seeders
# If there's no change in the seeders, then it won't reseed.
dotnet ef database update -p GolBet.Repositories -s GolBet.Web
