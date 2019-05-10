@echo off
set nu="..\..\packages\NuGet.CommandLine.4.7.1\tools\NuGet.exe" 
for %%a in (*_Debug.nuspec) do %nu% pack %%a
if not exist c:\temp\Nuget_Debug\GDL.IDAS.WebApi.Client md c:\temp\Nuget_Debug\GDL.IDAS.WebApi.Client
for %%a in (*.nupkg) do move /y %%a \temp\Nuget_Debug\GDL.IDAS.WebApi.Client
