let button = document.getElementsByClassName('btn btn-primary');

let myFunction = function(){
    if(this.id=="addTransport" && this.id!='registerButton' && this.id!='loginButton'){
    window.alert("Kurjeris priskirtas");
    location.replace('../index.html');
    }
    else{
        if(this.id!='registerButton' && this.id!='loginButton')
        location.replace('../index.html');
    }
};

window.onload = function(){
for( let i=0; i < button.length; i++){
    button[i].addEventListener('click', myFunction, false);
}

let registerButton = document.getElementById('registerButton');
let loginButton = document.getElementById('loginButton');
registerButton.addEventListener('click', register, false);
loginButton.addEventListener('click', register, fasle);
}

function register(){
    let div = document.getElementById('register');
    div.innerHTML="";
    let form = div.appendChild(document.createElement('form'));
    let input = form.appendChild(document.createElement('input'));
    input.type = 'email';
    input.name = 'email';
    input.value = 'Elektroninis Pastas';

    let inputPassword = form.appendChild(document.createElement('input'));
    inputPassword.type = 'text';
    inputPassword.name = 'password';
    inputPassword.value = 'Slaptazodis';

    let button = form.appendChild(document.createElement('button'));
    button.className = 'btn btn-primary';
    button.innerHTML = 'GERAI'

}
