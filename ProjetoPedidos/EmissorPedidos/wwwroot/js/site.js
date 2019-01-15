// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var toggleSideBar = $("#toggleSideBar");
$(function () {    
    toggleSideBar.on("click", showHideSideBar);
});

function showHideSideBar () {
    $(".ui.sidebar").sidebar("toggle");
}

function CarregarEstados(NomeController, NomeMetodo) {  
    var url = `/${NomeController}/${NomeMetodo}`;

    $.get(url, function (data) {
        $.each(data, function () {
            $("#dropdownEstado").append($("<option>").val(this.id).text(this.uf));
        });
    });
}

function CarregarPaises(NomeController, NomeMetodo) {
    var url = `/${NomeController}/${NomeMetodo}`;
    $.get("/Empresa/GetPaises", function (data) {
        $.each(data, function () {
            $("#dropdownPais").append($("<option>").val(this.id).text(this.nome));
        });
    });
}