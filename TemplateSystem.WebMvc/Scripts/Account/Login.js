$(document).ready(function () {
    $("#btnLogin").click(function (e) {
        //$("#frmLogin").submit()
        Log();
    });

    $("#Password").keypress(function (e) {
        if (e.which == 13) {
            //$("#frmLogin").submit()
            Log();
        }
    });

    $(".modal-dialog").draggable({
        handle: ".modal-header"
    });
});

function Log() {
    var domain;

    domain = document.domain;

    if (domain == 'localhost') {
        domain = "domain.com";
    }

    var ocredential = {
        UserName: $("#username").val(),
        Password: $("#Password").val(),
        NewPassword: '',
        ConfirmPassword: '',
        //SystemId: systemId,
        //Domain: domain,
    }

    if ($("#Username").val() != "" && $("#Password").val() != "") {
        logInAccess(ocredential);
    }
    else {
        Alerta('Warning', 'Advertencia', "Es necesario llenar los campos solicitados")
    }
}

function logInAccess(ocredential) {
    $.ajax({
        url: config.contextPath + "Account/LogInAccess",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        //data: JSON.stringify(ocredential),
        success: function (Result) {
            if (Result.Result == 'OK') {
                Alerta('Success', 'Acceso', 'Acceso correcto !!!!')
                //getcustomresource(Result.SystemId, Result.UserId);
                setTimeout(function () {
                    location.href = Result.url;
                }, 800);
            } else {
                if (Result.ChagePass == '1') {
                    Alerta('Info', 'Aviso', Result.Message)
                }
                else {
                    Alerta('Danger', 'Error', Result.Message)
                }
            }
        },
        error: function () {
            Alerta('Danger', 'Error', 'Error de ejecución.')
        }
    });
}

function Alerta(Type, Titulo, Cuerpo) {
    switch (Type) {
        case "Primary":
            swal({
                title: Titulo,
                text: Cuerpo,
                icon: "info",
                showCancelButton: false,
                closeOnConfirm: false,
                buttons: {
                }
            });
            break;

        case "Success":
            swal({
                title: Titulo,
                text: Cuerpo,
                icon: "success",
                showCancelButton: false,
                closeOnConfirm: false,
                buttons: {
                }
            });
            break;

        case "Info":
            swal({
                title: Titulo,
                text: Cuerpo,
                icon: "info",
                showCancelButton: false,
                closeOnConfirm: false,
                buttons: {
                }
            });
            break;

        case "Danger":
            swal({
                title: Titulo,
                text: Cuerpo,
                icon: "error",
                showCancelButton: false,
                closeOnConfirm: false,
                buttons: {
                }
            });
            break;

        case "Warning":
            swal({
                title: Titulo,
                text: Cuerpo,
                icon: "warning",
                showCancelButton: false,
                closeOnConfirm: false,
                buttons: {
                }
            });
            break;
    }
}