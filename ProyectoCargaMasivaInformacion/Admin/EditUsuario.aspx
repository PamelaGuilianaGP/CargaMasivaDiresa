<%@ Page Title="Edicion de Usuario" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditUsuario.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.Admin.EditUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-primary">
                        <h4 class="card-title">Edicion de Perfil</h4>
                        <p class="card-category">Actualiza tu perfil</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Usuario</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ReadOnly  ID="txtUsuario"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Usuario" ControlToValidate="txtUsuario" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Estado</label>
                                    <asp:RadioButtonList runat="server" ID="rbEstado" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="form-control">
                                        <asp:ListItem Text="ACTIVO" Value="1"/>
                                        <asp:ListItem Text="INACTIVO" Value="2"/>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ErrorMessage="Seleccione Estado" ControlToValidate="rbEstado" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Unidad</label>
                                    <asp:DropDownList runat="server" ID="ddlUnidad" CssClass="form-control">
                                        <asp:ListItem Text="text1" />
                                        <asp:ListItem Text="text2" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ErrorMessage="Seleccione Unidad" ControlToValidate="ddlUnidad" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Rol</label>
                                     <asp:DropDownList runat="server" ID="ddlRol" CssClass="form-control">
                                        <asp:ListItem Text="text1" />
                                        <asp:ListItem Text="text2" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ErrorMessage="Seleccione Rol" ControlToValidate="ddlRol" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Alias</label>
                                    <asp:TextBox runat="server" CssClass="form-control"  ID="txtAlias"/>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">DNI</label>
                                    <asp:TextBox runat="server" CssClass="form-control"  ID="txtDNI" onchange="VerificaDni(this.value)"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese DNI" ControlToValidate="txtDNI" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Celular</label>
                                    <asp:TextBox runat="server" CssClass="form-control"   ID="txtCelular"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Celular" ControlToValidate="txtCelular" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Correo</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txtCorreo" onchange="validateEmail(this.value)"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Correo" ControlToValidate="txtCorreo" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Nombres</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombres"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Nombres" ControlToValidate="txtNombres" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Apellido Paterno</label>
                                    <asp:TextBox runat="server" CssClass="form-control"  ID="txtAPPaterno"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese apellido paterno" ControlToValidate="txtAPPaterno" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Apellido Materno</label>
                                     <asp:TextBox runat="server" CssClass="form-control"  ID="txtAPMaterno"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese apellido materno" ControlToValidate="txtAPMaterno" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                        </div>
                        
                        <asp:Button Text="Guardar Cambios" runat="server" ValidationGroup="General" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary pull-right"/>
                        
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="IdUsuario" />
        <asp:HiddenField runat="server" ID="lbmsg" />
        <asp:HiddenField runat="server" ID="HfIdUsuario"/>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterScript" runat="server">
    <script>
        $('.input-number').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
        function validateEmail(ValCorreo) {
            var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
            if (emailReg.test(ValCorreo)) {
                $.ajax({
                    type: "POST",
                    url: "../RegistroUsuario.aspx/Verifica_Correo",
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
                    url: "../RegistroUsuario.aspx/Verifica_Dni",
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
                            $("#<%= txtDNI.ClientID %>").val("");
                        }
                    }

                });
            }
        }
        function RespGuardado() {
            if ($("#<%=lbmsg.ClientID%>").val() > 0) {
                swal("Bien!", "Los datos se actualizaron correctamente!", "success");
                //setTimeout(function () { $(location).attr('href', 'Index.aspx') }, 3000);
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
        GuardadoConError();
        RespGuardado();
    </script>
</asp:Content>
