
$(function () {
    var num = $("#schoolpic li").length;

    function gunDongLeft() {
        ///////////////////////////////////////////// li的个数，大于4个的时候，才可以滚动 /////////////////////////////////////
        if (num > 4) {
            ///////////////////////// 获取第一个 display = none 的li的索引 //////////////////
            var nonenum = 0;
            $("#schoolpic").find("li").each(function (index) {
                if ($(this).css("display") == "none") {
                    nonenum = index;
                    return false;
                }
            });
            ///////////////////////// 获取第一个 display != none 的li的索引 //////////////////
            var blocknum = 0;
            $("#schoolpic").find("li").each(function (index) {
                if ($(this).css("display") != "none") {
                    blocknum = index;
                    return false;
                }
            });
            //////////////////////////////
            if ((num - 1) - blocknum < 4) {
                return false;
            } else {
                $("#schoolpic li").eq(blocknum).animate(300, function () {
                    $(this).css("display", "none");
                });
                $("#schoolpic li").eq((parseInt(blocknum) + 4)).animate(300, function () {
                    $(this).css("display", "block");
                });
            }
        }
        else {
            return false;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////点击向左滚动///////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////
    $("#arrowleft").click(function () {
        gunDongLeft();

    });
    //////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////点击向右滚动///////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////
    $("#arrowright").click(function () {
        ///////////////////////////////////////////// li的个数，大于4个的时候，才可以滚动 /////////////////////////////////////
        if (num > 4) {
            ///////////////////////// 获取第一个 display = block 的li的索引 //////////////////
            var blocknum = 0;
            $("#schoolpic").find("li").each(function (index) {
                if ($(this).css("display") != "none") {
                    blocknum = index;
                    return false;
                }
            });
            //////////////////
            if (blocknum == 0) {
                return false;
            } else {
                $("#schoolpic li").eq(blocknum - 1).animate(300, function () {
                    $(this).css("display", "block");
                });
                $("#schoolpic li").eq((parseInt(blocknum) + 3)).animate(300, function () {
                    $(this).css("display", "none");
                });
            }
        }
        else {
            return false;
        }
    });
});
