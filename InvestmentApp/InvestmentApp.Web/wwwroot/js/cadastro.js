function cadastrar() {
    if (!$("#txt_nome").val()) {
        alert("Nome deve ser preenchido");
        return;
    }

    if (!$("#txt_email").val()) {
        alert("Email deve ser preenchido");
        return;
    }

    if (!$("#txt_senha").val() || $("#txt_senha").val() != $("#txt_confirmar_senha").val()) {
        alert("Senha em branco ou senhas não coincidem");
        return;
    }

    $("#spinner_loading").removeAttr("hidden");
    var user = {
        nome: $("#txt_nome").val(),
        email: $("#txt_email").val(),
        password: $("#txt_senha").val()
    }

    $.ajax({
        url: location.origin + "/api/Cadastro/Usuario",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(user),
        success: function (response) {
            alert(response.message);
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