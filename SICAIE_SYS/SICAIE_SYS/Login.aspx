<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Secundaria.Master" CodeBehind="Login.aspx.vb" Inherits="SICAIE_SYS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="Contenido">
    <br><br><br>  <br>  

      
          <asp:Panel ID="pnlForm" runat="server" >
         <center>
       
       
<table class="LoginUBTabla"   > 
<tr ><td colspan=3 class="LoginUBBordeHor"></td></tr>
<tr><td class="LoginUBBordeVer"> </td><td  ><br></td><td class="LoginUBBordeVer"> </td></tr>
<tr ><td colspan=3 class="LoginUBTitulo">INICIO DE SESIÓN</td></tr>
<tr><td class="LoginUBBordeVer"></td><td class="LoginUBCentro">





               <table   cellpadding=0 cellspacing=0 align=center>
               
                <!--<tr >
                    <td  align=right style="height:25px"  >
                       Usuario: &nbsp;</td>
                    <td>
                     <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                      </td>
                </tr>
                <tr>
                    <td align=right  style="height:25px">
                         Contraseña &nbsp;</td>
                    <td>
                          <asp:TextBox ID="txtPwd"  TextMode="Password" runat="server"></asp:TextBox></td>
                </tr>-->
                 <tr>
                    <td colspan=2 style="text-align: center;">
                        <asp:Button ID="cmdAceptar" runat="server" Text="Aceptar" OnClick="cmdAceptar_Click" class="LoginUBBoton" ClientIDMode="Static" Style="display:none;"/>
                        <!--<a href="enviarclave.aspx" class="LinkMail">Olvide mi Contraseña</a>
                        <asp:Button runat="server" OnClientClick="sarasa(); return false;" Text="Click for sarasa" />-->
                        <div class="g-signin2" data-onsuccess="onSignIn"></div><br>
                       <asp:label ID="lblError" ForeColor=red runat="server"></asp:label> 
                       </td>
                </tr>
            </table>
          </center>
          <asp:HiddenField ID="usrDat" ClientIDMode="static" runat="server" Value="" />
        
      
</td><td class="LoginUBBordeVer"></td></tr>
<tr><td colspan=3 class="LoginUBBordeHor"></td></tr>
</table> <br>
         
         <center>

               <table   class="MVL14_LoginUB">
               
                <tr >
                    <td  align=center style="height:25px"  >
                 Si entrás por 1° vez, ingresá como Usuario tu número de legajo y como contraseña tu número de DNI.
                  </td>
                </tr>
            </table>
          </center>
          </asp:Panel>
   <asp:Panel ID="pnlOut" runat="server" >
    <asp:label ID="lblOut" ForeColor=red runat="server"></asp:label> <br>
      </asp:Panel>
   </div>    
<!--<script src="js/jquery.min.js"></script>-->
<meta name="google-signin-client_id" content="363107088169-6mbvid726g3rdem2rfi865act4dsl7va.apps.googleusercontent.com">
<script>
    function sarasa() {
        //var pepe = $("#cmdAceptar");
        var pepe = document.getElementById('cmdAceptar');
        pepe.click();
    }
    function onSignIn(googleUser) {
        var profile = googleUser.getBasicProfile();
        console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
        console.log('Name: ' + profile.getName());
        console.log('Image URL: ' + profile.getImageUrl());
        console.log('Email: ' + profile.getEmail());
        var mail = profile.getEmail();
        if (mail.endsWith('@comunidad.ub.edu.ar') || mail.endsWith('@ub.edu.ar')) {
            var usrDat = document.getElementById('usrDat');
            usrDat.value = profile.getEmail();
            document.getElementById('cmdAceptar').click();
        }
        else {
            alert("Por favor ingrese con su direccion de Comunidad o UB");
            signOut();
        }
        //TODO tarea para el hogar
        //mandar profile.getEmail() al campo hidden usrDat
        //en backcode cambiar logica e cmdAceptar_click, saca data del hidden field
        //if domino not @comunidad.ub.edu.ar o @ub, signOut(); y escribir alerta en lblerror
        //sarasa();
    }
    function signOut() {
        var iframe = document.createElement('iframe');
        iframe.src = 'https://accounts.google.com/Logout';
        iframe.style.display = 'none';
        document.body.appendChild(iframe);
    }
    /*function sarasa() {
        $.ajax({
            type: "GET",
            url: "Login.aspx/SubmitReport_Click",
            success: function () {
                alert('It Worked!');
            },
            failure: function () {
                alert('It Failed!');
            }
        });
    }*/
</script> 
<script src="https://apis.google.com/js/platform.js" async defer></script>
</asp:Content>