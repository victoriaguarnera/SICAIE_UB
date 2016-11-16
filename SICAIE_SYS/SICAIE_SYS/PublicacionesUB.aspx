<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="css/sicaie-ub.css">

<div class="container" style="background-color:#FFF !important;padding:0px !important">
    <asp:DataList ID="DataList1" runat="server"  RepeatColumns="1" style="text-align: left" HorizontalAlign="Center" RepeatDirection="Horizontal" >
        <EditItemStyle BorderColor="#006600"  />
        <ItemTemplate>
	            <div class="sec-new altaNot-box pub-box">
                    <h1 class="tittle-news">
                        <asp:Label ID="lblInformacion" runat="server" Font-Bold="True" Text='<%# Eval("Titulo")%>'></asp:Label>
                    </h1>
                    <br />
                    <h2>
                        <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Text='<%# Eval("Texto_Corto")%>'></asp:Label>
                    </h2>
                    <center>
                        <img alt="" src= <%# Eval("Foto")%> class="img-responsive" />
                    </center>
                    <br />
                    <p>
                        <asp:Label ID="lblTelefono" runat="server" Font-Bold="True" Text='<%# Eval("Texto_Largo")%>'></asp:Label>
                        <asp:Panel ID="pnlFotos" runat="server" ></asp:Panel>
                    </p>
                </div>
                <div class="col-md-12 banner"></div>
        </ItemTemplate>
    </asp:DataList>
</div>   
    
<script>
    function ventana(stUrl) {
        var stWin = window.open(stUrl, "Detalle", "width=800,height=400,status=no,resizable=yes,scrollbars=yes,top=100,left=120")
        stWin.opener = self;
    }  
</script>
<script src="POPUP/jquery-1.6.1.min.js" type="text/javascript" charset="utf-8"></script>
<script src="POPUP/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript" charset="utf-8">
       $(document).ready(function() {
              $("a[rel^='prettyPhoto']").prettyPhoto({ social_tools: false });
       });
</script>  
</asp:Content>