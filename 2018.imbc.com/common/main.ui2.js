
$(document).ready(function () {
        sns(292);
        hotData();
        hotSlider();
        broadSlide();
        broadRolling();
        var instaItem = '';
        for (i=0; i<instaData.length-1; i++) {
            instaItem+= '<li><a href="'+instaData[i].url+'" target="_blank">'
                    +    '<img src="'+instaData[i].img+'" alt="">'
                    +    '<div class="txt-wrap">'
                    +        '<span class="img"><img src="'+instaData[i].thum+'" alt=""></span>'
                    +        '<span class="title ellipsis">'+instaData[i].title+'</span>'
                    +    '</div>'
                    +'</a></li>'
        }
        $('#instaArea').html(instaItem);

});


function broadRolling(){
    var obj= $(".noti-right>.slide"),
          list = obj.children('p'),
          listNum = list.length,
          ht = list.height(),
          slideTime,
          isMoving = true,
          isHold = false,
          speed = 600,
          timing = 3000,
          i = 0,
          n=0;
    
    start();
    auto(); 
    
    function start(){		
        timer = setInterval(function(){				 
            i++;
            $(".noti-right>.slide").children("p").filter(':last').after($(".noti-right>.slide").children("p").first());
        },timing);
    }  
    
    function end(){
        clearInterval(timer);
    }
    
    function auto(){
        list.hover(function(){
            end();
        },function(){
            start();
        });
    }

}

function hotData() {
	var item = '';
	for (i=0; i<hotIssue.length-1; i++) {
		item+= '<a href="'+hotIssue[i].url+'" class="on">'
                +    '<div class="vod-area"><img src="'+hotIssue[i].img+'" alt=""></div>'
                +    '<div class="txt-wrap">'
                +        '<p class="title ellipsis3">'+hotIssue[i].title+'</p>'
                +        '<p class="txt">'+hotIssue[i].txt+' </p>'
                +    '</div>'
                +'</a>'
	}
	$('#hotArea>.slide').html(item);
}

function hotSlider() {
    var $slideName= $(".hot-area>.slide"),
          $list = $slideName.children('a'),
          $listNum = $list.length,
          $width = $list.width(),
          $dot = $('.hot-wrap .indicator .btn'),
          $playBtn = $('.ico-playstop'),
          slideTime,
          isMoving = true,
          isHold = false,
          n = 0;
    
    creatDot();
    $('.slide-num').append('<strong>1</strong>/'+$listNum);
    
    function change() {
        $list.eq(n).addClass('on').siblings('a').removeClass('on');
        $('.indicator .indi').eq(n).addClass('on').siblings('.indi').removeClass('on');
    };

    function next() {
        n++;
        if (n == $listNum) {
            n = 0;
        };
        change();
        paging(n);
    };

    function prev() {
        if (n == 0) {
            n = $listNum;
        };
        n--;
        change();
        paging(n);
    };

    slideTime = setInterval(next, 4000);

    $playBtn.click(function () {
        $(this).toggleClass('ico-play');
        if (isMoving) {
            stop();
            isHold = true;
        } else {
            play();
            isHold = false;
        }
    });

    function play() {
        slideTime = setInterval(next, 3000);
        isMoving = true;
    }

    function stop() {
        clearInterval(slideTime);
        isMoving = false;
    }

    $(".hot-wrap .btn-box .prev").bind({
        mouseenter: function () {
            stop();
        },
        mouseleave: function () {
            if (!isHold) {
                play();
            }
        },
        click: function () {
            prev();
        }
    });
    $(".hot-wrap .btn-box .next").bind({
        mouseenter: function () {
            stop();
        },
        mouseleave: function () {
            if (!isHold) {
                play();
            }
        },
        click: function () {
            next();
        }
    });
    $('.indicator .btn').bind({
        'click': function () {
            var onNum = $(this).parent().index();
            change();
            n = onNum;
        },
        'focusin': function () {
            stop();
            var onNum = $(this).parent().index();
            change();
            n = onNum;
        },
        'mouseenter': function () {
            stop();
        },
        'mouseleave': function () {
            if (!isHold) {
                play();
            }
        }
    });

    function creatDot() {
        for (var i = 1; i <= $listNum + 1; i++) {
            var $item;
            $('.indicator .indi-area').append($item);
            if (i == 1) {
                $item = '<div class="indi on"><span class="vline"></span><input type="button" class="btn" title="' + i + '번째 HOTISSUE 보러가기"/></div>';
            } else {
                $item = '<div class="indi"><span class="vline"></span><input type="button" class="btn" title="' + i +'번째 HOTISSUE 보러가기"/></div>';
            }
        }
    }
    
    function paging(i) {
		$('.slide-num strong').text(i+1);
	}

}

function sns(height) {
	var facebook = '<div class="fb-page" data-href="https://www.facebook.com/mbcolympics/" data-tabs="timeline" data-width="250" data-height="'+height+'" data-small-header="true" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="false"><blockquote cite="http://www.facebook.com/mbcolympics" class="fb-xfbml-parse-ignore"><a href="http://www.facebook.com/mbcolympics">MBC</a></blockquote></div>';
	$("#snsArea").append(facebook);
}


function broadSlide(){
    var obj = $(".broad-wrap");
	var rolling_items = obj.find(".broad-area");
	var btn_prev = rolling_items.find('.prev');
	var btn_next = rolling_items.find('.next');
	var item = rolling_items.find('.slide');
	var list = item.find('>li');
	var list_len = list.length;
	var m = parseFloat(list.css('width'));
	var n = parseFloat(list.css('margin-right'));
	var viewing = 4;
	var cnt = 0;
	var x = (m+n)*viewing;
	var y = Math.ceil(list_len/viewing);
	var z = x*y;

	item.css('width',z+'px');

	btn_next.on('click',function(){
		nextAction();
	});

	btn_prev.on('click',function(){
		prevAction();
	});
	function nextAction() {

		if ( cnt == y-1 ) {
			item.css('margin-left',0);
			cnt = 0;
		} else {
			var x1 = parseFloat(item.css('margin-left'));
			var y1 = x1-x;
			item.css('margin-left',y1+'px');
			cnt++;
		}
	}
	function prevAction() {
		if ( cnt == 0 ) {
			item.css('margin-left',-z+x+'px');
			cnt = y-1;	
		} else {
			var x1 = parseFloat(item.css('margin-left'));
			var y1 = x1+x;
			item.css('margin-left',y1+'px');
			cnt--;
		}
	}
}
