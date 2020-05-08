[CmdletBinding()]

# Use a regular expression to get "minor, major, fix, revision" from the BUILD_BUILDNUMBER environment variable
# the build process will automatically set the value of the environment variable to the correct build number 
$VersionRegex = "\d+\.\d+\.\*+|\d+\.\d+.\d+\.\d+|\d+\.\d+.\d+"
Write-Host $Env:Build_BuildNumber
$NewVersion = [regex]::matches($Env:Build_BuildNumber, $VersionRegex)
Write-Host "Updating version of the application to the build version: " $NewVersion

##vso[task.setvariable variable=BUILDNUMBER]$NewVersion

Write-Host "##vso[task.setvariable variable=BUILDNUMBER]$NewVersion"

#AssemblyProjectInfo:
$file = ".\AssemblyProjectInfo.cs" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "AssemblyProjectInfo.cs" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionRegex, $NewVersion | Out-File $file

$VersionReplaceRegex = "(BUILDVERSION)"

#GDL.IDAS.WebApi.Client.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Build_BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.WebApi.Client\GDL.IDAS.WebApi.Client.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Client.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.WebApi.Data.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Build_BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.WebApi.Data\GDL.IDAS.WebApi.Data.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Client.Contracts.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Build_BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.Client.Contracts\GDL.IDAS.Client.Contracts.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Logging.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Build_BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.Logging\GDL.IDAS.Logging.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionReplaceRegex, $NewVersion | Out-File $file

#GDL.IDAS.Crypto.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Build_BuildNumber, $VersionRegex)
$file = ".\Gandalan.IDAS.Crypto\GDL.IDAS.Crypto.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionReplaceRegex, $NewVersion | Out-File $file