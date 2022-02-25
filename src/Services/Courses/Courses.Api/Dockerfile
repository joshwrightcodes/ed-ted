FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shared/DDD/Shared.Domain/Shared.Domain.csproj", "Shared/DDD/Shared.Domain/"]
COPY ["Shared/DDD/Shared.Application/Shared.Application.csproj", "Shared/DDD/Shared.Application/"]
COPY ["Services/Courses/Courses.Domain/Courses.Domain.csproj", "Services/Courses/Courses.Domain/"]
COPY ["Services/Courses/Courses.Application/Courses.Application.csproj", "Services/Courses/Courses.Application/"]
COPY ["Services/Courses/Courses.Infrastructure/Courses.Infrastructure.csproj", "Services/Courses/Courses.Infrastructure/"]
COPY ["Services/Courses/Courses.Api/Courses.Api.csproj", "Services/Courses/Courses.Api/"]
RUN dotnet restore Services/Courses/Courses.Api/Courses.Api.csproj

COPY . .
WORKDIR /src/Services/Courses/Courses.Api
RUN dotnet build Courses.Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Courses.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ted.Services.Courses.Api.dll"]
