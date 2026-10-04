#Presentado por Aramid Monsalve
# el constructor del esqueleto
# GolBet para Linux

# Herramienta EF Core CLI
# Requerida para el manejo de migraciones
# de entidades
dotnet tool install --global dotnet-ef

# Creando la solucion
dotnet new sln -n GolBet

# Creando a parte red
dotnet new mvc -n GolBet.Web -f net8.0

# Creando base de servicios
dotnet new classlib -n GolBet.Services -f net8.0

# Creando base de repos
dotnet new classlib -n GolBet.Repositories -f net8.0

# Creando base de entidades
dotnet new classlib -n GolBet.Entities -f net8.0

# Añadiendo bases a la solucion
dotnet sln add GolBet.Web GolBet.Services GolBet.Repositories GolBet.Entities

#Configurando referencias entre proyectos
dotnet add GolBet.Web reference GolBet.Services
dotnet add GolBet.Services reference GolBet.Repositories GolBet.Entities
dotnet add GolBet.Repositories reference GolBet.Entities

#Creando a git ignore
dotnet new gitignore

#Commit de esqueleto.
git add .
git commit -m "Add N-layer solution skeleton (Module 1)"
git push #Este comando sube commit al servidor
