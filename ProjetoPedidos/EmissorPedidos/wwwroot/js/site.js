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

function CarregarMunicipios(ddl) {
    var url = "/Util/GetMunicipios";
    $.get(url, function (data) {
        $.each(data, function () {
            ddl.append($("<option>").val(this.id).text(this.nome));
        });
    });
}

function CarregarEstados(ddl) {  
    var url = "/Util/GetEstados";
    $.get(url, function (data) {
        $.each(data, function () {
            ddl.append($("<option>").val(this.id).text(this.uf));
        });
    });
}

function CarregarPaises(ddl) {
    var url = "/Util/GetPaises";
    $.get(url, function (data) {
        $.each(data, function () {
            ddl.append($("<option>").val(this.id).text(this.nome));
        });
    });
}

function CarregarUsuarios(ddl, id) {
    $.get("/Util/GetUsuarioLogado", function (data) {
        console.log(data);        
        ddl.val(data.apelido);
        id.val(data.id);
    });
}

