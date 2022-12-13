module Tests

open System
open Xunit
open Day1

[<Fact>]
let ``Day01 - 1 Elf has 6000 calories`` () =
    let input = "1000
2000
3000"
    let result = Day1.FindMostCalories input Environment.NewLine
    Assert.Equal(6000, result)

[<Fact>]
let ``Day01 Elf has 24000 calories`` () =
    let input = "1000
2000
3000

4000

5000
6000

7000
8000
9000

10000"
    let result = Day1.FindMostCalories input Environment.NewLine
    Assert.Equal(24000, result)

[<Fact>]
let ``Day02 RockPaperScissors score is 15`` () =
    let input = "A Y
B X
C Z"
    let result = Day2.RockPaperScissors input Environment.NewLine
    Assert.Equal(15, result)