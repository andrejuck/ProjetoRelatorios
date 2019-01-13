// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var prev = 0;
$(function () {
    $(window).on("scroll", function () {
        var scrollTop = $(window).scrollTop();
        $("#navbar").toggleClass("hidden", scrollTop > prev);
        prev = scrollTop;
    });
});