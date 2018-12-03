let classCol= document.getElementsByClassName('col');
let classCol6 = document.getElementsByClassName('col-6');

let myFunction = function(){
    console.log(this.id);
    location.replace('./html/'+this.id+'.html');
};

window.onload = function(){
for( let i=0; i < classCol.length; i++){
    classCol[i].addEventListener('click', myFunction, false);
}

for( let i=0; i < classCol6.length; i++){
    classCol6[i].addEventListener('click', myFunction, false);
}

}

function sayHello(){
    console.log('hello');
}