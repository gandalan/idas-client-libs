#requires -Version 5.1
<#
.SYNOPSIS
    Master build script for IDAS Client Libraries documentation.
.DESCRIPTION
    This script orchestrates the complete documentation build process:
    1. Installs Docusaurus dependencies
    2. Generates C# API documentation
    3. Generates WebLibs API documentation
    4. Builds the Docusaurus site
    5. Reports success with output location
    
    Usage: .\build-docs.ps1 [-Verbose]
.PARAMETER Verbose
    Enables verbose output for detailed logging.
.EXAMPLE
    .\build-docs.ps1
    
    .\build-docs.ps1 -Verbose
.NOTES
    File Name      : build-docs.ps1
    Prerequisites  : Node.js, npm, .NET SDK, docfx
    Author         : IDAS Documentation Team
    Version        : 1.0.0
#>

[CmdletBinding()]
param()

$ErrorActionPreference = "Stop"
$ProgressPreference = "Continue"

# Script paths
$ScriptDir = $PSScriptRoot
$DocsDir = Split-Path -Parent $ScriptDir
$RootDir = Split-Path -Parent $DocsDir

function Write-Status {
    param(
        [string]$Message, 
        [string]$Status = "INFO",
        [int]$Step = 0,
        [int]$TotalSteps = 5
    )
    $timestamp = Get-Date -Format "HH:mm:ss"
    $colorMap = @{
        "INFO" = "Cyan"
        "SUCCESS" = "Green"
        "WARNING" = "Yellow"
        "ERROR" = "Red"
        "PROGRESS" = "Magenta"
    }
    $color = $colorMap[$Status]
    
    if ($Step -gt 0) {
        $progress = "[$Step/$TotalSteps]"
        Write-Host "[$timestamp] $progress [$Status] $Message" -ForegroundColor $color
    }
    else {
        Write-Host "[$timestamp] [$Status] $Message" -ForegroundColor $color
    }
}

function Write-Header {
    Clear-Host
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Blue
    Write-Host "  IDAS Client Libraries Documentation" -ForegroundColor Blue
    Write-Host "  Build Script v1.0.0" -ForegroundColor Blue
    Write-Host "========================================" -ForegroundColor Blue
    Write-Host ""
    Write-Status "Documentation directory: $DocsDir" "INFO"
    Write-Status "Working directory: $RootDir" "INFO"
    Write-Host ""
}

