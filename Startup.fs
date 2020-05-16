namespace fsharpworker

open System
open System.Collections.Generic
open System.Linq
open System.Threading
open System.Threading.Tasks
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type Worker(logger: ILogger<Worker>) =
    inherit BackgroundService()

    override _.ExecuteAsync(ct: CancellationToken) =
        async {
            while (not ct.IsCancellationRequested) do
                let msg = sprintf "Worker running at: %O" DateTime.Now
                logger.LogInformation msg
                return! (Task.Delay(1000, ct) |> Async.AwaitTask)
        } |> Async.StartAsTask :> Task
        
