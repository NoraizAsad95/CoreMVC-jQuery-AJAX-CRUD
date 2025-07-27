// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }

    })
}
jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#form-modal").modal('hide');
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#view-all").html(res.html);
                }
                else {
                    $("#form-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
        return false;
    } catch (ex) {
        console.log(ex);
    }
}

jQueryAjaxDelete = form => {
    if (confirm('Are you sure want to delete this record?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                       $("#view-all").html(res.html);
                    
                },
                error: function (err) {
                    console.log(err);
                }
            })
           
        } catch (ex) {
            console.log(ex);
        }
    }
    return false;
}