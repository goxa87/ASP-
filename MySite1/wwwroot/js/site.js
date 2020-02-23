// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('.work-comment-container-topmenu').click(function () {

        var body1 = $(this).parents('.work-comment-container').children('.work-comment-add');
        var body2 = $(this).parents('.work-comment-container').children('.work-comment-all');
        var arrow = $(this).children('.arrow');
        if ($('.work-comment-add').css('display') == 'block')
        {
            $(body1).css({ 'display': 'none' });
            $(body2).css({ 'display': 'none' });
            $(arrow).css('transform', 'rotate(0deg)');
        }
        else
        {
            $(body1).css({ 'display': 'block' });
            $(body2).css({ 'display': 'block' });
            $(arrow).css('transform', 'rotate(90deg)');
        }
    });
});

$(function () {
    $('.work-picture-static').click(function () {
        $(this).toggleClass('work-picture-max');
        $(this).toggleClass('work-picture-min');
    });
});


$(function () {
    $('.menu-small-size').click(function () {
        $('#side-menu').toggleClass('show-side-menu');
    });
});