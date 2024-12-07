const fs = require("node:fs");

let data = fs.readFileSync("./input.txt", "utf8");
data = data.split("\n").join("");

let arr = [...data.matchAll(/mul\(\d{1,3},\d{1,3}\)/g)];
arr = arr.map(x => x[0]); // Full of 'mul(x,y)'

let total = 0;

for (let i = 0; i < arr.length; i++) {
  arr[i] = arr[i].substring(4,arr[i].length-1);
  arr[i] = arr[i].split(",").map(x => parseInt(x,10));
  total += arr[i][0] * arr[i][1];
}

console.log(total);