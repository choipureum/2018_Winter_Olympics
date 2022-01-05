var _page = 1;  //현재 페이지
var _order = 1;  //정렬 : 1.최신 0.인기
var _gubun = 0;  //구분 : 1.하이라이트 / 2.다시보기 / 3.스페셜 / 4.어록 / 6.홍보영상 / 0.전체
var _type = "";  //종목
var setItemid = "";

$(document).ready(function () {

    $('.vod-menu .lics a').on('click', function () {
        $('.lics').find('a').removeClass('on');
        $(this).addClass('on');
        $("#orderbtn1").removeClass('on');
        $("#orderbtn1").addClass('on');
        $("#orderbtn2").removeClass('on');
    });
    
    $('.vod-popular button').on('click', function () {
    $(this).addClass('on').siblings().removeClass('on');
    });
    
    setHotClip();
    setVodList(_page, _order, _gubun, _type);

});




function setHotClip() {

    $.ajax({
        type: "get",
        url: "http://rio2016.imbc.com/api/getVodList.aspx?p=8&o=1&q=HOT",
        dataType: "json",
        success: function (data) {
            var hotstrHtml = [];
            for (var i = 0; i < data.List.length; i++) {
                hotstrHtml.push('<li><a href="javascript:setVodView(' + data.List[i].BroadcastID + ', ' + data.List[i].itemid + ');"');
                hotstrHtml.push('<img src="' + data.List[i].ImgUrl_Big + '" alt="' + data.List[i].ContentTitle + '>');
                hotstrHtml.push('<p class="num">' + data.List[i].HitCount + '</p><p class="txt ellipsis">' + data.List[i].ContentTitle + '</p></a></li>');
            }

            $("#hotClip").html('');
            $("#hotClip").append(hotstrHtml.join(''));

            var btnHotclipPrev = $('.hot-area .btn.prev');
            var btnHotclipNext = $('.hot-area .btn.next');
            var itemsHive = $('.hot-area');
            var itemsWrap = itemsHive.find('ul');
            var showingList = 2;
            var vodCnt = 0;
            var m_itemsWrap = '';
            var itemsHotclip = '';
            var h_itemHotclip = '';
            var len_itemHotclip = '';
            var oneShowingH = '';
            var showReNum = '';
            var item = itemsWrap.children('li');
            var page = Math.ceil(item.length / 2);

            itemsHive.find('.slide-num').html('<strong>1</strong>/' + page);

            btnHotclipPrev.on('click', function () {
                m_itemsWrap = parseInt(itemsWrap.css('margin-top'));
                itemsHotclip = itemsWrap.find('li');
                h_itemHotclip = parseInt(itemsHotclip.css('height'));
                len_itemHotclip = itemsHotclip.length;
                oneShowingH = h_itemHotclip * showingList;
                showReNum = Math.ceil(len_itemHotclip / showingList);
                if (vodCnt == 0) {
                    return false;
                } else {
                    itemsWrap.css('margin-top', m_itemsWrap + oneShowingH + 'px');
                    vodCnt--;
                }
                $('.slide-num>strong').text(vodCnt + 1);
            });

        },
        error: function (request, status, error) {
            alert(error);
        }
    });


}

function setVodView(bid, itemid) {
    setItemid = itemid;
    $('#vodList li').removeClass('on');
    $("#liid_" + itemid).addClass('on');

    changeVod(bid, itemid);
    $(document).scrollTop(200);
}


function addList() {
    setVodList(_page, _order, _gubun, _type);
}

function resetVodList(page, order, gubun, type) {
    _page = 1;
    _order = 1;
    _gubun = gubun;
    _type = "";
    $("#vodlist_list").html('');
    setVodList(page, order, gubun, type);
}

function setOrder(order) {
    $("#vodList").html('');
    _order = order;
    _page = 1;
    setVodList(_page, order, _gubun, _type);
}

function setType(type) {
    _type = type;
    _page = 1;
    //$("#vodlist_list").html('');
    //setVodList(_page, _order, _gubun, _type);
}

function goType() {
    $("#vodList").html('');
    setVodList(_page, _order, _gubun, _type);
}


function setVodList(page, order, gubun, type) {
    var pageSize = 9;
    type = encodeURI(type);
    $.ajax({
        type: "get",
        url: "http://rio2016.imbc.com/api/getVodList.aspx?c=" + page + "&p=" + pageSize + "&o=" + order + "&g=" + gubun + "&t=" + type,
        dataType: "json",
        success: function (data) {
            var strHtml = [];
            var totalcnt = data.TotalCount;
            $("#pagination-module").html('');
            if (totalcnt > 0) {

                for (var i = 0; i < data.List.length; i++) {
                    if (data.List[i].itemid == setItemid) {
                        strHtml.push('<li id="liid_' + data.List[i].itemid + '" class="on">');
                    } else {
                        strHtml.push('<li id="liid_' + data.List[i].itemid + '">');
                    }

                    strHtml.push('<a href="javascript:setVodView(' + data.List[i].BroadcastID + ', ' + data.List[i].itemid + ')">');
                    strHtml.push('<div class="img"><img src="' + data.List[i].ImgUrl_Big + '" alt="' + data.List[i].ContentTitle + '></div>');
                    strHtml.push('<div class="txt-wrap"><p class="title ellipsis2">' + data.List[i].ContentTitle + '</p>');
                    strHtml.push('<p class="num">' + data.List[i].HitCount + '</p></div></a></li>');
                }
                $("#vodList").html('');
                $("#vodList").append(strHtml.join(''));

                var pageHtml = [];
                var pb = 10;
                var navCount = Math.ceil(totalcnt / pageSize);
                var blockPage = (parseInt((page - 1) / pb)) * pb + 1;
                var endPage = navCount >= blockPage + pb ? blockPage + pb : navCount + 1;
                var prevPage = (parseInt((blockPage - pb) / pb)) * pb + 1;
                var nextPage = (parseInt((blockPage + pb) / pb)) * pb + 1;

                if (nextPage > navCount) nextPage = navCount;

                for (var j = blockPage; j < endPage; j++) {
                    if (page == j) {
                        pageHtml.push('<a id="page_' + j + '" class="on">' + j + '</a>');
                    } else {
                        pageHtml.push('<a id="page_' + j + '" href="javascript:setVodList(' + j + ', _order, _gubun, _type);">' + j + '</a>');
                    }
                }

                $("#pagination").append(pageHtml.join(''));
                
            } else {
                $("#vodList").html('');
            }

        },
        error: function (request, status, error) {
            alert(error);
        }
    });
}

