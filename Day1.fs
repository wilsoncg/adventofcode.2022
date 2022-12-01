module Day1 

open System

let tryParseInt s = 
    try 
        s |> int |> Some
    with :? FormatException -> 
        None

let FindMostCalories (i:string) = 
 i.Split $"{Environment.NewLine}{Environment.NewLine}"
  |> Seq.map (fun f -> f.Split $"{Environment.NewLine}")
 |> (fun s -> 
   s |> Seq.map (fun t -> (t |> Seq.map tryParseInt |> Seq.choose id |> Seq.sum))
   )
 |> Seq.max