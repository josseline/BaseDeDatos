<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.Anuncio.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
      <!DOCTYPE html>
    <html>
    <head>

    </head>
    <body>
        <h2>Crear <small>Anuncio</small></h2>
        <asp:ValidationSummary ID="vsCrearProvincias" runat="server" ForeColor="Red" />
        <table>
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
                    <button id="btnBuscaPrograma" class="btn btn-warning BuscarPersona"  data-target="#buscarPrograma" onclick="return false">+</button>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblRepresentante" runat="server" Text="Patrocinador"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNifRep" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNombreRep" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>

                </td>
                <td>
                    <button id="btnBuscaPersona" class="btn btn-warning BuscarPersona"  data-target="#buscarPersona" onclick="return false">+</button>
                </td>
            </tr>
                        <tr>
                <td style="height: 50px; width: 150px">
                    <asp:Label ID="lblNombrePrograma" runat="server" Text="Duracion Anuncio"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDuracionAnuncio" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar Duracion" ForeColor="Red" ControlToValidate="txtDuracionAnuncio">*</asp:RequiredFieldValidator>

                </td>
            </tr>
                   <tr>
                <td style="height: 50px; width: 150px">
                    <asp:Label ID="Label2" runat="server" Text="Precio Segundo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrecioPorSegundo" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar Duracion" ForeColor="Red" ControlToValidate="txtPrecioPorSegundo">*</asp:RequiredFieldValidator>

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
                        <h4 id="busquedaPersonaLabel">Busqueda de Persona</h4>
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
                                        <asp:BoundField DataField="NIFPatrocinador" HeaderText="NIFPatrocinador" SortExpression="NIFPatrocinador" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">

                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>


                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="PersonasODS" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.PersonasServicio">
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
