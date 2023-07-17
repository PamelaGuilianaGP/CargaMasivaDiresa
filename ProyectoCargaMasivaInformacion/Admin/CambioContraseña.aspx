<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="CambioContraseña.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.Admin.CambioContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <form runat="server" id="Form1">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-primary">
                        <h4 class="card-title">Gestión de Contraseña</h4>
                        <p class="card-category">Cambio de contraseña</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Ingrese contraseña Actual</label>
                                    <asp:TextBox runat="server" CssClass="form-control"  ID="txtPassActual" TextMode="Password"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Contraseña Actual" ControlToValidate="txtPassActual" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Ingrese contraseña Nueva</label>
                                    <asp:TextBox runat="server" CssClass="form-control"  ID="txtPassNew" TextMode="Password"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Ingrese Contraseña Nueva" ControlToValidate="txtPassNew" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Repita contraseña Nueva</label>
                                    <asp:TextBox runat="server" CssClass="form-control"  ID="txtPassNew2" TextMode="Password" onchange="ValidaPass(this.value);"/>
                                    <asp:RequiredFieldValidator ErrorMessage="Repita su contraseña nueva" ControlToValidate="txtPassNew2" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                </div>
                            </div>
                        </div>
                        <asp:Button Text="Cambiar Contraseña" runat="server" ValidationGroup="General" ID="btnGuardar" CausesValidation="true" OnClick="btnGuardar_Click" CssClass="btn btn-primary pull-right"/>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="HfIdUsuario" />
        <asp:HiddenField runat="server" ID="lbmsg"/>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterScript" runat="server">
    <script>
        function ValidaPass(Valor) {
            if ($("#<%=txtPassNew.ClientID%>").val() != Valor) {
                swal({
                    title: "Las contraseñas no coinciden",
                    type: "warning",
                    confirmButtonColor: "#DD6B55",
                });
                $("#<%=txtPassNew2.ClientID%>").val('');
            }
            
        }
        function RespGuardado() {
            if ($("#<%=lbmsg.ClientID%>").val() > 0) {
                swal("Bien!", "Se realizo el cambio de contraseña!", "success");
                //setTimeout(function () { $(location).attr('href', 'Index.aspx') }, 3000);
            }
            
        }
        function GuardadoConError() {
            if ($("#<%=lbmsg.ClientID%>").val() == "0") {
                swal({
                    title: "Error",
                    type: "warning",
                    text: 'La Contraseña actual que esta ingresando no coincide',
                    confirmButtonColor: "#DD6B55",
                })
            }
        }
        GuardadoConError();
        RespGuardado();
    </script>
</asp:Content>
