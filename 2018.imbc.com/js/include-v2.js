var data = {
    name : "2018 평창 동계올림픽 대회",
    home : "http://2018.imbc.com/m/",
    imgUrl : "http://2018.imbc.com/images/m/"   
}
//header
function loadHeader(){
var loadheader = '';
loadheader
+= '<h1 class="title"><a href="'+data.home+'">\
<span class="tit">'+data.name+'</span><span class="date">2018.02.09~25</span></a></h1><a href="http://m.imbc.com/" target="_blank"><h2 class="logo">MBC</h2></a><span class="btn_menu">메뉴 열기</span>';
$('header').append(loadheader);
}
//navi
function loadNavi(){
var loadnavi ='';
loadnavi
+= '<div class="nav">\
        <ul>\
            <li class="nav-main"><a href="'+data.home+'main/">홈</a></li>\
            <li class="nav-vod"><a href="'+data.home+'vod/">영상</a></li>\
            <li class="nav-vr"><a href="'+data.home+'vr/index.html">VR</a></li>\
            <li class="nav-news"><a href="'+data.home+'news/">뉴스</a></li>\
            <li class="nav-schedule"><a href="'+data.home+'schedule/all.html">일정/결과</a></li>\
            <li class="nav-medal"><a href="'+data.home+'medal/index.html">메달 순위</a></li>\
            <li class="nav-about"><a href="'+data.home+'about/index.html">대회 소개</a></li>\
        </ul>\
    </div>';
$('#navi').append(loadnavi);
//left nav on
if($('.main').length) {
    $('.nav-main').addClass('on');
    }
if($('.sub').length) {
 var bodyClass = $('#wrapper').attr('class').split('sub-')[1];
    $('.nav-' + bodyClass).addClass('on');
    }
}
function loadMenu(){
var loadMenu = '';
loadMenu
+='<div class="depth1"><a href="'+data.home+'main/" class="menu1">홈</a></div>\
        <div class="depth1"><a href="'+data.home+'vod/" class="menu3">영상</a></div>\
        <div class="depth1"><a href="'+data.home+'vr/" class="menu8">VR</a></div>\
        <div class="depth1"><a href="'+data.home+'news/" class="menu4">뉴스</a></div>\
        <div class="depth1"><a href="'+data.home+'schedule/all.html" class="menu5">일정/결과</a></div>\
        <div class="depth1"><a href="'+data.home+'medal/" class="menu6">메달 순위</a></div>\
        <div class="depth1 sub"><a href="#none" class="menu2">대회소개</a></div>\
        <ul class="dropdown">\
            <li><a href="'+data.home+'about/index.html">대회 개요</a></li>\
            <li><a href="'+data.home+'about/items.html">대회 종목</a></li>\
        </ul>';
    $('.left_menu').append(loadMenu);
    }
//sns
function loadsns(){
var loadsns = '';
loadsns
+= '<div class="link"><span><img src="http://2018.imbc.com/images/m/mbc_sns.png" alt="mbc sns 바로가기"></span></div>\
            <div class="link">\
                <ul>\
                    <li><a href="http://www.facebook.com/mbcolympics" class="fb" target="_blank">페이스북 바로가기</a></li>\
                    <li><a href="http://www.instagram.com/mbcolympics" class="insta" target="_blank">인스타그램 바로가기</a></li>\
                    <li><a href="http://www.twitter.com/withmbc" class="tw" target="_blank">트위터 바로가기</a></li>\
                </ul>\
            </div>';
$('.sns').html(loadsns);
}

//d-day
var loadDday = function() {
    $("#d-day").countdown("2018/2/10", function(event) {
        $(this).text(
            event.strftime('%D')
        );
    });
};