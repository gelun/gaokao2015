//按下取消键是的操作
function doCancel() {

    alert();
    document.getElementById("shield").style.display = "none";
    document.getElementById("alertFram").style.display = "none";
}


//改写alert
window.alert = function (txt, okValue, cancelValue, locationhref) {
    var shield = document.createElement("DIV");
    shield.id = "shield";
    shield.tagName = "shield";
    shield.style.position = "fixed";
    shield.style.left = "0px";
    shield.style.top = "0px";
    shield.style.width = "100%";
    // shield.style.height = document.body.scrollHeight + "px";
    shield.style.height = "100%";
    shield.style.overflow = "hidden";
    shield.style.tabindex = "0";
    shield.style.opacity = "0.7";
    shield.style.background = "rgb(0, 0, 0)";
    shield.style.textAlign = "center";
    shield.style.zIndex = "10000";
    //  shield.style.filter = "alpha(opacity=0)";
    var alertFram = document.createElement("DIV");
    alertFram.id = "alertFram";
    alertFram.style.position = "absolute";
    alertFram.style.left = "50%";
    alertFram.style.top = "50%";
    alertFram.style.marginLeft = "-175px";
    alertFram.style.marginTop = "-125px";
    alertFram.style.width = "350px";
    alertFram.style.height = "250px";
    alertFram.style.background = "#fff";
    alertFram.style.textAlign = "center";
    alertFram.style.borderRadius = "6px";
    // alertFram.style.lineHeight = "150px";
    alertFram.style.zIndex = "10001";
    var strHtml = "<div id=\"Alert1\" style=\"width: 350px;height: 200px;text-align: center;padding: 25px 5px;position: relative;\">\n";
    strHtml += " <div class=\"one1\" style=\"height: 100px;\"><img src=\"images/tanchu1.jpg\" width=\"91\" height=\"91\" /></div>\n";
    strHtml += " <div class=\"two1\" style=\"height: 36px;color:#000; padding-left:20px; padding-right:20px; padding-bottom:5px;\">" + txt + "</div>\n";
    strHtml += " <div class=\"three1\">";
    strHtml += " <input name=\"\" type=\"button\" class=\"btn1\" style=\"text-decoration:none; color:#fff; display:inline-block; padding:0 13px; height:34px; line-height:34px; font-weight:bold; margin-right:10px;background:#0185da; border-radius:5px; cursor:pointer;\" value=\"" + okValue + "\" onclick=\"doOk()\" />";
    strHtml += " <input name=\"\" type=\"button\" class=\"btn2\" style=\"text-decoration:none; color:#fff; display:inline-block; padding:0 13px; height:34px; line-height:34px; font-weight:bold; margin-right:10px;background:#91d412; border-radius:5px; cursor:pointer;\" value=\"" + cancelValue + "\" onclicke=\"doCancel()\" />";
    strHtml += " </div>\n";
    strHtml += " </div>\n";


    //    <div id="Alert">
    //        <div class="one"><img src="images/tanchu1.jpg" width="91" height="91" /></div>
    //        <div class="two">需要付费升级后，才能进行此项操作。</div>
    //        <div class="three"><a href="#"><input name="" type="button" class="btn1" /></a><a href="#"><input name="" type="button" class="btn2" /></a></div>
    //    </div>

    alertFram.innerHTML = strHtml;

    document.appendChild(alertFram);
    document.appendChild(shield);
    var c = 0;
    this.doAlpha = function () {
        if (c++ > 20) { clearInterval(ad); return 0; }
        shield.style.filter = "alpha(opacity=" + c + ");";
    }
    var ad = setInterval("doAlpha()", 5);


    alertFram.focus();
    document.body.onselectstart = function () { return false; };

}


//按下ok键时的操作
function doOk() {
    if (locationhref == "") {
        //不需跳转
        document.getElementById("shield").style.display = "none";
        document.getElementById("alertFram").style.display = "none";
    } else {
        window.location.href = locationhref;
    }
}
