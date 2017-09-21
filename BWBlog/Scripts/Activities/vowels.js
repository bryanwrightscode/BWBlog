function vowels() {
    $('#vow-alerts').empty();
    $('#vow-results').empty();
    var input = $('#vow-input').val();
    if (!input.match(/[a-z]/ig)) {
        $('#vow-results').hide(); //If previous attempt produced results
        $('#vow-alerts').append('<div class="alert alert-danger alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>Oh snap! </strong> You didn&#39t enter any letters.</div>');
    } else {
        if (!input.match(/[a|e|i|o|u]/ig)) {
            $('#vow-alerts').append('<div class="alert alert-warning alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>Your entry didn&#39t include any vowels.</div>');
        }
        input = input.toLowerCase();
        var vowels = [];
        for (i=0; i<input.length; i++) {
            var current = input[i];
            if (current.match(/[a|e|i|o|u]/ig)) {
                vowels.push(current);
            }
        }
        var count = vowels.length;
        $('#vow-results').append('<p>' + vowels +'</p>');
        $('#vow-results').append('<p><strong>Total: </strong>' + count + '</p>');
        $('#vow-results').show();
    }
}