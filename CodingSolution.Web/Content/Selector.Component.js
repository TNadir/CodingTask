$(function () {
    var selectedData;
    $('#jstree').jstree({
        "core": {
            "multiple": true,
            "check_callback": false,
            'themes': {
                "responsive": true,
                'variant': 'larg',
                'stripes': false,
                'dots': false
            }
        },
        "checkbox": {
            "keep_selected_style": false
        },
        "types": {
            "default": {
                "icon": "fa fa-check icon-state-warning icon-lg"
            },
            "file": {
                "icon": "fa fa-file icon-state-warning icon-lg"
            }
        },
        "plugins": ["dnd", "state", "types", "sort", "checkbox"]
    }).on('changed.jstree', function (e, data) {
        selectedData = data.selected;
        // console.log(selectedData);
    });

    var $treeview = $("#jstree");

    $treeview.jstree("deselect_all");

   

    function Delete(ID) {
        var ans = confirm("Are you sure you want to delete this Sector?");
        if (ans) {
            $.ajax({
                url: "/Home/Delete/" + ID,
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    loadData();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    } 
    $("#getChecked").click(function () {

        var res = validate();

        if (res) {
            var dataObject = JSON.stringify(
                {
                    RegisterForm:
                        {
                            'Selector': selectedData,
                            'Name': $("#name").val(),
                            'Agree': $("#checkagree").is(':checked')
                        }
                });

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Home/RegisterForm",
                data: dataObject,
                dataType: "json",
                success: function (data) {
                    //var res = $.parseJSON(data);
                    //console.log(data);
                    if (data.StatusCode == 0) {
                        ShowMessage(data.Message, 2);
                        $('#lblname').text(data.Name);
                        var html = '';
                        $.each(data.Sectors, function (key, item) {
                            html += '<tr>';

                            html += '<td>' + item.SectorName + '</td>';

                            html += '<td> <a href="#" onclick="Delete(' + item.Id + ')">Delete</a></td>';
                            html += '</tr>';
                        });
                        $('.tbody').html(html);
                    } else {
                        ShowMessage(data.Message, 1);

                    }








                    // $("#myform").html("<h3>Json data: <h3>" + res.fname + ", " + res.lastname)
                },
                error: function (xhr, err) {
                    ShowMessage("readyState: " + xhr.readyState + "\nstatus: " + xhr.status + " \nResponse Text" + xhr.responseText, 1);
                    //alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                    //alert("responseText: " + xhr.responseText);
                }
            });

        }


    });

    $(document).ready(function () {
        loadData();
    }); 


    function loadData() {
        $.ajax({
            url: "/Home/List",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                var html = '';
                $.each(data.Sectors, function (key, item) {
                    html += '<tr>';

                    html += '<td>' + item.SectorName + '</td>';

                    html += '<td> <a href="/Home/Delete/1" id="btn" >Delete</a></td>';
                    html += '</tr>';

                    
                });
                $('.tbody').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }  

    function RemoveAllClass() {
        $('#msgbox').removeClass("alert");
        $('#msgbox').removeClass("alert alert-danger");
        $('#msgbox').removeClass("alert alert-success");
        $('#msgbox').text("");
    }

    function ShowMessage(msg, type) {
        RemoveAllClass();
        if (type == 1) {
            $('#msgbox').addClass("alert alert-danger");
            $('#msgbox').text(msg);
        } else if (type == 2) {
            $('#msgbox').addClass("alert alert-success");
            $('#msgbox').text(msg);
        }

        setTimeout(function () {
            RemoveAllClass();
        }, 3000);
    }


    function validate() {
        var isValid = true;

        if ($('#name').val().trim() == "") {
            isValid = false;
            ShowMessage("Name is mandatory field!", 1);

        } else
            if (selectedData.length == 0) {

                isValid = false;
                ShowMessage("Pick the Sectors you are currently involved in!", 1);
            } else
                if (!$("#checkagree").is(':checked')) {

                    isValid = false;
                    ShowMessage("You must to agree to terms!", 1);
                }

        return isValid;
    }


    //$.ajax({
    //    url: '/home/check',
    //    type: 'POST',
    //    data: {
    //        Address1: "423 Judy Road",
    //        Address2: "1001",
    //        City: "New York",
    //        State: "NY",
    //        ZipCode: "10301",
    //        Country: "USA"
    //    },
    //    contentType: 'application/json; charset=utf-8',
    //    success: function (data) {
    //        alert(data.success);
    //    },
    //    error: function () {
    //        alert("error");
    //    }
    //});


});


