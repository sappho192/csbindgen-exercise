$sourceFiles = @(
    "target\debug\mylib.dll",
    "target\debug\mylib.dll.exp",
    "target\debug\mylib.dll.lib"
)
$destinationPath = "csproj\cs-bindtest\"

# Copy each file to the destination, overwriting existing files
foreach ($file in $sourceFiles) {
    Copy-Item -Path $file -Destination $destinationPath -Force
}