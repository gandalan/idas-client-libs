#requires -Version 5.1
<#
.SYNOPSIS
    Generates WebLibs JavaScript/TypeScript documentation.
.DESCRIPTION
    This script generates API documentation for the WebLibs JavaScript/TypeScript
    library using JSDoc and jsdoc-to-markdown, then copies the output to api/weblibs/.
.PARAMETER Verbose
    Enables verbose output for detailed logging.
.EXAMPLE
    .\generate-weblibs-docs.ps1 -Verbose
.NOTES
    Prerequisites: Node.js and npm must be installed.
#>

[CmdletBinding()]
param()

$ErrorActionPreference = "Stop"
$ProgressPreference = "Continue"

# Script paths
$ScriptDir = $PSScriptRoot
$DocsDir = Split-Path -Parent $ScriptDir
$RootDir = Split-Path -Parent $DocsDir
$WebLibsDir = Join-Path $RootDir "WebLibs"
$OutputDir = Join-Path $DocsDir "api" "weblibs"

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
    
    # Check if Node.js is installed
    $node = Get-Command node -ErrorAction SilentlyContinue
    if (-not $node) {
        Write-Status "Node.js is not installed. Please install Node.js 20 or later." "ERROR"
        exit 1
    }
    else {
        $nodeVersion = (node --version)
        Write-Status "Node.js found: version $nodeVersion" "SUCCESS"
    }
    
    # Check if npm is installed
    $npm = Get-Command npm -ErrorAction SilentlyContinue
    if (-not $npm) {
        Write-Status "npm is not installed. Please install npm." "ERROR"
        exit 1
    }
    else {
        $npmVersion = (npm --version)
        Write-Status "npm found: version $npmVersion" "SUCCESS"
    }
    
    # Check if WebLibs directory exists
    if (-not (Test-Path $WebLibsDir)) {
        Write-Status "WebLibs directory not found: $WebLibsDir" "ERROR"
        exit 1
    }
    else {
        Write-Status "WebLibs directory found: $WebLibsDir" "SUCCESS"
    }
    
    Write-Status "All prerequisites met" "SUCCESS"
}

