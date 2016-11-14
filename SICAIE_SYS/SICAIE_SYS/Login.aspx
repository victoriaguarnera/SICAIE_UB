<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SICAIE_Secundaria.Master" CodeBehind="Login.aspx.vb" Inherits="SICAIE_SYS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="css/sicaie-ub.css">
<link rel="stylesheet" href="Content/bootstrap.min.css">
 <asp:Panel ID="pnlForm" runat="server" >
 <div class="login">
		<div class="login-box">
			<div class="inic" style="text-align:center;background-color:#AA0A20">
				<p id="i-s">INICIAR SESION</p>			
			</div>
            <div class="login-boxtwo">
            <div class="btn-google">
            <asp:Button ID="cmdAceptar" runat="server" Text="Aceptar" OnClick="cmdAceptar_Click" class="LoginUBBoton" ClientIDMode="Static" Style="display:none;"/>
                        <!--<a href="enviarclave.aspx" class="LinkMail">Olvide mi Contraseña</a>
                        <asp:Button runat="server" OnClientClick="sarasa(); return false;" Text="Click for sarasa" />-->
            <div class="g-signin2" data-onsuccess="onSignIn"></div><br>
                <asp:HiddenField ID="usrDat" ClientIDMode="static" runat="server" Value="" />
            <asp:label ID="lblError" ForeColor=red runat="server"></asp:label>
            </div>
          </div>
		</div>
 </div>
 </asp:Panel>
 <asp:Panel ID="pnlOut" runat="server" >
     <asp:label ID="lblOut" ForeColor=red runat="server"></asp:label>
 </asp:Panel>
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
            //TODO descomentar
            //BootstrapDialog.alert("Por favor ingrese con su direccion de Comunidad o UB");
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