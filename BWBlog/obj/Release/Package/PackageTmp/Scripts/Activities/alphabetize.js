function alphabetize() {
    // Clear the warnings and results divs of any content and show it
    $('#alph-outputDiv').hide();
    $('#alph-warnings').empty();
    $('#alph-outputDiv').empty();
    var input = $('#alph-input').val();
    if (!input.match(/[a-zA-Z]+/g)) {
        console.log('Foo');
        $('#alph-warnings').show();
        createAlert('alph-warnings', 'danger', 'You didn\'t enter any letters.');
    } else {
        $('#alph-outputDiv').show();
        if (input.match(/[A-Z]+/g)) {
            $('#alph-warnings').show();
            createAlert('alph-warnings', 'warning', 'You entered capital letters and they were converted to lowercase.');
        }
        if (input.match(/\s+/g)) {
            $('#alph-warnings').show();
            createAlert('alph-warnings', 'warning', 'You entered spaces and they were removed.');
        }
        if (input.match(/\d+/g)) {
            $('#alph-warnings').show();
            createAlert('alph-warnings', 'warning', 'You entered numbers and they were removed.');
        }
        if (input.match(/\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:/g)) {
            $('#alph-warnings').show();
            createAlert('alph-warnings', 'warning', 'You entered special characters and they were removed.');
        }
        var lower = input.toLowerCase();
        var clean = lower.replace(/[^a-zA-Z]|\s+/ig,'');
        var arr = clean.split('');
        var original = arr.join();  // Because the sort function is an in-place algorithm, the original order can only be compared if stored in a new string.
        var sort = arr.sort();
        var sorted = sort.join();
        if (original === sorted) {
            createAlert('alph-warnings', 'success', 'You entered alphabetized letters!');
        }
        $('#alph-outputDiv').append('<p>' + sort + '<p>');
    }
}