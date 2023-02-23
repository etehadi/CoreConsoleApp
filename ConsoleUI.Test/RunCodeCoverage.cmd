rmdir /S /Q TestResults 2>NUL
mkdir .\TestResults\

rem You can use the "--filter Category=BankAccountData" argument to filter by a specific category.
dotnet test --logger "trx;LogFileName=TestResults.trx" --results-directory ./TestResults /p:CollectCoverage=true /p:CoverletOutput=TestResults\ /p:CoverletOutputFormat=cobertura /p:CopyLocalLockFileAssemblies=true  /p:Include="[Lowell.OmsAdapter*]*"
dotnet %userProfile%\.nuget\packages\reportgenerator\5.1.9\tools\netcoreapp3.1\ReportGenerator.dll "-reports:TestResults\coverage.cobertura.xml" "-targetdir:TestResults\coveragereport" -reporttypes:HTML;HTMLSummary

start .\TestResults\coveragereport\index.htm