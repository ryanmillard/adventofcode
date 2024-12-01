import re

file = open("input.txt");

leftList = []
rightList = []
totalSimilarityScore = 0

for line in file:
  # Remove \n
  nums = line.strip()

  # Split by any amount of whitespace
  nums = re.split(r'\s+', nums)
  
  leftList.append(int(nums[0]))
  rightList.append(int(nums[1]))

for i in range(len(leftList)):
  left = leftList[i]
  count = rightList.count(left)
  totalSimilarityScore += left * count

file.close();

print(totalSimilarityScore)