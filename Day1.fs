module Day1 

open System

let tryParseInt s = 
    try 
        s |> int |> Some
    with :? FormatException -> 
        None

let FindMostCalories (i:string) = 
 let split = i.Split $"{Environment.NewLine}{Environment.NewLine}"
 let parsed = split |> Seq.map tryParseInt
 let choosed = parsed |> Seq.choose id |> Seq.sum
 //parsed |> Option.fold (fun accum x -> accum + x)
 choosed