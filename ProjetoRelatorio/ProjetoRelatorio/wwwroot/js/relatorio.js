$('#example').DataTable({
    processing: true,
    serverSide: true,
    ajax: {
        type: "POST",
        url: "/Relatorio/GetData",
        dataType: 'json',
    },
    columns: [
        {"data": "numero_pedido"},
        {"data": "nota_fiscal"},
    ]
        
});