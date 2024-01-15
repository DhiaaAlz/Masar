var AllCustomer = [];
$.get("GetAllCustomer", {}, function (data) {
    for (let i = 0; i < data.length; i++) {
        AllCustomer.push(data[i]);
    }
});

$("#keyWord").keyup(() => {
    var key = $("#keyWord").val();

    $.get("GetAllCustomerWithKeyWord", { text: key }, function (data) {

        $("#TableBody").empty();

        for (let i = 0; i < data.length; i++) {
            $("#TableBody").append(
                "<tr><td>" + (i + 1) + "</td><td>" + data[i].customerName + "</td><td>" + new Date(data[i].createdAt).toLocaleDateString() + "</td><td>" + data[i].companyName + "</td><td>" + data[i].phone + "</td><td><a href='mailto: " + data[i].email + "' > " + data[i].email + "</a></td> <td>" + data[i].type + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + data[i].id + "' class='customerSta'><span style='position: relative'> "
                + data[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td><td>" + data[i].followBy + "</td><td>" + data[i].createdBy + "</td>"
                + "</tr>");
        }
    });

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

$("#answer").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "رد") {
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
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});



$("#ok").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "تعميد") {
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
                + "<a class='btn btn-primary' href='../Customer/ShowProjects/" + AllCustomer[i].id + "'>تفاصيل المشاريع </a> "
                + "<a class='btn btn-outline-primary' href='../Customer/EditInformation/" + AllCustomer[i].id + "'>تعديل معلومات العميل</a> "
                + "<a class='btn btn-outline-success' href='mailto: " + AllCustomer[i].email + "'>مراسلة العميل</a>"
                + "</td>"
                + "</tr>");
        }

    }
});


$("#btnBetween").click(function () {
    $("#towDate").fadeToggle();
});

$("#btnOk").click(function () {
    let startDate = $("#startD").val();
    let endDate = $("#endD").val();
    $.get("GetAllCustomersBetweenDate", { sDate: startDate, eDate: endDate }, function (data) {
        document.getElementById("customerCount").innerHTML = data.length;
        $("#TableBody").empty();

        for (let i = 0; i < data.length; i++) {
            $("#TableBody").append(
                "<tr><td>" + (i + 1) + "</td><td>" + data[i].customerName + "</td><td>" + new Date(data[i].createdAt).toLocaleDateString() + "</td><td>" + data[i].companyName + "</td><td>" + data[i].phone + "</td><td><a href='mailto: " + data[i].email + "' > " + data[i].email + "</a></td> <td>" + data[i].type + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + data[i].id + "' class='customerSta'><span style='position: relative'> "
                + data[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td><td>" + data[i].followBy + "</td><td>" + data[i].createdBy + "</td>"
                + "</tr>");
        }
    });
});


$("#btnYear").click(function () {
    $.get("GetAllCustomersLastYear", {}, function (data) {
        document.getElementById("customerCount").innerHTML = data.length;
        $("#TableBody").empty();

        for (let i = 0; i < data.length; i++) {
            $("#TableBody").append(
                "<tr><td>" + (i + 1) + "</td><td>" + data[i].customerName + "</td><td>" + new Date(data[i].createdAt).toLocaleDateString() + "</td><td>" + data[i].companyName + "</td><td>" + data[i].phone + "</td><td><a href='mailto: " + data[i].email + "' > " + data[i].email + "</a></td> <td>" + data[i].type + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + data[i].id + "' class='customerSta'><span style='position: relative'> "
                + data[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td><td>" + data[i].followBy + "</td><td>" + data[i].createdBy + "</td>"
                + "</tr>");
        }
    });
});

$("#btnMonth").click(function () {
    $.get("GetAllCustomersLastMonth", {}, function (data) {
        document.getElementById("customerCount").innerHTML = data.length;
        $("#TableBody").empty();

        for (let i = 0; i < data.length; i++) {
            $("#TableBody").append(
                "<tr><td>" + (i + 1) + "</td><td>" + data[i].customerName + "</td><td>" + new Date(data[i].createdAt).toLocaleDateString() + "</td><td>" + data[i].companyName + "</td><td>" + data[i].phone + "</td><td><a href='mailto: " + data[i].email + "' > " + data[i].email + "</a></td> <td>" + data[i].type + "</td>"
                + "<td>"
                + "<a href='../Customer/CustomerStateComment?customerId=" + data[i].id + "' class='customerSta'><span style='position: relative'> "
                + data[i].customerState
                + "<span class='addComm'>اضف تعليقاً</span></span></a></td><td>" + data[i].followBy + "</td><td>" + data[i].createdBy + "</td>"
                + "</tr>");
        }
    });
});