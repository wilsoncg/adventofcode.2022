open System
open System.IO
module Program =
 let [<EntryPoint>] main _ = 
   let file = 
    Path.Combine [| __SOURCE_DIRECTORY__; "day01-input.txt" |]
    |> File.ReadAllText
   Day1.FindMostCalories file "\n" |> Console.WriteLine
   0
