const FormataDecimal = $.fn.dataTable.render.number('.', ',', 2);
const FormataPorcentagem = $.fn.dataTable.render.number('.', ',', 2, '', '%');

$('#example').DataTable({
    processing: true,
    serverSide: true,
    ajax: {
        type: "POST",
        url: "/Relatorio/GetData",
        dataType: 'json'
    },
    columns: [
        { "data": "usuario" },
        { "data": "titulosAbertos" },
        { "data": "titulosTotais", render: FormataDecimal},
        { "data": "indiceEmAberto", render: FormataPorcentagem }        
    ],
    columnDefs: [
        { targets: [1, 2], className: "text-right" },
        { targets: 3, className: "text-center" }
    ]
});