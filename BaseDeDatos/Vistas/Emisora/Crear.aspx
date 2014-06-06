<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.Emisora.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!DOCTYPE html>
    <html>
    <head>

    </head>
    <body>
        <h2>Crear <small>Emisora</small></h2>
        <asp:ValidationSummary ID="vsCrearProvincias" runat="server" ForeColor="Red" />
        <table>
            <tr>
                <td style="height: 50px; width: 150px">
                    <asp:Label ID="Label3" runat="server" Text="NIF"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNIF" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar NIF" ForeColor="Red" ControlToValidate="txtNIF">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 150px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombreEmisora" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar Nombre" ForeColor="Red" ControlToValidate="txtNombreEmisora">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 150px">
                    <asp:Label ID="Label4" runat="server" Text="Direccion"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar Direccion" ForeColor="Red" ControlToValidate="txtDireccion">*</asp:RequiredFieldValidator>

                </td>
            </tr>
                        <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblBanda" runat="server" Text="Banda HZ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBanda" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvIdBanda" runat="server" ErrorMessage="Debe ingresar una Banda Hertziana" ForeColor="Red" ControlToValidate="txtBanda">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <button id="btnBuscaPersona" class="btn btn-warning BuscarPersona"  data-target="#buscarPersona" onclick="return false">+</button>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="Label5" runat="server" Text="Provincia"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdProvincia" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcionProvincia" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ErrorMessage="Debe ingresar una Provincia" ForeColor="Red" ControlToValidate="txtIdProvincia">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <button id="btnBuscaProvincia" class="btn btn-warning BuscarPersona"  data-target="#buscarProvincia" onclick="return false">+</button>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Programa"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdPrograma" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ErrorMessage="Debe ingresar un programa" ForeColor="Red" ControlToValidate="txtIdPrograma">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <button id="btnBuscaPrograma" class="btn btn-warning BuscarPersona"  data-target="#buscarPrograma" onclick="return false">+</button>
                </td>
            </tr>


        </table>
        <br />
        <div class="form-actions">
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
            <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
        </div>

        <%--    MODAL BUSQUEDA PERSONA--%>
        <div class="modal fade" id="buscarPersona" tabindex="-1" role="dialog" aria-labelledby="busquedaPersonaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="busquedaPersonaLabel">Busqueda de Banda</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="persona" runat="server" />
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged"></asp:TextBox>
                                <asp:Button ID="btnBusqueda" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvBanda" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvBanda_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="IdBandaHertziana" HeaderText="IdBandaHertziana" SortExpression="IdBandaHertziana" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Nombre" SortExpression="Descripcion" />
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">

                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>


                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="PersonasODS" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.EmisoraServicio">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtBusqueda" Name="criterio" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="gvBanda" />
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
         <%--    MODAL BUSQUEDA Provincia--%>
        <div class="modal fade" id="buscarProvincia" tabindex="-1" role="dialog" aria-labelledby="busquedaProvinciaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="busquedaProvinciaLabel">Busqueda de Provincia</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="provincia" runat="server" />
                                <asp:TextBox ID="txtBusquedaProvincia" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusquedaprovincia_TextChanged"></asp:TextBox>
                                <asp:Button ID="Button2" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvProvincia" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvProvincia_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="IdProvincia" HeaderText="IdProvincia" SortExpression="IdProvincia" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <%--<asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />--%>
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">

                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>


                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.ProvinciaServicio">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtBusqueda" Name="criterio" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="gvProvincia" />
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
                         $('#btnBuscaProvincia').click(function () {
                             $('#buscarProvincia').modal('show');
                             $('#buscarProvincia').find('#MainContent_provincia').val('provincia');
                         });
                     });
        </script>
    </body>
    </html>
</asp:Content>
