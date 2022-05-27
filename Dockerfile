FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic

WORKDIR /src

COPY src/DMI5Checker .

RUN dotnet build

ENTRYPOINT ["dotnet", "run", "--no-build", "--project", "/src/DMI5Checker.csproj", "--"]