function Step1-InstallDependencies {
    param([int]$Step = 1, [int]$Total = 5)
    
    Write-Status "Installing Docusaurus dependencies..." "PROGRESS" $Step $Total
    
    try {
        Push-Location $DocsDir
        
        # Check if node_modules exists
        $nodeModules = Join-Path $DocsDir "node_modules"
        if (Test-Path $nodeModules) {
            Write-Status "node_modules already exists, skipping npm install" "INFO"
        }
        else {
            Write-Status "Running npm install..." "INFO"
            $installOutput = npm install 2>&1
            
            if ($LASTEXITCODE -ne 0) {
                throw "npm install failed with exit code $LASTEXITCODE"
            }
            
            Write-Status "Dependencies installed successfully" "SUCCESS"
            
            if ($VerbosePreference -eq "Continue") {
                $installOutput | ForEach-Object { Write-Verbose $_ }
            }
        }
    }
    catch {
        Write-Status "Failed to install dependencies: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Step2-GenerateCSharpDocs {
    param([int]$Step = 2, [int]$Total = 5)
    
    Write-Status "Generating C# API documentation..." "PROGRESS" $Step $Total
    
    $csharpScript = Join-Path $ScriptDir "generate-csharp-docs.ps1"
    
    if (-not (Test-Path $csharpScript)) {
        Write-Status "C# documentation script not found: $csharpScript" "ERROR"
        exit 1
    }
    
    try {
        $params = @{}
        if ($VerbosePreference -eq "Continue") {
            $params['Verbose'] = $true
        }
        
        & $csharpScript @params
        
        if ($LASTEXITCODE -ne 0) {
            throw "C# documentation generation failed with exit code $LASTEXITCODE"
        }
        
        Write-Status "C# documentation generated successfully" "SUCCESS"
    }
    catch {
        Write-Status "C# documentation generation failed: $_" "ERROR"
        exit 1
    }
}

function Step3-GenerateWebLibsDocs {
    param([int]$Step = 3, [int]$Total = 5)
    
    Write-Status "Generating WebLibs API documentation..." "PROGRESS" $Step $Total
    
    $weblibsScript = Join-Path $ScriptDir "generate-weblibs-docs.ps1"
    
    if (-not (Test-Path $weblibsScript)) {
        Write-Status "WebLibs documentation script not found: $weblibsScript" "ERROR"
        exit 1
    }
    
    try {
        $params = @{}
        if ($VerbosePreference -eq "Continue") {
            $params['Verbose'] = $true
        }
        
        & $weblibsScript @params
        
        if ($LASTEXITCODE -ne 0) {
            throw "WebLibs documentation generation failed with exit code $LASTEXITCODE"
        }
        
        Write-Status "WebLibs documentation generated successfully" "SUCCESS"
    }
    catch {
        Write-Status "WebLibs documentation generation failed: $_" "ERROR"
        exit 1
    }
}

function Step4-BuildDocusaurus {
    param([int]$Step = 4, [int]$Total = 5)
    
    Write-Status "Building Docusaurus site..." "PROGRESS" $Step $Total
    
    try {
        Push-Location $DocsDir
        
        # Clean previous build
        $buildDir = Join-Path $DocsDir "build"
        if (Test-Path $buildDir) {
            Write-Status "Cleaning previous build..." "INFO"
            Remove-Item -Path $buildDir -Recurse -Force
        }
        
        Write-Status "Running npm run build..." "INFO"
        $buildOutput = npm run build 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            throw "Docusaurus build failed with exit code $LASTEXITCODE"
        }
        
        Write-Status "Docusaurus site built successfully" "SUCCESS"
        
        if ($VerbosePreference -eq "Continue") {
            $buildOutput | ForEach-Object { Write-Verbose $_ }
        }
        
        # Verify build output
        if (-not (Test-Path $buildDir)) {
            throw "Build directory not found after build: $buildDir"
        }
        
        $fileCount = (Get-ChildItem $buildDir -Recurse -File | Measure-Object).Count
        Write-Status "Generated $fileCount files in build directory" "INFO"
    }
    catch {
        Write-Status "Docusaurus build failed: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Step5-ReportSuccess {
    param([int]$Step = 5, [int]$Total = 5)
    
    Write-Status "Finalizing..." "PROGRESS" $Step $Total
    
    $buildDir = Join-Path $DocsDir "build"
    $indexFile = Join-Path $buildDir "index.html"
    
    if (-not (Test-Path $indexFile)) {
        Write-Status "index.html not found in build directory" "WARNING"
    }
    
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "  DOCUMENTATION BUILT SUCCESSFULLY!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "Output location: docs/build/" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "To preview locally, run:" -ForegroundColor Yellow
    Write-Host "  cd docs && npm run serve" -ForegroundColor White
    Write-Host ""
    Write-Host "To deploy, copy the contents of docs/build/ to your web server." -ForegroundColor Yellow
    Write-Host ""
}

# Main execution
Write-Header

$totalSteps = 5
$exitCode = 0

try {
    Step1-InstallDependencies -Step 1 -Total $totalSteps
    Step2-GenerateCSharpDocs -Step 2 -Total $totalSteps
    Step3-GenerateWebLibsDocs -Step 3 -Total $totalSteps
    Step4-BuildDocusaurus -Step 4 -Total $totalSteps
    Step5-ReportSuccess -Step 5 -Total $totalSteps
}
catch {
    Write-Status "Build failed: $_" "ERROR"
    $exitCode = 1
}
finally {
    Write-Host ""
    if ($exitCode -eq 0) {
        Write-Status "Documentation built successfully! Output: docs/build/" "SUCCESS"
    }
    else {
        Write-Status "Documentation build failed. Check the error messages above." "ERROR"
    }
}

exit $exitCode
