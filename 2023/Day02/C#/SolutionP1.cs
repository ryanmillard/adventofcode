// My Solution in C# to Part 1 of Day 2

string[] lines = File.ReadAllLines("E:\\AdventOfCode\\Day2\\input.txt");

Dictionary<string, int> cubeColoursMax = new Dictionary<string, int>();
cubeColoursMax.Add("red", 12);
cubeColoursMax.Add("green", 13);
cubeColoursMax.Add("blue", 14);

int sum = 0;
int currentGameNum = 1;

foreach (string line in lines) {
    string gameData = line.Split(": ")[1];

    bool validGameData = true;

    foreach (string cubeSelection in gameData.Split("; ")) {
        foreach (string colourSelection in cubeSelection.Split(", ")) {
            string[] colourData = colourSelection.Split(' ');
            if (int.Parse(colourData[0]) > cubeColoursMax[colourData[1]]) {
                validGameData = false;
                break;
            }
        }
        if (!validGameData) break;
    }

    if (validGameData) sum += currentGameNum;

    currentGameNum++;
}

Console.WriteLine(sum);
