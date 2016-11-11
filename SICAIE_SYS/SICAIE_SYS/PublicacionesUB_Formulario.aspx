<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB_Formulario.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB_Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br>  <br> <table  border=0  style=" max-width:1500px; ">
     
        
        <tr>
            <td valign=top  width="33%" align=center>
            <!--<img  src="Cartelera/banner-01.png"  style="      margin-bottom:50%; max-width:230px; width:85%"> <br> -->
            &nbsp;&nbsp;</td>
            <td style="width:33%;  vertical-align:top;"> 
               <table  style=" max-width:456px; width:85% "   cellpadding=0   cellspacing=0 class="Cartelera_Cuaderno" >
                  
                    <tr>
                        <td style="vertical-align:top;" class="style1">
                           
                          <table> <tr> <td>                       
                           
                            <asp:Label ID="Label2" runat="server" CssClass="TextoFormulario" Text="Tipo de Publicacion"></asp:Label>
                                  </td><td>
                            <asp:RadioButtonList ID="rblTipos" runat="server" CssClass="TextoFormulario" 
                                      RepeatDirection="Horizontal" CellSpacing="10" AutoPostBack="True"  >
                            
                                <asp:ListItem>Academico</asp:ListItem>
                                <asp:ListItem>Informativo</asp:ListItem>
                                 <asp:ListItem>Interes general</asp:ListItem>
                                 <asp:ListItem>Otro</asp:ListItem>
                            </asp:RadioButtonList>
                            </td> 
                            </tr></table>
                            
                        </td>
                        <td class="style1">
                            </td>
                    </tr>
                    <tr>
                        <td>
                           
        
                            <table class="style4">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" CssClass="TextoFormulario" Text="Título Noticia"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTitulo" runat="server"  BorderColor="Red" BorderWidth="3px" Height="28px" Width="289px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSubtitulo" runat="server" CssClass="TextoFormulario" Text="Subtitulo"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubtitulo" runat="server"  BorderColor="Red" BorderWidth="3px" Height="28px" Width="287px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="TextoFormulario" Text="Fotos"></asp:Label>
                                        <asp:FileUpload ID="FileUpload1"  runat="server" Width="221px"/>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubirFoto" runat="server" CommandName="btnVer" Text="Subir Foto" CssClass="BotonCartelera" onclick="btnSubirFoto_Click"  />
                                    </td>
                                </tr> 
                                <tr>
                                    <td colspan="2" style="text-align:center">
                                      
                                            <asp:Image ID="ImgFotoNoticia" width="75%"  runat="server" />

                                        
                                    </td>
                                </tr>  
                                <tr>
                                   <td Colspan="2" style="text-align:center">
                                       <asp:Label ID="lblCuerpo" runat="server" CssClass="TextoFormulario" Text="Cuerpo de la Noticia"></asp:Label>
                                   </td> 
                                </tr>
                                <tr id="trSubir2" runat="server">
                                    <td Colspan="2">
                                        <asp:TextBox ID="txtCuerpo" runat="server"  BorderColor="Red" BorderWidth="3px" Height="500px" Width="600px" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                              </table>
                           

                            
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            <%--<asp:Label ID="Label8" runat="server" CssClass="TextoFormulario" Text="Información del Anuncio"></asp:Label>
                            <asp:TextBox ID="txtInformacion" runat="server" BorderColor="Red" 
                                BorderWidth="3px" Height="60px" TextMode="MultiLine" Width="300px" 
                                MaxLength="2000"></asp:TextBox>--%>
                            <br />
                            <asp:Label ID="Label9" runat="server" 
                                Text="Toda informacion que se complete en este formulario y las fotos que se adjunten podrán ser modificados o editadas para su publicación." Font-Size="8pt"></asp:Label>
                            <br />
                            <br />
                            <asp:CheckBox ID="chkTerminos" runat="server" 
                                
                                Text="Leí y acepto los " Font-Size="8pt" />
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" Font-Size="8pt" 
                                Font-Underline="True" NavigateUrl="Cartelera/Terminos.pdf" Target="_blank">Términos y condiciones</asp:HyperLink>
--%>

<a  style="text-decoration:underline;font-size:8pt;" href="#" onclick="javascript:LlamarPF('Cartelera/terminos.pdf')">Términos y condiciones</a>
<asp:Label ID="Label10" runat="server" Font-Size="8pt" 
                                Text=" para la publicación de la noticia en la web"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                       
                                                    <br />
                            <asp:Button ID="btnEnviar" runat="server" CssClass="BotonCartelera" Text="ENVIAR" Width="114px" />
                            
                            <br />
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" 
                                Visible="False"></asp:Label>
                                                    <br />
                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                </table>
            </td>
            <td align=center valign=top width="33%">
                     &nbsp;</td>
        </tr>
      
    </table>
    
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
