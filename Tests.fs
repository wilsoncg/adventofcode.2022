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
let ``Day02 RockPaperScissors score part 1 is 15`` () =
    let input = "A Y
B X
C Z
"
    let result = Day2.RockPaperScissors input Environment.NewLine Day2.ScorePart1
    Assert.Equal(15, result)

[<Fact>]
let ``Day02 RockPaperScissors score part 1 is 30`` () =
    let input = "A Y
B X
C Z
A Y
B X
C Z
"
    let result = Day2.RockPaperScissors input Environment.NewLine Day2.ScorePart1
    Assert.Equal(30, result)

[<Fact>]
let ``Day02 RockPaperScissors score part 2 is 12`` () =
    let input = "A Y
B X
C Z
"
    let result = Day2.RockPaperScissors input Environment.NewLine Day2.ScorePart2
    Assert.Equal(12, result)

[<Fact>]
let ``Day03 Rucksack priority sum is 157`` ()=
    let input = "
vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
"
    let result = Day3.RucksackPriority input Environment.NewLine
    Assert.Equal(157, result)