/// <reference path="../../../../../scripts/ckeditor/config.js" />
//Setup Ckeditor và Ckfinder
$(document).ready(function () {
    var editor = CKEDITOR.replace('new-description', {
        customConfig: '../../../../../scripts/ckeditor/config.js',
    });
    var editor1 = CKEDITOR.replace('new-detail', {
        customConfig: '../../../../../scripts/ckeditor/config.js',
    });
    editor.setData($('#new-description').val());
    editor1.setData($('#new-detail').val());


    $('#select-image').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $('#new-image').val(url);
        };
        finder.popup();
    })
})

$(document).ready(function () {
    //Replace new base on selected category
    $('#base-new').on('change', function () {
        var id = $('#base-new').val();
        $.ajax({
            type: 'POST',
            data: { "ID": id },
            url: 'ListSubNew',
            success: function (respone) {
                $('#replace-table').replaceWith(respone);
            }
        })
    })
    //Thêm mới danh mục tin tức
    $('#CreateNewCategory').on('click', function (e) {
        e.preventDefault();
        var Name = $('#newcategory-name').val();
        var Title = $('#newcategory-title').val();
        var parentid = $('#newcategory-parentid').val();
        var order = $('#newcategory-order').val();
        var seo = $('#newcategory-seo').val();
        var metakeyword = $('#metakeyword').val();
        var metadescription = $('#metadiscription').val();
        var show = document.getElementById('showonhome').checked;
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        var Create = {
            "Name": Name,
            "Title": Title,
            "ParentID": parentid,
            "DisplayOrder": order,
            "SeoTitle": seo,
            "MetaKeyword": metakeyword,
            "MetaDescription": metadescription,
            "ShowOnHome": show,
            "Status": status,
        }

        $.ajax({
            type: 'POST',
            data: Create,
            url: 'CreateNewCategory',
            success: function (respone) {
                if (respone.Status == false) {
                    alert(respone.Message);
                }
                else {
                    alert(respone.Message);
                    window.setTimeout(function () {
                        location.href = respone.url;
                    }, 1500);
                }
            }
        })
    })

    //Sửa danh mục tin tức
    $('#EditNewCategory').on('click', function (e) {
        e.preventDefault();
        var ID = $('#newcategoryID').val();
        var Name = $('#newcategory-name').val();
        var Title = $('#newcategory-title').val();
        var parentid = $('#newcategory-parentid').val();
        var order = $('#newcategory-order').val();
        var seo = $('#newcategory-seo').val();
        var metakeyword = $('#metakeyword').val();
        var metadescription = $('#metadiscription').val();
        var show = document.getElementById('showonhome').checked;
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        var Edit = {
            "ID" : ID,
            "Name": Name,
            "Title": Title,
            "ParentID": parentid,
            "DisplayOrder": order,
            "SeoTitle": seo,
            "MetaKeyword": metakeyword,
            "MetaDescription": metadescription,
            "ShowOnHome": show,
            "Status": status,
        }

        $.ajax({
            type: 'POST',
            data: Edit,
            url: 'EditNewCategory',
            success: function (respone) {
                if (respone.Status == false) {
                    alert(respone.Message);
                }
                else {
                    alert(respone.Message);
                    window.setTimeout(function () {
                        location.href = respone.url;
                    }, 1500);
                }
            }
        })
    })

    //Thêm mới tin tức
    $('#CreateNew').on('click', function (e) {
        e.preventDefault();
        var Name = $('#new-name').val();
        var Title = $('#new-title').val();
        var Description = CKEDITOR.instances['new-description'].getData();
        var Image = $('#new-image').val();
        var MoreImage = $('#new-moreimage').val();
        var CategoryID = $('#new-category').val();
        var Details = CKEDITOR.instances['new-detail'].getData();
        var metakeyword = $('#new-metakeyword').val();
        var metadescription = $('#new-metadescription').val();
        var Tag = $('#new-tag').val();
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        if (CategoryID == "") {
            $('#message').html("Danh mục không được để trống");
            return;
        }
        var Create = {
            "Name": Name,
            "Title": Title,
            "Description": Description,
            "Image": Image,
            "DetailImage": MoreImage,
            "CategoryID": CategoryID,
            "ProductDetail": Details,
            "MetaKeyword": metakeyword,
            "MetaDescription": metadescription,
            "Tag": Tag,
            "Status": status
        }

        $.ajax({
            type: 'POST',
            data: Create,
            url: 'CreateNew',
            success: function (respone) {
                if (respone.Status == false) {
                    alert(respone.Message);
                }
                else {
                    alert(respone.Message);
                    window.setTimeout(function () {
                        location.href = respone.url;
                    }, 1500);
                }
            }
        })
    })

    //Sửa tin tức
    $('#EditNew').on('click', function (e) {
        e.preventDefault();
        var ID = $('#newID').val();
        var Name = $('#new-name').val();
        var Title = $('#new-title').val();
        var Description = CKEDITOR.instances['new-description'].getData();
        var Image = $('#new-image').val();
        var MoreImage = $('#new-moreimage').val();
        var CategoryID = $('#new-category').val();
        var Details = CKEDITOR.instances['new-detail'].getData();
        var metakeyword = $('#new-metakeyword').val();
        var metadescription = $('#new-metadescription').val();
        var Tag = $('#new-tag').val();
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        if (CategoryID == "") {
            $('#message').html("Danh mục không được để trống");
            return;
        }
        var Create = {
            "ID" : ID,
            "Name": Name,
            "Title": Title,
            "Description": Description,
            "Image": Image,
            "DetailImage": MoreImage,
            "CategoryID": CategoryID,
            "ProductDetail": Details,
            "MetaKeyword": metakeyword,
            "MetaDescription": metadescription,
            "Tag": Tag,
            "Status": status
        }

        $.ajax({
            type: 'POST',
            data: Create,
            url: 'CreateNew',
            success: function (respone) {
                if (respone.Status == false) {
                    alert(respone.Message);
                }
                else {
                    alert(respone.Message);
                    window.setTimeout(function () {
                        location.href = respone.url;
                    }, 1500);
                }
            }
        })
    })
})