<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.FranjaHorario.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Crear <small>Franja Horario</small></h2>
    <asp:ValidationSummary ID="vsCrearFranja" runat="server" ForeColor="Red"/>
    <table>
        <tr>
            <td style="height:50px; width:150px" >
                <asp:Label ID="lblHoraInicio" runat="server" Text="Hora Inicio"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHoraInicio" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHoraInicio" runat="server" ErrorMessage="Debe ingresar una hora de inicio para la franja" ForeColor="Red" ControlToValidate="txtHoraInicio">*</asp:RequiredFieldValidator>

            </td>
        </tr>
     <tr>
            <td style="height:50px; width:150px" >
                <asp:Label ID="lblHoraFin" runat="server" Text="Hora Fin"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtHoraFin" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHoraFin" runat="server" ErrorMessage="Debe ingresar una hora fin para la franja" ForeColor="Red" ControlToValidate="txtHoraFin">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
           <td style="height:50px; width:150px" >
                <asp:Label ID="lblDiaSemana" runat="server" Text="Dia de la Semana"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDiaSemana" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem>Lunes</asp:ListItem>
                    <asp:ListItem>Martes</asp:ListItem>
                    <asp:ListItem>Miercoles</asp:ListItem>
                    <asp:ListItem>Jueves</asp:ListItem>
                    <asp:ListItem>Viernes</asp:ListItem>
                    <asp:ListItem>Sabado</asp:ListItem>
                    <asp:ListItem>Domingo</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDiaSemana" runat="server" ErrorMessage="Debe seleccionar un dia de la semana" ForeColor="Red" ControlToValidate="ddlDiaSemana">*</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
    </div>
</asp:Content>
