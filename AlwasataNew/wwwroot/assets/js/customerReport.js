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











$("#ok").click(() => {
    $("#TableBody").empty();

    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].customerState == "تعميد") {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].createdAt + "</td>"
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

$("#Follow").click(() => {
    $("#TableBody").empty();
    let count = 0;
    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].followBy != null && (AllCustomer[i].customerComeFrom == 'Internet' || AllCustomer[i].customerComeFrom =='حملات التسويق')) {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].createdAt + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td><td>" + AllCustomer[i].type + "</td><td>" + AllCustomer[i].customerState + "</td><td>" + AllCustomer[i].clientSource + "</td><td><a class='btn btn-outline-info' href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "'><i class='fa-regular fa-comment'></i></a></td>"
                + "</tr>");
            count++;
        }

    }
    document.getElementById("customerCount").innerHTML = count;
});

$("#UnFollow").click(() => {
    $("#TableBody").empty();
    let count = 0;
    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].followBy == null && (AllCustomer[i].customerComeFrom == 'Internet' || AllCustomer[i].customerComeFrom == 'حملات التسويق')) {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].createdAt + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td><td>" + AllCustomer[i].type + "</td><td>" + AllCustomer[i].customerState + "</td><td>" + AllCustomer[i].clientSource + "</td><td><a class='btn btn-outline-info' href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "'><i class='fa-regular fa-comment'></i></a></td>"
                + "</tr>");
            count++;
        }

    }
    document.getElementById("customerCount").innerHTML = count;
});

$("#FollowOther").click(() => {
    $("#TableBody").empty();
    let count = 0;
    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].followBy != null && (AllCustomer[i].customerComeFrom != 'Internet' && AllCustomer[i].customerComeFrom != 'حملات التسويق')) {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].createdAt + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td><td>" + AllCustomer[i].type + "</td><td>" + AllCustomer[i].customerState + "</td><td>" + AllCustomer[i].clientSource + "</td><td><a class='btn btn-outline-info' href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "'><i class='fa-regular fa-comment'></i></a></td>"
                + "</tr>");
            count++;
        }

    }
    document.getElementById("customerCount").innerHTML = count;
});

$("#UnFollowOther").click(() => {
    $("#TableBody").empty();
    let count = 0;
    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].followBy == null && (AllCustomer[i].customerComeFrom != 'Internet' && AllCustomer[i].customerComeFrom != 'حملات التسويق')) {
            $("#TableBody").append(
                "<tr><td>" + AllCustomer[i].customerName + "</td><td>" + AllCustomer[i].createdAt + "</td><td>" + AllCustomer[i].companyName + "</td><td>" + AllCustomer[i].phone + "</td><td>" + AllCustomer[i].type + "</td><td>" + AllCustomer[i].customerState + "</td><td>" + AllCustomer[i].clientSource + "</td><td><a class='btn btn-outline-info' href='../Customer/CustomerStateComment?customerId=" + AllCustomer[i].id + "'><i class='fa-regular fa-comment'></i></a></td>"
                + "</tr>");
            count++;
        }

    }
    document.getElementById("customerCount").innerHTML = count;
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