using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using WebApplication1;

CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            if (context.HostingEnvironment.IsProduction())
            {
                IConfigurationRoot builtConfig = config.Build();
                SecretClient secretClient = new(
                    new Uri($"https://{builtConfig["KeyVaultName"]}.vault.azure.net/"),
                    new DefaultAzureCredential());
                config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
            }
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });