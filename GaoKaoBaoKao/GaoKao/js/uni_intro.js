$(function () {
    //简介
    $('div.conRword').expander({
        slicePoint: 200,
        expandPrefix: '……',
        expandText: '查看详细&gt;&gt;', // default is 'read more'
        collapseTimer: 0, // re-collapses after 5 seconds; default is 0, so no re-collapsing
        userCollapseText: '', //收起
        widow: 2,
        beforeExpand: function () {
            $('.details').css('display', '');
        },
        onSlice: function () {
            $('.intro').css('text-indent', '28px');
        },
        onCollapse: function () {
            $('.details').css('display', '');
        }
    });
})
