[CmdletBinding()]

# Use a regular expression to get "minor, major, fix, revision" from the BUILD_BUILDNUMBER environment variable
# the build process will automatically set the value of the environment variable to the correct build number 
$VersionRegex = "\d+\.\d+\.\*+|\d+\.\d+.\d+\.\d+|\d+\.\d+.\d+"
Write-Host $Env:Release_ReleaseName
$NewVersion = [regex]::matches($Env:Release_ReleaseName,$VersionRegex)
Write-Host "Updating version of the application to the build version: " $NewVersion

#AssemblyProjectInfo:
$file = ".\_gandalan_idas-client-libs\AssemblyProjectInfo.cs" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "AssemblyProjectInfo.cs" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionRegex, $NewVersion | Out-File $file

#GDL.IDAS.WebApi.Client.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Release_ReleaseName,$VersionRegex)
$file = ".\_gandalan_idas-client-libs\Gandalan.IDAS.WebApi.Client\GDL.IDAS.WebApi.Client.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Client.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionRegex, $NewVersion | Out-File $file

#GDL.IDAS.WebApi.Data.nuspec
$VersionRegex = "\d+\.\d+.\d+\.\d+"
$NewVersion = [regex]::matches($Env:Release_ReleaseName,$VersionRegex)
$file = ".\_gandalan_idas-client-libs\Gandalan.IDAS.WebApi.Data\GDL.IDAS.WebApi.Data.nuspec" 
$filecontent = Get-Content($file)
attrib $file -r
# Search in the "GDL.IDAS.WebApi.Data.nuspec" file items that matches the version regex and replace them with the
# correct version number
$filecontent -replace $VersionRegex, $NewVersion | Out-File $file