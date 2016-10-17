<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .style1
        {
            height: 50px;
            width: 759px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       <center>
    
      <table   >
      <tr>
<%--       <td align=center colspan=3>     <img src="Cartelera/titulo avisos-01.png" style="  max-width:300px; width:85%  ">  
        </td>--%>
         </tr>
        <tr>
        
         <td style="width:80%"; valign="top" align=center>
        <table  style=" min-width:660px;width:90%"  > <tr>
        <td style="background:url(Cartelera/Fondo.png); background-size:cover;      ">
        <div style=" margin-top:110px; margin-left:50px; min-width:600px;width:93%; height:600px ;overflow:auto;   " >
    
        <asp:DataList ID="DataList1" runat="server" BorderColor="Black"   borderwidth="0"
             RepeatColumns="1" style="text-align: left"  
             HorizontalAlign="Center" RepeatDirection="Horizontal" >
            <EditItemStyle BorderColor="#006600"  />
            <ItemTemplate>
                <table border="2" style=" width:100%;" cellpadding=0 cellspacing=0    >
                    <tr>
                        <td style="  width: 759px;" valign="top" align=left>
                            <asp:Label ID="lblInformacion" runat="server" Font-Bold="True" Font-Size="20pt" 
                                Text='<%# Eval("Titulo")%>'></asp:Label>
                            <br />
                            <%--<asp:Label ID="lblTitulo0" runat="server" Font-Bold="True" Font-Size="8pt" 
                                Text="Cualquier consulta comunicarse con:"></asp:Label>--%>
                           <%-- <asp:Image ID="Foto" runat="server"  SRC="Imagenes/"  ></asp:Image>--%>
                           
                       
                            <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="16pt" 
                                Text='<%# Eval("Texto_Corto")%>'></asp:Label>
                         <%--   &nbsp;<asp:Label ID="lblTitulo1" runat="server" Font-Bold="True" Font-Size="8pt" 
                                Text="al "></asp:Label>--%>
                              <br />
                            <img alt="" src= <%# Eval("Foto")%>   width="75%" />
                             <br />
                            <asp:Label ID="lblTelefono" runat="server" Font-Bold="True" Font-Size="12pt" 
                                Text='<%# Eval("Texto_Largo")%>'></asp:Label>
                            <br />
                           <%-- <asp:Label ID="lblTitulo2" runat="server" Font-Bold="True" Font-Size="8pt" 
                                Text="Vigencia del aviso: "></asp:Label>
                            <asp:Label ID="lblVigencia" runat="server" Font-Bold="True" Font-Size="8pt" 
                                Text='<%# Eval("FechaVigencia")%>'></asp:Label>--%>
                            <br />
                        </td>
						<td  valign="top" align=left>
                            <asp:Panel ID="pnlFotos" runat="server" >
                          <%-- <%#fnVLObtenerImagenes(Eval("ID"))%>--%>
                              <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SubSICAIE_UBConnectionString %>" 
                                SelectCommand='Select * from tblPublicacionesFotos where IDPublicacion=<%# Eval("ID") %>'></asp:SqlDataSource>

                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                <ItemTemplate>
     

<IMG alt="" src="Cartelera/Fotos/<%#Eval("Archivo")%> ">

                        </ItemTemplate>
                                </asp:Repeater>--%></asp:Panel>
                         </td>
						 
                    </tr>
                    <br />
                </table>
            </ItemTemplate>
        </asp:DataList>
    
    
    
     </div>
     
      </td> 
    </tr> 
    </table>
    
    </td> 
    <%--<td valign=top style="width:126px" align=center> 
        <%--<input type="button" ID="btnSubir" onclick="window.location='PublicacionesUB_Formulario.aspx';" 
            value="Subir Novedad" style="width:119px"  class="Boton"/>--%>
            <%--  <input type="button" ID="btnVolver" onclick="window.location = 'Login.aspx';" 
            value="Volver" style="width:119px"  class="Boton"/>--%--%>>
                
    </tr> 
    </table>
    
    
     </center>
    <script>
        function ventana(stUrl) {

            var stWin = window.open(stUrl, "Detalle", "width=800,height=400,status=no,resizable=yes,scrollbars=yes,top=100,left=120")


            stWin.opener = self;


        }  
    
    </script>
    
    <link rel="stylesheet" href="POPUP/prettyPhoto.css" type="text/css" media="screen" charset="utf-8" />
<script src="POPUP/jquery-1.6.1.min.js" type="text/javascript" charset="utf-8"></script>
<script src="POPUP/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>

<!-- inicializador del prettyphoto -->
        <script type="text/javascript" charset="utf-8">
            $(document).ready(function() {
                $("a[rel^='prettyPhoto']").prettyPhoto({ social_tools: false });
            });
        </script>
        
   
</asp:Content>
