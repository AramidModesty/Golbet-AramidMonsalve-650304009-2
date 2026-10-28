# First, make yourself sure the app is not running
#  then make yourself sure you drop either the table
#  or the database that you want to reseed
# Then run this:
dotnet ef migrations add InitialDomain -p GolBet.Repositories -s GolBet.Web
dotnet ef migrations add IdentitySchema -p GolBet.Repositories -s GolBet.Web
dotnet ef database update -p GolBet.Repositories -s GolBet.Web
# And execute your app.
