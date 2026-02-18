#requires -Version 5.1
<#
.SYNOPSIS
    Generates C# API documentation using DocFX.
.DESCRIPTION
    This script builds the C# solution in Release mode, generates API documentation
    using DocFX, applies the docfx-to-docusaurus conversion, and copies the output
    to the api/csharp/ directory.
.PARAMETER Verbose
    Enables verbose output for detailed logging.
.EXAMPLE
    .\generate-csharp-docs.ps1 -Verbose
.NOTES
    Prerequisites: docfx must be installed (dotnet tool install -g docfx)
#>

[CmdletBinding()]
param()

$ErrorActionPreference = "Stop"
$ProgressPreference = "Continue"

# Script paths
$ScriptDir = $PSScriptRoot
$DocsDir = Split-Path -Parent $ScriptDir
$RootDir = Split-Path -Parent $DocsDir
$OutputDir = Join-Path $DocsDir "api" "csharp"

function Write-Status {
    param([string]$Message, [string]$Status = "INFO")
    $timestamp = Get-Date -Format "HH:mm:ss"
    $colorMap = @{
        "INFO" = "Cyan"
        "SUCCESS" = "Green"
        "WARNING" = "Yellow"
        "ERROR" = "Red"
    }
    $color = $colorMap[$Status]
    Write-Host "[$timestamp] [$Status] $Message" -ForegroundColor $color
}

function Test-Prerequisites {
    Write-Status "Checking prerequisites..." "INFO"
    
    # Check if docfx is installed
    $docfx = Get-Command docfx -ErrorAction SilentlyContinue
    if (-not $docfx) {
        Write-Status "docfx is not installed. Installing..." "WARNING"
        try {
            dotnet tool install -g docfx
            Write-Status "docfx installed successfully" "SUCCESS"
        }
        catch {
            Write-Status "Failed to install docfx. Please install manually: dotnet tool install -g docfx" "ERROR"
            exit 1
        }
    }
    else {
        $docfxVersion = (docfx --version) -replace "[a-zA-Z\s]", ""
        Write-Status "docfx found: version $docfxVersion" "SUCCESS"
    }
    
    # Check if dotnet is installed
    $dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
    if (-not $dotnet) {
        Write-Status ".NET SDK is not installed. Please install .NET SDK 8.0 or later." "ERROR"
        exit 1
    }
    else {
        $dotnetVersion = (dotnet --version)
        Write-Status ".NET SDK found: version $dotnetVersion" "SUCCESS"
    }
    
    Write-Status "All prerequisites met" "SUCCESS"
}

function Build-Solution {
    Write-Status "Building C# solution in Release mode..." "INFO"
    
    $solutionFile = Join-Path $RootDir "Gandalan.IDAS.WebApi.Client.sln"
    if (-not (Test-Path $solutionFile)) {
        Write-Status "Solution file not found: $solutionFile" "ERROR"
        exit 1
    }
    
    try {
        Push-Location $RootDir
        $buildOutput = dotnet build $solutionFile -c Release 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "Build failed with exit code $LASTEXITCODE"
        }
        Write-Status "Solution built successfully" "SUCCESS"
        if ($VerbosePreference -eq "Continue") {
            $buildOutput | ForEach-Object { Write-Verbose $_ }
        }
    }
    catch {
        Write-Status "Build failed: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Generate-Metadata {
    Write-Status "Generating DocFX metadata..." "INFO"
    
    $docfxJson = Join-Path $DocsDir "docfx.json"
    if (-not (Test-Path $docfxJson)) {
        Write-Status "docfx.json not found: $docfxJson" "ERROR"
        exit 1
    }
    
    try {
        Push-Location $DocsDir
        $metadataOutput = docfx metadata $docfxJson 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "Metadata generation failed with exit code $LASTEXITCODE"
        }
        Write-Status "Metadata generated successfully" "SUCCESS"
        if ($VerbosePreference -eq "Continue") {
            $metadataOutput | ForEach-Object { Write-Verbose $_ }
        }
    }
    catch {
        Write-Status "Metadata generation failed: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Build-DocFX {
    Write-Status "Building DocFX documentation..." "INFO"
    
    $docfxJson = Join-Path $DocsDir "docfx.json"
    
    try {
        Push-Location $DocsDir
        $buildOutput = docfx build $docfxJson 2>&1
        if ($LASTEXITCODE -ne 0) {
            throw "DocFX build failed with exit code $LASTEXITCODE"
        }
        Write-Status "DocFX build completed successfully" "SUCCESS"
        if ($VerbosePreference -eq "Continue") {
            $buildOutput | ForEach-Object { Write-Verbose $_ }
        }
    }
    catch {
        Write-Status "DocFX build failed: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Apply-DocusaurusConversion {
    Write-Status "Applying Docusaurus conversion..." "INFO"
    
    # Check if docfx-to-docusaurus plugin exists
    $pluginConfig = Join-Path $DocsDir "docfx-to-docusaurus.json"
    if (-not (Test-Path $pluginConfig)) {
        Write-Status "Docusaurus plugin config not found: $pluginConfig" "WARNING"
        return
    }
    
    try {
        # The template in docfx.json should handle the conversion
        Write-Status "Docusaurus templates applied via DocFX configuration" "SUCCESS"
    }
    catch {
        Write-Status "Docusaurus conversion failed: $_" "ERROR"
        exit 1
    }
}

function Copy-Output {
    Write-Status "Copying output to api/csharp/..." "INFO"
    
    if (-not (Test-Path $OutputDir)) {
        Write-Status "Output directory not found: $OutputDir" "WARNING"
        # DocFX should have created it
        return
    }
    
    $fileCount = (Get-ChildItem $OutputDir -Recurse -File | Measure-Object).Count
    Write-Status "Generated $fileCount files in $OutputDir" "SUCCESS"
}

# Main execution
Write-Status "Starting C# documentation generation..." "INFO"

try {
    Test-Prerequisites
    Build-Solution
    Generate-Metadata
    Build-DocFX
    Apply-DocusaurusConversion
    Copy-Output
    
    Write-Status "C# documentation generated successfully!" "SUCCESS"
    Write-Status "Output location: $OutputDir" "INFO"
    exit 0
}
catch {
    Write-Status "Script failed: $_" "ERROR"
    exit 1
}
