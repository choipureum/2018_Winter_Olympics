function setNewsList(page) {
    var pageSize = 5;
    $.ajax({
        type: "get",
        url: "http://rio2016.imbc.com/api/getEnewsList.aspx?page=" + page + "&pageSize=" + pageSize,
        dataType: "json",
        success: function (data) {
            var strHtml = [];
            var totalcnt = data.TotalCount;

            for (var i = 0; i < data.List.length; i++) {
                var cont = data.List[i].Summary;
                if (cont.length > 120) {
                    cont = cont.substring(0, 120) + '...';
                }


                if (data.List[i].Nickname == "IMNEWS") {
                    strHtml.push('<li><a href="/api/gateNews.aspx?o=I&i=' + data.List[i].Idx + '&u=' + data.List[i].OrgUrl + '" target="_blank" >');
                    strHtml.push('<div class="img"><img src="' + data.List[i].ImgUrlR + '"  alt="' + data.List[i].Title + '" onerror="this.src=\'http://rio2016.imbc.com/img/img-default.jpg\'"></div>');
                } else {
                    var link = encodeURIComponent('http://rio2016.imbc.com/news/view.aspx?idx=' + data.List[i].Idx + '&page=' + page);
                    strHtml.push('<li><a href="/api/gateNews.aspx?o=E&i=' + data.List[i].Idx + '&u=' + link + '" >');
                    strHtml.push('div class="img"><img src="http://talkimg.imbc.com/TVianUpload/TVian/TViews/image/' + data.List[i].ImgUrlR + '"  alt="' + data.List[i].Title + '" onerror="this.src=\'http://rio2016.imbc.com/img/img-default.jpg\'" ></div>');
                }
                strHtml.push('<div class="txt-wrap"><p class="title ellipsis">' + data.List[i].Title + '</p>');
                strHtml.push('<p class="txt ellipsis2">' + cont + '</p>');
                strHtml.push('<p class="date">' + data.List[i].PublicationDate + '</p></div></a></li>');
            }

            $("#newsList").html('');
            $("#newsList").append(strHtml.join(''));

            
            $("#pagination").html('');
            if (totalcnt > 0) {
                var pageHtml = [];
                var pb = 5;
                var navCount = Math.ceil(totalcnt / pageSize);
                var blockPage = (parseInt((page - 1) / pb)) * pb + 1;
                var endPage = navCount >= blockPage + pb ? blockPage + pb : navCount + 1;
                var prevPage = (parseInt((blockPage - pb) / pb)) * pb + 1;
                var nextPage = (parseInt((blockPage + pb) / pb)) * pb + 1;

                if (nextPage > navCount) nextPage = navCount;

                for (var j = blockPage; j < endPage; j++) {
                    if (page == j) {
                        pageHtml.push('<a id="page' + j + '" class="on">' + j + '</a>');
                    } else {
                        pageHtml.push('<a id="page' + j + '" href="javascript:setNewsList(' + j + ');">' + j + '</a>');
                    }
                }

                $("#pagination").append(pageHtml.join(''));
            }


        }
    });

}