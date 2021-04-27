
$(document).ready(function () {


    $("#btnLogin").click(function (e) {
        Log();
    });


    $("#Password").keypress(function (e) {
        if (e.which == 13) {
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

    logInAccess(ocredential);

    

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
                    Alerta('Info', 'AVISO', Result.Message)
                }
                else {
                    Alerta('Danger', 'ERROR', Result.Message)
                }
            }
        },
        error: function () {
            Alerta('Danger', 'ERROR', 'Error de ejecución.')
        }
    });
}


function Alerta(Type, Titulo, Cuerpo) {
    switch (Type) {
        case "Primary":
            $.gritter.add({
                title: Titulo,
                text: Cuerpo,
                class_name: 'gritter-primary'
            });
            break;

        case "Success":
            $.gritter.add({
                title: Titulo,
                text: Cuerpo,
                class_name: 'gritter-success'
            });
            break;

        case "Info":
            $.gritter.add({
                title: Titulo,
                text: Cuerpo,
                class_name: 'gritter-info'
            });
            break;

        case "Danger":
            $.gritter.add({
                title: Titulo,
                text: Cuerpo,
                class_name: 'gritter-danger'
            });
            break;

        case "Warning":
            $.gritter.add({
                title: Titulo,
                text: Cuerpo,
                class_name: 'gritter-warning'
            });
            break;
    }
}
