
$(document).ready(function () {
    //Scroll to ID
    $("#AddUser").click(function () {
        $('html, body').animate({
            scrollTop: $("#User").offset().top
        }, 2000);
    });
    //Cancel Add Form
    $('#Cancel').click(function () {
        $('#username').val("");
        $('#password').val("");
        $('#repass').val("");
        $('#User').hide();
        $('html, body').animate({   
            scrollTop: $('body').offset().top
        }, 2000);
    });
    //Change status UserAdmin
    $(document).on('click', '.change', function () {
        var id = $(this).attr('id');
        $.ajax({
            type: 'POST',
            data: { "ID": id },
            url: 'ChangeStatus',
            success: function (respone) {
                $('#tr-' + id + '').replaceWith(respone);
            }
        })
    })
    //Thêm mới UserAdmin
    $('#Add').click(function () {
        var uname = $('#username').val();
        var upass = $('#password').val();
        var rep = $('#repass').val();
        if (uname.trim() == "") {
            $('#message').html("Username không được để trống!");
            return;
        }
        if (upass.trim() == "") {
            $('#message').html("Password không được để trống!");
            return;
        }
        if (rep != upass) {
            $('#message').html("Mật khẩu không khớp!");
            return;
        }
        var Create = {
            "Username": uname,
            "Password": upass,
            "Status": true,
        }
        $.ajax({
            type: 'POST',
            data: Create,
            url: "AddUser",
            success: function (respone) {
                var newitem = '<tr id="tr-' + respone.ID +'"><th>' + respone.Username + '</th><th><input type="checkbox" checked=' + respone.Status + ' disabled /></th><th><button class="change btn-primary" id=' + respone.ID + '>' + (respone.Status ? "Vô hiệu hóa" : "Kích hoạt") + '</button></th></tr>';
                $('#table-user').append(newitem);
                $('#username').val("");
                $('#password').val("");
                $('#repass').val("");
                $('#message').html(respone.Message);
                setTimeout(function () {
                    $("#User").fadeOut('fast')
                    $('#message').hide()
                }, 3000);
            }
        })
    });
});
