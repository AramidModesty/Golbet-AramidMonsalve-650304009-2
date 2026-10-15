#I've been having trouble with the roles migration to the database
# for 6 hours. The next two commands were recommended by gpt-6 luna
# and fix the migration
dotnet ef migrations add AddIdentitySchema --project GolBet.Repositories/GolBet.Repositories.csproj --startup-project GolBet.Web/GolBet.Web.csproj
dotnet ef database update --project GolBet.Repositories/GolBet.Repositories.csproj --startup-project GolBet.Web/GolBet.Web.csproj
