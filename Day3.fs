module Day3

open System

let RucksackPriority (i:string) (seperator:string) =
    let lines = i.Split seperator |> Array.where (fun f -> not(String.IsNullOrEmpty f))
    let chars: seq<char> = Seq.append(seq { 'a'..'z' }) (seq { 'A'..'Z' })
    let numbers = seq { 1..52 }
    let combined = Seq.zip chars numbers
    let priority = Map combined 
    lines
    |> Array.map (fun s -> 
        // each line, split in half, find common letters
        let split = 
            let first = s |> Seq.take (s.Length/2) |> Set
            let second = s |> Seq.skip (s.Length/2) |> Set
            let common = Set.intersect first second
            let p = 
                common 
                |> Seq.map (fun f -> priority[f])
                |> Seq.reduce (+)
            p
        split)
    |> Seq.reduce (+)