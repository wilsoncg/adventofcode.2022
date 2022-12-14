module Day1 

open System

let tryParseInt s = 
    try 
        s |> int |> Some
    with :? FormatException -> 
        None

let Top1 (s:seq<int>) =
  s |> Seq.sortDescending |> Seq.truncate 1 |> Seq.sum

let Top3 (s:seq<int>) =
  s |> Seq.sortDescending |> Seq.take 3 |> Seq.sum

let FindMostCalories (i:string) (seperator:string) topN = 
 i.Split $"{seperator}{seperator}"
  |> Seq.map (fun f -> f.Split $"{seperator}")
 |> (fun s -> 
   s |> Seq.map (fun t -> (t |> Seq.map tryParseInt |> Seq.choose id |> Seq.sum))
   )
 |> topN