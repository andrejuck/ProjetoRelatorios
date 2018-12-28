$('#example').DataTable({
    processing: true,
    serverSide: true,
    ajax: {
        type: "POST",
        url: "/Relatorio/GetData",
        dataType: 'json',
    },
    columns: [
        { "data": "usuario" },
        { "data": "idPedido" },
        { "data": "idNotaFiscal" }
        
    ]
});