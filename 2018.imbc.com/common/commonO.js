var programData = {
    name: '2018 평창 동계올림픽',
    prgCode: '1003367100000100000', //
    home: 'http://2018.imbc.com/',
    imgUrl: 'http://2018.imbc.com/images/'
}

var navData = {
    "title": ['대회소개', '영상', '뉴스', '일정'],
    "url": ['about', 'vod', 'news', 'allschedule']
}

var snsLink ={
    facebook :'https://www.facebook.com/mbcolympics',
    twitter:'https://www.twitter.com/withmbc',
    insta:'https://www.instagram.com/mbcolympics'
}

$(document).ready(function () {

    var headerHtml = String();
    if ($('.main').length) {
        headerHtml = '<div class="top-area">'
                                +'<h2 class="emblem"><span class="icon ico-emblem">PyeongChang 2018TM</span></h2>'
                                +'<div class="date">2018.02.09~25</div>'
                                +'<div class="timer" id="timer"><span class="count"></span></div>'
                                +'<p class="open-day">개막식 2018.02.09 PM08:00</p>'
                            +'</div>'
                            +'<div class="sns-link">'
                                +'<ul>'
                                    +'<li class="sns-face"><a href="'+snsLink.facebook+'" target="_blank">페이스북</a></li>'
                                    +'<li class="sns-twit"><a href="'+snsLink.twitter+'" target="_blank">트위터</a></li>'
                                    +'<li class="sns-insta"><a href="'+snsLink.insta+'" target="_blank">인스타그램</a></li>'
                                +'</ul>'
                            +'</div>'
                            +'<div class="top-ban">'
                                +'<a href="http://2018.imbc.com/allschedule/index.html">PyeongChang 2018™<br>경기일정 자세히보기</a>'
                            +'</div>';
                    $("#header").prepend(headerHtml);
    } else {
        headerHtml = '<div class="top-area">'
                                +'<h2  class="emblem"><a href="'+programData.home+'"><span class="icon ico-emblem">PyeongChang 2018TM</span></a></h2>'
                                +'<div class="date">2018.02.09~25</div>'
                            +'</div>'
                            +'<div class="sns-link">'
                                +'<ul>'
                                    +'<li class="sns-face"><a href="'+snsLink.facebook+'" target="_blank">페이스북</a></li>'
                                    +'<li class="sns-twit"><a href="'+snsLink.twitter+'" target="_blank">트위터</a></li>'
                                    +'<li class="sns-insta"><a href="'+snsLink.insta+'" target="_blank">인스타그램</a></li>'
                                +'</ul>'
                            +'</div>'
                            +'<div class="top-ban">'
                                +'<a href="http://2018.imbc.com/allschedule/index.html">PyeongChang 2018™<br>경기일정 자세히보기</a>'
                            +'</div>';
        $("#header").prepend(headerHtml);
    }
    
    
    
    var navHtml = '';
        navHtml += '<h3 class="tit-nav">' + programData.name + ' 메뉴</h3>';
        navHtml += '<ul class="nav">';
        for (var i = 0; i < navData.title.length; i++) {
            navHtml += '<li class="nav-'+ navData.url[i] +'"><a href="' + programData.home + navData.url[i] + '">' + navData.title[i] + '</a></li>';
        }
        navHtml += '</ul>';
        $('#navWrap').append(navHtml);
    
    var footerHtml ='';
        footerHtml+='<p>본 콘텐츠의 저작권은 MBC에 있습니다.<br>Copyright(c) Since 1996, MBC&amp;iMBC All rights reserved.</p>';
        $("#footer").append(footerHtml);
        
});

function itemsList(){
    var gate ='';
    if($(".main").length){
        gate = 'items/index.html';
        
    }else{
        gate ='';
        
    }
    var innerHtml ='';
    innerHtml = '<div class="game-area">'
                        +'<ul class="slide">'
                        +    '<li class="tab01"><a href="'+gate+'#items01"><span class="icon gam01"></span><p class="name">알파인 스키</p></a></li>'
                        +    '<li class="tab02"><a href="'+gate+'#items02"><span class="icon gam02"></span><p class="name">바이애슬론</p></a></li>'
                        +    '<li class="tab03"><a href="'+gate+'#items03"><span class="icon gam03"></span><p class="name">봅슬레이</p></a></li>'
                        +    '<li class="tab04"><a href="'+gate+'#items04"><span class="icon gam04"></span><p class="name">크로스컨트리<br>스키</p></a></li>'
                        +    '<li class="tab05"><a href="'+gate+'#items05"><span class="icon gam05"></span><p class="name">컬링</p></a></li>'
                        +    '<li class="tab06"><a href="'+gate+'#items06"><span class="icon gam06"></span><p class="name">피겨 스케이팅</p></a></li>'
                        +    '<li class="tab07"><a href="'+gate+'#items07"><span class="icon gam07"></span><p class="name">프리스타일 스키</p></a></li>'
                        +    '<li class="tab08"><a href="'+gate+'#items08"><span class="icon gam08"></span><p class="name">아이스 하키</p></a></li>'
                        +    '<li class="tab09"><a href="'+gate+'#items09"><span class="icon gam09"></span><p class="name">루지</p></a></li>'
                        +    '<li class="tab10"><a href="'+gate+'#items10"><span class="icon gam10"></span><p class="name">노르딕 복합</p></a></li>'
                        +    '<li class="tab11"><a href="'+gate+'#items11"><span class="icon gam11"></span><p class="name">쇼트트랙<br>스피드 스케이팅</p></a></li>'
                        +    '<li class="tab12"><a href="'+gate+'#items12"><span class="icon gam12"></span><p class="name">스컬레톤</p></a></li>'
                        +    '<li class="tab13"><a href="'+gate+'#items13"><span class="icon gam13"></span><p class="name">스키점프</p></a></li>'
                        +    '<li class="tab14"><a href="'+gate+'#items14"><span class="icon gam14"></span><p class="name">스노보드</p></a></li>'
                        +    '<li class="tab15"><a href="'+gate+'#items15"><span class="icon gam15"></span><p class="name">스피드 스케이팅</p></a></li>'
                        +'</ul>'
                        +'<div class="btn-box">'
                        +    '<button type="button" class="btn prev"><span class="icon">이전 종목 보기</span></button>'
                        +    '<button type="button" class="btn next"><span class="icon">다음 종목 보기</span></button>'
                        +'</div>'
                    +'</div>';
    $(".game-wrap").append(innerHtml);
    
}

//구글코드
var _gaq = _gaq || [];
(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-81416310-3', 'auto');
ga('send', 'pageview');