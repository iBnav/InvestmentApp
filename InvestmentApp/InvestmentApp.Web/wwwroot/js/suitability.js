var qtdPerguntas;

$(document).ready(function () {
    var perfil = sessionStorage.getItem("perfil_investmentApp");
    if(perfil == 1)
    $("#descricao_perfil").html("Seu perfil é <strong>Conservador</strong>");
            
    if(perfil == 2)
        $("#descricao_perfil").html("Seu perfil é <strong>Moderado</strong>");
            
    if(perfil == 3)
        $("#descricao_perfil").html("Seu perfil é <strong>Agressivo</strong>");

    $("body").css("overflow", "auto");
    $.ajax({
        url: location.origin + "/api/Suitability/retornarPerguntasRespostas",
        contentType: "application/json",
        success: function (response) {
            qtdPerguntas = response.perguntas.length;
            for (var i = 0; i < response.perguntas.length; i++) {
                $("#frm_suitability").append(`<label class="font-weight-bold">Pergunta ${response.perguntas[i].idPergunta}</label><select class="custom-select custom-select-sm mb-2" id="pergunta_${response.perguntas[i].idPergunta}"><option value="naoselecionado" selected>${response.perguntas[i].descricao}</option></select>`);
            }

            for (var i = 0; i < response.respostas.length; i++) {
                $("#pergunta_" + response.respostas[i].idPergunta).append(`<option value="${response.respostas[i].pontuacao}">${response.respostas[i].descricao}</option>`);
            }
        },
        error: function (err) {
            console.log(response.textMessage);
        }
        
    });
});

function enviarSuitability() {
    var total = 0;
    for (var i = 0; i < qtdPerguntas; i++) {
        if ($(`#pergunta_${i + 1}`).val() == "naoselecionado") {
            alert("Pergunta " + parseInt(i + 1) + " não preenchida");
            total = 0;
            break;
        }
        total += parseInt($(`#pergunta_${i+1}`).val());
    }

    if (total == 0) {
        return;
    }

    var obj = {
        userID: sessionStorage.getItem("id_user_investmentApp"),
        pontuacao: total
    }

    $("#spinner_loading").removeAttr("hidden");

    $.ajax({
        url: location.origin + "/api/Suitability/salvarPontuacao",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify(obj),
        success: function (response) {
            alert("Perfil salvo com sucesso!");
            if(total <= 10)
                sessionStorage.setItem("perfil_investmentApp", 1);
            if (total > 10 && total <= 25)
                sessionStorage.setItem("perfil_investmentApp", 2);
            if (total > 25)
                sessionStorage.setItem("perfil_investmentApp", 3);
            location.href = "/";
        },
        error: function (err) {
            $("#spinner_loading").attr("hidden", true);
            alert("Erro: " + err.responseText);
        }
    });
}