function Install-Dependencies {
    Write-Status "Checking WebLibs dependencies..." "INFO"
    
    $nodeModulesDir = Join-Path $WebLibsDir "node_modules"
    
    if (-not (Test-Path $nodeModulesDir)) {
        Write-Status "node_modules not found. Running npm install..." "WARNING"
        try {
            Push-Location $WebLibsDir
            $installOutput = npm install 2>&1
            if ($LASTEXITCODE -ne 0) {
                throw "npm install failed with exit code $LASTEXITCODE"
            }
            Write-Status "Dependencies installed successfully" "SUCCESS"
            if ($VerbosePreference -eq "Continue") {
                $installOutput | ForEach-Object { Write-Verbose $_ }
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
    else {
        Write-Status "node_modules already exists" "SUCCESS"
    }
}

function Test-JSDocConfig {
    Write-Status "Checking JSDoc configuration..." "INFO"
    
    $jsdocConfig = Join-Path $WebLibsDir "jsdoc.json"
    
    if (-not (Test-Path $jsdocConfig)) {
        Write-Status "Creating default jsdoc.json configuration..." "WARNING"
        
        $jsdocConfigContent = @"
{
  "source": {
    "include": ["./"],
    "includePattern": "\\.(js|ts)$",
    "exclude": ["node_modules/", "dist/", "build/"]
  },
  "opts": {
    "destination": "./docs/"
  },
  "plugins": ["plugins/markdown"]
}
"@
        
        try {
            Set-Content -Path $jsdocConfig -Value $jsdocConfigContent -Encoding UTF8
            Write-Status "Created jsdoc.json" "SUCCESS"
        }
        catch {
            Write-Status "Failed to create jsdoc.json: $_" "ERROR"
            exit 1
        }
    }
    else {
        Write-Status "jsdoc.json found" "SUCCESS"
    }
}

function Install-JSDocTools {
    Write-Status "Checking JSDoc tools..." "INFO"
    
    try {
        Push-Location $WebLibsDir
        
        # Check and install jsdoc
        $jsdocInstalled = npm list jsdoc --depth=0 2>$null
        if ($LASTEXITCODE -ne 0) {
            Write-Status "Installing jsdoc..." "WARNING"
            npm install --save-dev jsdoc 2>&1 | Out-Null
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to install jsdoc"
            }
        }
        
        # Check and install jsdoc-to-markdown
        $jsdoc2mdInstalled = npm list jsdoc-to-markdown --depth=0 2>$null
        if ($LASTEXITCODE -ne 0) {
            Write-Status "Installing jsdoc-to-markdown..." "WARNING"
            npm install --save-dev jsdoc-to-markdown 2>&1 | Out-Null
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to install jsdoc-to-markdown"
            }
        }
        
        Write-Status "JSDoc tools ready" "SUCCESS"
    }
    catch {
        Write-Status "Failed to install JSDoc tools: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Generate-JSDoc {
    Write-Status "Generating JSDoc documentation..." "INFO"
    
    try {
        Push-Location $WebLibsDir
        
        $jsdocConfig = Join-Path $WebLibsDir "jsdoc.json"
        $jsdocOutput = npx jsdoc -c $jsdocConfig 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            throw "JSDoc generation failed with exit code $LASTEXITCODE"
        }
        
        Write-Status "JSDoc documentation generated" "SUCCESS"
        if ($VerbosePreference -eq "Continue") {
            $jsdocOutput | ForEach-Object { Write-Verbose $_ }
        }
    }
    catch {
        Write-Status "JSDoc generation failed: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Generate-Markdown {
    Write-Status "Generating Markdown documentation..." "INFO"
    
    try {
        Push-Location $WebLibsDir
        
        # Create output directory
        $tempOutput = Join-Path $WebLibsDir "docs-md"
        if (-not (Test-Path $tempOutput)) {
            New-Item -ItemType Directory -Path $tempOutput -Force | Out-Null
        }
        
        # Find all JS/TS files and generate markdown
        $sourceFiles = Get-ChildItem -Path $WebLibsDir -Include "*.js", "*.ts" -Recurse | 
            Where-Object { $_.FullName -notmatch "node_modules|dist|build|\.d\.ts$" }
        
        if ($sourceFiles.Count -eq 0) {
            Write-Status "No JavaScript/TypeScript files found" "WARNING"
            return
        }
        
        Write-Status "Found $($sourceFiles.Count) source files" "INFO"
        
        # Generate markdown using jsdoc-to-markdown
        $markdownOutput = npx jsdoc2md $sourceFiles.FullName --template README.md 2>&1
        
        if ($LASTEXITCODE -ne 0) {
            Write-Status "Markdown generation may have issues, continuing..." "WARNING"
        }
        
        Write-Status "Markdown documentation generated" "SUCCESS"
    }
    catch {
        Write-Status "Markdown generation failed: $_" "ERROR"
        exit 1
    }
    finally {
        Pop-Location
    }
}

function Copy-Output {
    Write-Status "Copying output to api/weblibs/..." "INFO"
    
    try {
        # Create output directory
        if (-not (Test-Path $OutputDir)) {
            New-Item -ItemType Directory -Path $OutputDir -Force | Out-Null
        }
        
        # Copy from WebLibs docs directory
        $sourceDocs = Join-Path $WebLibsDir "docs"
        if (Test-Path $sourceDocs) {
            Copy-Item -Path "$sourceDocs\*" -Destination $OutputDir -Recurse -Force
            Write-Status "Documentation copied to $OutputDir" "SUCCESS"
        }
        else {
            Write-Status "Source docs directory not found: $sourceDocs" "WARNING"
        }
        
        # Check for and create index.md if not exists
        $indexFile = Join-Path $OutputDir "index.md"
        if (-not (Test-Path $indexFile)) {
            Write-Status "Creating index.md..." "WARNING"
            $indexContent = @"
# WebLibs API Documentation

Welcome to the WebLibs API documentation.

## Overview

This documentation covers the JavaScript/TypeScript WebLibs library.

## Getting Started

View the API documentation in the sidebar.
"@
            Set-Content -Path $indexFile -Value $indexContent -Encoding UTF8
            Write-Status "Created index.md" "SUCCESS"
        }
        
        $fileCount = (Get-ChildItem $OutputDir -Recurse -File | Measure-Object).Count
        Write-Status "Total files in output: $fileCount" "INFO"
    }
    catch {
        Write-Status "Failed to copy output: $_" "ERROR"
        exit 1
    }
}

# Main execution
Write-Status "Starting WebLibs documentation generation..." "INFO"

try {
    Test-Prerequisites
    Install-Dependencies
    Test-JSDocConfig
    Install-JSDocTools
    Generate-JSDoc
    Generate-Markdown
    Copy-Output
    
    Write-Status "WebLibs documentation generated successfully!" "SUCCESS"
    Write-Status "Output location: $OutputDir" "INFO"
    exit 0
}
catch {
    Write-Status "Script failed: $_" "ERROR"
    exit 1
}
