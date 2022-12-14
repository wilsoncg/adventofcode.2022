module Day4

open System

let OverlappingPairs (pairs:string) =
    // 2-8,3-7
    // 6-6,4-6
    let section (s:string) =
        let sectionStart = int s[0]
        let sectionEnd = int s[2]
        (sectionStart, sectionEnd)
    let isOverlapping t1 t2 =
        match (t1,t2) with
        | (a,b),(x,y) when x >= a && y <= b -> 1
        | (a,b),(x,y) when a >= x && b >= y -> 1
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