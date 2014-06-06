<%@ Page Title="Pagina Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BaseDeDatos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<%--    <div class="jumbotron">

        <h1 style="text-align: center">Publi-UMG</h1>
        <p class="lead">Es una aplicaci&oacute;n que permite desea controlar los patrocinadores que aparecen en la programación semanal de las emisoras de radio en las que inserta la publicidad que tiene contratada. </p>

    </div>--%>
    <div id="myCarousel" class="carousel slide">
      <div class="carousel-inner">  
        <div class="item active">
          <img src="Imagenes/imagen1.png" />
          <div class="container">
            <div class="carousel-caption">
              <h1>Qu&eacute esperas?.</h1>
              <p class="lead">Toda tu m&uacute;sica est&aacute; aqu&iacute;. </p>
              <%--<a class="btn btn-large btn-primary" href="#">Sign up today</a>--%>
            </div>
          </div>
        </div>
        <div class="item">
          <img src="Imagenes/imagen2.png" />
          <div class="container">
            <div class="carousel-caption">
              <h1>Descubre!</h1>
              <p class="lead">La m&uacute;sica que te encanta.</p>
             <%-- <a class="btn btn-large btn-primary" href="#">Learn more</a>--%>
            </div>
          </div>
        </div>
      </div>
      <a class="left carousel-control" href="#myCarousel" data-slide="prev">‹</a>
      <a class="right carousel-control" href="#myCarousel" data-slide="next">›</a>
    </div><!-- /.carousel -->
    <div class="row">
        <div class="col-md-4">
            <h2 style="text-align: center">Indicaciones:</h2>
            <p>
                Para poder gestionar la aplicacci&oacute;n deber&aacute; iniciar sesi&oacute;n en el link  <span class="label label-primary">Log in</span> ubicado en la parte superior de la pantalla
            </p>
            
            <p><center>
                <object type="application/x-shockwave-flash"  data="http://174.142.111.104/~radioeva/accplus/umg/AACplayer.swf" width="250" height="50" id="dbPlayer_1" style="visibility: visible;"><param name="id" value="dbPlayer_1"><param name="scale" value="noScale"><param name="salign" value="tl"><param name="allowFullscreen" value="true"><param name="allowScriptAccess" value="always"><param name="bgcolor" value="#5D5D5D"><param name="wmode" value="opaque"><param name="flashvars" value="colors=0xFF9900, 0xAF6A03, 0x2E1C01&amp;width=250&amp;defaultLanguage=es&amp;defaultStation=all&amp;autoplay=true&amp;mode=mini&amp;url=http://174.142.111.104/~radioeva/accplus/umg&amp;path=http://174.142.111.104/~radioeva/accplus/umg/AACplayer.swf&amp;height=50&amp;manager=http://174.142.111.104/~radioeva/accplus/umg/manager.php&amp;popupUrl=http://174.142.111.104/~radioeva/accplus/umg/popup.php&amp;popupWidth=600&amp;popupHeight=310&amp;popupResizable=true&amp;embedCallback=null&amp;bgcolor=#5D5D5D&amp;wmode=opaque&amp;containerId=dbPlayer_1">
                </object>
                </center>
            </p>

        </div>
        <div class="col-md-4">
            <h2 style="text-align: center">Herramientas Utilizadas:</h2>
            <p>
                Para el desarrollo de la aplicaci&oacute;n, se utilizaron las siguientes herramientas:
            </p>
            <ul>
                <li>Visual Studio 2012
                
                <a class="btn btn-default" href="http://www.visualstudio.com/">Leer m&aacute;s</a>

                </li>
                <li>Tecnolog&iacute;a: ASP.NET WebForms
                   
                <a class="btn btn-default" href="http://www.asp.net/web-forms">Leer m&aacute;s</a>

                </li>
                <li>Diseño: Bootstrap
                  
                <a class="btn btn-default" href="http://getbootstrap.com/">Leer m&aacute;s</a>

                </li>
            </ul>
        </div>
        <div class="col-md-4">
            <h2 style="text-align: center">Como Utilizarlo?</h2>
            <p>
                Podr&aacute; descargar la <a href="#">Gu&iacute;a de Usuario</a> la cual le ayudar&aacute; en la navegaci&oacute;n dentro del sistema.
            </p>

        </div>
    </div>

</asp:Content>
