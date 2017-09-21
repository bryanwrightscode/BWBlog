function capitalize() {
    $('#cap-results').hide();
    $('#cap-results').empty();
    $('#cap-alerts').empty();
    var input = $('#cap-input').val();
    if (!input.match(/[a-zA-Z]+/g)) {
        $('#cap-alerts').append('<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Oh snap!</strong> You didn\'t enter any letters.</div>');
    } else {
        if ($('#cap-option').is(':checked')) {
            var repl = input.replace(/\b[a-z]/g, function(a){return a.toUpperCase()});
            repl = repl.replace(/(\bThe\b|\bIn\b|\bOf\b|\bA\b|\bAn\b|\bAnd\b)/g, function(a){return a.toLowerCase()});
            repl = repl.replace(repl[0], repl[0].toUpperCase());
            $('#cap-results').append('<h4>' + repl + '</h4>');
            $('#cap-results').show();
        } else {
            var repl = input.replace(/\b[a-z]/g, function(a){return a.toUpperCase()});
            $('#cap-results').append('<h4>' + repl + '</h4>');
            $('#cap-results').show();
        }
    }
}

function options() {
    $('#cap-optionsDiv').stop().toggle('fast');
}