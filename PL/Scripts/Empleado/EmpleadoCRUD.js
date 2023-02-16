$(document).ready(function () {
    GetAll();
    $(document).ajaxComplete(function () {
        GetAll();
    });
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44396/api/empleado/GetAll',
        success: function(result)
        {
            $('#tblEmpleado tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center">'
                    + '<a class="glyphicon glyphicon-edit" href="#" onclick="GetById('+ empleado.IdEmpleado +')">'
                    + '</a>'
                    + '</td>'
                    + '<td class="text-center" >' + empleado.NumeroNomina + '</td>'
                    + '<td class="text-center">' + empleado.Nombre + " " + empleado.ApellidoPaterno + " " + empleado.ApellidoMaterno + '</td>'
                    + '<td class="text-center">' + empleado.Estado.Nombre + '</td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + '</tr>';

                $('#tblEmpleado tbody').append(filas);
            });
        },
        error: function (result) {
            alert("Error en la consulta" + result.responseJSON.ErrorMessage);
        }
    });
};

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44396/api/empleado/GetById/' + IdEmpleado,
        success: function (result) {
            EntidadFederativaGetAll();
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlEstados').val(result.Object.Estado.IdEstado);

            $('#ModalForm').modal('show');
            $('#lblTitulo').modal('Modificar Empleado');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage)
        }
    });
}

function EntidadFederativaGetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44396/api/estado/GetEstado',
        success: function (result) {
            $('ddlEstados').append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Nombre + '</option>');
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);

        }
    });
}

function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44396/api/empleado/Add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#ModalForm').modal('hide');
            $('#myModal').modal();

            EntidadFederativaGetAll();
        },
        error: function (result) {
            alert('Error en la consulta' + result.responseJSON.ErrorMessage)
        }
    });
}

function Update(empleado) {

    $.ajax({
        type: 'PUT',
        url: 'https://localhost:44396/api/empleado/Update',
        dataType: 'json',
        data: empleado,
        success: function (result) {

            $('#ModalForm').modal('hide');
            $('#myModal').modal();

            EntidadFederativaGetAll();
            Console(respond);

        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Guardar() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()
        }
    }
    if ($('#txtIdEmpleado').val() == "") {
        Add(empleado);
    }
    else {
        //alert("Esto actualizando");
        Update(empleado);
    }
}

function InitializaControls() {
    $('#txtIdEmpleado').val('');
    $('#txtNumeroNomina').val('');
    $('#txtNombre').val('');
    $('#txtApellidoPaterno').val('');
    $('#txtApellidoMaterno').val('');
    $('#ddlEstados').val(0);
    $('#ModalForm').modal('show');
}

function ShowModal() {
    $('#ModalForm').modal('show');
    EntidadFederativaGetAll();
    InitializaControls();
    $('#lblTitulo').modal('Agregar Empleado');
}

function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar al Empleado seleccionado?")) {
        $.ajax({
            type: 'DELETE',
            url: 'https://localhost:44396/api/empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    }
}