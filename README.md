# DevsubLab.Common

## Add Configuration Env
```bash
version="1.0.1"
owner="Salesforce-Devsu-Lab"
github_pat="[YOUR PERSONAL ACCESS TOKEN HERE]"
```

## Add the GitHub Package Source
```bash
dotnet nuget add source --username USERNAME --password $github_pat --store-password-in-clear-text --name github "https://nuget.pkg.github.com/$owner/index.json"
```

## Create and publish package

```powershell
dotnet pack src/Devsulab.Common/ --configuration Release -p:PackageVersion=$version -p:RepositoryUrl=https://github.com/$owner/DevsubLab.Common -o ../../packages


dotnet nuget push ../../packages/Devsulab.Common.$version.nupkg --api-key $github_pat --source "github"
```