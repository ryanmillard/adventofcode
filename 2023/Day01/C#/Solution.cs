string[] lines = File.ReadAllLines("E:\\AdventOfCode\\Day1\\input.txt");

static string replaceWordedNumbers(string inputString) {
    string[] numberedWords = {"one","two","three","four","five","six","seven","eight","nine"};

    int wordNum = 1;
    foreach (string word in numberedWords) {
        while (inputString.Contains(word)) {
            inputString = inputString.Replace(word, (word[0] + wordNum.ToString() + word[word.Length-1]));
        }
        wordNum++;
    }

    return inputString;
}

int sum = 0;

foreach (string line in lines) {
    char firstDigit = '0';
    char lastDigit = '0';

    foreach (char character in replaceWordedNumbers(line)) {
        if (!char.IsDigit(character)) continue;
        if (firstDigit.Equals('0')) firstDigit = character;
        lastDigit = character;
    }

    sum += (((int) firstDigit - '0') * 10) + (int) lastDigit - '0';
}

Console.WriteLine(sum);
