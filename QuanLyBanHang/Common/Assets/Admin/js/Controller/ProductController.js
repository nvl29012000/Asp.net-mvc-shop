/// <reference path="../../../../../scripts/ckeditor/config.js" />
//Setup Ckeditor và Ckfinder
$(document).ready(function () {
    var editor = CKEDITOR.replace('product-description', {
        customConfig: '../../../../../scripts/ckeditor/config.js',
    });
    var editor1 = CKEDITOR.replace('product-detail', {
        customConfig: '../../../../../scripts/ckeditor/config.js',
    });
    editor.setData($('#product-description').val());
    editor1.setData($('#product-detail').val());


    $('#select-image').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $('#product-image').val(url);
        };
        finder.popup();
    })
})



$(document).ready(function () {

    //Replace based on selected category
    $('#base-product-category').on('change', function () {
        var id = $('#base-product-category').val();
        $.ajax({
            type: 'POST',
            data: { "ID": id },
            url: 'ListSubCategory',
            success: function (respone) {
                $('#replace-table').replaceWith(respone);
            }
        })
    })

    //Replace product base on selected category
    $('#base-product').on('change', function () {
        var id = $('#base-product').val();
        $.ajax({
            type: 'POST',
            data: { "ID": id },
            url: 'ListSubProduct',
            success: function (respone) {
                $('#replace-table').replaceWith(respone);
            }
        })
    })

    //Thêm mới danh mục sản phẩm
    $('#CreateProductCategory').on('click', function (e) {
        e.preventDefault();
        var Name = $('#productcategory-name').val();
        var parentid = $('#productcategory-parentid').val();
        var order = $('#productcategory-order').val();
        var seo = $('#productcategory-seo').val();
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
            url: 'Create',
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

    //Sửa danh mục sản phẩm
    $('#EditProductCategory').on('click', function (e) {
        e.preventDefault();
        var ID = $('#productcategoryID').val();
        var Name = $('#productcategory-name').val();
        var Title = $('#productcategory-title').val();
        var parentid = $('#productcategory-parentid').val();
        var order = $('#productcategory-order').val();
        var seo = $('#productcategory-seo').val();
        var metakeyword = $('#metakeyword').val();
        var metadescription = $('#metadiscription').val();
        var show = document.getElementById('showonhome').checked;
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        var Edit = {
            "ID": ID,
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
            url: 'Edit',
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

    //Thêm mới sản phẩm
    $('#CreateProduct').on('click', function (e) {
        e.preventDefault();
        var Name = $('#product-name').val();
        var Code = $('#product-code').val();
        var Description = CKEDITOR.instances['product-description'].getData();
        var Image = $('#product-image').val();
        var MoreImage = $('#product-moreimage').val();
        var Price = $('#product-price').val();
        var SalePrice = $('#product-saleprice').val();
        var Quantity = $('#product-quantity').val();
        var CategoryID = $('#product-category').val();
        var Details = CKEDITOR.instances['product-detail'].getData();
        var SaleDate = $('#Saledate').val();
        var metakeyword = $('#product-metakeyword').val();
        var metadescription = $('#product-metadescription').val();
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        if (Price.trim() == "" || Price <=0 ) {
            $('#message').html("Giá phải là số lớn hơn 0 và không được để trống");
            return;
        }
        if (Quantity == "" || Quantity <= 0) {
            $('#message').html("Số lượng phải là số lớn hơn 0 và không được để trống");
            return;
        }
        if (CategoryID == "") {
            $('#message').html("Danh mục không được để trống");
            return;
        }
        var Create = {
            "Name": Name,
            "ProductCode": Code,
            "Description": Description,
            "Image": Image,
            "DetailImage": MoreImage,
            "Price": Price,
            "SalePrice": SalePrice,
            "Quantity": Quantity,
            "CategoryID": CategoryID,
            "ProductDetail": Details,
            "SaleDate": SaleDate,
            "MetaKeyword": metakeyword,
            "MetaDescription": metadescription,
            "Status": status
        }

        $.ajax({
            type: 'POST',
            data: Create,
            url: 'CreateProduct',
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

    //Sửa sản phẩm
    $('#EditProduct').on('click', function (e) {
        e.preventDefault();
        var ID = $('#productID').val();
        var Name = $('#product-name').val();
        var Code = $('#product-code').val();
        var Title = $('#product-title').val();
        var Description = CKEDITOR.instances['product-description'].getData();
        var Image = $('#product-image').val();
        var MoreImage = $('#product-moreimage').val();
        var Price = $('#product-price').val();
        var SalePrice = $('#product-saleprice').val();
        var Quantity = $('#product-quantity').val();
        var CategoryID = $('#product-category').val();
        var Details = CKEDITOR.instances['product-detail'].getData();
        var SaleDate = $('#Saledate').val();
        var metakeyword = $('#product-metakeyword').val();
        var metadescription = $('#product-metadescription').val();
        var status = document.getElementById('status').checked;

        if (Name.trim() == "") {
            $('#message').html("Tên không được để trống");
            return;
        }
        if (Price.trim() == "" || Price <= 0) {
            $('#message').html("Giá phải là số lớn hơn 0 và không được để trống");
            return;
        }
        if (Quantity == "" || Quantity <= 0) {
            $('#message').html("Số lượng phải là số lớn hơn 0 và không được để trống");
            return;
        }
        if (CategoryID == "") {
            $('#message').html("Danh mục không được để trống");
            return;
        }
        var Edit = {
            "ID": ID,
            "Name": Name,
            "ProductCode": Code,
            "Title": Title,
            "Description": Description,
            "Image": Image,
            "DetailImage": MoreImage,
            "Price": Price,
            "SalePrice": SalePrice,
            "Quantity": Quantity,
            "CategoryID": CategoryID,
            "ProductDetail": Details,
            "SaleDate": SaleDate,
            "MetaKeyword": metakeyword,
            "MetaDescription": metadescription,
            "Status": status
        }

        $.ajax({
            type: 'POST',
            data: Edit,
            url: 'EditProduct',
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