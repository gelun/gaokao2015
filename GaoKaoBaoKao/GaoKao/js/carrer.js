$(function () {
    var domain = 'http://www.gaokaopai.com';
    $('.zhiyeSeaBox .tab').gstab({ event: 'click', content: '.zhiyeSeaBox .item' });

    $.extend({

        /**	
        * 获取相关专业
        * 
        * @param url 
        * @param job_code
        */
        getRelateMajor: function (code) {
            var ajaxUrl = "http://www.gaokaopai.com/ajax-career-getRelateMajor.html";
            var obj = $('.relateMajor');

            $.ajax({
                type: "post",
                url: "http://www.gaokaopai.com/ajax-career-getRelateMajor.html",
                data: 'code=' + code,
                beforeSend: function () {
                    obj.html('读取中...');
                },
                success: function (response) {
                    var html = '';
                    if (response.status == 1) {
                        $.each(response.data, function (k, v) {
                            html += '<a href="' + domain + '/zhuanye-jianjie-' + v.major_code + '.html" title="' + v.major_name + '">' + v.major_name + '</a>';
                        });
                    } else {
                        html = '对不起，暂时没有匹配的大学本专科专业！';
                    }
                    obj.html(html);
                }
            });
        },

        /**
        * 获取热门职业
        */
        getHotCareer: function (url, limit) {
            var url = url;
            var limit = limit;
            var obj = $('.careerHotList');

            $.ajax({
                type: "post",
                url: url,
                data: 'limit=' + limit + '&rand=' + 1,
                beforeSend: function () {
                    obj.html("读取中...");
                },
                success: function (response) {
                    var html = '';
                    if (response.status) {
                        $.each(response.data, function (k, v) {
                            html += '<li>';
                            html += '<a href="' + domain + '/zhiye-jianjie-' + v.id + '.html">' + v.job_name + '</a>';
                            html += '</li>';
                        });
                    } else {
                        html = '数据获取失败，请尝试重新刷新！！';
                    }

                    obj.html(html);
                }
            });
        },

        /**
        * 获取热门行业
        */
        getHotCategory: function (url, limit) {
            var url = url;
            var limit = limit;
            var obj = $('.majorHotList');

            $.ajax({
                type: "post",
                url: url,
                data: 'limit=' + limit + '&rand=' + 1,
                beforeSend: function () {
                    obj.html("读取中...");
                },
                success: function (response) {
                    var html = '';
                    if (response.status) {
                        $.each(response.data, function (k, v) {
                            html += '<li>';
                            html += '<a href="' + domain + '/zhiye-jianjie-' + v.code + '.html">' + v.name + '</a>';
                            html += '</li>';
                        });
                    } else {
                        html = '数据获取失败，请尝试重新刷新！！';
                    }

                    obj.html(html);
                }
            });
        }
    });


})
