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