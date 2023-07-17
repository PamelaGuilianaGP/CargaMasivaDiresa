<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
	<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
	<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css"/>
	<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
	<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
	<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css"/>
	<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css"/>
	<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css"/>
	<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css"/>
	<link rel="stylesheet" type="text/css" href="css/main.css"/>
	<!--===============================================================================================-->
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100 p-l-50 p-r-50 p-t-77 p-b-30">
                    <span class="login100-form-title p-b-55">Bienvenido
                    </span>
                    <div class="wrap-input100 validate-input m-b-16" data-validate="Valid email is required: ex@abc.xyz">
                        <asp:TextBox runat="server" ID="txtemail" CssClass="input100" placeholder="Usuario"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <span class="lnr lnr-envelope"></span>
                        </span>
                        
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Usuario" ControlToValidate="txtemail" runat="server" InitialValue="" ForeColor="Red" ValidationGroup="Glogin"/>
                    <div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                        <asp:TextBox runat="server" ID="txtPass" CssClass="input100" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <span class="lnr lnr-lock"></span>
                        </span>
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Contraseña" ControlToValidate="txtPass" runat="server" InitialValue="" ForeColor="Red" ValidationGroup="Glogin"/>
                    <div class="container-login100-form-btn p-t-25">
                        <asp:Button CssClass="login100-form-btn" Text="INICIAR SESÍON" runat="server" ID="Btn_Guardar" OnClick="Btn_Guardar_Click" ValidationGroup="Glogin" />
                    </div>
                    <div class="text-center w-full p-t-42 p-b-22">
                        <asp:Label Text="" runat="server" Visible="false" ID="lbMensaje" />
                    </div>
                    <div class="text-center w-full p-t-42 p-b-22">
                        <span class="txt1"><a class="txt1 bo1 hov1" href="OlvideClave.aspx">Olvide mi contraseña</a></span><br />
                        <br />
                        <span class="txt1">No estas registrado ?
                        </span>
                        <a class="txt1 bo1 hov1" href="RegistroUsuario.aspx">Click aquí para registrate							
                        </a>
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
	<!--===============================================================================================-->	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
	<!--===============================================================================================-->
	<script src="js/main.js"></script>
</body>
</html>
