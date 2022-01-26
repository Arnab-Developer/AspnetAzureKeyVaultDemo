# ASP.NET Azure key vault demo

A demo to show how an ASP.NET app can access Azure key vault secret.

Application secrets should not be stored in `appsettings.json`. When the app is
running in local machine then it should read the secrets from 
[user secret](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#how-the-secret-manager-tool-works).
When the app is deployed and running from Azure then it should read secrets from 
[key vault](https://azure.microsoft.com/en-gb/services/key-vault/).

To test azure key vault:

- Create app service in azure and deploy this app.
- Create key vault and add 'Address' secret with some value.
- You need to 'add access policy' in the key vault with the app service identity 
principal so that the application can access key vault successfully.
- Run the app