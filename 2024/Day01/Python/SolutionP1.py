import re

file = open("input.txt");

leftList = []
rightList = []
totalDistance = 0

for line in file:
  # Remove \n
  nums = line.strip()

  # Split by any amount of whitespace
  nums = re.split(r'\s+', nums)
  
  leftList.append(int(nums[0]))
  rightList.append(int(nums[1]))

leftList.sort()
rightList.sort()

for i in range(len(leftList)):
  left = leftList[i]
  right = rightList[i]
  totalDistance += abs(left - right)

file.close();

print(totalDistance)