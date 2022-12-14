module Day4

open System

let private containsSubset t1 t2 =
    match (t1,t2) with
    | (a,b),(x,y) when (x >= a && b >= y) || (a >= x && b <= y) -> 1
    | _ -> 0 

let private areConsecutiveOrOverlapping t1 t2 =
    match (t1,t2) with
    | (a,b),(x,y) when b = x && a <= y -> 1 // overlap single
    | (a,b),(x,y) when (x >= a && b >= y) || (a >= x && b <= y) -> 1 // is subset
    | (a,b),(x,y) when b >= x && b <= y -> 1 // 2-6,4-8
    | _ -> 0

let private Pairs (pairs:string) rule =
    let sectionToPair (s:string) =
        let digits = s.Split '-'
        let sectionStart = int digits[0]
        let sectionEnd = int digits[1]
        (sectionStart, sectionEnd)
    let p =
      pairs.Split ',' 
      |> Seq.map sectionToPair
      |> Seq.sortBy (fun f -> fst f)
      |> Seq.toArray
    rule p[0] p[1]

let OverlappingPairs (pairs:string) =
    Pairs pairs containsSubset

let ConsecutiveOrOverlapping (pairs:string) =
    Pairs pairs areConsecutiveOrOverlapping

let WorkAssignments (i:string) (seperator:string) consideration =
    let lines = i.Split seperator |> Array.where (fun f -> not(String.IsNullOrEmpty f))
    lines
    |> Seq.map consideration
    |> Seq.reduce (+)