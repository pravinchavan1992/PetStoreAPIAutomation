#!/bin/bash
set -e

echo "Starting Test Case Execution..."

# 1. Go to Tests folder
cd "$(dirname "$0")/Tests"

# 2. Restore & build
echo "Restoring and building solution..."
dotnet restore
dotnet build --no-restore

# 3. Run tests with Allure results
echo "Running NUnit tests..."
dotnet test --logger "trx;LogFileName=TestResults.trx" --results-directory ../allure-results

# 4. Generate and open Allure report
cd ..
echo "Generating Allure report..."
allure generate allure-results --clean -o allure-report

echo "Test Execution Completed"
