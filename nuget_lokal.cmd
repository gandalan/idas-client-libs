@echo off
echo You need to have recommended latest nuget.exe in your PATH environment variable. Download it from https://www.nuget.org/downloads
echo Remember to build solution for Release configuration first

SET "nuget_source=c:\projects\0nuget\"
SET "common_params=-NonInteractive -Verbosity Detailed -OutputDirectory GDLPackages -Symbols -SymbolPackageFormat snupkg"

@echo on

nuget pack Gandalan.IDAS.Crypto/GDL.IDAS.Crypto.nuspec %common_params%
nuget pack Gandalan.IDAS.Logging/GDL.IDAS.Logging.nuspec %common_params%
nuget pack Gandalan.IDAS.WebApi.Client/GDL.IDAS.WebApi.Client.nuspec %common_params%
nuget pack Gandalan.IDAS.WebApi.Client.Wpf/GDL.IDAS.WebApi.Client.Wpf.nuspec %common_params%
nuget pack Gandalan.IDAS.Contracts/GDL.IDAS.Contracts.nuspec %common_params%

nuget init GDLPackages %nuget_source%
