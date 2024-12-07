const fs = require("node:fs");

let data = fs.readFileSync("./input.txt", "utf8");
let lines = data.split("\n");

let arr = [];

function isReportSafe(arr) {
  let first = arr[0];
  let second = arr[1];
  let isDescending = first > second;
  
  for (let i = 0; i < arr.length-1; i++) {
    let current = arr[i];
    let next = arr[i+1];
    let difference = Math.abs(current - next);

    if (current > next && !isDescending) return false;
    if (current < next && isDescending) return false;
    if (difference < 1 || difference > 3) return false;
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