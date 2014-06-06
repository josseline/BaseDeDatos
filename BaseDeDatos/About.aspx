<%@ Page Title="Acerca del Grupo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BaseDeDatos.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Datos:</h3>
    <table class="table table-bordered table-hover">
        <tr>
            <th>
                Nombres y Apellidos
            </th>
            <th>
                Carnet
            </th>
            <th>
                Correo Electr&oacute;nico
            </th>
        </tr>
       
        <tr>
            <td>
                Josseline Luc&iacute;a Rom&aacute;n Mart&iacute;nez
            </td>
            <td>
                0900 - 11 - 6552
            </td>
            <td>
                josselinelucia@gmail.com
            </td>
        </tr>
          <tr>
            <td>
               Blanca Luc&iacute;a De Le&oacute;n Arag&oacute;n
            </td>
            <td>
                0900 - 09 - 284
            </td>
            <td>
                luchys286xd@gmail.com
            </td>
        </tr>
           
         <tr>
            <td>
               Luis Alejandro Garc&iacute;a Hern&aacute;ndez
            </td>
            <td>
                0900 - 11- 1302
            </td>
            <td>
                lalejandro.1988@gmail.com
            </td>
        </tr>

         <tr>
            <td>
               Mario Roberto Alvarez Fuentes
            </td>
            <td>
                0900 - 07-1751  
            </td>
            <td>
                mr.2010alvarez@gmail.com
            </td>
        </tr>

         <tr>
            <td>
               William Miguel Garc&iacute;a
            </td>
            <td>
                0900 - 08- 207
            </td>
            <td>
                grcmiguel@gmail.com
            </td>
        </tr>
    </table>
</asp:Content>
