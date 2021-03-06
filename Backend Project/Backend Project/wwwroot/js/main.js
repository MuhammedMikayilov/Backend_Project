(function ($) {
"use strict";  
    
/*------------------------------------
	Sticky Menu 
--------------------------------------*/
 var windows = $(window);
    var stick = $(".header-sticky");
	windows.on('scroll',function() {    
		var scroll = windows.scrollTop();
		if (scroll < 5) {
			stick.removeClass("sticky");
		}else{
			stick.addClass("sticky");
		}
	});  
/*------------------------------------
	jQuery MeanMenu 
--------------------------------------*/
	$('.main-menu nav').meanmenu({
		meanScreenWidth: "767",
		meanMenuContainer: '.mobile-menu'
	});
    
    
    /* last  2 li child add class */
    $('ul.menu>li').slice(-2).addClass('last-elements');
/*------------------------------------
	Owl Carousel
--------------------------------------*/
    $('.slider-owl').owlCarousel({
        loop:true,
        nav:true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 2500,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });

    $('.partner-owl').owlCarousel({
        loop:true,
        nav:true,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });  

    $('.testimonial-owl').owlCarousel({
        loop:true,
        nav:true,
        navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });
/*------------------------------------
	Video Player
--------------------------------------*/
    $('.video-popup').magnificPopup({
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        zoom: {
            enabled: true,
        }
    });
    
    $('.image-popup').magnificPopup({
        type: 'image',
        gallery:{
            enabled:true
        }
    }); 
/*----------------------------
    Wow js active
------------------------------ */
    new WOW().init();
/*------------------------------------
	Scrollup
--------------------------------------*/
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });
/*------------------------------------
	Nicescroll
--------------------------------------*/
     $('body').scrollspy({ 
            target: '.navbar-collapse',
            offset: 95
        });
$(".notice-left").niceScroll({
            cursorcolor: "#EC1C23",
            cursorborder: "0px solid #fff",
            autohidemode: false,
            
        });

})(jQuery);	


//----Searching start----\\
$(document).ready(function () {
    //---- Ajax function start ----\\
    const ajaxFunction = (action) => {
        let pathname = window.location.pathname;
        let controller = pathname.substring(1, pathname.length)

        let inputVal = $(`#search-${action}`).val().trim();
        console.log("input", inputVal)
        if (inputVal !== "") {
            $(`#search-list-${action} div`).css("display", "none");
        }
        if (inputVal === "") {
            $(`#search-list-${action} div`).css("display", "block");
            $(`#search-list-${action} .searching`).remove();
            console.log("Action", action, "Class", $(`#search-list-${action}`))
        }
        console.log("test", inputVal)
        if (inputVal.length >= 0) {
            $.ajax({
                url: `/${controller}/Search?search=` + inputVal,
                type: "GET",
                success: function (res) {
                    $(`#search-list-${action}`).append(res)
                }
            })
        }
        console.log("window location", controller)
    }

    const ajaxHeaderSearch = (action) => {
        let path = window.location.pathname;
        let controller = path.substring(1, path.length)

        let inputVal = $('#search-header').val().trim();
        if (inputVal !== "") {
            $(`#search-list-${action} div`).css("display", "none");
        }
        if (inputVal === "") {
            $(`#search-list-${action} div`).css("display", "block");
            $(`#search-list-${action} .searching`).remove();
            console.log("Action", action, "Class", $(`#search-list-${action}`))
        }
        if (inputVal.length >= 0) {
            $.ajax({
                url: `/${controller}/Search?search=` + inputVal,
                type: "GET",
                success: function (res) {
                    $(`#search-list-${action}`).append(res)
                    console.log("action", action)
                    console.log("input:", inputVal);
                }
            })
        }
    }
    //---- Ajax function end----\\
    
    $(document).on('keyup', '#search-blg', function () {
        ajaxFunction('blg')
    })

    $(document).on('keyup', '#search-crs', function () {
        ajaxFunction('crs')
    })

    $(document).on('keyup', '#search-event', function () {
        ajaxFunction('event')
    })
    $(document).on('keyup', '#search-header', function () {
        let path = window.location.pathname;
        let pathname = path.substring(1, path.length)
        console.log("ppp", pathname)
        switch (pathname) {
            case 'Blog':
                ajaxHeaderSearch('blg')
                console.log("blg");
                break;
            case 'Course':
                ajaxHeaderSearch('crs')
                console.log("crs");
                break;
            case 'Event':
                ajaxHeaderSearch('event')
                console.log("event");
                break;
            case 'Teacher':
                ajaxHeaderSearch('teacher')
                console.log("teacher");
                break;
            default:
                "not found"
                break;
        }
    })

    //e.prevetDefault()
    $(document).on('click', '.disabled a', function (e) {
        e.preventDefault();
    })
    $(document).on('click', '#search-list-header', function (e) {
        e.preventDefault();
    })
})
//----Searching end----\\


//----Anime----\\
anime({
    targets: '.row svg',
    translateY: 10,
    autoplay: true,
    loop: true,
    easing: 'easeInOutSine',
    direction: 'alternate'
});

anime({
    targets: '#zero',
    translateX: 10,
    autoplay: true,
    loop: true,
    easing: 'easeInOutSine',
    direction: 'alternate',
    scale: [{ value: 1 }, { value: 1.4 }, { value: 1, delay: 250 }],
    rotateY: { value: '+=180', delay: 200 },
});


