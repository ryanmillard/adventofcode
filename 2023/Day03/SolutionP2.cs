// My solution to Part 2 of Day 3 in C#

string[] lines = File.ReadAllLines("E:\\AdventOfCode\\Day3\\input.txt");

int MaximumX = lines[0].Length;
int MaximumY = lines.Length;

static int getEntireNum(string line, int posX, int MaximumX)
{
    if (!char.IsDigit(line[posX])) return 0;

    string foundNum = line[posX].ToString();

    // Go all the way left until it ends
    int leftPosX = posX;
    while (leftPosX != 0)
    {
        leftPosX--;
        if (!char.IsDigit(line[leftPosX])) break;
        foundNum = line[leftPosX].ToString() + foundNum;
    }

    // Go all the way right until it ends
    int rightPosX = posX;
    while (rightPosX != MaximumX - 1)
    {
        rightPosX++;
        if (!char.IsDigit(line[rightPosX])) break;
        foundNum = foundNum + line[rightPosX].ToString();
    }

    return int.Parse(foundNum);
}

int sum = 0;

for (int y = 0; y < MaximumY; y++)
{
    for (int x = 0; x < MaximumX; x++)
    {
        if (lines[y][x] != '*') continue;

        List<int> nearbyNumbers = new List<int>();

        if (x != 0) nearbyNumbers.Add(getEntireNum(lines[y], x-1, MaximumX)); // Left
        if (x != MaximumX) nearbyNumbers.Add(getEntireNum(lines[y], x+1, MaximumX)); // Right

        if (y != 0) {
            int aboveNumber = getEntireNum(lines[y-1], x, MaximumX);
            nearbyNumbers.Add(aboveNumber);
            if (aboveNumber == 0) {
                nearbyNumbers.Add(getEntireNum(lines[y-1], x-1, MaximumX)); // Up and Left
                nearbyNumbers.Add(getEntireNum(lines[y-1], x+1, MaximumX)); // Up and Right
            }
        }

        if (y != MaximumY) {
            int belowNumber = getEntireNum(lines[y+1], x, MaximumX);
            nearbyNumbers.Add(belowNumber);
            if (belowNumber == 0) {
                nearbyNumbers.Add(getEntireNum(lines[y+1], x-1, MaximumX)); // Down and Left
                nearbyNumbers.Add(getEntireNum(lines[y+1], x+1, MaximumX)); // Down and Right
            }
        }

        int nearbyNumbersAmount = 0;
        int gearProduct = 1;
        foreach (int num in nearbyNumbers) {
            if (num == 0) continue;
            nearbyNumbersAmount++;
            if (nearbyNumbersAmount > 2) break;
            gearProduct *= num;
        }

        if (nearbyNumbersAmount == 2) sum += gearProduct;
    }
}

Console.WriteLine(sum);
