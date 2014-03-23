
$(document).ready(function () {
    jQuery.support.cors = true;
    // $('#startDate').change(function () { $('#UKPrice').focus(); });
   
    $('#theCarousel').carousel();

});


function NullifyObject(obj) {
    if (obj.ISBN13 === "")
        obj.ISBN13 = null;
    if (obj.title === "")
        obj.title = null;
    if (obj.author === "")
        obj.author = null;

    return obj;
}

function showMessage(isVisible) {
    if (isVisible) {
        $('#dialog-confirm').dialog('open');
    }
    else {
        $('#dialog-confirm').dialog('close');
    }
}















//function assert(value,desc) {

//    var li = document.createElement("li");
//    li.className = value ? "pass" : "fail";
//    li.appendChild(document.createTextNode(desc));
//    document.getElementById("results").appendChild(li);

//}


//var things = function () {

//    return 'The thing function';
    
//}

//console.log(things());


//var ninja = {

//    yell: function yell(n) {
//        return n > 0 ? yell(n - 1) + 'a' : 'hiy';
//    }
//}

//assert(ninja.yell(4) == 'hiyaaaa', 'Works as we expect it to!');

//assert(ninja.yell(4) == 'hiyaaa', 'Ahh Man this failed!');