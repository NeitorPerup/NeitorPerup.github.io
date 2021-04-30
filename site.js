let form = document.getElementById("form_signUp");

form.addEventListener("submit", function (event) {
    event.preventDefault();
    new FormData(form);
});

form.addEventListener("formdata", event => {
    const data = event.formData;
    const values = [...data.values()];

    console.log(values);

    let name = data.get("name");
    let email = data.get("email");
    let password = data.get("password");
    let repeatedPassword = data.get("repeatpassword");

    if (email == null || email.length == 0 || password == null || password.length == 0
     || repeatedPassword == null || repeatedPassword.length == 0 || name == null || name.length == 0) {
        Swal.fire('Одно из полей не заполнено!', 'Проверьте введенные данные', 'error');
        return;
    }
    if (password != repeatedPassword) {
        Swal.fire('Пароли не совпадают!', '', 'error');
        return;
    }
    Swal.fire('Вы зарегистрированы!', 'Хорошего отдыха в нашем зоопарке!', 'success');
});