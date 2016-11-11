<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="False" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB_Admin.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
    <style type="text/css">
       .tabla_1
        {  border: 1px solid gray;
           text-align: center;
           width:800px;
           height:50;
           padding:7;
           border-collapse: collapse;

          }
          .td_1
          {
               border-right :1px solid gray;   
           } 
           .BotonSmall{
            border-style: none;
            border-color: inherit;
            border-width: 0;
            background-color:black;
            color:White;
            height:20px;
            width:80px;
            font-family: 'Raleway',sans-serif;
            text-transform:capitalize;
            text-align: center;
              }
          
           
        </style>
</head>

    <p>
        <asp:Panel runat="server" ID = "pnlMensaje" visible = 'false'>
        <table class = "style3" align = 'center' >
          <tr>
          <td>
           <br/>
           <br/>
           <br/>
          No hay publicaciones disponibles para aprobacion .
          <br/>
           <br/>
           <br/>
           </td> </tr> 
           
          
             
          </table>
            
        </asp:Panel>
        
    <asp:Panel runat="server" ID = "pnlDatos">
        
    <table class = "tabla_1" align = 'center' >
        
        <tr>
            <th class="tabla_1" colspan=10>
               <center>Publicaciones a verificar</center> </th>
            <tr class="tabla_1">
             <td class="td_1"><center>Titulo</center></td>
             <td class="td_1"><center>Estado</center></td>
             <td class="td_1"><center>Creador</center></td>
             <td class="td_1"><center>Fecha Alta</center></td> 
             <td class="td_1"><center>Fecha Modificacion</center></td>
             <td class="td_1"></td>
             <td class="td_1"></td>
             <td class="td_1"></td>
             <td class="td_1"></td>
            </tr>
            <asp:Repeater ID="RepeaterAdmin"  runat="server" visible="true">
                <ItemTemplate>
                    <tr class="tabla_1">
                    <td class="td_1">
                            <%#Eval("Titulo")%></td>
                        <td class="td_1">
                            <%#Eval("Estado")%></td>
                        <td class="td_1">
                            <%#Eval("Creador")%></td>
                        <td class="td_1">
                            <%#Eval("Fecha_Alta")%></td>
                        <td class="td_1">
                            <%#Eval("Fecha_Modificacion")%></td>
                        <td class="td_1">
                            <%--<asp:Button ID="btnEditarAviso"   runat="server" Text="Editar" /></td>--%>
                          <%--  <center>--%>
                               <%-- <a class="LinkMail" href="PublicacionesUB.aspx?">
                                    <asp:Label ID="Label1" class='BotonSmall' runat="server" Text="Editar"></asp:Label>
                                <a>--%>
                                 <asp:Button ID="btnEditarAviso"  class='BotonSmall' CommandName='<%#Eval("ID")%>'  OnClick='OnbtnEditarAviso_Click' runat="server" Text="Editar" />
                          <%--  </center>--%>
                            <td class="td_1">
                                   <%-- <a class='LinkMail'  href='AdminPublicacionesUB.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'><asp:Label ID="Label2" runat="server" Text="Eliminar"></asp:Label> <a>--%>
                                <%-- <center >--%>
                                   <asp:Button ID="btnEliminarAviso" onclientclick="if (!confirm('¿esta seguro?...')) return false; " CommandName='<%#Eval("ID")%>' class='BotonSmall' UseSubmitBehavior="false" runat="server" Text="Eliminar" />
                                <%-- </center>--%>
                            </td>
                          <td class="td_1">
                                   <%-- <a class='LinkMail'  href='AdminPublicacionesUB.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'><asp:Label ID="Label2" runat="server" Text="Eliminar"></asp:Label> <a>--%>
                                 <center >
                                   <asp:Button ID="btnAprobarPublicacion" OnClick='OnbtnAprobarPublicacion_Click' CommandArgument='<%#Eval("ID")%>' class='BotonSmall' UseSubmitBehavior="false" runat="server" Text="Aprobar" />
                                 </center>
                            </td>
                               <td class="td_1">
                                   <%-- <a class='LinkMail'  href='AdminPublicacionesUB.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'><asp:Label ID="Label2" runat="server" Text="Eliminar"></asp:Label> <a>--%>
                                 <center >
                                   <asp:Button ID="btnRevisarPublicacion"  OnClick='OnbtnRevisarPublicacion_Click' CommandArgument='<%#Eval("ID")%>' class='BotonSmall' UseSubmitBehavior="false" runat="server" Text="Revision" />
                                 </center>
                            </td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tr>
        </table>
            
    </asp:Panel>
    </p>
    
</asp:Content>
