<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.ProgramaFranja.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <html>
    <head>

    </head>
    <body>
        <h2>Crear <small>Programa - Franja </small></h2>
        <asp:ValidationSummary ID="vsCrearProgramaFranja" runat="server" ForeColor="Red" />
        <table>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Programa"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdPrograma" runat="server" MaxLength="50" CssClass="form-control" Enabled="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNombrePrograma" runat="server" MaxLength="50" CssClass="form-control" Enabled="true" Width="200"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ErrorMessage="Debe ingresar un Programa" ForeColor="Red" ControlToValidate="txtIdPrograma">*</asp:RequiredFieldValidator>

                </td>
                <td>
                    <button id="btnBuscaPrograma" class="btn btn-warning BuscarPersona"  data-target="#buscarPrograma" onclick="return false">+</button>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblFranja" runat="server" Text="Franja"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdFranja" runat="server" MaxLength="50" CssClass="form-control" Enabled="true"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcionFranja" runat="server" MaxLength="50" CssClass="form-control" Enabled="true" Width="200"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvFranja" runat="server" ErrorMessage="Debe ingresar una Franja" ForeColor="Red" ControlToValidate="txtIdFranja">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <button id="btnBuscaPersona" class="btn btn-warning BuscarPersona"  data-target="#buscarPersona" onclick="return false">+</button>
                </td>
            </tr>
        </table>
        <br />
        <div class="form-actions">
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
            <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
        </div>
        <%--    MODAL BUSQUEDA fRANJA--%>
        <div class="modal fade" id="buscarPersona" tabindex="-1" role="dialog" aria-labelledby="busquedaPersonaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="busquedaPersonaLabel">Busqueda de Franja</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="persona" runat="server" />
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged"></asp:TextBox>
                                <asp:Button ID="btnBusqueda" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="IdFranjaHorario" HeaderText="IdFranjaHorario" SortExpression="IdFranjaHorario" />
                                        <asp:BoundField DataField="HoraInicio" HeaderText="HoraInicio" SortExpression="HoraInicio" />
                                        <asp:BoundField DataField="HoraFin" HeaderText="HoraFin" SortExpression="HoraFin" />
                                        <asp:BoundField DataField="DiaSemana" HeaderText="Direccion" SortExpression="DiaSemana" />
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">

                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>


                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="PersonasODS" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.FranjaHorarioServicio">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtBusqueda" Name="criterio" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="gvPersonas" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <div class="modal-footer">
                        <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </div>
        </div>

    
         <script type="text/javascript">

             $(document).ready(function () {
                 $('#btnBuscaPersona').click(function () {
                     $('#buscarPersona').modal('show');
                     $('#buscarPersona').find('#MainContent_persona').val('persona');
                 });
             });
        </script>

        <%--    MODAL BUSQUEDA Programa--%>
        <div class="modal fade" id="buscarPrograma" tabindex="-1" role="dialog" aria-labelledby="busquedaProgramaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="busquedaProgramaLabel">Busqueda de Programa</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="programa" runat="server" />
                                <asp:TextBox ID="txtBusquedaPrograma" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusquedaPrograma_TextChanged"></asp:TextBox>
                                <asp:Button ID="Button1" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvPrograma" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvPrograma_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="IdPrograma" HeaderText="IdPrograma" SortExpression="IdPrograma" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <%--<asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />--%>
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">

                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>


                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.ProgramasServicio">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtBusqueda" Name="criterio" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="gvPrograma" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <div class="modal-footer">
                        <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </div>
        </div>
                 <script type="text/javascript">

                     $(document).ready(function () {
                         $('#btnBuscaPrograma').click(function () {
                             $('#buscarPrograma').modal('show');
                             $('#buscarPrograma').find('#MainContent_programa').val('programa');
                         });
                     });
        </script>
    </body>
    </html>
</asp:Content>
