module Tests

open System
open Xunit
open Day1

[<Fact>]
let ``Day01 - Part1 - 1 Elf has 6000 calories`` () =
    let input = "1000
2000
3000"
    let result = Day1.FindMostCalories input Environment.NewLine Day1.Top1
    Assert.Equal(6000, result)

[<Fact>]
let ``Day01 - Part1 - Elf with most calories has 24000 calories`` () =
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
    let result = Day1.FindMostCalories input Environment.NewLine Day1.Top1
    Assert.Equal(24000, result)

[<Fact>]
let ``Day01 - Part2 - Top 3 elves have 45000 calories`` () =
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
    let result = Day1.FindMostCalories input Environment.NewLine Day1.Top3
    Assert.Equal(45000, result)

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
    let result = Day3.RucksackPriority input Environment.NewLine Day3.Part1
    Assert.Equal(157, result)

[<Fact>]
let ``Day03 Rucksack priority sum is 70 when split into chunks``() =
    let input = "
vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
"
    let result = Day3.RucksackPriority input Environment.NewLine Day3.Part2
    Assert.Equal(70, result)

[<Fact>]
let ``Day04 Work assignments, there are 2 overlapping pairs``() =
    let input = "
2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
"
    let result = Day4.WorkAssignments input Environment.NewLine Day4.OverlappingPairs
    Assert.Equal(2, result)