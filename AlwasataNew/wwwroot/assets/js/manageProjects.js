var AllProject = [];
var AllCustomer = [];
var AllCompanies = [];
$(async () => {

    await $.get("GetAllProjects", {}, function (data) {
        for (let i = 0; i < data.length; i++) {
            AllProject.push(data[i]);
        }
    });

    await $.get("GetAllCustomer", {}, function (data) {
        for (let i = 0; i < data.length; i++) {
            AllCustomer.push(data[i]);
        }
    });

    await $.get("GetAllCompanies", {}, function (data) {
        for (let i = 0; i < data.length; i++) {
            AllCompanies.push(data[i]);
        }
    });

    $("#ProjectTbody").empty();
    

    for (let i = 0; i < AllProject.length; i++) {
        if (AllProject[i].isDone != true) {
            for (let j = 0; j < AllCustomer.length; j++) {
                if (AllCustomer[j].id == AllProject[i].customerId) {
                    var customerName = AllCustomer[j].customerName;
                    var followBy = AllCustomer[j].followBy;
                    var now = moment();
                    var publishedDate = moment(new Date(AllProject[i].createdAt));
                    if (AllCustomer[j].followBy == null) {
                        $("#ProjectTbody").append("<tr><td>" + AllProject[i].id + "</td><td>" + moment.duration(publishedDate.diff(now)).humanize(true) + "</td><td>" + AllProject[i].description + "</td><td>" + customerName + "</td><td>" + followBy + "</td><td style='color:darkcyan'> متابع </td><td><a class='btn btn-primary' href='../Customer/ShowProjectsDescription?projId=" + AllProject[i].id + "'>تفاصيل المشروع</a></td></tr>");
                    }
                }
            }
        }
    }
});

document.getElementById("Done").addEventListener("click", function () {
    $("#ProjectTbody").empty();
    $(".thChange").text("متابع من قبل");
    for (let i = 0; i < AllProject.length; i++) {
        if (AllProject[i].isDone == true) {
            for (let j = 0; j < AllCustomer.length; j++) {
                if (AllCustomer[j].id == AllProject[i].customerId) {
                    var customerName = AllCustomer[j].customerName;
                    var followBy = AllCustomer[j].followBy;
                }
            }
            var now = moment();
            var publishedDate = moment(new Date(AllProject[i].createdAt));
            $("#ProjectTbody").append("<tr><td>" + AllCustomer[i].id + "</td><td>" + moment.duration(publishedDate.diff(now)).humanize(true) + "</td><td>" + AllProject[i].description + "</td><td>" + customerName + "</td><td>" + followBy + "</td><td style='color:darkgreen'> تم التسليم</td><td><a class='btn btn-primary' href='../Customer/ShowProjectsDescription?projId=" + AllProject[i].id + "'>تفاصيل المشروع</a></td></tr>");
        }
    }
});

document.getElementById("Proccess").addEventListener("click", function () {
    $("#ProjectTbody").empty();
    $(".thChange").text("متابع من قبل");
    for (let i = 0; i < AllProject.length; i++) {
        if (AllProject[i].isDone != true) {
            for (let j = 0; j < AllCustomer.length; j++) {
                if (AllCustomer[j].id == AllProject[i].customerId) {
                    var customerName = AllCustomer[j].customerName;
                    var followBy = AllCustomer[j].followBy;
                    var workType = AllCustomer[j].workType;
                    if (AllCustomer[j].followBy != null) {
                        var now = moment();
                        var publishedDate = moment(new Date(AllProject[i].createdAt));
                        $("#ProjectTbody").append("<tr><td>" + AllProject[i].id + "</td><td>" + moment.duration(publishedDate.diff(now)).humanize(true) + "</td><td>" + AllProject[i].description + "</td><td>" + customerName + "</td><td>" + followBy + "</td><td style='color:darkcyan'> متابع </td><td><a class='btn btn-primary' href='../Customer/ShowProjectsDescription?projId=" + AllProject[i].id + "'>تفاصيل المشروع</a></td></tr>");
                    }
                }
            }
        }
    }
});

document.getElementById("UnFollow").addEventListener("click", function () {
    $("#ProjectTbody").empty();
    $(".thChange").text("تابع لشركة ");
    for (let i = 0; i < AllCustomer.length; i++) {
        if (AllCustomer[i].followBy == null) {
            for (let j = 0; j < AllProject.length; j++) {
                if (AllProject[j].customerId == AllCustomer[i].id) {
                    var companyName = "";
                    for (let c = 0; c < AllCompanies.length; c++) {
                        if (AllCompanies[c].id == AllCustomer[i].companyId) {
                            companyName = AllCompanies[c].name;
                        }
                    }
                    var now = moment();
                    var publishedDate = moment(new Date(AllProject[i].createdAt));
                    $("#ProjectTbody").append("<tr><td>" + AllProject[j].id + "</td><td>" + moment.duration(publishedDate.diff(now)).humanize(true) + "</td><td>" + AllProject[j].description + "</td><td>" + AllCustomer[i].customerName + "</td><td>" + companyName + "</td><td style='color:darkred'>غير متابع </td><td><a class='btn btn-primary' href='../Customer/ShowProjectsDescription?projId=" + AllProject[j].id + "'>تفاصيل المشروع</a></td></tr>");
                }
            }
        }
    }
});