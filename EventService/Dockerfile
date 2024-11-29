FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Копируем файл решения и все проекты
COPY EventService/EventService.sql ./
COPY . ./

# Восстанавливаем зависимости
RUN dotnet restore

# Копируем остальные файлы
COPY . ./

# Строим и публикуем проект
RUN dotnet build
RUN dotnet publish -c Release -o out

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "out/EventService.dll"]
