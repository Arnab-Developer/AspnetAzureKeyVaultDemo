# ASP.NET Azure key vault demo

A demo to show how an ASP.NET app can access Azure key vault secret.

Application secrets should not be stored in `appsettings.json`. When the app is
running in local machine then it should read the secrets from 
[user secret](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#how-the-secret-manager-tool-works).
When the app is deployed and running from Azure then it should read secrets from 
[key vault](https://azure.microsoft.com/en-gb/services/key-vault/).

With this sample app you can able to see how 'appsettings' value has been overwritten 
by 'user secret' and 'user secret' value has been overwritten by 'azure key vault'.

## Run this app from local with user secret

- Clone the repo.
- Open the solution with Visual Studio.
- Right click on the project and click on 'Manage User Secrets'.
- Use below json in the user secret
```json
{
  "Address": "user secret value"
}
```
- Press F5 in Visual Studio to run the app.

## Run this app from azure with azure key vault

- Create app service in azure and deploy this app.
- Create key vault and add 'Address' secret with some value.
- You need to 'add access policy' in the key vault with the app service identity 
principal so that the application can access key vault successfully.
- Run the app
