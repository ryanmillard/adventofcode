// My C# solution to Part 2 of Day 2.

string[] lines = File.ReadAllLines("E:\\AdventOfCode\\Day2\\input.txt");

int sum = 0;

foreach (string line in lines) {
    string gameData = line.Split(": ")[1];

    Dictionary<string, int> cubeColoursMax = new Dictionary<string, int>();
    cubeColoursMax.Add("red", 1);
    cubeColoursMax.Add("green", 1);
    cubeColoursMax.Add("blue", 1);

    foreach (string cubeSelection in gameData.Split("; ")) {
        foreach (string colourSelection in cubeSelection.Split(", ")) {
            string[] colourData = colourSelection.Split(' ');
            int cubeAmount = int.Parse(colourData[0]);
            if (cubeAmount < cubeColoursMax[colourData[1]]) continue;
            cubeColoursMax[colourData[1]] = cubeAmount;
        }
    }

    sum += cubeColoursMax["red"] * cubeColoursMax["green"] * cubeColoursMax["blue"];
}

Console.WriteLine(sum);
