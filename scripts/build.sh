#!/usr/bin/env bash
dotnet restore ./tests/SolarCalculator.Test.csproj
dotnet build ./tests/SolarCalculator.Test.csproj
dotnet test ./tests/SolarCalculator.Test.csproj