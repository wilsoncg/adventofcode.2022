module Day5

open System
open System.Collections.Generic
open System.Text

type MoveInstruction =
  // move (number of crates) from (stack i) to (stack j)
  | Item of int * int * int

let private MoveStacks moves (stacks: list<Stack<string>>) = 
  let regexp = @"(\d+)"
  let toInt s = Int32.Parse s
  let toMoveInstruction (g:RegularExpressions.GroupCollection) =
    let n = g[0].Value |> toInt
    let i = g[1].Value |> toInt
    let j = g[2].Value |> toInt
    Item(n, i, j)
  let regexMatch s =
    let m = RegularExpressions.Regex.Match(regexp, s) 
    match m with
    | m when m.Success -> Some(toMoveInstruction m.Groups)
    | _ -> None
  moves
  |> Seq.map (fun f -> regexMatch f)
  stacks

let CrateStacking (i:string) (seperator:string) skipN stackSetup =
    let moves = 
      i.Split seperator 
      |> Array.skip skipN
      |> Array.where (fun f -> not(String.IsNullOrEmpty f))
    let moved =
      MoveStacks moves stackSetup
      |> Seq.map (fun f -> f.Pop())
    String.Join ("", moved)