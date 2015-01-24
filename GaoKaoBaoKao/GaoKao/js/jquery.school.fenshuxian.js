
$(function () {
    ////////////////////////////////////////页面加载时/////////////////////////////////
    ////////////各省录取线
    var year = $("#ContentPlaceHolder1_ddlYearShengFen  option:selected").val();
    var province = $("#ContentPlaceHolder1_ddlProvinceShengFen  option:selected").val();
    var wenli = $("#ContentPlaceHolder1_ddlWenLiShengFen  option:selected").val();
    var schoolid = $.trim($("#intSchoolId").text());

    var b = "false";

    if (isgaokaocard == "1") {
        //是高考卡登陆用户
        b = "true";
    } else {
        //不是高考卡登陆用户
        if (year == "2013") {
            b = "false";
        } else {
            b = "true";
        }
    }

    if (b == "true") {
        $.ajax({
            type: "get",

            url: "/gk/ashx/FenShengLuQu.ashx",

            data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

            dataType: "html",

            success: function (data, textStatus) {

                $("#shengfenluquxian").html("<tr><th width=\"142px\">年份</th><th width=\"62px\">最高分</th><th width=\"90px\">平均分</th><th width=\"90px\">省控线</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                $("#shengfenluquxian").append(data);

                //更多
                $("#shengfenluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/fsx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");

            }
        });
    } else {
        alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
        $("#ContentPlaceHolder1_ddlYearShengFen option[value='2012']").attr("selected", true);
        window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
    }

    ////////////各专业录取线
    var year = $("#ContentPlaceHolder1_ddlYearZhuanYe  option:selected").val();
    var province = $("#ContentPlaceHolder1_ddlProvinceZhuanYe  option:selected").val();
    var wenli = $("#ContentPlaceHolder1_ddlWenLiZhuanYe  option:selected").val();
    var schoolid = $.trim($("#intSchoolId").text());

    var b = "false";
    if (isgaokaocard == "1") {
        //是高考卡登陆用户
        b = "true";
    } else {
        //不是高考卡登陆用户
        if (year == "2013") {
            b = "false";
        } else {
            b = "true";
        }
    }

    if (b == "true") {
        $.ajax({
            type: "get",

            url: "/gk/ashx/FenShengZhuanYeLuQu.ashx",

            data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

            dataType: "html",

            success: function (data, textStatus) {
                //绑定筛选出来的数据
                $("#zhuanyeluqu").html("<tr><th width=\"142px\">专业名称</th><th width=\"62px\">年份</th><th width=\"90px\">最高分</th><th width=\"90px\">平均分</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                $("#zhuanyeluqu").append(data);

                //更多
                $("#zhuanyeluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/zyx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");
            }

        });
    } else {
        alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
        $("#ContentPlaceHolder1_ddlYearZhuanYe option[text='2012年']").attr("selected", true);
        window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////各省院校录取///////////////////////////////////////
    /////////////年份的时候
    $("#ContentPlaceHolder1_ddlYearShengFen").change(function () {
        var year = $("#ContentPlaceHolder1_ddlYearShengFen  option:selected").val();
        var province = $("#ContentPlaceHolder1_ddlProvinceShengFen  option:selected").val();
        var wenli = $("#ContentPlaceHolder1_ddlWenLiShengFen  option:selected").val();
        var schoolid = $.trim($("#intSchoolId").text());
        var b = "false";
        if (isgaokaocard == "1") {
            //是高考卡登陆用户
            b = "true";
        } else {
            //不是高考卡登陆用户
            if (year == "2013") {
                b = "false";
            } else {
                b = "true";
            }
        }

        if (b == "true") {
            $.ajax({
                type: "get",

                url: "/gk/ashx/FenShengLuQu.ashx",

                data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

                dataType: "html",

                success: function (data, textStatus) {

                    $("#shengfenluquxian").html("<tr><th width=\"142px\">年份</th><th width=\"62px\">最高分</th><th width=\"90px\">平均分</th><th width=\"90px\">省控线</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                    $("#shengfenluquxian").append(data);

                    //更多
                    $("#shengfenluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/fsx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");

                }
            });
        } else {
            alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
            $("#ContentPlaceHolder1_ddlYearShengFen option[value='2012']").attr("selected", true);
            window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
        }
    });
    ///////////////////////省份的时候/////////////////////////
    $("#ContentPlaceHolder1_ddlProvinceShengFen").change(function () {
        var year = $("#ContentPlaceHolder1_ddlYearShengFen  option:selected").val();
        var province = $("#ContentPlaceHolder1_ddlProvinceShengFen  option:selected").val();
        var wenli = $("#ContentPlaceHolder1_ddlWenLiShengFen  option:selected").val();
        var schoolid = $.trim($("#intSchoolId").text());
        var b = "false";
        if (isgaokaocard == "1") {
            //是高考卡登陆用户
            b = "true";
        } else {
            //不是高考卡登陆用户
            if (year == "2013") {
                b = "false";
            } else {
                b = "true";
            }
        }

        if (b == "true") {
            $.ajax({
                type: "get",

                url: "/gk/ashx/FenShengLuQu.ashx",

                data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

                dataType: "html",

                success: function (data, textStatus) {

                    $("#shengfenluquxian").html("<tr><th width=\"142px\">年份</th><th width=\"62px\">最高分</th><th width=\"90px\">平均分</th><th width=\"90px\">省控线</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                    $("#shengfenluquxian").append(data);

                    //更多
                    $("#shengfenluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/fsx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");

                }

            });
        } else {
            alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
            $("#ContentPlaceHolder1_ddlYearShengFen option[value='2012']").attr("selected", true);
            window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
        }
    });
    //////////////////////文理科的时候///////////////////
    $("#ContentPlaceHolder1_ddlWenLiShengFen").change(function () {
        var year = $("#ContentPlaceHolder1_ddlYearShengFen  option:selected").val();
        var province = $("#ContentPlaceHolder1_ddlProvinceShengFen  option:selected").val();
        var wenli = $("#ContentPlaceHolder1_ddlWenLiShengFen  option:selected").val();
        var schoolid = $.trim($("#intSchoolId").text());
        var b = "false";
        if (isgaokaocard == "1") {
            //是高考卡登陆用户
            b = "true";
        } else {
            //不是高考卡登陆用户
            if (year == "2013") {
                b = "false";
            } else {
                b = "true";
            }
        }

        if (b == "true") {
            $.ajax({
                type: "get",

                url: "/gk/ashx/FenShengLuQu.ashx",

                data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

                dataType: "html",

                success: function (data, textStatus) {
                    $("#shengfenluquxian").html("<tr><th width=\"142px\">年份</th><th width=\"62px\">最高分</th><th width=\"90px\">平均分</th><th width=\"90px\">省控线</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                    $("#shengfenluquxian").append(data);

                    //更多
                    $("#shengfenluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/fsx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");

                }

            });
        } else {
            alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
            $("#ContentPlaceHolder1_ddlYearShengFen option[value='2012']").attr("selected", true);
            window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
        }
    });

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////各专业录取/////////////////////////////////////////
    ////////////年份的时候
    $("#ContentPlaceHolder1_ddlYearZhuanYe").change(function () {
        var year = $("#ContentPlaceHolder1_ddlYearZhuanYe  option:selected").val();
        var province = $("#ContentPlaceHolder1_ddlProvinceZhuanYe  option:selected").val();
        var wenli = $("#ContentPlaceHolder1_ddlWenLiZhuanYe  option:selected").val();
        var schoolid = $.trim($("#intSchoolId").text());

        var b = "false";

        if (isgaokaocard == "1") {
            //是高考卡登陆用户
            b = "true";
        } else {
            //不是高考卡登陆用户
            if (year == "2013") {
                b = "false";
            } else {
                b = "true";
            }
        }
        if (b == "true") {
            $.ajax({
                type: "get",

                url: "/gk/ashx/FenShengZhuanYeLuQu.ashx",

                data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

                dataType: "html",

                success: function (data, textStatus) {
                    //绑定筛选出来的数据
                    $("#zhuanyeluqu").html("<tr><th width=\"142px\">专业名称</th><th width=\"62px\">年份</th><th width=\"90px\">最高分</th><th width=\"90px\">平均分</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                    $("#zhuanyeluqu").append(data);

                    //更多
                    $("#zhuanyeluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/zyx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");
                }

            });
        } else {
            alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
            $("#ContentPlaceHolder1_ddlYearZhuanYe option[value='2012']").attr("selected", true);
            window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
        }
    });
    //////////////省份的时候
    $("#ContentPlaceHolder1_ddlProvinceZhuanYe").change(function () {
        var year = $("#ContentPlaceHolder1_ddlYearZhuanYe  option:selected").val();
        var province = $("#ContentPlaceHolder1_ddlProvinceZhuanYe  option:selected").val();
        var wenli = $("#ContentPlaceHolder1_ddlWenLiZhuanYe  option:selected").val();
        var schoolid = $.trim($("#intSchoolId").text());

        var b = "false";

        if (isgaokaocard == "1") {
            //是高考卡登陆用户
            b = "true";
        } else {
            //不是高考卡登陆用户
            if (year == "2013") {
                b = "false";
            } else {
                b = "true";
            }
        }
        if (b == "true") {
            $.ajax({
                type: "get",

                url: "/gk/ashx/FenShengZhuanYeLuQu.ashx",

                data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

                dataType: "html",

                success: function (data, textStatus) {

                    $("#zhuanyeluqu").html("<tr><th width=\"142px\">专业名称</th><th width=\"62px\">年份</th><th width=\"90px\">最高分</th><th width=\"90px\">平均分</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                    $("#zhuanyeluqu").append(data);


                    //更多
                    $("#zhuanyeluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/zyx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");
                }

            });
        } else {
            alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
            $("#ContentPlaceHolder1_ddlYearZhuanYe option[value='2012']").attr("selected", true);
            window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
        }

    });
    /////////////文理科的时候
    $("#ContentPlaceHolder1_ddlWenLiZhuanYe").change(function () {
        var year = $("#ContentPlaceHolder1_ddlYearZhuanYe  option:selected").val();
        var province = $("#ContentPlaceHolder1_ddlProvinceZhuanYe  option:selected").val();
        var wenli = $("#ContentPlaceHolder1_ddlWenLiZhuanYe  option:selected").val();
        var schoolid = $.trim($("#intSchoolId").text());

        var b = "false";

        if (isgaokaocard == "1") {
            //是高考卡登陆用户
            b = "true";
        } else {
            //不是高考卡登陆用户
            if (year == "2013") {
                b = "false";
            } else {
                b = "true";
            }
        }
        if (b == "true") {
            $.ajax({
                type: "get",

                url: "/gk/ashx/FenShengZhuanYeLuQu.ashx",

                data: { year: year, province: province, wenli: wenli, schoolid: schoolid },

                dataType: "html",

                success: function (data, textStatus) {
                    $("#zhuanyeluqu").html("<tr><th width=\"142px\">专业名称</th><th width=\"62px\">年份</th><th width=\"90px\">最高分</th><th width=\"90px\">平均分</th><th width=\"140px\">考生类别</th><th width=\"140px\">录取批次</th></tr>");
                    $("#zhuanyeluqu").append(data);


                    //更多
                    $("#zhuanyeluquadd").html("<a title=\"更多\" target=\"_blank\" href=\"/gk/xx" + $.trim(schoolid) + "/zyx" + year + "_" + wenli + "_" + province + ".shtml\">更多>></a>");
                }

            });
        } else {
            alert("您还不是高考报考卡用户，如果您想浏览2013年的数据，请先购买高考报考卡");
            $("#ContentPlaceHolder1_ddlYearZhuanYe option[value='2012']").attr("selected", true);
            window.open("http://www.gelunjiaoyu.com/gaokao/gouka/");
        }
    });
});