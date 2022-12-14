open System
open System.IO

module Program =
 let [<EntryPoint>] main _ = 
   let file = 
    Path.Combine [| __SOURCE_DIRECTORY__; "input"; "day04-input.txt" |]
    |> File.ReadAllText
   Day4.WorkAssignments file "\n" Day4.OverlappingPairs |> Console.WriteLine
   0
