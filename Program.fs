open System
open System.IO
module Program =
 let [<EntryPoint>] main _ = 
   let file = 
    Path.Combine [| __SOURCE_DIRECTORY__; "input"; "day02-input.txt" |]
    |> File.ReadAllText
   Day2.RockPaperScissors file "\n" |> Console.WriteLine
   0
