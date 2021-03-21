$Current = $PSScriptRoot

$OpenJpegDotNetRoot = Split-Path $Current -Parent
$SourceRoot = Join-Path $OpenJpegDotNetRoot src
$OpenJpegDotNetProjectRoot = Join-Path $SourceRoot OpenJpegDotNet
$DocumentDir = Join-Path $OpenJpegDotNetProjectRoot docfx
$Json = Join-Path $Current docfx.json

docfx "${Json}" --serve
Set-Location $Current