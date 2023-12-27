var AllCustomer = [];
$.get("GetAllCustomer", {}, function (data) {
    for (let i = 0; i < data.length; i++) {
        AllCustomer.push(data[i]);
    }
});

var AllCustomerStateDescription = [];
$.get("GetAllCustomerStateDescription", {}, function (data) {
    for (let i = 0; i < data.length; i++) {
        AllCustomerStateDescription.push(data[i]);
    }
});


$("#keyWord").keyup(() => {
    var key = $("#keyWord").val();
    console.log(key);

    $.get("GetAllCustomerWithKeyWord", { text: key }, function (data) {

        $("#TableBody").empty();

        for (let i = 0; i < data.length; i++) {
            $("#TableBody").append(
                "<tr><td>" + data[i].customerName + "</td><td>" + data[i].companyName + "</td><td>" + data[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + data[i].id + "' class='customerSta'><span style='position: relative'> "
                + data[i].customerState
                + "<span class='addComm'>التعليقات</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + data[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + data[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + data[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }
    });

});


$("#comp-1").click(() => {

    $("#comp-1").addClass("btnActive");
    $("#comp-2").removeClass("btnActive");
    $("#comp-3").removeClass("btnActive");
    $("#comp-4").removeClass("btnActive");
    $("#TableBody").empty();


    for (let i = 0; i < AllCustomer.length; i++) {
        console.log(AllCustomer[i].companyId)
        if (AllCustomer[i].companyId == 1) {
            $("#TableBody").append
                (
                    "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                    + "<td>"
                    + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                    + AllCustomer[i].customerState
                    + "<span class='addComm'>التعليقات</span></span></a></td>"
                    + "<td>"
                    + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                    + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                    + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                    + "</td>"
                    + "</tr>"
                );
        }
    }
});

$("#comp-2").click(() => {

    $("#comp-1").removeClass("btnActive");
    $("#comp-2").addClass("btnActive");
    $("#comp-3").removeClass("btnActive");
    $("#comp-4").removeClass("btnActive");
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].companyId == 2) {
            $("#TableBody").append
                (
                    "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                    + "<td>"
                    + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                    + AllCustomer[i].customerState
                    + "<span class='addComm'>التعليقات</span></span></a></td>"
                    + "<td>"
                    + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'> تفاصيل المشاريع </a> "
                    + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                    + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                    + "</td>"
                    + "</tr>");
        }
    }
});

$("#comp-3").click(() => {

    $("#comp-1").removeClass("btnActive");
    $("#comp-2").removeClass("btnActive");
    $("#comp-3").addClass("btnActive");
    $("#comp-4").removeClass("btnActive");
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].companyId == 3) {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>التعليقات</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }
    }
});

$("#comp-4").click(() => {
    $("#comp-1").removeClass("btnActive");
    $("#comp-2").removeClass("btnActive");
    $("#comp-3").removeClass("btnActive");
    $("#comp-4").addClass("btnActive");
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].companyId == 4) {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>التعليقات</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }
    }
});


$("#active").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "متفاعل") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});

$("#notAnswer").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "لم يرد") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }
    }
});


$("#waiting").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "منتظر") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td><td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});


$("#unActive").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "غير متفاعل") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});


$("#following").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "متابعة") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td style='color:darkcyan;font-weight:bold'>" + AllCustomer[i].customerState + "</td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjectsDescription/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});

$("#complete").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "مكتمل") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjectsDescription/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});

$("#interview").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "مقابلة") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjectsDescription/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }
    }
});


$("#new").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "جديد") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "' class='customerSta'><span style='position: relative'> "
                + AllCustomer[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td>"
                + "<td>"
                + "<a class='btn btn-primary' href='../Customer/ShowProjectsDescription/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});
