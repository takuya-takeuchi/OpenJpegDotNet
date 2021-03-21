$Current = $PSScriptRoot

$OpenJpegDotNetRoot = Split-Path $Current -Parent
$SourceRoot = Join-Path $OpenJpegDotNetRoot src
$OpenJpegDotNetProjectRoot = Join-Path $SourceRoot OpenJpegDotNet

docfx init -q -o docs
Set-Location $Current