<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="False" MasterPageFile="~/SICAIE_Publicaciones.Master" CodeBehind="PublicacionesUB_Admin.aspx.vb" Inherits="SICAIE_SYS.PublicacionesUB_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="Content/bootstrap.min.css">
 <link rel="stylesheet" href="css/sicaie-ub.css">
    
    <asp:Panel runat="server" ID = "pnlMensaje" visible = 'false'>
        <table align="center">
            <tr>
                <td>
                    <br/>
                    <br/>
                    <br/>
                    <asp:Label ID="LabelMsj1" runat="server" Text="No hay publicaciones disponibles para aprobación."></asp:Label>
                    <asp:Label ID="LabelMsj2" runat="server" Text="ERROR: Debe ser usuario administrador para ingresar a esta pagina ."></asp:Label>
                    <br/>
                    <br/>
                    <br/>
                </td>
            </tr>
        </table>
    </asp:Panel>
            
    <asp:Panel runat="server" ID = "pnlDatos">
    <div class="container adm-not" style="padding:0px">
         <div class="table-responsive">
             <table class="table table-bordered" style="margin:0px;" >
                 <thead>
                     <tr>
                         <th class="a-c">Titulo</th>
                         <th class="a-c">Estado</th>
                         <th class="a-c">Creador</th>
                         <th class="a-c">Fecha alta</th>
                         <th class="a-c">Fecha de modificacion</th>
                         <th class="a-c">Aprobar</th>
                         <th class="a-c">Editar</th>
                         <th class="a-c">Eliminar</th>
                     </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterAdmin"  runat="server" visible="true">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("Titulo")%></td>
                                <td class="a-c">
                                    <%#Eval("Estado")%></td>
                                <td class="a-c">
                                    <%#Eval("Creador")%></td>
                                <td class="a-c">
                                    <%#Eval("Fecha_Alta")%></td>
                                <td class="a-c">
                                    <%#Eval("Fecha_Modificacion")%></td>
                                <td class="a-c">
                                    <asp:Button ID="btnAprobarPublicacion" OnClick='OnbtnAprobarPublicacion_Click' CommandArgument='<%#Eval("ID")%>' CssClass='btn btn-info' UseSubmitBehavior="false" runat="server" Text="Aprobar" />
                                </td>
                                <td class="a-c">
                                    <asp:Button ID="btnEditarAviso"  CssClass='btn btn-default' CommandName='<%#Eval("ID")%>'  OnClick='OnbtnEditarAviso_Click' runat="server" Text="Editar"/>
                                </td>
                                <td class="a-c">    
                                   <asp:Button ID="btnEliminarAviso" onclientclick="if (!confirm('¿esta seguro?...')) return false; " CommandName='<%#Eval("ID")%>' CssClass="btn btn-danger" UseSubmitBehavior="false" runat="server" Text="Eliminar" /> <i class="fa fa-trash-o" aria-hidden="true"></i>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    </asp:Panel>
 </asp:Content>