/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
        //config.language = 'vi';
    // config.uiColor = '#AADC6E';
    config.entities_latin = false;
    config.filebrowserBrowseUrl = '/Scripts/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Scripts/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Scripts/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Scripts/ckfinder/connector.ascx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Scripts/ckfinder/userfiles';
    config.filebrowseFlashUploadUrl = '/Scripts/ckfinder/connector.ascx?command=QuickUpload&type=Flash';
    CKFinder.setupCKEditor( null,'/Scripts/ckfinder/');
};
