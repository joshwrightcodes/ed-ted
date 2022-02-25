FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shared/DDD/Shared.Domain/Shared.Domain.csproj", "Shared/DDD/Shared.Domain/"]
COPY ["Shared/DDD/Shared.Application/Shared.Application.csproj", "Shared/DDD/Shared.Application/"]
COPY ["Services/Courses/Courses.Domain/Courses.Domain.csproj", "Services/Courses/Courses.Domain/"]
COPY ["Services/Courses/Courses.Application/Courses.Application.csproj", "Services/Courses/Courses.Application/"]
COPY ["Services/Courses/Courses.Infrastructure/Courses.Infrastructure.csproj", "Services/Courses/Courses.Infrastructure/"]
COPY ["Services/Courses/Courses.WorkerService/Courses.WorkerService.csproj", "Services/Courses/Courses.WorkerService/"]
RUN dotnet restore Services/Courses/Courses.WorkerService/Courses.WorkerService.csproj

COPY . .
WORKDIR /src/Services/Courses/Courses.WorkerService
RUN dotnet build Courses.WorkerService.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Courses.WorkerService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ted.Services.Courses.WorkerService.dll"]
