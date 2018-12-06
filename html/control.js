let button = document.getElementsByClassName('btn btn-primary');
console.log('hey');

let myFunction = function(){
    if(this.id=="addTransport"){
    window.alert("Kurjeris priskirtas");
    location.replace('../index.html');
    }
    else{
        location.replace('../index.html');
    }
};

window.onload = function(){
for( let i=0; i < button.length; i++){
    button[i].addEventListener('click', myFunction, false);
}

}
