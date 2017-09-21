/*
Write a program that determines whether a word is a Palindrome (the same backward as it
is forward – “radar” for example). Display the result to the user.
*/
function palindrome() {
    document.getElementById('pal-messageYes').style.display = 'none';
    document.getElementById('pal-messageNo').style.display = 'none';
    var wordInput = document.getElementById('pal-wordInput').value;
    var wordCap = wordInput.toUpperCase();
    var wordClean = wordCap.replace(/[^a-zA-Z]|\s+/ig,'');
    var wordArr = wordClean.split('');
    var wordRevArr = wordArr.reverse();
    var wordRev = wordRevArr.join('');
    if (wordClean === wordRev) {
        var succPar = document.createElement('p');
        var succNode = document.createTextNode('Congratulations, ' + '"' + wordInput + '"' + ' is a palindrome!');
        succPar.appendChild(succNode);
        var succMessage = document.getElementById('pal-messageYes');
        succMessage.appendChild(succPar);
        document.getElementById('pal-messageYes').style.display = 'block';
    } else {
        var failPar = document.createElement('p');
        var failNode = document.createTextNode('Sorry, ' + '"' + wordInput + '"' + ' is not a palindrome.');
        failPar.appendChild(failNode);
        var failMessage = document.getElementById('pal-messageNo');
        failMessage.appendChild(failPar);
        document.getElementById('pal-messageNo').style.display = 'block';
    }
}