function prime() {
    $('#prime-alerts').empty();
    $('#prime-results').empty();
    var input = $('#prime-input').val();
    if (!input.match(/^-?\d\d*$/g)) {
        $('#prime-results').hide(); //If previous attempt produced results
        $('#prime-alerts').append('<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Oh snap! </strong>'+ input + ' is not a natural number.</div>');
        if (input <= 1 && input.match(/^-?.?\..*$/g)) {
            $('#prime-alerts').append('<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Oh snap! </strong>' + input+' is not greater than 1.</div>');
        }
    } else {
        if (input <= 1) {
            $('#prime-results').hide(); //If previous attempt produced results
            $('#prime-alerts').append('<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Oh snap! </strong>' + input + ' is not greater than 1.</div>');
        } else {
            var nonFactors = [];
            var factors = [];
            for (i=2; i<input; i++) {
                if (input % i !== 0) {
                    nonFactors.push(i);
                }
                if (input % i === 0) {
                    factors.push(i);
                }
            }
            if (factors.length === 0) {
                $('#prime-results').hide();
                $('#prime-alerts').append('<div class="alert alert-success alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Congrats! </strong>' + input + ' is prime.</div>');
            }
            if (factors.length !== 0) {
                $('#prime-alerts').append('<div class="alert alert-warning alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Sorry. </strong>' + input + ' is not prime.</div>');
                $('#prime-results').append('<p>' + input + ' is divisible by:</p>' + '<p>' + factors + '</p>');
                $('#prime-results').show();
            }
        }
    }
}



