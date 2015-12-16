function colocaFotoImg(idimg, idarq) {
    var input = document.getElementById(idarq);
    var imgtext;
    var fReader = new FileReader();
    fReader.readAsDataURL(input.files[0]);
    fReader.onloadend = function (event) {
        var img = document.getElementById(idimg);
        imgtext = event.target.result;
        img.src = imgtext;
    }
}

function validatePassword() {
    var password = document.getElementById("Password"), confirmPassword = document.getElementById("ConfirmPassword"), confirmPasswordDiv = document.getElementById("ConfirmPasswordDiv");

    if (password.value != confirmPassword.value) {
        confirmPasswordDiv.className = "col-sm-10 has-error";
        confirmPassword.setCustomValidity("As senhas não combinam");
    } else {
        confirmPassword.setCustomValidity('');
        confirmPasswordDiv.className = "col-sm-10";
    }
}