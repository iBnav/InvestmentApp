function logout() {
    sessionStorage.removeItem("id_user_investmentApp");
    sessionStorage.removeItem("user_name_investmentApp");
    location.reload();
}