<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.Personas.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Crear <small>Persona</small></h2>
    <asp:ValidationSummary ID="vsCrearPersona" runat="server" ForeColor="Red"/>
    <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblNif" runat="server" Text="NIF"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNif" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNif" runat="server" ErrorMessage="Debe ingresar un NIF para la persona" ForeColor="Red" ControlToValidate="txtNif">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombres"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"  MaxLength="200" CssClass="form-control"></asp:TextBox>
             
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un Nombre para la persona" ForeColor="Red" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
                  
            </td>
        </tr>
          <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellidos" runat="server"  MaxLength="200" CssClass="form-control"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server"  MaxLength="100" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
    </div>

     <%--    MODAL BUSQUEDA SOLICITANTE--%>
                    <div id="buscarPersona" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="busquedaPersonaLabel" aria-hidden="false" style="display: block">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                            <h4 id="busquedaPersonaLabel">Busqueda de Persona</h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                <ContentTemplate>
                                    <asp:HiddenField ID="persona" runat="server" />
                                    <asp:TextBox ID="txtBusqueda" runat="server" CssClass="uppercase" AutoPostBack="true"></asp:TextBox>
                                    <asp:Button ID="btnBusqueda" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                    <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable">
                                        <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                        <EmptyDataTemplate>

                                            <asp:Image ID="NoDataImage" runat="server" />

                                            No se encontro ninguna coincidencia.  

                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="NIFPERSONA" HeaderText="NIF" SortExpression="NIFPERSONA" />
                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                                            <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">

                                                <ControlStyle CssClass="icon-hand-up" />
                                            </asp:CommandField>

                                        </Columns>

                                    </asp:GridView>

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

      <script type="text/javascript">
          $(document).ready(function () {
              $('.BuscarPersona').click(function () {
                  $('#buscarPersona').modal('show');
                  $('#buscarPersona').find('#MainContent_persona').val('persona');
              });
          });
     </script>
</asp:Content>
