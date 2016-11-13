<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB_Formulario.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB_Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="css/sicaie-ub.css">
<link rel="stylesheet" href="Content/bootstrap.min.css">
	<div class="altaNot">
		<div class="altaNot-box col-md-6 col-xs-12">
			
				<div class="form-group">    				               
                    <label><asp:Label ID="Label11" runat="server" CssClass="TextoFormulario" Text="Título"></asp:Label></label>                 
                    <asp:TextBox ID="txtTitulo" runat="server"  CssClass="form-control"></asp:TextBox>                                
   				</div>
				<div class="form-group">
                    <label><asp:Label ID="lblSubtitulo" runat="server" Text="Subtitulo"></asp:Label></label>
                    <asp:TextBox ID="txtSubtitulo" runat="server" CssClass="form-control" ></asp:TextBox>
   				</div>
  				<div class="form-group">
    				<label><asp:Label ID="Label6" runat="server" CssClass="TextoFormulario" Text="Imagenes"></asp:Label></label>
                    <asp:FileUpload ID="FileUpload1"  runat="server" Width="450px"/>
    				<p class="help-block"></p>
                    <asp:Button ID="btnSubirFoto" runat="server" CommandName="btnVer" Text="Subir imagen" CssClass="BotonCartelera" onclick="btnSubirFoto_Click" />
                    <p class="help-block"></p>
                    <asp:Image ID="ImgFotoNoticia" cssclass="img-responsive"  runat="server" />
                </div>
  				<div class="form-group">
  					<label><asp:Label ID="lblCuerpo" runat="server" CssClass="TextoFormulario" Text="Cuerpo"></asp:Label></label>
                    <asp:TextBox ID="txtCuerpo" runat="server"  CssClass="form-control" style="resize:none" Rows="8" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
  				</div>
  				<div class="col-md-12">
  				<label for=""><asp:Label ID="Label1" runat="server" CssClass="TextoFormulario" Text="Tipo de Publicacion"></asp:Label></label>
  				<div class="col-md-12 l-box">
                      <asp:RadioButtonList ID="rblTipos" runat="server" RepeatDirection="Vertical" CellSpacing="10" AutoPostBack="True">
                          <asp:ListItem>Academico</asp:ListItem>
                          <asp:ListItem>Informativo</asp:ListItem>
                          <asp:ListItem>Interes general</asp:ListItem>
                          <asp:ListItem>Otro</asp:ListItem>
                      </asp:RadioButtonList>                  
                  </div>
  				</div>
              <div class="col-xs-12" id="info-boxx">
                <p><asp:Label ID="Label9" runat="server" Text="Toda informacion que se complete en este formulario y las fotos que se adjunten podrán ser modificados o editadas para su publicación." ></asp:Label></p>
                <asp:CheckBox ID="chkTerminos" runat="server"                                 
                                Text="Leí y acepto los " Font-Size="8pt" />
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" Font-Size="8pt" 
                                Font-Underline="True" NavigateUrl="Cartelera/Terminos.pdf" Target="_blank">Términos y condiciones</asp:HyperLink>
                             --%>
                <a style="text-decoration:underline;font-size:8pt;" href="#" onclick="javascript:LlamarPF('Cartelera/terminos.pdf')">Términos y condiciones</a>
                <asp:Label ID="Label10" runat="server" Font-Size="8pt" 
                                Text=" para la publicación de anuncios en la Web del Empleado"></asp:Label>
                  <br />
                  <br />
               <asp:Button ID="btnEnviar" runat="server" CssClass="" Text="ENVIAR" />
                   <br />
               <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" 
                                Visible="False"></asp:Label>
            </div>     
    </div>
</div>
    <br />
    <br />
<link rel="stylesheet" href="POPUP/prettyPhoto.css" type="text/css" media="screen" charset="utf-8" />
<script src="POPUP/jquery-1.6.1.min.js" type="text/javascript" charset="utf-8"></script>
<script src="POPUP/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>
<!-- inicializador del prettyphoto--> 
<script type="text/javascript" charset="utf-8">
    $(document).ready(function() {
        $("a[rel^='prettyPhoto']").prettyPhoto({ social_tools: false });
    });
</script>

<script type="text/javascript">
    function LlamarPF( strPdf)
    {   var num = Math.random().toString
        var str = strPdf + "#toolbar=0&navpanes=0&amp;iframe=true&amp;&amp;width=880&amp;height=620'"
//        str = str.replace("toolbar=0", "toolbar=0")
        javascript:$.prettyPhoto.open(str, '', '');

    }
</script>
</asp:Content>
