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

    if (email == null || password == null || name == null || repeatedPassword == null)
        Swal.fire("Упс, у нас что-то пошло не так =(", "Попробуйте позже", 'error');

    if (email.length === 0 || password.length === 0 || repeatedPassword.length === 0 || name.length === 0) {
        Swal.fire('Одно из полей не заполнено!', 'Проверьте введенные данные', 'error');
        return;
    }
    if (password != repeatedPassword) {
        Swal.fire('Пароли не совпадают!', '', 'error');
        return;
    }
    Swal.fire('Вы зарегистрированы!', 'Хорошего отдыха в нашем зоопарке!', 'success');
});