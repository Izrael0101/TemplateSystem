function Salir() {

    var ocredential = new Object();

    ocredential.UserName = '';
    ocredential.Password = '';
    ocredential.NewPassword = '';
    ocredential.ConfirmPassword = '';
    ocredential.SystemId = '';
    ocredential.Domain = '';

    $.ajax({
        url: config.contextPath + "Account/DeleteSession",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        //data: JSON.stringify(ocredential),
        async: false,
        cache: false
    });


    //Este llamado al controlador de Account es para matar las sessiones del usuario y las opciones del menu
    var url = config.contextPath + 'Account/LogOut';
    $.post(url, {}, function (data) { location.href = url; });


}

$(document).ready(function () {
    $("#lnkSalir").click(function (e) {
        swal({
            title: "¿Esta seguro de que desea salir del sistema?",
            text: "",
            icon: "warning",
            showCancelButton: true,
            closeOnConfirm: false,
            buttons: {
                cancel: {
                    text: 'Cancelar',
                    value: null,
                    visible: true,
                    className: 'btn btn-default',
                    closeModal: true,
                },
                confirm: {
                    text: 'Aceptar',
                    value: true,
                    visible: true,
                    className: 'btn btn-warning',
                    closeModal: true
                }
            }
        }).then((willClose) => {
            if (willClose) {
                Salir();
            }
            
        });
    });


   


});