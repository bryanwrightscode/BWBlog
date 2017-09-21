// Write a JavaScript function that generates all combinations of a string ex) pie to p, pi, pe, i, ie, e

/*
This functions works by repeatedly modifying a user input string until 1 of 2 conditions is met. The string is 
modified in two ways on each recursion, leading to two new active strings each time the function repeats. The
two ways the input string is modified are transferring the [0] key or removing without transferring. The function 
runs until either both the active and original strings are null, or just the original string is null. If 
both are null, the function ends. If just the original string is null (empty), then that string is added to an
array. The result of each scenario is added the the output array, a, and it is finally returned. Since there is 
only one combination of events that results in both strings being empty, the function runs until all possible cominations
are created.

Possible improvements:
The combinations function treats duplicate characters in user input the same as different characters. It could modify the string
to remove all duplicate characters so the results don't include a combination with two of the same characters.

References:
Code is heavily based on Wayne Burkett's entry at Stackexchange.com.
[https://codereview.stackexchange.com/questions/7001/generating-all-combinations-of-an-array]
*/

function combinations(str) {
    function fn(active, rest, a) {
        if (!active && !rest)
            return;
        if (!rest) {
           a.push(active);
        } else {                                        // each key in string is removed or removed and added until nothing is left
            fn(active + rest[0], rest.slice(1), a);     // adds first key to active string and removes from rest string
            fn(active, rest.slice(1), a);               // only removes first key from rest string
        }
        return a;
    }
    return fn("", str, []);
}

function stringRun() {
    $("#scram-alerts").empty().hide();
    $('#string-comboList').empty();                            // clears the contents of the previous results (if not first time).
    $('.well').show();                                  // changes the display of the results div from hidden (if first time).
    var inputStr = $('#string-inputStr').val();                // assigns 'inputStr' variable the value of the user input contents.
    if (inputStr.length > 6) {
        $("#scram-alerts").show();
        createAlert("scram-alerts", "danger", "Enter a string with 6 or fewer characters.")
    }
    else {
        var results = combinations(inputStr);               // assigns 'results' variable the value of the combinations function output.
        for (i = 0; i < results.length; i++) {
            console.log(results[i]);
            $("#string-comboList").append('<li>' + results[i] + '</li>');
        }
    }
}