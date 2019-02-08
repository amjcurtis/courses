'use strict';

// SUM POSITIVE NUMBERS IN ARRAY OF INTEGERS
function positiveSum(arr) {
  var total = 0;
  for (var i = 0; i < arr.length; i++) {
    if (arr[i] > 0) {
      total += arr[i];
    }
  }
  return total;
}

// VALIDATE PIN NUMBER TO ENSURE IT'S EITHER 4 OR 6 INTEGERS
function validatePIN(pin) {
  return /^(\d{4}|\d{6})$/.test(pin);
}