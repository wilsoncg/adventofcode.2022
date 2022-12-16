open System
open System.IO

module Program =
 let [<EntryPoint>] main _ = 
   let file = 
    Path.Combine [| __SOURCE_DIRECTORY__; "input"; "day05-input.txt" |]
    |> File.ReadAllText
   Day5.CrateStacking file "\n" 10 Day5.PuzzleInputStackSetup true |> Console.WriteLine
   0
