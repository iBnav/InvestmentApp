$(document).ready(function () {
    $.ajax({
        url: location.origin + "/api/Acoes/retornarAcoes/" + sessionStorage.getItem("id_user_investmentApp"),
        success: function (response) {
            if (response.length == 0) {
                $("#tbody_acoes").append('<tr class="text-center"><td colspan="4">Não há ações cadastradas</td></tr>')
            }

            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    $("#tbody_acoes").append(`<tr id="tr_${response[i].acaoID}"><th scope="row" id="th_nota_${response[i].acaoID}">${response[i].nota == -1 ? 'N/A' : response[i].nota}</th><td id="td_papel_${response[i].acaoID}">${response[i].papel}</td><td id="td_valor_${response[i].acaoID}">R$ ${response[i].valorPago}</td><td><i class="fa fa-trash clickable text-danger" onclick="apagarAcao(${response[i].acaoID})"></i>&nbsp;&nbsp;<i class="fa fa-edit clickable text-info" onclick="editarAcao(${response[i].acaoID})"></i></td></tr>`)
                }
                
            }
        },
        error: function (err) {
            alert(err.responseText);
        }
    })
});

function salvarAcao() {
    if (!$("#papel_acao").val() || $("#papel_acao").val() == " ") {
        alert("Papel não pode ser em branco");
        return;
    }

    if (!$("#valor_acao").val() || $("#valor_acao").val() <= 0) {
        alert("Valor da ação inválido");
        return;
    }

    if ($("#nota_acao").val() < 0 || $("#nota_acao").val() > 10) {
        alert("Nota da ação inválida");
        return;
    }

    var obj = {
        acaoID: 0,
        usuarioID: sessionStorage.getItem("id_user_investmentApp"),
        papel: $("#papel_acao").val(),
        valorPago: $("#valor_acao").val(),
        nota: !$("#nota_acao").val() ? null : $("#nota_acao").val()
    }

    $.ajax({
        url: location.origin + "/api/Acoes/salvar",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj),
        success: function (response) {
            location.reload();
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}


function apagarAcao(idAcao) {
    $.ajax({
        url: location.origin + "/api/Acoes/apagar/" + idAcao,
        method: "DELETE",
        success: function () {
            location.reload();
        },
        error: function (err) {
            alert(err.responseText);
        }
    })
}

function editarAcao(idAcao) {
    $("#valor_acao").attr("disabled", true);
    $("#valor_acao").val($("#td_valor_" + idAcao).html().substring(3));
    $("#papel_acao").attr("disabled", true);
    $("#papel_acao").val($("#td_papel_" + idAcao).html());
    $("#nota_acao").val($("#th_nota_" + idAcao).html());
    $("#btn_salvar").attr("onclick", "salvarAcao(" + idAcao + ")");
}

function salvarAcao(idAcao) {
    if ($("#nota_acao").val() < 0 || $("#nota_acao").val() > 10) {
        alert("Nota da ação inválida");
        return;
    }

    var obj = {
        acaoID: idAcao,
        usuarioID: sessionStorage.getItem("id_user_investmentApp"),
        papel: $("#papel_acao").val(),
        valorPago: $("#valor_acao").val(),
        nota: !$("#nota_acao").val() ? null : $("#nota_acao").val()
    }

    $.ajax({
        url: location.origin + "/api/Acoes/salvar",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj),
        success: function (response) {
            location.reload();
        },
        error: function (err) {
            alert(err.responseText);
        }
    });
}