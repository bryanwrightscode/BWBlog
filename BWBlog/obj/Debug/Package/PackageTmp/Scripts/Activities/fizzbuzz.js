/*
Write a program that accepts two numbers between 1 and 100 from the user. The program
then iterates through all numbers from 1 to 100, printing numbers in ascending order to the
screen. For each number that is a multiple of the first number input by the user, print "Fizz"
instead of the number. For each number that is a multiple of the second number input by
the user, print "Buzz" instead of the number. For numbers that are multiples of both
numbers, print "FizzBuzz" instead of the number.
*/

/*  Use JQuery instead of JS DOM methods
    Use .Hide and .Show etc
*/

function fizzBuzz() {

    $('#fizz-message').empty().hide();
    $('#fizz-numList').empty().hide();
    var numOne = $('#fizz-numOne').val();
    var numTwo = $('#fizz-numTwo').val();
    if (numOne < 1 ||
        numOne > 100 ||
        numTwo < 1 ||
        numTwo > 100) {
        $('#fizz-message').show();
        createAlert('fizz-message', 'danger', 'You must enter numbers between 1 and 100');
    }
    else {
        $('#fizz-numList').show();
        console.log(numOne + 'and ' + numTwo);
        for (i = 1; i < 101; i++) {
            if (i % numOne == 0 && i % numTwo != 0) {
                createParagraph('fizz-numList', 'fizz', 'Fizz');
            }
            else if (i % numTwo == 0 && i % numOne != 0) {
                createParagraph('fizz-numList', 'buzz', 'Buzz');
            }
            else if (i % numOne == 0 && i % numTwo == 0) {
                createParagraph('fizz-numList', 'fizzBuzz', 'FizzBuzz');
            }
            else {
                createParagraph('fizz-numList', '', i);
            }
        }
    }
}