<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB_Formulario.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB_Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br>  <br> <table  border=0  style=" max-width:1500px; ">
     
        
        <tr>
            <td valign=top  width="33%" align=center>
            <img  src="Cartelera/banner-01.png"  style="      margin-bottom:50%; max-width:230px; width:85%"> <br> 
            <img src="Cartelera/cartelito1-01.png"   style="  max-width:150px;max-width:150px;  width:85%    ">  
                &nbsp;</td>
            <td style="width:33%;  vertical-align:top;"> 
               <table  style=" max-width:456px; width:85% "   cellpadding=0   cellspacing=0 class="Cartelera_Cuaderno" >
                  
                    <tr>
                        <td style="vertical-align:top;" class="style1">
                           
                          <table> <tr> <td>                       
                           
                            <asp:Label ID="Label2" runat="server" CssClass="TextoFormulario" Text="Tipo de Anuncio"></asp:Label>
                                  </td><td>
                            <asp:RadioButtonList ID="rblTipos" runat="server" CssClass="TextoFormulario" 
                                      RepeatDirection="Horizontal" CellSpacing="10" AutoPostBack="True"  >
                            
                                <asp:ListItem>Aviso   </asp:ListItem>
                                <asp:ListItem>Solidario</asp:ListItem>
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
                                                  
                            <asp:Label ID="Label11" runat="server" CssClass="TextoFormulario" Text="Título"></asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtTitulo" runat="server"  BorderColor="#669900" 
                                BorderWidth="3px" Height="28px" Width="289px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        
                            <asp:Label ID="lblNombre" runat="server" CssClass="TextoFormulario" Text="Contacto"></asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtNombre" runat="server"  BorderColor="#669900" 
                                BorderWidth="3px" Height="28px" Width="287px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        
                            <asp:Label ID="Label3" runat="server" CssClass="TextoFormulario" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtTelefono" runat="server"  BorderColor="#669900" 
                                BorderWidth="3px" Height="28px" Width="137px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                  
                                        <asp:Label ID="lblEmail" runat="server" CssClass="TextoFormulario" Text="Email"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server"  BorderColor="#669900" 
                                BorderWidth="3px" Height="28px" Width="286px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        
                            <asp:Label ID="lblPrecio" runat="server" CssClass="TextoFormulario" Text="Precio"></asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtPrecio" runat="server"  BorderColor="#669900" 
                                BorderWidth="3px" Height="28px" Width="137px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                           
<%--                          <table> <tr> <td valign=top>  
                        
                        &nbsp;
                            &nbsp;
                                                  
                            &nbsp;<br />
                        
                              <br />
                                                  
                              <br />
                                                  
                            
                            
                              <br />
                          </td><td valign=top class="style3">  
                            
&nbsp;
                            &nbsp;<br />
                           </td> 
                            </tr>
                              <tr>
                                  <td>
                                      <a href="Evaluaciondesempeno.aspx">Evaluaciondesempeno.aspx</a></td>
                              </tr>
                            </table> --%> 
                            
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                        
                          <table border=0>
                          <tr id="trSubir1" runat="server">
                            
                          <td>
                            <asp:Label ID="Label6" runat="server" CssClass="TextoFormulario" Text="Fotos"></asp:Label>
                            
                            <asp:FileUpload ID="FileUpload1"  runat="server" Width="221px" 
                                 /></td><td>
                             <asp:Button ID="btnSubirFoto" runat="server" CommandName="btnVer" 
                                Text="Subir Foto" CssClass="BotonCartelera" onclick="btnSubirFoto_Click"  />
                          </td></tr>   
                          <tr id="trSubir2" runat="server">
                          <td>
                              
                              
                            <asp:Label ID="Label7" runat="server" Text="(podés cargar 3 fotos)" 
                                Font-Size="8pt"></asp:Label>
                            <br />
                              
                               <asp:Panel ID="pnlFotos" runat="server" Width="270px">
                                  </asp:Panel>
                               </td> <td>
                               <asp:Button ID="btnCancelarUltima" runat="server" CommandName="btnVer" 
                                Text="Borrar" CssClass="BotonCartelera"   />
                              </td>

                              </tr>
                              
                           </table>
                          
                            &nbsp;
         <asp:Panel ID="pnlFotosEdicion" visible="False" runat="server">
         <table>
           <tr><td><center>Fotos Guardadas</center></td></tr>
                <asp:Repeater ID="Repeater1" runat="server">
                 <ItemTemplate>
                 <tr>
                  <td><img class='FotoCartelera' src='Cartelera/Fotos/<%#Eval("Archivo")%>'></td>
                  <td>
                  <center >
                    <asp:Button ID="btnEliminarFoto" CommandArgument='<%#Eval("ID")%>' CssClass="BotonCartelera" OnClick='btnEliminarFoto_Click' runat="server" Text="Borrar" />
                    <br/>
                   </center>
                   </td>   
                 </tr>
                 </ItemTemplate>
                </asp:Repeater>    
          </table> 
          </asp:Panel>
                            <asp:Label ID="lblArchivos" runat="server" Visible="false"></asp:Label>
                            
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="TextoFormulario" Text="Información del Anuncio"></asp:Label>
                            <asp:TextBox ID="txtInformacion" runat="server" BorderColor="#669900" 
                                BorderWidth="3px" Height="60px" TextMode="MultiLine" Width="300px" 
                                MaxLength="2000"></asp:TextBox>
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
                                Text=" para la publicación de anuncios en la Web del Empleado"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                       
                                                    <br />
                            <asp:Button ID="btnEnviar" runat="server" CssClass="BotonCartelera" Text="ENVIAR" Width="114px" 
                                />
                          
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
                     <table style="height:100%">
            <tr><td style="height:50%" valign=top>               <img  src="Cartelera/cartelito2-01.png" width=180px   style="   max-width:200px; width:85%;  margin-bottom:70% "> </td></tr>
            <tr><td style="height:50%" valign=bottom>  <a href="CarteleraMVL.aspx"> <img src="Cartelera/boton volver-01.png"  style="   max-width:100px; width:85%; float:inherit;   "><br><br></a></td></tr>
            </table>
               
               </td>
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
