

$(document).ready(function () {
    
     var bodyClass = $('body').attr('class').split('ui-state-')[1];
    var a = $('.nav-'+ bodyClass).children("a").addClass('on');
    $('.nav-' + bodyClass).children("a").addClass('on');
    
    if ($('.container.items').length) {
        itemsList();
        itemsSlide();
    }
    
    if($(".container.vod").length){
        sns(699);
        hotClipSlide();
        itemSelect();
    }
    if($(".container.news").length){
        sns(882);
    }
    if($(".ui-state-allschedule").length){
        sns(882);
        schDate();
    }
    if($(".ui-state-schedule").length){
        sns(882);
        schDate2();
    }
    if($(".ui-state-medal").length){
        sns(935);
       vodGlory();
    }
    if($(".ui-state-vr").length){
        sns(717);
    }
    if($(".ui-state-vrLive").length){
        sns(1326);
    }
});


function itemsSlide() {
    var obj = $('.game-wrap');
    var rolling_items = obj.find('.game-area');
    var btn_prev = rolling_items.find('.btn-box .prev');
    var btn_next = rolling_items.find('.btn-box .next');
    var item = rolling_items.find('.slide');
    var list = item.find('>li');
    var list_len = list.length;
    var m = parseFloat(list.css('width'));
    var n = parseFloat(list.css('margin-right'));
    var viewing = 8;
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


    var url = window.location.href.split("/");
    var urlLink = url[url.length-1];
    var urlName = url[url.length-1].split('index.html#items')[1];

    if(urlLink=='index.html'){
        $(".game-area li.tab01").addClass("on");
        $("#items01").show();

    }else{
        $(".game-area li").removeClass("on");
        if(urlName>08){
             $('.game-area').find('li.tab'+urlName).addClass('on');
           nextAction();
        }else{
             $('.game-area').find('li.tab'+urlName).addClass('on');
        }
        $(".item-detail").hide();
        $(".item-detail#items"+urlName).show();
    }


    $(".game-area li").on("click",function(e){
        e.preventDefault();
        var target = $(this).children("a").attr("href");
        $(".game-area li").removeClass("on");
        $(this).addClass("on");
        $(".item-detail").hide();
        $(target).show();
   });
}

function sns(height) {
	var facebook = '<div class="fb-page" data-href="https://www.facebook.com/mbcolympics/" data-tabs="timeline" data-width="250" data-height="'+height+'" data-small-header="true" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="false"><blockquote cite="http://www.facebook.com/mbcolympics" class="fb-xfbml-parse-ignore"><a href="http://www.facebook.com/mbcolympics">MBC</a></blockquote></div>';
	$("#snsArea").append(facebook);
}

function schDate(){
    var schNav ='';
    schNav+='<li><span class="icon date1">8 목</span></li>'
                +'<li><span class="icon date2">9 금</span></li>'
                +'<li><span class="icon date3">10 토</span></li>'
                +'<li><span class="icon date4">11 일</span></li>'
                +'<li><span class="icon date5">12 월</span></li>'
                +'<li><span class="icon date6">13 화</span></li>'
                +'<li><span class="icon date7">14 수</span></li>'
                +'<li><span class="icon date8">15 목</span></li>'
                +'<li><span class="icon date9">16 금</span></li>'
                +'<li><span class="icon date10">17 토</span></li>'
                +'<li><span class="icon date11">18 일</span></li>'
                +'<li><span class="icon date12">19 월</span></li>'
                +'<li><span class="icon date13">20 화</span></li>'
                +'<li><span class="icon date14">21 수</span></li>'
                +'<li><span class="icon date15">22 목</span></li>'
                +'<li><span class="icon date16">23 금</span></li>'
                +'<li><span class="icon date17">24 토</span></li>'
                +'<li><span class="icon date18">25 일</span></li>';
    $("#schDate").append(schNav);
    
    var obj = $('.sch-wrap');
    var rolling_items = obj.find('.sch-date');
    var btn_prev = obj.find('.sch-top .prev');
    var btn_next = obj.find('.sch-top .next');
    var item = rolling_items.find('#schDate');
    var list = item.find('li');
    var list_len = list.length;
    var m = parseFloat(list.css('width'));
    var n = parseFloat(list.css('margin-right'));
    var viewing =9;
    var cnt = 0;
    var x = (m+n)*viewing;
    var y = Math.ceil(list_len/viewing);//2
    var z = x*y;
    var tableArea = $(".table-area");
    var tableGroup = $(".table-area").find(".sch-group");
    
    tableArea.width(tableGroup.width()*tableGroup.length);
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
            tableArea.css('margin-left',0);
            cnt = 0;
        } else {
            var x1 = parseFloat(item.css('margin-left'));
            var x2 = parseFloat(tableArea.css('margin-left'));
            var y1 = x1-x;
            var y2 = x2- tableGroup.width();
            item.css('margin-left',y1+'px');
            tableArea.css('margin-left',y2+'px');
            cnt++;
        }
    }
    function prevAction() {
        if ( cnt == 0 ) {
            item.css('margin-left',-z+x+'px');
            tableArea.css('margin-left',-(tableGroup.width()*y)+tableGroup.width()+'px');
            cnt = y-1;	
        } else {
            var x1 = parseFloat(item.css('margin-left'));
            var x2 = parseFloat(tableArea.css('margin-left'));
            var y1 = x1+x;
            var y2 = x2+tableGroup.width();
            item.css('margin-left',y1+'px');
            tableArea.css('margin-left',y2+'px');
            cnt--;
        }
    }
}

