(function ($) {
    $.extend({
        //
        ajaxExtend: function (userOptions) {
            var defaultOpts = {
                type: 'POST',
                contentType: 'application/json',//application/x-www-form-urlencoded
                global: false,
                async: false
            };
            userOptions = userOptions || {};

            var options = $.extend({}, defaultOpts, userOptions);
            options.success = function (result) {
                if (result.IsSuccess) {
                    userOptions.successHd(result);
                } else {
                    userOptions.errorHd(result);
                }
            }

            $.ajax(options);
            //$.ajax({
            //    url: "/Login/UserLogin",
            //    type: "POST",
            //    data: JSON.stringify(postData),
            //    contentType: 'application/json',
            //    global: false,
            //    async: false,
            //    success: function (result) {
            //        if (result.IsSuccess) {
            //            window.location.href = "/Home/Index";
            //        } else {
            //            alert(result.Message);
            //        }

            //    }
            //});
        }
    });
})(jQuery);