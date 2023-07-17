<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoUsuarios.aspx.cs" Inherits="ProyectoCargaMasivaInformacion.Admin.ListadoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/dataTables.bootstrap4.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-primary">
                        <h4 class="card-title mt-0">Listado Usuarios</h4>
                        <p class="card-category">Datos Usuarios</p>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-hover" id="ListUsuarios" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>Usuario</th>
                                        <th>Nombres</th>
                                        <th>Apellidos</th>
                                        <th>Estado</th>
                                        <th>Tipo Usuario</th>
                                        <th>Editar</th>
                                    </tr>
                                </thead>
                               
                            </table>
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="HfIdUsuario" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterScript" runat="server">
    <script>
        var jsondata = "";
        $.ajax({
            type: "POST",
            url: "ListadoUsuarios.aspx/ObtenerUsuarios",
            //data: '{Id_Alumno: "' + idUsuario + '",Tipo_User:"' + IdTipouser + '"}',
            contentType: "application/json;",
            dataType: "json",
            success: function (resultado) {

                jsondata = JSON.parse(resultado.d);
                var table = $('#ListUsuarios').DataTable({
                    "scrollX": true,
                    lengthChange: false,
                    data: jsondata,
                    columns: [
                        { data: 'userName' },
                        { data: 'nombre' },
                        { data: 'APELLIDOS' },
                        { data: 'ESTADO' },
                        { data: 'TIPOUSUARIO' },
                        {
                            data: 'idUsuario',
                            fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                                $(nTd).html("<a href='EditUsuario.aspx?IdUsuario=" + oData.idUsuario + "' class='btn btn-success btn-sm'><i class='material-icons'>create</i>&nbsp;Editar</a>");
                            }
                        }
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
                aler(error.Message);
            }
        });
    </script>
</asp:Content>
