
//$(function () {
//    //$(document).keyup(function(e) { //捕获文档对象的按键弹起事件  
//    //  //  alert(e.keyCode);
//    //    if (e.keyCode === 13) { //按键信息对象以参数的形式传递进来了  
//    //        e.keyCode = 9;
//    //    }
//    //});


//    document.onkeyup = function (e) {
//        if (window.event)//如果window.event对象存在，就以此事件对象为准  
//            e = window.event;
//        var code = e.charCode || e.keyCode;
    
//        if (code == 13) {
//            e.keyCode = 9;
//        }
//    }
//});


//document.onkeyup = function (e) {
//    if (window.event)//如果window.event对象存在，就以此事件对象为准  
//        e = window.event;
//    var code = e.charCode || e.keyCode;
//    if (code == 13) {
//        e.keyCode = 9;
//    }
//}