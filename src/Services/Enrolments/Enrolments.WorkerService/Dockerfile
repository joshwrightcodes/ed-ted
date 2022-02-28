FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shared/DDD/Shared.Domain/Shared.Domain.csproj", "Shared/DDD/Shared.Domain/"]
COPY ["Shared/DDD/Shared.Application/Shared.Application.csproj", "Shared/DDD/Shared.Application/"]
COPY ["Services/Enrolment/Enrolment.Domain/Enrolment.Domain.csproj", "Services/Enrolment/Enrolment.Domain/"]
COPY ["Services/Enrolment/Enrolment.Application/Enrolment.Application.csproj", "Services/Enrolment/Enrolment.Application/"]
COPY ["Services/Enrolment/Enrolment.Infrastructure/Enrolment.Infrastructure.csproj", "Services/Enrolment/Enrolment.Infrastructure/"]
COPY ["Services/Enrolment/Enrolment.WorkerService/Enrolment.WorkerService.csproj", "Services/Enrolment/Enrolment.WorkerService/"]
RUN dotnet restore Services/Enrolment/Enrolment.WorkerService/Enrolment.WorkerService.csproj

COPY . .
WORKDIR /src/Services/Enrolment/Enrolment.WorkerService
RUN dotnet build Enrolment.WorkerService.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Enrolment.WorkerService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ted.Services.Enrolment.WorkerService.dll"]
