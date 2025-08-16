using namespace System.IO

param(
	[Parameter(Mandatory)]
	[ValidateNotNullOrEmpty()]
	[string] $Version, 

	[Parameter(Mandatory)]
	[ValidateNotNullOrEmpty()]
	[string] $Token
)

curl https://api.github.com/users/Arnab-Developer/packages/nuget/Arc.StringSanitizer/versions \
    -X "GET"
	-H "Accept: application/vnd.github+json" \
	-H "X-GitHub-Api-Version: 2022-11-28" \
	-H "Authorization: Bearer $($Token)" >> $HOME/versions.json

$version = $File.ReadAllText("$HOME/versions.json") | ConvertFrom-Json | Where-Object { $_.Name == "$($Version)" }

return $version