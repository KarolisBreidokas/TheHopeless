let button = document.getElementsByClassName('btn btn-primary');
console.log('hey');

let myFunction = function(){
    console.log('hey');
    location.replace('../index.html');
};

window.onload = function(){
for( let i=0; i < button.length; i++){
    button[i].addEventListener('click', myFunction, false);
}

}
