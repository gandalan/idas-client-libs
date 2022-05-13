[CmdletBinding()]

param (
    # https://regex101.com/r/3qs3QO/1
    [ValidatePattern("[0-9]{4}\.[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2}")]
    [String]
    $PackageVersion
)

if ($PackageVersion) {
    $BuildNumber = $PackageVersion
} else {
    # Could be run in DevOps
    # The build process will automatically set the value of the BUILD_BUILDNUMBER environment variable to the correct build number
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

$VersionReplaceRegex = "(BUILDVERSION)"

#GDL.IDAS.WebApi.Client.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.WebApi.Client\GDL.IDAS.WebApi.Client.nuspec"
# Search in the "GDL.IDAS.WebApi.Client.nuspec" file items that matches the version regex and replace them with the
# correct version number
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Logging.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.Logging\GDL.IDAS.Logging.nuspec"
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Crypto.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.Crypto\GDL.IDAS.Crypto.nuspec"
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.WebApi.Client.Wpf
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.WebApi.Client.Wpf\GDL.IDAS.WebApi.Client.Wpf.nuspec"
# Search in the "GDL.IDAS.WebApi.Client.Wpf.nuspec" file items that matches the version regex and replace them with the
# correct version number
(Get-Content $file) -replace $VersionReplaceRegex, $NewVersion | Out-File $file