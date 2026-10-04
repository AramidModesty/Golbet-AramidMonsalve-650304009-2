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
dotnet new gitignore --force #Si gitignore existe entonces es borrado

#Commit de esqueleto.
git add .
git commit -m "Add N-layer solution skeleton (Modulo 1)" #mensaje del commit, visto ya antes
git push #Este comando sube commit al servidor, debe ser hecho manualmente para poner el token creado con herramientas de desarollador como contraseña
git push -u origin main #Si es la primera vez, como upstream para no mas contraseñas
git config --global http.sslCAinfo /etc/ssl/certs/ca-certificates.crt #Did you know git doesn't trust to Ubuntu push main sometimes? Because it's true.

