#Requires -Version 7.4
# Run this script with pwsh command. Running via .\UpdateVersionInfo.ps1 2024.11.27.356 can't add PackageVersion param somehow
[CmdletBinding()]

param (
    # https://regex101.com/r/L80HcG/1
    [ValidatePattern("^[0-9]{4}\.[0-9]{1,2}\.[0-9]{1,2}\.[0-9]+$")]
    [String]
    $PackageVersion
)

if ($PackageVersion) {
    $BuildNumber = $PackageVersion
} else {
    # Could be run in DevOps
    # The build process will automatically set the value of the BUILD_BUILDNUMBER environment variable to the correct build number
    Write-Host "PackageVersion param is empty. Try to set BuildNumber from environment variable"
	$BuildNumber = $Env:Build_BuildNumber
}

Write-Host "BuildNumber: $BuildNumber"

if (-not $BuildNumber) {
    throw 'BuildNumber variable cannot be null'
}

# Use a regular expression to get "minor, major, fix, revision"
$VersionRegex = "\d+\.\d+\.\*+|\d+\.\d+.\d+\.\d+|\d+\.\d+.\d+"

$NewVersion = [regex]::matches($BuildNumber, $VersionRegex)
Write-Host "Updating version of the application to the build version: $NewVersion"

if (-not $PackageVersion) {
    ##vso[task.setvariable variable=BUILDNUMBER]$NewVersion
    Write-Host "##vso[task.setvariable variable=BUILDNUMBER]$NewVersion"
}

#AssemblyProjectInfo:
$file = ".\AssemblyProjectInfo.cs"
# Search in the "AssemblyProjectInfo.cs" file items that matches the version regex and replace them with the
# correct version number
(Get-Content $file) -replace $VersionRegex, $NewVersion | Out-File $file

$VersionReplaceRegex = "(BUILDVERSION)|(0\.0\.1)"
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($BuildNumber, $VersionRegex)

#GDL.IDAS.WebApi.Client.nuspec
$file = ".\Gandalan.IDAS.WebApi.Client\GDL.IDAS.WebApi.Client.nuspec"
# Search in the "GDL.IDAS.WebApi.Client.nuspec" file items that matches the version regex and replace them with the
# correct version number
Write-Host "Updating $file..."
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Logging.nuspec
$file = ".\Gandalan.IDAS.Logging\GDL.IDAS.Logging.nuspec"
Write-Host "Updating $file..."
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Crypto.nuspec
$file = ".\Gandalan.IDAS.Crypto\GDL.IDAS.Crypto.nuspec"
Write-Host "Updating $file..."
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.WebApi.Client.Wpf.nuspec
$file = ".\Gandalan.IDAS.WebApi.Client.Wpf\GDL.IDAS.WebApi.Client.Wpf.nuspec"
Write-Host "Updating $file..."
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Contracts.nuspec
$file = ".\Gandalan.IDAS.Contracts\GDL.IDAS.Contracts.nuspec"
Write-Host "Updating $file..."
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

Write-Host "Done"
