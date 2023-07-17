<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.RegistroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Registro usuario</title>
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
    <link href="css/sweetalert.css" rel="stylesheet" /> 
    <style>
        .wrap-login100 {
            width: 100%;
            background: #fff;
            border-radius: 3px;
            overflow: hidden;
        }

        .input100 {
            font-family: Raleway-SemiBold;
            font-size: 18px;
            line-height: 1.2;
            color: #686868;
            display: block;
            width: 100%;
            background: #e6e6e6;
            height: 62px;
            border-radius: 3px;
            padding: 0 0px 0 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
         <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100 p-l-50 p-r-50 p-t-77 p-b-30">
                    <span class="login100-form-title p-b-55">Registro Usuario
                    </span>

                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="inputEmail4 ">Usuario</label>
                            <asp:TextBox runat="server" ID="txtusuario" CssClass="input100" onchange="VerificaUsuario(this.value)" ></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese Usuario" ControlToValidate="txtusuario" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputPassword4">Contraseña</label>
                            <asp:TextBox runat="server" ID="txtPass1" CssClass="input100" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese Contraseña" ControlToValidate="txtPass1" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general"  />
                        </div>
                         <div class="form-group col-md-4">
                            <label for="inputPassword4">Repita Contraseña</label>
                            <asp:TextBox runat="server" ID="txtPass2" CssClass="input100" onchange="ValidaPass(this.value);" TextMode="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ErrorMessage="Repita Contraseña" ControlToValidate="txtPass2" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="inputEmail4">Unidad</label>
                            <asp:DropDownList runat="server" CssClass="input100" ID="ddUnidad">
                                <asp:ListItem Text="text1" />
                                <asp:ListItem Text="text2" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Seleccione Unidad" ControlToValidate="ddUnidad" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputEmail4">Rol</label>
                            <asp:DropDownList runat="server" CssClass="input100" ID="ddlRol">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Seleccione Rol" ControlToValidate="ddlRol" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputPassword4">Alias</label>
                            <asp:TextBox runat="server" ID="TxtAlias" CssClass="input100"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="inputEmail4">DNI</label>
                            <asp:TextBox runat="server" ID="txtIdentificador" CssClass="input100 input-number" MaxLength="8" onchange="VerificaDni(this.value)"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese DNI" ControlToValidate="txtIdentificador" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputPassword4">Celular</label>
                            <asp:TextBox runat="server" ID="txtCelular" CssClass="input100"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese Celular" ControlToValidate="txtCelular" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputPassword4">Correo</label>
                            <asp:TextBox runat="server" ID="txtCorreo" CssClass="input100" onchange="validateEmail(this.value)"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese Correo" ControlToValidate="txtCorreo" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="inputEmail4">Nombres</label>
                            <asp:TextBox runat="server" ID="txtNombres" CssClass="input100"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese su Nombre" ControlToValidate="txtNombres" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputPassword4">Apellidos Paterno</label>
                            <asp:TextBox runat="server" ID="txtApPaterno" CssClass="input100"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese su Apellido Paterno" ControlToValidate="txtApPaterno" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                        <div class="form-group col-md-4">
                            <label for="inputPassword4">Apellidos Materno</label>
                            <asp:TextBox runat="server" ID="txtApMaterno" CssClass="input100"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Ingrese su Apellido Materno" ControlToValidate="txtApMaterno" runat="server" InitialValue="" SetFocusOnError="true" ForeColor="Red" ValidationGroup="general" />
                        </div>
                    </div>
     
          
                    <div class="container-login100-form-btn p-t-25">
                        <asp:Button CssClass="login100-form-btn" Text="Registrar" runat="server" ValidationGroup="general" CausesValidation="true" ID="BtnGuardar" OnClick="BtnGuardar_Click"/>
                    </div>
                    <div class="text-center w-full p-t-42 p-b-22">
                        <span class="txt1"><a class="txt1 bo1 hov1" href="Login.aspx">Ir al login</a>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="lbmsg" Value=""/>
    </form>
    <!--===============================================================================================-->	
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
    <script src="js/sweet-alerts.js"></script>
    <script src="js/sweetalert.min.js"></script>
	<!--===============================================================================================-->
	<script src="js/main.js"></script>
    <script>
        function ValidaPass(Valor) {
            if ($("#<%=txtPass1.ClientID%>").val() != Valor) {
                swal({
                    title: "Las contraseñas no coinciden",
                    type: "warning",
                    confirmButtonColor: "#DD6B55",
                })
                $("#<%=txtPass2.ClientID%>").val('');
            }
        }
        function RespGuardado() {
            if ($("#<%=lbmsg.ClientID%>").val() > 0) {
                swal("Bien!", "Registrado Correctamente!", "success");
                setTimeout(function () { $(location).attr('href', 'Login.aspx') }, 3000);
            }
            
        }
        function GuardadoConError() {
            if ($("#<%=lbmsg.ClientID%>").val() == "0") {
                swal({
                    title: "Error",
                    type: "warning",
                    text: 'Ocurrio un Error al Guardar, Intentelo nuevamente',
                    confirmButtonColor: "#DD6B55",
                })
            }
                
        }
        $('.input-number').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
        function validateEmail(ValCorreo) {
            var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
            if (emailReg.test(ValCorreo)) {
                $.ajax({
                    type: "POST",
                    url: "RegistroUsuario.aspx/Verifica_Correo",
                    data: '{email: "' + ValCorreo + '"}',
                    contentType: "application/json;",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            swal({
                                title: data.d,
                                type: "warning",
                                confirmButtonColor: "#DD6B55",
                            })
                            $("#<%= txtCorreo.ClientID %>").val("");
                        }

                    }

                });
            }
            else {
                swal({
                    title: "Correo Incorrecto",
                    type: "warning",
                    confirmButtonColor: "#DD6B55",
                })
                $("#<%=txtCorreo.ClientID%>").val('');
            }
        }
        function VerificaDni(ValDNI) {
            if ($.trim(ValDNI != "")) {
                $.ajax({
                    type: "POST",
                    url: "RegistroUsuario.aspx/Verifica_Dni",
                    data: '{Dni: "' + $.trim(ValDNI) + '"}',
                    contentType: "application/json;",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            swal({
                                title: data.d,
                                type: "warning",
                                confirmButtonColor: "#DD6B55",
                            })
                            $("#<%= txtIdentificador.ClientID %>").val("");
                        }
                    }

                });
            }
        }
        function VerificaUsuario(usuario) {

            if ($.trim(usuario != "")) {
                $.ajax({
                    type: "POST",
                    url: "RegistroUsuario.aspx/Verifica_Usuario",
                    data: '{Usuario: "' + $.trim(usuario) + '"}',
                    contentType: "application/json;",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            swal({
                                title: data.d,
                                type: "warning",
                                confirmButtonColor: "#DD6B55",
                            })
                            $("#<%= txtusuario.ClientID %>").val("");
                        }
                    }

                });
            }
        }
        GuardadoConError();
        RespGuardado();
    </script>
</body>
</html>
