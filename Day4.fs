module Day4

open System

let OverlappingPairs (p:string) =
    0

let WorkAssignments (i:string) (seperator:string) consideration =
    let lines = i.Split seperator |> Array.where (fun f -> not(String.IsNullOrEmpty f))    
    lines
    |> Seq.map consideration
    |> Seq.reduce (+)