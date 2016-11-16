<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB_Formulario.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB_Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<link rel="stylesheet" href="Content/bootstrap.min.css">
<link rel="stylesheet" href="css/sicaie-ub.css">
    
    <div class="altaNot" >
        <div class="altaNot-box col-xs-12">
            <label><asp:Label ID="Label2" runat="server" CssClass="TextoFormulario" Text="Tipo de Publicacion "></asp:Label></label> 
            <asp:RadioButtonList ID="rblTipos" runat="server" CssClass="TextoFormulario"  RepeatDirection="Horizontal" CellSpacing="10" AutoPostBack="True">
                <asp:ListItem style="font-size:13px">Academico </asp:ListItem>
                <asp:ListItem style="font-size:13px">Informativo </asp:ListItem>
                <asp:ListItem style="font-size:13px">Interes general </asp:ListItem>
                <asp:ListItem style="font-size:13px">Otro</asp:ListItem>
            </asp:RadioButtonList>   
            <br />
            <label><asp:Label ID="Label11" runat="server" CssClass="TextoFormulario" Text="Título"></asp:Label></label>                                                 
            <asp:TextBox ID="txtTitulo" runat="server" cssclass="form-control" Height="28px" Width="100%" MaxLength="200"></asp:TextBox>
            <br />
            <label><asp:Label ID="lblSubtitulo" runat="server" CssClass="TextoFormulario" Text="Subtitulo"></asp:Label></label>
            <asp:TextBox ID="txtSubtitulo" runat="server" cssclass="form-control" Height="28px" Width="100%" MaxLength="500"></asp:TextBox>
            <br />
            <label><asp:Label ID="Label6" runat="server" CssClass="TextoFormulario" Text="Fotos"></asp:Label></label>
            <asp:FileUpload ID="FileUpload1"  runat="server" Width=""/>                                                 
            <br />
            <asp:Button ID="btnSubirFoto" runat="server" CommandName="btnVer" Text="Subir Foto" CssClass="BotonCartelera" onclick="btnSubirFoto_Click"  />
            <asp:Image ID="ImgFotoNoticia" CssClass="img-responsive" width="" runat="server" />
            <br />
            <br />
            <label><asp:Label ID="lblCuerpo" runat="server" CssClass="TextoFormulario" Text="Cuerpo de la Noticia"></asp:Label></label>
            <table class="col-md-12">
                <tr id="trSubir2" runat="server">
                    <td>
                        <asp:TextBox ID="txtCuerpo" runat="server" CssClass="form-control" style="resize:none" Rows="8" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Toda informacion que se complete en este formulario y las fotos que se adjunten podrán ser modificados o editadas para su publicación." Font-Size="8pt"></asp:Label>
            <br />
            <br />
            <asp:CheckBox ID="chkTerminos" runat="server" Text="Leí y acepto los " Font-Size="8pt" />
            <a  style="text-decoration:underline;font-size:8pt;" href="#" onclick="javascript:LlamarPF('Cartelera/terminos.pdf')">Términos y condiciones</a>
            <asp:Label ID="Label10" runat="server" Font-Size="8pt" Text=" para la publicación de la noticia en la web."></asp:Label>
            <br />
            <br />
            <div style="text-align:center">
                <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-default" Text="ENVIAR" Width="120px" />
                <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
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
