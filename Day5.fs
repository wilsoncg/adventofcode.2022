module Day5

open System
open System.Collections.Generic
open System.Text

type MoveInstruction =
  // move (number of crates) from (stack i) to (stack j)
  | Instruction of int * int * int

let private MoveStacks moves (stacks: list<Stack<string>>) = 
  let regexp = "move (\d+) from (\d+) to (\d+)"
  let toInt s = Int32.Parse s
  let toInstruction (g:RegularExpressions.GroupCollection) =
    let n = g[1].Value |> toInt
    let i = g[2].Value |> toInt
    let j = g[3].Value |> toInt
    Instruction(n, i, j)
  let toMoveInstruction s =
    let m = RegularExpressions.Regex.Match(s, regexp, RegularExpressions.RegexOptions.Compiled) 
    match m with
    | m when m.Success -> Some(toInstruction m.Groups)
    | _ -> None
  let popThenPush n i j =
    let popped = [
      for a in 1..n do
       yield stacks[i-1].Pop()
    ]
    Seq.iter (fun f -> stacks[j-1].Push(f)) popped
    stacks
  moves
  |> Seq.map toMoveInstruction
  |> Seq.choose id
  |> Seq.map (fun (mi:MoveInstruction) ->
    match mi with
    | Instruction (n,i,j) -> popThenPush n i j
  )

let CrateStacking (i:string) (seperator:string) skipN stackSetup =
    let moves = 
      i.Split seperator 
      |> Array.skip skipN
      |> Array.where (fun f -> not(String.IsNullOrEmpty f))
    let moved =
      MoveStacks moves stackSetup
      |> Seq.last
    let result = List.map (fun (f:Stack<string>) -> f.Pop()) moved
    String.Join ("", result)