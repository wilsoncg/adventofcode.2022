module Day4

open System

let OverlappingPairs (pairs:string) =
    let section (s:string) =
        let digits = s.Split '-'
        let sectionStart = int digits[0]
        let sectionEnd = int digits[1]
        (sectionStart, sectionEnd)
    let isOverlapping t1 t2 =
        match (t1,t2) with
        | (a,b),(x,y) when (x >= a && b >= y) || (a >= x && b <= y) -> 1
        | _ -> 0 
    let p =
      pairs.Split ',' 
      |> Seq.map section
      |> Seq.toArray
    isOverlapping p[0] p[1]

let WorkAssignments (i:string) (seperator:string) consideration =
    let lines = i.Split seperator |> Array.where (fun f -> not(String.IsNullOrEmpty f))    
    lines
    |> Seq.map consideration
    |> Seq.reduce (+)