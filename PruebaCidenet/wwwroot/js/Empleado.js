var pageInitialized = false;

$(document).ready(function () {
    if (pageInitialized) {
        return;
    }
    pageInitialized = true;
    $('#tablaEmpleado').DataTable();
    var fecha = new Date();
    var fechaInicial = fecha.toISOString();
    $("#FechaRegistro").val(fechaInicial.substring(0, 16));
    $("#FechaRegistro").prop("disabled", "disabled");

    $('#Nombre').keydown(function () {
        $("#CorreoElectronico").val($("#Nombre").val() + "." + $("#PrimerApellido").val().replace(/ /g, "") + "@cidenet.com.co");
    });

    $('#Nombre').focusout(function () {
        if (cambiarNombre($('#Nombre').val()) === null) 
            $('#Nombre').val("");
    });

    $('#PrimerApellido').focusout(function () {
        if (cambiarNombre($('#PrimerApellido').val()) === null)
            $('#PrimerApellido').val("");
    });

    $('#OtrosNombres').focusout(function () {
        if (cambiarNombre($('#OtrosNombres').val()) === null)
            $('#OtrosNombres').val("");
    });

    $('#SegundoApellido').focusout(function () {
        if (cambiarNombre($('#SegundoApellido').val()) === null)
            $('#SegundoApellido').val("");
    });

    $('#PrimerApellido').keydown(function () {
        $("#CorreoElectronico").val($("#Nombre").val() + "." + $("#PrimerApellido").val().replace(/ /g, "") + "@cidenet.com.co");
    });

    $('#FechaIngreso').focusout(function () {
        var fecha = new Date();
        const añoActual = fecha.getFullYear();
        const hoy = fecha.getDate();
        const mesActual = fecha.getMonth() + 1; 
        var fechaInicial = hoy + "/" + mesActual + "/" + añoActual;
        var fechaFinal = $("#FechaIngreso").val();

        if (validate_fechaMayorQue(fechaInicial, fechaFinal)) {
            alert("La fecha " + fechaFinal + " es superior a la fecha " + fechaInicial);
            $('#FechaIngreso').val("");
        } else {
            //document.write("La fecha " + fechaFinal + " NO es superior a la fecha " + fechaInicial);
        }
    });

    function cambiarNombre(nombre) {
        let regex = /^[A-Z\s]+$/;
        return regex.exec(nombre);
    }

    function validate_fechaMayorQue(fechaInicial, fechaFinal) {
        valuesStart = fechaInicial.split("/");
        valuesEnd = fechaFinal.split("-");

        // Verificamos que la fecha no sea posterior a la actual
        var dateStart = new Date(valuesStart[2], (valuesStart[1] - 1), valuesStart[0]);
        var dateEnd = new Date(valuesEnd[0], (valuesEnd[1] - 1), valuesEnd[2].substring(0,2));
        if (dateStart >= dateEnd) {
            return 0;
        }
        return 1;
    }



    $('#Crear').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'CorreoElectronico': {
                required: true,
                email: true
            },

            'NumIdentificacion': {
                required: true,
                minlength: 6
            },

            'Nombre': {
                required: true,
            },

            'PrimerApellido': {
                required: true,
            },

            'SegundoApellido': {
                required: true,
            }
        },
        messages: {
            'CorreoElectronico': 'Please enter valid email address',

            'Password': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long'
            },

            'ConfirmPassword': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long',
                equalTo: 'Please enter the same password as above'
            }
        }
    });  
});



