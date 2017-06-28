var pro = pro || {};
(function () {
    pro.IndexPage = pro.IndexPage || {};
    pro.IndexPage = {
        initPage: function () {
            $("#btn_Login").click(function () {
                pro.IndexPage.login();
            });

            $("#LoginId").change(function () {
                pro.IndexPage.changeLoginName();
            });


            $("#SelectDepartmentCode").change(function () {
                pro.IndexPage.changeDepartment();
            });


            $("#SelectDepartmentName").change(function () {
                pro.IndexPage.chooseDepartment();
            });

        },
        login: function () {
            var postData = pro.submitKit.getHeadJson();
            $.ajaxExtend({
                url: "/Login/UserLogin",
                data: JSON.stringify(postData),
                successHd: function (result) {
                    window.location.href = "/Home/Index";
                },
                errorHd: function (result) {
                    alert(result.Message);
                }
            });
        },
        changeLoginName: function () {
            var loginId = $("#LoginId").val();
            var postData = { LoginId: loginId };
            $.ajaxExtend({
                url: "/Login/ChangeLoginName",
                data: postData,
                contentType: pro.globalConfig.contentType.form,
                successHd: function (result) {
                    var html = "";
                    JSLINQ(result.Data).ForEach(function (item) {
                        html += "<option value=\"" + item.DepartmentCode + "\">" + item.DepartmentName + "</option>";
                    });
                    $("#SelectDepartmentCode").html(html);
                    if (result.AttachData) {
                        $("#SelectDepartmentCode").val(result.AttachData);
                        $("#SelectDepartmentCode").trigger("change");
                    }

                },
                errorHd: function (result) {
                    alert(result.Message);
                }
            });
        },
        changeDepartment: function () {
            var departmentName = $("#SelectDepartmentCode").find("option:selected").text();
            $("#SelectDepartmentName").val(departmentName);
        },
        chooseDepartment: function () {
            $("#SelectDepartmentCode").val($("#SelectDepartmentName").val());
            $("#SelectDepartmentCode").trigger("change");
        }


    };
})();


$(function () {
    pro.IndexPage.initPage();
});

