
/* -------------------------------- 

signup and signin

-------------------------------- */
$(".email-signup").hide();
$("#signup-box-link").click(function () {
    $(".email-login").fadeOut(100);
    $(".email-signup").delay(100).fadeIn(100);
    $("#login-box-link").removeClass("active");
    $("#signup-box-link").addClass("active");
});
$("#login-box-link").click(function () {
    $(".email-login").delay(100).fadeIn(100);;
    $(".email-signup").fadeOut(100);
    $("#login-box-link").addClass("active");
    $("#signup-box-link").removeClass("active");
});

/* -------------------------------- 

navbar

-------------------------------- */

function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}


/* -------------------------------- 

read More

-------------------------------- */


$('.hiding').addClass('hide-me');

$('.read-more').on('click', function () {
    $(this).addClass('hide-me');
    $('.hiding').toggle();
    $('.dots').toggle();
});
$('.show-less').on('click', function () {
    $(this).removeClass('hide-me');
    $('.read-more').removeClass('hide-me');
    $('.hiding').toggle();
    $('.dots').toggle();
});



/* -------------------------------- 

like button

-------------------------------- */


$('.fa-heart').on('click', function (event, count) {
    event.preventDefault();

    var $this = $(this),
        count = $this.attr('data-count'),
        active = $this.hasClass('active'),
        multiple = $this.hasClass('multiple-count');


    $.fn.noop = $.noop;
    $this.attr('data-count', !active || multiple ? ++count : --count)[multiple ? 'noop' : 'toggleClass']('active');

});

/* -------------------------------- 

Dyanmic TAgs

-------------------------------- */

function openCity(evt, cityName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("city");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-red", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " w3-red";
}

/* -------------------------------- 

Dyanmic TAgs

-------------------------------- */


(function ($, document) {

    // get tallest tab__content element
    let height = -1;

    $('.tab__content').each(function () {
        height = height > $(this).outerHeight() ? height : $(this).outerHeight();
        $(this).css('position', 'absolute');
    });

    // set height of tabs + top offset
    $('[data-tabs]').css('min-height', height + 40 + 'px');

}(jQuery, document));

