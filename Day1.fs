module Day1 

open System

let tryParseInt s = 
    try 
        s |> int |> Some
    with :? FormatException -> 
        None

let FindMostCalories (i:string) (seperator:string) = 
 i.Split $"{seperator}{seperator}"
  |> Seq.map (fun f -> f.Split $"{seperator}")
 |> (fun s -> 
   s |> Seq.map (fun t -> (t |> Seq.map tryParseInt |> Seq.choose id |> Seq.sum))
   )
 |> Seq.sortDescending |> Seq.take 3 |> Seq.sum