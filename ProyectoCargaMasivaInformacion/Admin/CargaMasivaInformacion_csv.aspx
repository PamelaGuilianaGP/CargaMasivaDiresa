<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="CargaMasivaInformacion_csv.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <form runat="server" id="Form1">
        <asp:HiddenField runat="server" ID="HfIdUsuario" />
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-primary">
                        <h4 class="card-title">Carga Masiva de Pacientes</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="bmd-label-floating">Seleccione un Archivo CSV</label>
                                    <asp:FileUpload runat="server" ID="FuFile" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ErrorMessage="Seleccione un archivo CSV." ControlToValidate="FuFile" ValidationGroup="General" runat="server" ForeColor="Red" InitialValue="" />
                                    
                                </div>
                                <asp:Label runat="server" ID="LbError" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card-body table-responsive">
                                    <asp:GridView runat="server" ID="GvResumenCarga" CssClass="table table-hover"></asp:GridView>
                                </div>
                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <div class="alert alert-danger" role="alert">
                                    Mientras realiza la carga masiva no cerrar el navegador, por favor
                                </div>
                            </div>
                            <div class="col-md-7">
                                <asp:Button Text="Cargar Informacíon" runat="server" ValidationGroup="General" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary pull-right"/>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterScript" runat="server">
</asp:Content>
