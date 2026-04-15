#!/bin/bash

echo "🧽 Cleaning old report..."
rm -rf coverage-report

echo "🧪 Running tests with coverage..."

dotnet test ./src/QuickCode.DemoCms.sln \
  /p:CollectCoverage=true \
  /p:Exclude="[*.Dtos]*" \
  /p:CoverletOutputFormat=cobertura \
  /p:CoverletOutput=./TestResults/

echo "📊 Generating coverage report..."

reportgenerator \
  -reports:**/TestResults/**/coverage.cobertura.xml \
  -targetdir:coverage-report \
  -reporttypes:Html \
  "-assemblyfilters:-QuickCode.DemoCms.Common*;-QuickCode.DemoCms.Portal*;-QuickCode.DemoCms.Gateway*;"

echo "✅ Report generated in ./coverage-report/index.html"