function statistics() {
    $('#stat-message').empty().hide();
    $('#stat-results').hide();
    $('#stat-results tbody td').empty();
    // the value entered in the 'numbers' element ID is now the value for the numbers variable.
    var Str = document.getElementById('stat-numbers').value;
    // separate the string with commas into an array
    var numbers = Str.split(',')
    if (numbers.length < 5) {	// If the user supplied at least 5 numbers
        createAlert('stat-message', 'danger', 'You did not enter at least 5 numbers.');
        $('#stat-message').show();
    } else if (/^[0-9\-\s\.]+(,[0-9\-\s\.]+)*$/.test(Str)) {	// Regex test to confirm only numbers and commas. Accepts negative numbers and whitespace between values
        // iterate through each key to clean the data and run calcs on it.
        for (i = 0;i < numbers.length; i++) {
        //each key has white space removed from it
            numbers[i] = parseInt(numbers[i].trim());
        }
        // new variable sorts array ascending and is assigned value of lowest key
        var min = numbers.sort(function(a, b){return a - b});
        min = min[0];
        // new variable sorts array descending and is assigned value of lowest key
        var max = numbers.sort(function(a, b){return b - a});
        max = max[0];
        var sum = 0;
        var product = 1;
        // iterates through array for sum and product
        for (i = 0; i < numbers.length; i++) {
            sum = sum + numbers[i];
            product = product * numbers[i];
            }
        // new variable finds the mean
        var mean = sum / numbers.length;
        document.getElementById('stat-min').innerHTML = min;
        document.getElementById('stat-max').innerHTML = max;
        document.getElementById('stat-mean').innerHTML = mean;
        document.getElementById('stat-sum').innerHTML = sum;
        document.getElementById('stat-product').innerHTML = product;
        $('#stat-results').show();
    } else {    // If the regex test above failed write approp. error message.
        createAlert('stat-message', 'danger', 'You entered punctuation or letters.');
        $('#stat-message').show();
    }
}