module Day2

open System

type RPS = 
    | Rock = 1
    | Paper = 2
    | Scissors = 3

let Score hands =
    let loss = 0
    let draw = 3
    let win = 6
    match hands with
    | (RPS.Rock, RPS.Paper) -> (int)RPS.Rock + loss
    | (RPS.Rock, RPS.Rock) -> (int)RPS.Rock + draw
    | (RPS.Rock, RPS.Scissors) -> (int)RPS.Rock + win
    | (RPS.Paper, RPS.Rock) -> (int)RPS.Paper + win
    | (RPS.Paper, RPS.Paper) -> (int)RPS.Paper + draw
    | (RPS.Paper, RPS.Scissors) -> (int)RPS.Paper + loss
    | (RPS.Scissors, RPS.Rock) -> (int)RPS.Scissors + loss
    | (RPS.Scissors, RPS.Paper) -> (int)RPS.Scissors + win
    | (RPS.Scissors, RPS.Scissors) -> (int)RPS.Scissors + draw
    | _ -> 0

let RockPaperScissors (i:string) (seperator:string) =
    let lookup =
        Map [ 
            ("A", RPS.Rock);
            ("B", RPS.Paper);
            ("C", RPS.Scissors);
            ("X", RPS.Rock);
            ("Y", RPS.Paper);
            ("Z", RPS.Scissors)
        ]
    let scoreHands (s:string) =
        let hands = s.Split ' '
        let opponentHand = lookup[hands[0]]
        let myHand = lookup[hands[1]]
        Score (myHand, opponentHand)
    i.Split seperator //each line
    |> Seq.map (fun s-> 
        match String.IsNullOrEmpty s with
        | true -> 0
        | false -> scoreHands s
        )
    |> Seq.reduce (fun x y -> x + y)