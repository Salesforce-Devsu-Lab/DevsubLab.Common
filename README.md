# DevsubLab.Common

## Create and publish package
```powershell
$version="1.0.0"
$owner="Salesforce-Devsu-Lab"
$github_pat="[YOUR PERSONAL ACCESS TOKEN HERE]"

dotnet pack src\Devsulab.Common\ --configuration Release -p:PackageVersion=$version -p:RepositoryUrl=https://github.com/$owner/devsulab.common -o ..\packages

dotnet nuget push ..\packages\Devsulab.Common.$version.nupkg --api-key $github_pat --source "github"
```