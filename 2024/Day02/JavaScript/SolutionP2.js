const fs = require("node:fs");

let data = fs.readFileSync("./input.txt", "utf8");
let lines = data.split("\n");

let arr = [];

function isReportSafe(arr) {
  let first = arr[0];
  let second = arr[1];
  let isDescending = first > second;
  let badLevelAmount = 0;

  for (let i = 0; i < arr.length-1; i++) {
    let current = arr[i];
    let next = arr[i+1];
    let difference = Math.abs(current - next);
    let isBadLevel = false;

    if (current > next && !isDescending) isBadLevel = true;
    if (current < next && isDescending) isBadLevel = true;
    if (difference < 1 || difference > 3) isBadLevel = true;

    if (isBadLevel) badLevelAmount++;

    if (badLevelAmount === 2) return false;
  }

  return true;
}

for (let i = 0; i < lines.length; i++) {
  let line = lines[i];
  let lineArr = line.split(" ");
  if (lineArr.length <= 1) continue;

  lineArr = lineArr.map(x => parseInt(x, 10));
  arr.push(lineArr);
}

let totalSafeReports = 0;

for (let i = 0; i < arr.length; i++) {
  if (isReportSafe(arr[i])) {
    totalSafeReports += 1;
  }
}

console.log(totalSafeReports);