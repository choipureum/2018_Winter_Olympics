$(window).on({
	load : function() {
		loadHeader();
		loadNavi();
		loadMenu();
		//scrollNav();
		scrollMenu();
		loadsns();
		if($('.main').length) {
			visualLoad();
			loadDday();
			 var swiper = new Swiper('.swiper-container', {
		      slidesPerView: 'auto',
		      spaceBetween: 7,
		      loop: true,
		      slideToClickedSlide: true,
		      nextButton: '.swiper-button-next',
		       pagination: '.swiper-pagination'
		    });
			
		};
		if($('.sub .vod').length) {
			 var swiper = new Swiper('.swiper-container', {
		      slidesPerView: 1,
		      loop: true,
		      slideToClickedSlide: true,
		      nextButton: '.swiper-button-next',
		       pagination: '.swiper-pagination'
		    });
		};
		if($('.sub-about').length) {
			 itemSlide();
		};
		if($('.sub-news').length){
			sortTab();
		}
	},
    resize : function() {
    },
    orientationchange : function() {
    }
});

//visual ui
function visualLoad() {
    var innerArticle = '';
      for (var i = 0; i < hotIssue.length-1; i++) {
          var item = hotIssue[i];
          innerArticle
          +='<div class="swiper-slide">\
                   <a href='+item.mUrl+'><span class="img"><img src='+item.img+' alt=""></span><p class="txt ellipsis">'+item.title+'</p>\
                   </a>\
               </div>';
      }
      $('.main .swiper-wrapper').append(innerArticle);

  }
function scrollMenu(){
	$('.btn_menu').click(function(){
		$("body").css({overflow:'hidden'}).bind('touchmove', function(e){e.preventDefault()});
		$('.left_menu').show();
		$('.bg_box').show();
		$('.btn_close').show();
	});
	$('.btn_close, .bg_box').click(function(){
		$("body").css({overflow:'visible'}).unbind('touchmove');
		$('.left_menu').hide();
		$('.bg_box').hide();
		$('.btn_close').hide();
		$('.dropdown').hide();
		$('.depth1.sub').removeClass('on');
	})
	//sub slide
	var list = $('.depth1.sub');
	$(list).unbind('click').click(function(){
		if($(this).hasClass('on')) {
			$(this).removeClass('on');
			$(this).next().slideUp();
		}else{
			$('.dropdown').slideUp();
			$(list).removeClass('on');
			$(this).addClass('on');
			$(this).next().slideDown();
		}
	})

}
function scrollNav() {
	var w = window.innerWidth||document.documentElement.clientWidth||document.body.clientWidth;
	var scroll;
		var list = document.getElementById("navi");
		if (list) {
			scroll = new IScroll('#navi', { scrollX: true, scrollY: false, mouseWheel: true, click:true });
			list.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);
		}
		var position = -parseInt($(".nav ul li").filter(".on").offset().left);
		var width = w-$(".nav ul").width();
		if (position<width) {
			scroll.scrollTo(width,0);
		}
}
function itemSlide(){
	var items = $('.items-list li .pic');
	$(items).unbind('click').click(function(){
		if($(this).parent('li').hasClass('on')) {
			$(this).parent('li').removeClass('on');
			$(this).next().slideUp();
		}else{
			$(this).next().slideUp();
			$(this).parent('li').addClass('on');
			$(this).next().slideDown();
		}
	})
}
//news tab menu
var sortTab = function () {
    //$('.tab1').addClass('on');
    $('.tab').each(function (index) {
        $(this).click(function () {
            $('.tab').removeClass('on');
            $(this).addClass('on');
        });
    });
}