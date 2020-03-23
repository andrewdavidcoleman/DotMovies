function saveMovie(id, element, event) {
    $(element).toggleClass('saved');
    $.ajax({
        type: "POST",
        url: "/Saved?handler=Save",
        data: { id },
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        success: function (res) {
            console.log(res)
        }
    });
}