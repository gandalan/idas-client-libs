@echo off
echo You need to have recommended latest nuget.exe in your PATH environment variable. Download it from https://www.nuget.org/downloads
SET "nuget_source=c:\projects\0nuget\"
nuget init Gandalan.IDAS.Crypto\bin %nuget_source%
nuget init Gandalan.IDAS.Logging\bin %nuget_source%
nuget init Gandalan.IDAS.WebApi.Client\bin %nuget_source%
nuget init Gandalan.IDAS.WebApi.Client.Wpf\bin %nuget_source%
nuget init Gandalan.IDAS.Contracts\bin %nuget_source%