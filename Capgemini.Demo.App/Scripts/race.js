
$(document).ready(function ()
{
    var name = $("input:radio:checked").attr('name');
    var checkedtyp = $("input:radio:checked").val();
    $.ajax({
        url: "/Home/_AzureCloud",
        type: 'GET',
        data: { platform: checkedtyp },
        success: function (partialView) {
            $("#Azurecloudui").html('')
            //$("#Amazoncloudui").html('')
            //$("#OnPremise").html('')
            $("#Azurecloudui").html(partialView)
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
    //$("input[name="+ name +"]:radio").change(function (e)
    //{
    //    var checkedtyp = $('input:radio[name]:checked').val()
    //    if (checkedtyp == "Azure") {
    //        $.ajax({
    //            url: "/Home/_AzureCloud",
    //            type: 'Post',
    //            data: { platform: checkedtyp },
    //            success: function (partialView) {
    //                $("#Azurecloudui").html('')
    //                //$("#Amazoncloudui").html('')
    //                //$("#OnPremise").html('')
    //                $("#Azurecloudui").html(partialView)
    //            },
    //            error: function () {
    //                alert("An error has occured!!!");
    //            }
    //        });
    //    }
    //    if (checkedtyp == "Amazon") {
    //        $.ajax({
    //            url: "/Home/_AmazonCloud",
    //            type: 'Post',
    //            data: { platform: checkedtyp },
    //            success: function (partialView) {
    //                $("#Amazoncloudui").html('')
    //                $("#OnPremise").html('')
    //                $("#Azurecloudui").html('')
    //                $("#Amazoncloudui").html(partialView)
    //            },
    //            error: function () {
    //                alert("An error has occured!!!");
    //            }
    //        });
    //    }
    //    if (checkedtyp == "OnPremise") {
    //        $.ajax({
    //            url: "/Home/_OnPremises",
    //            type: 'Post',
    //            data: { platform: checkedtyp },
    //            success: function (partialView) {
    //                $("#OnPremises").html('')
    //                $("#Azurecloudui").html('')
    //                $("#Amazoncloudui").html('')
    //                $("#OnPremise").html(partialView)
    //            },
    //            error: function () {
    //                alert("An error has occured!!!");
    //            }
    //        });
    //    }
    //});


    $('#someButton').click(function() {
        var list = [];
        $('.MyDiv input:checked').each(function ()
        {
            debugger;
            var a= $("input:checkbox:checked").attr('name');
           // var b=$("input:radio:checked").val();
            list.push($("input:checkbox:checked").attr('name'));
        });
        console.log(list)
        // now names contains all of the names of checked checkboxes
        // do something with it for excamle post with ajax
        $.ajax({
            url: '/Home/Cloud',
            type: 'POST',
            data: { Parameters: list},
            success: function (result) {
                alert("success")
                },
            error: function (result) {
                alert("error!");
            }
        });   //end ajax
    });


});

    