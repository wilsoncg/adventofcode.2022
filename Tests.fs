module Tests

open System
open System.Collections.Generic
open Xunit

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

[<Fact>]
let ``Day04 Work assignments, there are 2 overlapping pairs with double digits``() =
    let input = "
12-14,16-18
12-13,14-15
25-27,27-29
32-38,33-37
36-36,32-36
42-46,44-48
"
    let result = Day4.WorkAssignments input Environment.NewLine Day4.OverlappingPairs
    Assert.Equal(2, result)

[<Fact>]
let ``Day04 Work assignments, no overlapping pairs with double digits``() =
    let input = "
6-92,4-5
4-5,6-92
"
    let result = Day4.WorkAssignments input Environment.NewLine Day4.OverlappingPairs
    Assert.Equal(0, result)

[<Fact>]
let ``Day04 Work assignments, 0 pairs with any overlap``() =
    let input = "
2-4,6-8
2-3,4-5
"
    let result = Day4.WorkAssignments input Environment.NewLine Day4.ConsecutiveOrOverlapping
    Assert.Equal(0, result)

[<Fact>]
let ``Day04 Work assignments, 0 pairs with any overlap (reversed)``() =
    let input = "
6-8,2-4
4-5,2-3
"
    let result = Day4.WorkAssignments input Environment.NewLine Day4.ConsecutiveOrOverlapping
    Assert.Equal(0, result)

[<Fact>]
let ``Day04 Work assignments, 8 pairs with any overlap``() =
    let input = "
5-7,7-9
7-9,5-7
2-8,3-7
3-7,2-8
6-6,4-6
4-6,6-6
2-6,4-8
4-8,2-6
"
    let result = Day4.WorkAssignments input Environment.NewLine Day4.ConsecutiveOrOverlapping
    Assert.Equal(8, result)

[<Fact>]
let ``Day05 Crate stacking, result should be CMZ``() =
    let input = "    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
"
    let stackSetup = 
      [
        Stack<string>(["Z";"N"]);
        Stack<string>(["M";"C";"D"]);
        Stack<string>(["P"]);
      ]
    let result = Day5.CrateStacking input Environment.NewLine 4 stackSetup
    Assert.Equal("CMZ", result)