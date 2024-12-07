const fs = require("node:fs");

let data = fs.readFileSync("./input.txt", "utf8");
data = data.split("\n").join("");

const mulReg = /^mul\(\d{1,3},\d{1,3}\)/g;

let arr = [];
let total = 0;
let isMulEnabled = true;

for (let i = 0; i < data.length; i++) {
  let char = data[i];
  if (char === "m") {
    if (isMulEnabled === false) continue;
    let checkString = data.substring(i, i+12);
    let match = checkString.match(mulReg);
    if (match === null) continue;
    console.log(match);
    arr.push(match[0]);
  } else if (char === "d") {
    let checkString = data.substring(i,i+7);
    if (checkString.startsWith("don't()")) {
      isMulEnabled = false;
    } else if (checkString.startsWith("do()")) {
      isMulEnabled = true;
    }
  }
}

for (let i = 0; i < arr.length; i++) {
  arr[i] = arr[i].substring(4,arr[i].length-1);
  arr[i] = arr[i].split(",").map(x => parseInt(x,10));
  total += arr[i][0] * arr[i][1];
}

console.log(total);