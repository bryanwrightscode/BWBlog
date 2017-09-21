// JavaScript source code
$("[data-toggle=popover]").popover();

function createAlert(container_id, alert_type, message)
{
    if (alert_type == 'danger') {
        var strong_phrase = 'Oh snap!';
    }
    else if (alert_type == 'warning') {
        var strong_phrase = 'Holy guacamole!';
    }
    else if (alert_type == 'success')
    {
        var strong_phrase = 'Well done!';
    }
    $('#' + container_id).append('<div class="alert alert-' + alert_type + ' alert-dismissible" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><strong>' + strong_phrase + '</strong> ' + message + '</div>');
}

function createParagraph(container_id, class_attribute, text) {
    $('#' + container_id).append('<p class="' + class_attribute + '">' + text + '</p>');
}

//function toggleCode() {
//    var modal_id = $('')
//    $('#' + modal_id + ' pre').toggle();
//}