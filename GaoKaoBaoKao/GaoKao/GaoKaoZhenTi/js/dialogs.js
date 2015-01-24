
seajs.config({
    alias: {
        "jquery": "jquery-1.10.2.js"
    }
});
function artDialog11(contentvalue, okvalue, cancelvalue, hashref, loading) {
    // function artDialog11() {
    if (okvalue == undefined || okvalue == "") {
        okvalue = "确定";
    }
    if (cancelvalue == undefined || cancelvalue == "") {
        cancelvalue = "取消";
    }
    if (hashref == undefined || hashref == "") {
        hashref = "0";
    }
    if (loading == undefined || loading == "") {
        loading = "";
    }
    seajs.use(['jquery', '/gaokaozhenti/js/aui-artDialog-5c965d5/src/dialog'], function ($, dialog) {
        var d = dialog({
            // title: '消息',
            content: contentvalue,
            cancelValue: cancelvalue,
            cancel: function () { },
            okValue: okvalue,
            ok: function () {
                var that = this;
                setTimeout(function () {
                    //  that.title('跳转中..');
                    if (loading.length > 0) {
                        window.location.href = loading;
                    }
                }, 100);
                return false;
            }
        });

        d.showModal();

        $(function () {
            if (hashref == "0") {
                $("#divartdialogok").attr("data-id", "cancel");
            }
        });
    });
}


//弹框，1秒钟后自动关闭
function alertResult(result) {
    seajs.use(['jquery', '/gaokaozhenti/js/aui-artDialog-5c965d5/src/dialog'], function ($, dialog) {
        var dd = dialog({
            content: result
        });
        dd.show();
        setTimeout(function () {
            dd.close().remove();
        }, 1000);
    });
}
