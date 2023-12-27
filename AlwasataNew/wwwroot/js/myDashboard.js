$(function () {

    $("#custInfoBtn").click(() => {
        $(".ProjectInfo").css("display","none");
        $(".CustomerInfo").css("display","block");
        $("#custInfoBtn").addClass("active");
        $("#projInfoBtn").removeClass("active");

    });
    $("#projInfoBtn").click(() => {
        $(".CustomerInfo").css("display","none");
        $(".ProjectInfo").css("display","block");
        $("#custInfoBtn").removeClass("active");
        $("#projInfoBtn").addClass("active");
    });

});