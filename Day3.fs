module Day3

open System

let priority =
    let chars: seq<char> = Seq.append(seq { 'a'..'z' }) (seq { 'A'..'Z' })
    let numbers = seq { 1..52 }
    let combined = Seq.zip chars numbers
    Map combined

let Part1 (lines:string array) =
  lines
  |> Seq.map (fun s -> 
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

let Part2 (lines:string array) =
    let intersect (s: string array) =
        match s.Length with
        | 3 -> Set.intersect(Set s[0]) (Set s[1]) |> Set.intersect (Set s[2])
        | 2 -> Set.intersect(Set s[0]) (Set s[1])
        | _ -> Set.empty
    lines 
    |> Array.chunkBySize 3
    |> Seq.map (fun chunk -> 
        let common = intersect chunk
        let p = 
            common 
            |> Seq.map (fun f -> priority[f])
            |> Seq.reduce (+)
        p
    )

let RucksackPriority (i:string) (seperator:string) priorityScoring =
    let lines = i.Split seperator |> Array.where (fun f -> not(String.IsNullOrEmpty f))    
    lines
    |> priorityScoring
    |> Seq.reduce (+)