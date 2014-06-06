<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="BaseDeDatos.Vistas.CadenaEmisora.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <html>
    <head>

    </head>
    <body>
        <h2>Editar <small>Cadena - Emisora </small></h2>
        <asp:ValidationSummary ID="vsCrearCadenaEmisora" runat="server" ForeColor="Red" />
         <table>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblCadena" runat="server" Text="Cadena"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdCadena" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtNombreCadena" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCadena" runat="server" ErrorMessage="Debe ingresar una cadena" ForeColor="Red" ControlToValidate="txtIdCadena">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblEmisora" runat="server" Text="Emisora"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNifEmisora" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtNombreEmisora" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvNifEmisora" runat="server" ErrorMessage="Debe ingresar una Emisora" ForeColor="Red" ControlToValidate="txtNifEmisora">*</asp:RequiredFieldValidator>
                </td>
            </tr>

              <tr>
                <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblRepresentante" runat="server" Text="Director"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNifRep" runat="server" MaxLength="50" CssClass="form-control" Enabled="false"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtNombreRep" runat="server" MaxLength="50" CssClass="form-control" Enabled="false" Width="200"></asp:TextBox>

                </td>
                  <td>
                      <asp:RequiredFieldValidator ID="rfvDirector" runat="server" ErrorMessage="Debe seleccionar un director" ForeColor="Red" ControlToValidate="txtNifRep">*</asp:RequiredFieldValidator>
                  </td>
                <td>
                    <button id="btnBuscaPersona" class="btn btn-warning BuscarPersona"  data-target="#buscarPersona" onclick="return false">+</button>
                </td>
            </tr>
             <tr>
               <td style="height: 50px; width: 100px">
                    <asp:Label ID="lblEsCentral" runat="server" Text="Es Central?"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblEsCentral" runat="server" RepeatDirection="Horizontal" Width="50px">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                 <td>
                      &nbsp;</td>
             </tr>
        </table>

            <br />
        <div class="form-actions">
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
            <asp:Button ID="btnCrear" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
       
             <%--    MODAL BUSQUEDA CADENA--%>
        <div class="modal fade" id="buscarCadena" tabindex="-1" role="dialog" aria-labelledby="busquedaCadenaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="BusquedaCadena"></h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="cadena" runat="server" />
                                <asp:TextBox ID="txtBusquedaCadena" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusquedaCadena_TextChanged"></asp:TextBox>
                                <asp:Button ID="btnBusqueda" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvCadenas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvCadenas_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="IdCadena" HeaderText="Id"/>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">
                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>

                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.CadenaRadioServicio">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtBusquedaCadena" Name="criterio" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="gvCadenas" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <div class="modal-footer">
                        <button class="btn" data-dismiss="modal" aria-hidden="true" Closehidden="true">Close</button>
                    </div>
                </div>
            </div>
        </div>

    
         <script type="text/javascript">

             $(document).ready(function () {
                 $('#btnBuscarCadena').click(function () {
                     $('#buscarCadena').modal('show');
                     $('#buscarCadena').find('#MainContent_cadena').val('cadena');
                 });
             });
        </script>



         <%--    MODAL BUSQUEDA EMISORA--%>
        <div class="modal fade" id="buscarEmisora" tabindex="-1" role="dialog" aria-labelledby="busquedaEmisoraLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="BusquedaEmisora"></h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="emisora" runat="server" />
                                <asp:TextBox ID="txtBusquedaEmisora" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusquedaEmisora_TextChanged" ></asp:TextBox>
                                <asp:Button ID="btnBuscaEmisora" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvEmisorasEmisora" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvEmisorasEmisora_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="NIF" HeaderText="NIF"/>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                                        <asp:CommandField ShowSelectButton="True" SelectText="" HeaderText="SELECCIONAR">
                                            <ControlStyle CssClass="glyphicon glyphicon-hand-up" />
                                        </asp:CommandField>

                                    </Columns>

                                </asp:GridView>

                                <asp:ObjectDataSource ID="ODSEmisora" runat="server" SelectMethod="ObtenerPorBusqueda" TypeName="BaseDeDatos.Servicios.EmisoraServicio">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtBusquedaEmisora" Name="criterio" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="gvEmisorasEmisora" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <div class="modal-footer">
                        <button class="btn" data-dismiss="modal" aria-hidden="true" Closehidden="true">Close</button>
                    </div>
                </div>
            </div>
        </div>

    
         <script type="text/javascript">

             $(document).ready(function () {
                 $('#btnBuscarEmisora').click(function () {
                     $('#buscarEmisora').modal('show');
                     $('#buscarEmisora').find('#MainContent_emisora').val('emisora');
                 });
             });
        </script>

          <%--    MODAL BUSQUEDA PERSONA--%>
        <div class="modal fade" id="buscarPersona" tabindex="-1" role="dialog" aria-labelledby="busquedaPersonaLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                        <h4 id="busquedaPersonaLabel">Busqueda de Persona</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">

                            <ContentTemplate>
                                <asp:HiddenField ID="persona" runat="server" />
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="uppercase" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged"></asp:TextBox>
                                <asp:Button ID="btnBuscarPersona" Text="Buscar" runat="server" OnClientClick="return false" CssClass="btn-primary" />

                                <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-condensed dataTable" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged" >
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />

                                    <EmptyDataTemplate>

                                        <asp:Image ID="NoDataImage" runat="server" />

                                        No se encontro ninguna coincidencia.  

                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="NIFPERSONA" HeaderText="NIFPERSONA" SortExpression="NIFPERSONA" />
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
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


           </body>
    </html>
</asp:Content>
