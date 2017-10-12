var websiteNumber = $('.website').text();
var clientNumber = $('.client').text();
var developerNumber = $('.developer').text();
var awardsNumber = $('.awards').text();

$({numberValue: websiteNumber}).animate({numberValue: 150}, {
    duration: 3000,
    easing: 'linear',
    step: function() { 
        $('.website').text(Math.ceil(this.numberValue)); 
    }
});

$({numberValue: clientNumber}).animate({numberValue: 250}, {
    duration: 3000,
    easing: 'linear',
    step: function() { 
        $('.client').text(Math.ceil(this.numberValue)); 
    }
});

$({numberValue: developerNumber}).animate({numberValue: 24}, {
    duration: 3000,
    easing: 'linear',
    step: function() { 
        $('.developer').text(Math.ceil(this.numberValue)); 
    }
});

$({numberValue: awardsNumber}).animate({numberValue: 260}, {
    duration: 3000,
    easing: 'linear',
    step: function() { 
        $('.awards').text(Math.ceil(this.numberValue)); 
    }
});


/***********************/
// $(".all-testimonial").owlCarousel({
//             autoPlay: false, 
//             slideSpeed:2000,
//             pagination:false,
//             nav:true, 
//             dots:true, 
//             items :3,
//             navText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
//             itemsDesktop : [1199,2],
//             itemsDesktopSmall : [980,2],
//             itemsTablet: [768,1],
//             itemsTablet: [767,1],
//             itemsMobile : [479,1],
//           }); 
