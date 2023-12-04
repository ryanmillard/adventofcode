string[] lines = File.ReadAllLines("E:\\AdventOfCode\\Day4\\input.txt");

/* Example
Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
*/

double sum = 0;

for (int cardNum = 0; cardNum < lines.Length; cardNum++)
{
    string[] numbers = lines[cardNum].Split(':', StringSplitOptions.TrimEntries)[1].Split('|');

    HashSet<int> winningNums = numbers[0]
        .Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToHashSet();

    HashSet<int> chosenNums = numbers[1]
        .Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x))
        .ToHashSet();

    int matches = winningNums.Intersect(chosenNums).Count();
  
    if (matches != 0) {
        double points = matches == 1 ? 1 : Math.Pow(2, matches-1);
        sum += points;
    }
}

Console.WriteLine(sum);
