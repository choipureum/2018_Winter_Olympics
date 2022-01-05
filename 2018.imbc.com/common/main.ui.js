var now = new Date();
var then = new Date("Feb 10,2018"); 
var gap = then.getTime() - now.getTime();
gap = Math.floor(gap / (1000 * 60 * 60 * 24));


$(document).ready(function () {
        //setMainList();
        hotData();
        hotSlider();
        //itemsList();
        gameList();
        
        if(gap<10){
            $("#timer .count").prepend('0'+gap);
        }else{
            $("#timer .count").prepend(gap);
        }

});

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

function gameList(){
    var rakuten = $('.game-wrap');
	var rolling_items = rakuten.find('.game-area');
	var btn_prev = rolling_items.find('.btn-box .prev');
	var btn_next = rolling_items.find('.btn-box .next');
	var item = rolling_items.find('.slide');
	var list = item.find('>li');
	var list_len = list.length;
	var m = parseFloat(list.css('width'));
	var n = parseFloat(list.css('margin-right'));
	var viewing = 9;
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

function setMainList() {
    $.ajax({
        type: "get",
        url: "http://http://buyimbc24.cafe24.com/gong/chang/pc/common/test.js",
        //dataType: "json",
        success: function (data) {

            var ijstrHtml = [];
            var ccnt = data.Jlist.List.length;
            if (ccnt > 3) ccnt = 3;
            for (var j = 0; j < ccnt; j++) {
                ijstrHtml.push('<li>');
                ijstrHtml.push('<a href="/vod/vod.aspx?broid=' + data.Ilist.List[i].BroadcastID + '&itemid=' + data.Ilist.List[i].itemid + '">');
                ijstrHtml.push('<div class="img"><img src="' + data.Ilist.List[i].ImgUrl_Big + '" alt="'+data.Ilist.List[i].ContentTitle+'" /></div>');
                ijstrHtml.push('<div class="txt-wrap">');
                ijstrHtml.push('<p class="title ellipsis2">' + data.Ilist.List[i].ContentTitle + '</p>');
                ijstrHtml.push('<p class="num">' + data.Ilist.List[i].HitCount + '</p></div></a></li>');
            }

            $(".vod-list").html('');
            $(".vod-list").append(ijstrHtml.join(''));

            //많이 본 뉴스
            var lstrHtml = [];
            for (var l = 0; l < data.Llist.length; l++) {
                if (data.Llist[l].Opt == "E") {
                    lstrHtml.push('<li><a href="/api/gateNews.aspx?o=' + data.Llist[l].Opt + '&i=' + data.Llist[l].Idx + '&u=' + data.Llist[l].Link + '" >' + (l + 1) + '. ' + data.Llist[l].Title + '</a></li>');
                } else {
                    lstrHtml.push('<li><a href="/api/gateNews.aspx?o=' + data.Llist[l].Opt + '&i=' + data.Llist[l].Idx + '&u=' + data.Llist[l].Link + '" target="_blank">' + (l + 1) + '. ' + data.Llist[l].Title + '</a></li>');
                }
            }

            $("#l_list").html('');
            $("#l_list").append(lstrHtml.join(''));


            var mnstrHtml = [];

            for (var n = 0; n < data.Nlist.length; n++) {

                if (data.Nlist[n].Nickname == "IMNEWS") {
                    mnstrHtml.push('<li>');
                    mnstrHtml.push('<a href="/api/gateNews.aspx?o=I&i=' + data.Nlist[n].Idx + '&u=' + data.Nlist[n].OrgUrl + '" target="_blank">');
                    mnstrHtml.push('<img src="' + data.Nlist[n].ImgUrl + '" alt="' + data.Nlist[n].Title + '" class="thumnail-content" width="250" onerror="this.src=\'http://rio2016.imbc.com/img/img-default.jpg\'" />');
                    mnstrHtml.push('<p class="text">' + data.Nlist[n].Title + '</p>');
                    mnstrHtml.push('<span class="date">' + data.Nlist[n].PublicationDate + '</span> </a></li>');
                } else {
                    mnstrHtml.push('<li class="type-square">');
                    mnstrHtml.push('<a href="/api/gateNews.aspx?o=E&i=' + data.Nlist[n].Idx + '&u=http://rio2016.imbc.com/news/view.aspx?idx=' + data.Nlist[n].Idx + '" >');
                    mnstrHtml.push('<img src="http://talkimg.imbc.com/TVianUpload/TVian/TViews/image/' + data.Nlist[n].ImgUrl + '" alt="' + data.Nlist[n].Title + '" class="thumnail-content" width="250" onerror="this.src=\'http://rio2016.imbc.com/img/img-default.jpg\'" />');
                    mnstrHtml.push('<p class="text">' + data.Nlist[n].Title + '</p>');
                }
            }

            $("#m_n_list").html('');
            $("#m_n_list").append(mnstrHtml.join(''));


            var hstrHtml = [];

            if (data.Hlist.Gold == "0" && data.Hlist.Silver == "0" && data.Hlist.Bronze == "0") {
                hstrHtml.push('<a href="http://rio2016.imbc.com/event/" class="banner"><img src="img/banner-rio.png" alt="리우가요제 - 리우올림픽에 출전하는 선수들에게 힘을 모아 주세요! 지금, 바로 참여하기" /></a>');
            } else {

                hstrHtml.push('<h2>대한민국 종합 ' + data.Hlist.Rank + '위</h2>');
                hstrHtml.push('<div class="medal">');
                hstrHtml.push('<span><img src="img/img-gold.png" alt="금메달"><span class="count">' + data.Hlist.Gold + '</span></span>');
                hstrHtml.push('<span><img src="img/img-silver.png" alt="은메달"><span class="count">' + data.Hlist.Silver + '</span></span>');
                hstrHtml.push('<span><img src="img/img-bronze.png" alt="동메달"><span class="count">' + data.Hlist.Bronze + '</span></span>');
                hstrHtml.push('</div>');
                hstrHtml.push('<a href="/medal/medal.aspx" class="more"><span class="blind">자세히 보기</span></a>');
            }
            $("#h_list").html('');
            $("#h_list").append(hstrHtml.join(''));
        },
        error: function (request, status, error) {
          //  alert("에러"+error);
        }
    });
}
