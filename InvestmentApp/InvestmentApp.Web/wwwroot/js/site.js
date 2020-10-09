function logout() {
    sessionStorage.removeItem("id_user_investmentApp");
    sessionStorage.removeItem("user_name_investmentApp");
    location.reload();
}

$(document).ready(function () {
    $.ajax({
        url: "https://api.infomoney.com.br/ativos/ticker",
        contentType: "application/json",
        success: function (response) {
            response.forEach(function (item) {
                $(".ticker").append(`<label class="font-weight-bold mr-1"> ${item.Name} ${item.Value} <span class="${item.Direction == "positivo" ? "text-success" : "text-danger"}">${item.Spread}<span></label>|&nbsp`);
            });
            
        },
        error: function (err) {
            console.log(err);
        }
        
    })
})