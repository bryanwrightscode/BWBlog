/* 
References: 
For explanation of recursive function see https://stackoverflow.com/questions/4438131/factorial-of-a-number
For mathetmatical proof that 0! = 1 see https://www.zero-factorial.com/whatis.html
*/

function factRun() {
    $('#fact-fail').empty().hide();
    $('#fact-success').empty().hide();
    var number = document.getElementById('fact-number').value;
    if (number % 1 != 0) {
        createAlert('fact-fail', 'danger', 'You must enter a whole number.');
        $('#fact-fail').show();
    }
    else if (number < 0) {
        createAlert('fact-fail', 'danger', 'You must enter a number greater than 0.');
        $('#fact-fail').show();
    }
    else {
        var result = factorial(parseInt(number, 10));
        if (isFinite(result) == false)
        {
            createAlert('fact-fail', 'warning', 'Try entering a smaller number.');
            $('#fact-fail').show();
        }
        console.log(typeof (result));
        document.getElementById('fact-success').innerHTML = result;    //Print out result in the HTML
        document.getElementById('fact-success').style.display = 'block';
    }
}
function factorial(number) {
    if (number == 0) {
        return 1;
    }
    return number * factorial(number-1);
}