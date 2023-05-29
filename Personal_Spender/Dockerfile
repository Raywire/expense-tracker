FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Personal_Spender/Personal_Spender.csproj", "Personal_Spender/"]
RUN dotnet restore "Personal_Spender/Personal_Spender.csproj"
COPY . .
WORKDIR "/src/Personal_Spender"
RUN dotnet build "Personal_Spender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Personal_Spender.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Personal_Spender.dll"]
