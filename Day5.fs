module Day5

open System
open System.Collections.Generic
open System.Text

type MoveInstruction =
  // move (number of crates) from (stack i) to (stack j)
  | Instruction of int * int * int

type CrateStack<'a>(crates:IEnumerable<'a>) =
    let stack = Stack<'a>(crates)
    member this.Retrieve() =
        stack.Pop()
    member this.Place(crates:IEnumerable<'a>) =
        Seq.iter (fun f -> stack.Push(f)) crates
    member this.MoveAtOnce(crates:IEnumerable<'a>) =
        Seq.iter (fun f -> stack.Push(f)) (crates |> Seq.rev)
    member this.Peek() =
        stack.Peek()

let PuzzleInputStackSetup =
    [
        CrateStack<string>(["R";"G";"J";"B";"T";"V";"Z"]);
        CrateStack<string>(["J";"R";"V";"L"]);
        CrateStack<string>(["F";"Q";"S"]);
        CrateStack<string>(["Z";"H";"N";"L";"F";"V";"Q";"G"]);
        CrateStack<string>(["R";"Q";"T";"J";"C";"S";"M";"W"]);
        CrateStack<string>(["S";"W";"T";"C";"H";"F"]);
        CrateStack<string>(["D";"Z";"C";"V";"F";"N";"J"]);
        CrateStack<string>(["L";"G";"Z";"D";"W";"R";"F";"Q"]);
        CrateStack<string>(["J";"B";"W";"V";"P"]);
    ]

let private MoveStacks moves (stacks: list<CrateStack<string>>) crateMover9001 = 
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
       yield stacks[i-1].Retrieve()
    ]
    if(crateMover9001) then 
        stacks[j-1].MoveAtOnce(popped)
    else
        stacks[j-1].Place(popped)
    stacks
  moves
  |> Seq.map toMoveInstruction
  |> Seq.choose id
  |> Seq.map (fun (mi:MoveInstruction) ->
    match mi with
    | Instruction (n,i,j) -> popThenPush n i j
  )

let CrateStacking (i:string) (seperator:string) skipN stackSetup crateMover9001 =
    let moves = 
      i.Split seperator 
      |> Array.skip skipN
      |> Array.where (fun f -> not(String.IsNullOrEmpty f))
    let moved =
      MoveStacks moves stackSetup crateMover9001
      |> Seq.last
    let result = List.map (fun (f:CrateStack<string>) -> f.Peek()) moved
    String.Join ("", result)