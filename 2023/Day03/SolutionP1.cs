// My solution to Day 3 part 1 in C#

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
        if (char.IsDigit(lines[y][x])) continue;
        if (lines[y][x] == '.') continue;

        if (x != 0) sum += getEntireNum(lines[y], x-1, MaximumX); // Left
        if (x != MaximumX) sum += getEntireNum(lines[y], x+1, MaximumX); // Right

        if (y != 0) {
            int aboveNumber = getEntireNum(lines[y-1], x, MaximumX);
            sum += aboveNumber;
            if (aboveNumber == 0) {
                sum += getEntireNum(lines[y-1], x-1, MaximumX); // Up and Left
                sum += getEntireNum(lines[y-1], x+1, MaximumX); // Up and Right
            }
        }

        if (y != MaximumY) {
            int belowNumber = getEntireNum(lines[y+1], x, MaximumX);
            sum += belowNumber;
            if (belowNumber == 0) {
                sum += getEntireNum(lines[y+1], x-1, MaximumX); // Down and Left
                sum += getEntireNum(lines[y+1], x+1, MaximumX); // Down and Right
            }
        }
    }
}

Console.WriteLine(sum);