function schDate2(){
    var schNav ='';
    schNav+='<li class="dt1"><a href=""><span class="icon date1">8 목</span></a></li>'
                +'<li class="dt2"><a href=""><span class="icon date2">9 금</span></a></li>'
                +'<li class="dt3"><a href=""><span class="icon date3">10 토</span></a></li>'
                +'<li class="dt4"><a href=""><span class="icon date4">11 일</span></a></li>'
                +'<li class="dt5"><a href=""><span class="icon date5">12 월</span></a></li>'
                +'<li class="dt6"><a href=""><span class="icon date6">13 화</span></a></li>'
                +'<li class="dt7"><a href=""><span class="icon date7">14 수</span></a></li>'
                +'<li class="dt8"><a href=""><span class="icon date8">15 목</span></a></li>'
                +'<li class="dt9"><a href=""><span class="icon date9">16 금</span></a></li>'
                +'<li class="dt10 on" ><a href=""><span class="icon date10">17 토</span></a></li>'
                +'<li class="dt11 "><a href=""><span class="icon date11">18 일</span></a></li>'
                +'<li class="dt12" ><a href=""><span class="icon date12">19 월</span></a></li>'
                +'<li class="dt13"><a href=""><span class="icon date13">20 화</span></a></li>'
                +'<li class="dt14"><a href=""><span class="icon date14">21 수</span></a></li>'
                +'<li class="dt15"><a href=""><span class="icon date15">22 목</span></a></li>'
                +'<li class="dt16"><a href=""><span class="icon date16">23 금</span></a></li>'
                +'<li class="dt17"><a href=""><span class="icon date17">24 토</span></a></li>'
                +'<li class="dt18"><a href=""><span class="icon date18">25 일</span></a></li>';
    $("#schDate").append(schNav);
    
    var obj = $('.sch-wrap');
    var rolling_items = obj.find('.sch-date');
    var btn_prev = obj.find('.sch-top .prev');
    var btn_next = obj.find('.sch-top .next');
    var item = rolling_items.find('#schDate');
    var list = item.find('li');
    var list_len = list.length;
    var m = parseFloat(list.css('width'));
    var n = parseFloat(list.css('margin-right'));
    var viewing =10;
    var cnt = 0;
    var x = (m+n)*viewing;
    var y = Math.ceil(list_len/viewing);//2
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

function hotClipSlide(){
    var obj = $(".hot-area"),
        btnHotclipPrev = obj.find('.btn-box .prev'),
	    btnHotclipNext = obj.find('.btn-box .next'),
        itemsHive = $('.hot-slide'),
	    itemsWrap = itemsHive.find('ul'),
	    showingList = 2,
	    vodCnt = 0,
 	    m_itemsWrap = '',
	    itemsHotclip = '',
	    h_itemHotclip = '',
	    len_itemHotclip = '',
	    oneShowingH = '',
	    showReNum = '',
	    item = itemsWrap.children('li'),
	    page = Math.ceil(item.length/2);
    
	obj.find('.slide-num').html('<strong>1</strong>/'+page);

	btnHotclipPrev.on('click',function(){
		m_itemsWrap = parseInt(itemsWrap.css('margin-top'));
		itemsHotclip = itemsWrap.find('li');
		h_itemHotclip = parseInt(itemsHotclip.css('height'))+10;
		len_itemHotclip = itemsHotclip.length;
		oneShowingH = h_itemHotclip*showingList;
		showReNum  = Math.ceil(len_itemHotclip/showingList);

		if (vodCnt == 0) {
			return false;
		} else {
			itemsWrap.css('margin-top',m_itemsWrap+oneShowingH+'px');
			vodCnt--;
		}
		$('.slide-num strong').text(vodCnt+1);
	});
	btnHotclipNext.on('click',function(){
		m_itemsWrap = parseInt(itemsWrap.css('margin-top'));
		itemsHotclip = itemsWrap.find('li');
		h_itemHotclip = parseInt(itemsHotclip.css('height'))+10;
		len_itemHotclip = itemsHotclip.length;
		oneShowingH = h_itemHotclip*showingList;
		showReNum  = Math.ceil(len_itemHotclip/showingList);
		if (vodCnt == showReNum-1) {
			return false;
		} else {
			itemsWrap.css('margin-top',m_itemsWrap-oneShowingH+'px');
			vodCnt++;
		}
		$('.slide-num strong').text(vodCnt+1);
	});

}

function vodGlory(){
    var obj = $('.vod-rankTop');
    var rolling_items = obj.find('.glory-wrap');
    var btn_prev = obj.find('.prev');
    var btn_next = obj.find('.next');
    var item = rolling_items.find('.glory-area ul');
    var list = item.find('li');
    var list_len = list.length;
    var m = parseFloat(list.css('width'));
    var n = parseFloat(list.css('margin-right'));
    var viewing =3;
    var cnt = 0;
    var x = (m+n)*viewing;
    var y = Math.ceil(list_len/viewing);//2
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

function itemSelect(){
    var vodSelect = $('.btn-select');
	var vodItems = $('.item-select .scroll');
	var vodMenu = $('.vod-menu');
	var vodMenuItems = $('.vod-menu');
    
    vodSelect.on('click',function(){
		if ($(this).next().css('display')=='block') {
			$(this).next().css('display','none');
		} else {
			$(this).next().css('display','block');
		}
	});
	/* 영상페이지 종목선택 리스트 */
	vodItems.find('a').on('click',function(e) {
		var itemTxt = $(this).text();
		$('.btn-select').text(itemTxt);
		$('.btn-select').next().css('display','none');
		e.preventDefault();
	});
    
	vodMenuItems.find('a').on('click',function(){
		vodSelect.text('종목선택');
		vodSelect.next().css('display','none');
	});
    
}