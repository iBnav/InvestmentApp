function login() {
    if (!$("#txt_email").val()) {
        alert("Email em branco");
        return
    }

    if (!$("#txt_senha").val()) {
        alert("Senha em branco");
        return
    }
    $("#spinner_loading").removeAttr("hidden");

    var user = {
        email: $("#txt_email").val(),
        password: $("#txt_senha").val()
    }

    $.ajax({
        url: location.origin + "/api/Auth/AutenticarUsuario",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(user),
        success: function (response) {
            sessionStorage.setItem("id_user_investmentApp", response.id);
            sessionStorage.setItem("user_name_investmentApp", response.nome);
            $("#spinner_loading").attr("hidden", true);
            location.href = "/";
        },
        error: function (err) {
            alert("Erro! " + err.responseText);
            $("#spinner_loading").attr("hidden", true);
        }
    });

    
}