namespace fsharpworker

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let createHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(fun x ->
                webBuilder.UseStartup<Startup>() |> ignoreservices.AddHostedService<Worker>();
            )

    [<EntryPoint>]
    let main args =
        createHostBuilder(args).Build().Run()

        0 // edit code
