<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="Informe_Actualizacion.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.Admin.Informe_Actualizacion" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/dataTables.bootstrap4.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-primary">
                        <h4 class="card-title mt-0">Informe</h4>
                        <p class="card-category">Carga de Actualizaciones</p>
                    </div>
                    <div class="container-fluid row" style="margin-top: 40px;">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bmd-label-floating">Establecimiento</label>
                                <asp:TextBox runat="server" ID="txtEstablecimiento" CssClass="form-control" autocomplete="off" />
                            </div>
                        </div>
                    </div>
                    <div class="container-fluid row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="bmd-label-floating">Usuarios</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlUsuarios">
                                    <asp:ListItem Text="Seleccione Usuarios" />
                                </asp:DropDownList>
                            </div>

                        </div>
                         <div class="col-md-3">
                            <div class="form-group">
                                <label class="bmd-label-floating">&nbsp;</label>
                                <input type="button" name="name" value="Obtener Informe" style="margin-top: 30px;" class="btn btn-primary pull-right" onclick="ObtenerInforme();" />
                                
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-hover" id="ListUsuarios" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>DNI</th>
                                        <th>Nombres</th>
                                        <th>Apellido Paterno</th>
                                        <th>Apellidos Materno</th>
                                        <th>Usuario</th>
                                        <th>Fecha</th>
                                        <th>Cant.Pacientes Cargados</th>
                                    </tr>
                                </thead>
                               
                            </table>
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="HfIdUsuario" />
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="HfIdEstablecimiento" />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterScript" runat="server">
    <script src="assets/js/plugins/bootstrap3-typeahead.min.js"></script>
    
    <script>
        var $input = $("#<%=txtEstablecimiento.ClientID%>");
        $input.typeahead({
            source: function (query, result) {
                $.ajax({
                    method: "POST",
                    url: "Informe_Actualizacion.aspx/SelectEstablecimientos",
                    data: "{ 'Nombres': '" + query + "'}",
                    contentType: "application/json;",
                    dataType: "json",
                    success: function (data) {
                        var resultList = $.map($.parseJSON(data.d), function (item) {
                            var aItem = { id: item.Id_Establecimiento, name: item.Nombre_Establecimiento };
                            return JSON.stringify(aItem);
                        });

                        return result(resultList);
                    }
                });
            },
            autoSelect: true,
            matcher: function (obj) {
                var item = JSON.parse(obj);
                return ~item.name.toLowerCase().indexOf(this.query.toLowerCase())
            },
            highlighter: function (obj) {
                var item = JSON.parse(obj);
                var query = this.query.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g, '\\$&')
                return item.name.replace(new RegExp('(' + query + ')', 'ig'), function ($1, match) {
                    return '<strong>' + match + '</strong>'
                })
            },
            updater: function (obj) {
                var item = JSON.parse(obj);
                $('#<%=HfIdEstablecimiento.ClientID%>').val(item.id);
                CargaUsuarios(item.id);
                return item.name;
            }
        });

        function CargaUsuarios(IdEstablecimiento)
        {
            $.ajax({
                type: "POST",
                url: "Informe_Actualizacion.aspx/SelectUsuarios",
                data: "{ 'IdEstablecimiento': '" + IdEstablecimiento + "'}",
                contentType: "application/json;",
                dataType: "json",
                success: function (data) {

                    var ddlCustomers = $("#<%=ddlUsuarios.ClientID%>");
                    ddlCustomers.empty().append('<option selected="selected" value="0">Seleccionar Usuarios</option>');
                    $.each($.parseJSON(data.d), function () {
                        ddlCustomers.append($("<option></option>").val(this['idUsuario']).html(this['Usuario']));
                    });
                }
            });
        }
    </script>
    <script>
        function ObtenerInforme() {
            IdEstablecimiento = $('#<%=HfIdEstablecimiento.ClientID%>').val();
            IdUsuario = $('#<%=ddlUsuarios.ClientID%>').val();

            if (IdEstablecimiento != "") {
                var jsondata = "";
                $.ajax({
                    type: "POST",
                    url: "Informe_Actualizacion.aspx/ObtenerInforme",
                    data: '{IdEstablecimiento: "' + IdEstablecimiento + '",IdUsuario:"' + IdUsuario + '"}',
                    contentType: "application/json;",
                    dataType: "json",
                    success: function (resultado) {
                        jsondata = JSON.parse(resultado.d);
                        var table = $('#ListUsuarios').DataTable({
                            "scrollX": true,
                            lengthChange: false,
                            data: jsondata,
                            columns: [
                                { data: 'dni' },
                                { data: 'nombre' },
                                { data: 'apepat' },
                                { data: 'apemat' },
                                { data: 'userName' },
                                { data: 'Fecha' },
                                { data: 'CANTPACIENTE' }
                            ],

                            "language": {
                                "sProcessing": "Procesando...",
                                "sLengthMenu": "Mostrar _MENU_ registros",
                                "sZeroRecords": "No se encontraron resultados",
                                "sEmptyTable": "Ningún dato disponible en esta tabla",
                                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                                "sInfoPostFix": "",
                                "sSearch": "Buscar:",
                                "sUrl": "",
                                "sInfoThousands": ",",
                                "sLoadingRecords": "Cargando...",
                                "oPaginate": {
                                    "sFirst": "Primero",
                                    "sLast": "Último",
                                    "sNext": "Siguiente",
                                    "sPrevious": "Anterior"
                                },
                                "oAria": {
                                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                                }

                            }
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
                    }
                });
            }
            else {
                swal({
                    title: "Tiene que buscar y seleccionar un establecimiento",
                    type: "warning",
                    confirmButtonColor: "#DD6B55",
                })
                return false;
            } 
        }
    </script>
    
</asp:Content>
