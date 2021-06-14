$(function(){

    $('.main-menu nav > span').click(function(){
      $('.main-menu nav > ul').slideToggle();
    });

});

$(document).load($(window).bind("resize", checkPosition));

function checkPosition() {
    if (window.matchMedia('(max-width: 991px)').matches) {
    	$('.main-menu nav > ul').css('display','none');
    } else {
    	$('.main-menu nav > ul').css('display','block');
    }
}

function checkMenu() {
    var windowSize = $(window).width();
    if(windowSize <= 991)
    {
        $(".caret-icon").remove();
        $('.main-menu nav > ul > li').each(function(){
            if($(this).find('ul').length > 0) {
                $(this).append("<span class='caret-icon'><i class='zmdi zmdi-chevron-down'></i></span>");
            } 
        });
        $('.main-menu nav > ul > li > .caret-icon').click(function(){
            $(this).parent().find('ul').slideToggle();
        });

    } else {
        
        $('.main-menu nav > ul > li').hover(
            function() {
                $(this).find('ul').fadeIn('fast');
            },
            function(){
                $(this).find('ul').fadeOut('fast');
            }
        );

    }
}

checkMenu();

$(window).resize(function(event) { 
    event.preventDefault();
    checkMenu();
});
