open System
open System.IO

module Program =
 let [<EntryPoint>] main _ = 
   let file = 
    Path.Combine [| __SOURCE_DIRECTORY__; "input"; "day03-input.txt" |]
    |> File.ReadAllText
   Day3.RucksackPriority file "\n" |> Console.WriteLine
   0
