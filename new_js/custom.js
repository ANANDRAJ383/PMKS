jQuery(document).ready(function () {
  jQuery("#bannerslider").owlCarousel({
      items: 1,
      itemsMobile: [599, 1],
      nav: false,
      navText: false,
      margin: 0,
      navigationText: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      responsiveClass: true,
      responsive: {
          0: {
              items: 1,
              nav: true,
              loop: true
          },
          600: {
              items: 1,
              nav: true,
              loop: true
          },
          1000: {
              items: 1,
              nav: true,
              loop: true
          }
      }
  });
  jQuery("#periodwise").owlCarousel({
      items: 5,
      itemsMobile: [599, 1],
      nav: true,
      navText: true,
      margin: 10,
      navigationText: true,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      responsiveClass: true,
      responsive: {
          0: {
              items: 1,
              nav: true,
              loop: true
          },
          600: {
              items: 1,
              nav: true,
              loop: true
          },
          1000: {
              items: 5,
              nav: true,
              loop: true
          }
      }
  });
  jQuery("#villagedashboard").owlCarousel({
      items: 6,
      itemsMobile: [599, 1],
      nav: false,
      navText: false,
      margin: 10,
      navigationText: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      responsiveClass: true,
      responsive: {
          0: {
              items: 1,
              nav: true,
              loop: true
          },
          600: {
              items: 1,
              nav: true,
              loop: true
          },
          1000: {
              items: 6,
              nav: false,
              loop: false
          }
      }
  });
  jQuery("#adhaarstatus").owlCarousel({
      items: 6,
      itemsMobile: [599, 1],
      nav: false,
      navText: false,
      margin: 10,
      navigationText: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      responsiveClass: true,
      responsive: {
          0: {
              items: 1,
              nav: true,
              loop: true
          },
          600: {
              items: 1,
              nav: true,
              loop: true
          },
          1000: {
              items: 6,
              nav: false,
              loop: false
          }
      }
  });
  jQuery("#adhaaronlineregistration").owlCarousel({
        items: 4,
        itemsMobile: [599, 1],
        nav: false,
        navText: false,
        margin: 10,
        navigationText: false,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: true,
                loop: true
            },
            600: {
                items: 1,
                nav: true,
                loop: true
            },
            1000: {
                items:4,
                nav: false,
                loop: false
            }
        }
    });
});
(function ($) {
  "use strict";
  jQuery('#mobile-menu').meanmenu({
      meanMenuContainer: '.mobile-menu',
      meanScreenWidth: "991"
  });
})(jQuery);