<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="BaseDeDatos.Vistas.Anuncio.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <h2>Editar <small>Anuncio</small></h2>
    <asp:ValidationSummary ID="vsEditarProvincias" runat="server" ForeColor="Red"/>
    <asp:HiddenField ID="hdfIdCadena" runat="server" />
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
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"  />
    </div>

</asp:Content>
