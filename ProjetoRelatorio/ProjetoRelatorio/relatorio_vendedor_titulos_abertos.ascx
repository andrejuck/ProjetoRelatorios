<%@ Control Language="C#"%>
<%@ Import Namespace="B2bClasses" %>
<%@ Register TagPrefix="Dados" Namespace="b2b_gestao" Assembly="b2b_gestao" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="ClosedXML.Excel" %>
<%@ Import Namespace="System.Collections.Generic" %>

<link rel="stylesheet" href="../css/mensagemSistema.css" />
<style type="text/css">
    .auto-style14 {
        width: 307px;
        text-align: left;
        font-weight: 700;
    }
    .auto-style15 {
        width: 300px;
        height: auto;
    }
    .auto-style16 {
        font-weight: bold;
    }
    .auto-style17 {
        height: 101px;
        font-weight: bold;
    }
    .auto-style20 {
        width: 400px;
        height: auto;
    }
    .grid_periodo tr:not(:first-child):not(:last-child):hover td { 
	    background-color: #bbd5e3 !Important;
	}

</style>
<script runat="server">
    #region .: Metodos :.

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            LoadFiltroDatas();
            b2bClasses.Filtro.Load(b2bClasses.TipoFiltro.Empresa, ddlEmpresa);
            b2bClasses.Filtro.Load(b2bClasses.TipoFiltro.Vendedor, lstVendedores, "codigo_usuario", "usuario");
            //b2bClasses.Filtro.Load(b2bClasses.TipoFiltro.Cliente, lstClientes, "cnpj", "razao_social");
        }
    }


    protected void LoadFiltroDatas()
    {
        DateTime dataInicial = new DateTime();
        DateTime dataFinal = new DateTime();

        dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month, 1);
        dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        txt_inicio.Text = dataInicial.ToShortDateString();
        txt_final.Text = dataFinal.ToShortDateString();
    }

    protected string MontarConsulta()
    {
        string retorno_consulta = string.Empty;
        string data_inicio = txt_inicio.Text;
        string data_final = txt_final.Text;
        int vendedorSelecionado = Convert.ToInt32(lstVendedores.SelectedValue);
        int idEmpresa = Convert.ToInt32(ddlEmpresa.SelectedValue);

        string filtrosDescricao = b2bClasses.Filtro.SplitInDescription(b2bClasses.TipoFiltro.Empresa, ddlEmpresa);
        filtrosDescricao += b2bClasses.Filtro.SplitInDescription(data_inicio, data_final);
        filtrosDescricao += b2bClasses.Filtro.SplitInDescription(b2bClasses.TipoFiltro.Vendedor, lstVendedores);

        

        retorno_consulta += " SELECT ";
        retorno_consulta += " (SELECT usuario FROM usuarios WHERE codigo_usuario = ped.codigo_vendedor AND vendedor = 1) AS usuario, ";
        retorno_consulta += " sum(cpr.valor+ cpr.juros + cpr.multa - cpr.desconto) as titulos_totais, ";
        retorno_consulta += " (sum((cpr.valor + ISNULL(cpr.multa, 0) + ISNULL(cpr.juros, 0) -ISNULL(cpr.desconto, 0))) - sum(cpr.valor_pago)) as titulos_abertos, ";
        retorno_consulta += " CAST(100 - ((sum(cpr.valor_pago) / sum( cpr.valor + ISNULL(cpr.multa, 0) + ISNULL(cpr.juros, 0) -ISNULL(cpr.desconto, 0)) ) * 100) as decimal(16,2)) as indice ";
        retorno_consulta += " FROM Contas_pagar_receber cpr ";
        retorno_consulta += " INNER JOIN Pedidos ped ON ped.id_pedido = cpr.id_pedido ";
        if (!string.IsNullOrEmpty(data_inicio) && !string.IsNullOrEmpty(data_final))
            retorno_consulta += " WHERE CONVERT(DATE, vencimento, 103) BETWEEN CONVERT(DATE, '" + data_inicio + "', 103) AND CONVERT(DATE, '" + data_final + "', 103) ";
        else
            retorno_consulta += " WHERE ped.id_pedido is not null ";
        if(idEmpresa > 0)
            retorno_consulta += " AND ped.id_empresa = " + idEmpresa;

        if (vendedorSelecionado > 0)
            retorno_consulta += " AND codigo_vendedor = " + vendedorSelecionado + " ";

        retorno_consulta += " GROUP BY ped.codigo_vendedor";
        retorno_consulta += " ORDER BY ped.codigo_vendedor ";

        new MensagemSistemaAviso(pnlMsg, "<strong>FILTROS APLICADOS - </strong>" + filtrosDescricao);

        return retorno_consulta;
    }

    protected void BuscaMensal()
    {
        SqlConnection conexao = new SqlConnection(ConfigurationSettings.AppSettings["strcon"]);
        SqlCommand comando = new SqlCommand();

        comando.CommandText = MontarConsulta();

        try
        {
            conexao.Open();
            comando.Connection = conexao;
            dgPeriodo.DataSource = comando.ExecuteReader();
            dgPeriodo.DataBind();

            dgPeriodo.Visible = (dgPeriodo.Items.Count > 0);
            lblSemRegistros.Visible = !dgPeriodo.Visible;

            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            comando.Dispose();
            conexao.Close();
        }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (!dgPeriodo.Visible)
            return;

        using (XLWorkbook excel = new XLWorkbook())
        {
            using (var sheet = excel.Worksheets.Add("Plan1"))
            {
                DataSet ds = new DataSet();
                if(dgPeriodo.Visible)
                {
                    DataTable dt = new DataTable();
                    int qtdCol = 0;
                    foreach(DataGridColumn col in dgPeriodo.Columns)
                    {
                        if (col.Visible)
                        {
                            dt.Columns.Add(col.HeaderText);
                            qtdCol += 1;
                        }
                    }

                    object[] cellValues = new object[qtdCol];
                    for (int i = 0; i < dgPeriodo.Items.Count; i++)
                    {
                        int indexCelula = 0;
                        for (int j = 0; j < dgPeriodo.Columns.Count; j++)
                        {
                            if (dgPeriodo.Columns[j].Visible)
                            {
                                cellValues[indexCelula] = dgPeriodo.Items[i].Cells[j].Text.Replace("&nbsp;", "").Replace("<b>", "").Replace("</b>", "").Replace("R$ ", "");
                                indexCelula += 1;
                            }
                        }
                        dt.Rows.Add(cellValues);
                    }
                    ds.Tables.Add(dt);

                }

                //Percorre todas as DataTable do DataSet e adiciona na panilha do excel(Plan1)
                Int32 posX = 1, posY = 1;
                foreach (DataTable tab in ds.Tables)
                {
                    foreach (DataColumn coluna in tab.Columns)
                    {
                        //Adiciona o header do DataTable
                        sheet.Cell(posX, posY).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        sheet.Cell(posX, posY).Style.Font.Bold = true;
                        sheet.Cell(posX, posY).Style.Fill.BackgroundColor = XLColor.BlueGray;
                        sheet.Cell(posX, posY).Value = coluna.ColumnName;
                        posY += 1;
                    }
                    posX += 1;
                    posY = 1;

                    foreach (DataRow linha in tab.Rows)
                    {
                        //Adiciona os itens do DataTable
                        foreach (DataColumn coluna in tab.Columns)
                        {
                            sheet.Cell(posX, posY).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            sheet.Cell(posX, posY).Value = linha[coluna].ToString();
                            posY += 1;
                        }

                        posX += 1;
                        posY = 1;
                    }

                    for (int i = 1; i <= tab.Columns.Count; i++)
                    {
                        sheet.Cell(posX, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        sheet.Cell(posX, i).Style.Font.Bold = true;
                        sheet.Cell(posX, i).Style.Fill.BackgroundColor = XLColor.BlueGray;
                        if (i == 1)
                        {
                            sheet.Cell(posX, i).Value = "Totais >>";
                        }
                        else
                        {
                            int div = i;
                            string colLetter = String.Empty;
                            int mod = 0;

                            while (div > 0)
                            {
                                mod = (div - 1) % 26;
                                colLetter = (char)(65 + mod) + colLetter;
                                div = (int)((div - mod) / 26);
                            }

                            string formula = "=SUM(" + colLetter + "2:" + colLetter + (posX - 1) + ")";
                            sheet.Cell(posX, i).FormulaA1 = formula;

                            if (tab.Columns[i - 1].Caption.Contains("Fat"))
                            {
                                sheet.Cell(posX, i).Style.NumberFormat.Format = "R$ #,##0.00";
                            }
                        }
                    }

                    posX += 2;
                    posY = 1;
                    sheet.Columns().AdjustToContents();
                }
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=relatorio_vendedor_titulos_abertos" + DateTime.Now.ToShortDateString() + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                excel.SaveAs(MyMemoryStream);
                excel.Dispose();
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }

    protected void Buscar_Click(object sender, EventArgs e)
    {
        BuscaMensal();
    }
    #endregion
</script>
<table align="center" cellspading="0" cellspacing="0" width="99%" >
    <tbody>
        <tr>
            <td style="border-bottom: #becbad 2px solid; height: 23px">
                <font color="#8c8c8c"><strong>Relatório Vendedores por Títulos</strong></font>
            </td>            
            <td style="border-bottom: #becbad 2px solid; height: 23px">
                <p align="center">
                    [<span style="font-size: 7pt"> </span>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="default.aspx?pagina=relatorios"> Todos os relatórios </asp:HyperLink>
                    ]&nbsp;
                </p>
            </td>
            <td style="font-size: 12pt; border-bottom: #becbad 2px solid; height: 23px">
                <p align="right">
                    &nbsp; &nbsp;&nbsp;<a href="#"></a>
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="btnExcel" runat="server" AlternateText="Exportar para o Excel"
                        CssClass="sem_borda" ImageUrl="imgs/excel1.gif" OnClick="btnExcel_Click" ToolTip="Exportar para o Excel (.xlsx)" />
                </p>
            </td>
        </tr>
    </tbody>
</table>
<table align="center" cellpadding="0" cellspacing="0" class="top2_busca" style="font-size: 12pt"
    width="99%">
    <tbody>
        <tr bgcolor="#bbd5e3">
            <td colspan="2" height="30">
                <p>
                    <table cellpading="4">
                        <tbody>                            
                            <tr>                                
                                <td>
                                    <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" CssClass="auto-style14" />
                                    <br />
                                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="215px"  Height="21px"  />
                                </td>
                                <td class="auto-style15" rowspan="2">
                                    <asp:Label ID="lblVendedores" runat="server" CssClass="auto-style17" Text="Vendedores:"></asp:Label>
                                    <asp:ListBox ID="lstVendedores" runat="server" SelectionMode="Multiple" Width="100%">
                                    </asp:ListBox>
                                </td>                                                                                       
                            </tr>
                            <tr>
                                <td style="width: 240px">
                                    &nbsp;<asp:Label ID="lblPeriodo" runat="server"  Text="Período Vencimento:" CssClass="auto-style14"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txt_inicio" runat="server" Width="104px" CssClass="tcal" Height="21px" />
                                    <asp:TextBox ID="txt_final" runat="server" Width="104px" CssClass="tcal" Height="21px" />                                   
                                </td>  
                                <td colspan="1" style="text-align: center">
                                    <asp:Button ID="Buscar" runat="server" Text="Buscar" Height="39px" Width="88px" OnClick="Buscar_Click" />

                                    <br />
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </p>
            </td>
        </tr>
    </tbody>
</table>
<asp:Panel runat="server" ID="pnlMsg">
    
</asp:Panel>

<div align="center">
    <asp:DataGrid ID="dgPeriodo" runat="server"
        CellPadding="4" CssClass="gradiente grid_periodo" ForeColor="White" HorizontalAlign="Center"
        PageSize="12" Width="99%" ShowFooter="True" AutoGenerateColumns="False">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
        VerticalAlign="Middle" />
        <EditItemStyle BackColor="#999999" />
        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
        <Columns>   
            <asp:BoundColumn HeaderText="Vendedor" DataField="usuario" >
                <HeaderStyle Width="10%" HorizontalAlign="Left"/>
                <ItemStyle HorizontalAlign="Left" />                
            </asp:BoundColumn>           
            <asp:BoundColumn HeaderText="Titulos Totais" DataField="titulos_totais" DataFormatString="R$ {0}" >
                <HeaderStyle Width="15%" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Titulos Em Aberto" DataField="titulos_abertos" DataFormatString="R$ {0}" >
                <HeaderStyle Width="15%" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="% em aberto" DataField="indice" DataFormatString="{0}%" >
                <HeaderStyle Width="20%" />
            </asp:BoundColumn>
        </Columns>
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
        VerticalAlign="Middle" />
    </asp:DataGrid>
</div>
<div align="center">
    <asp:Label ID="lblSemRegistros" runat="server" Text="Sem Registros!" Visible="False" Font-Bold="True" Font-Size="14pt"></asp:Label>
</div>
<p>
    <br />
</p>