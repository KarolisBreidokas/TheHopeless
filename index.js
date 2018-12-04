let classCol= document.getElementsByClassName('col');
let classCol6 = document.getElementsByClassName('col-6');
let i = 0;


let myFunction = function(){
    if(this.id=='catalogView2'){
    let source = document.getElementById('catalogImage');
    document.getElementById('orderedImage').src = source.src;
    }
    else{
    console.log(this.id);
    location.replace('./html/'+this.id+'.html');
    }
}

window.onload = function(){
for( let i=0; i < classCol.length; i++){
    classCol[i].addEventListener('click', myFunction, false);
}

for( let i=0; i < classCol6.length; i++){
    if(classCol6[i].id!='catalogView3' && classCol6[i].id!='catalogView4' && classCol6[i].id!='catalogView')
    classCol6[i].addEventListener('click', myFunction, false);
}
let buttonNext = document.getElementById('buttonNext');
let buttonPrevious = document.getElementById('buttonPrevious');
let image = document.getElementById('catalogImage');
this.addListeners();
this.init();

}

function addListeners(){
    buttonNext.addEventListener('click', buttonPressed, false);
    buttonPrevious.addEventListener('click', buttonPressed, false);
}

function buttonPressed(){
    if(this.id == 'buttonNext'){
        if(i<6){
        i++;
        document.getElementById('catalogImage').src='./images/'+i+'.jpg';
        }
        else{
            document.getElementById('catalogImage').src='./images/'+0+'.jpg'; 
            i=0;  
        }
    }
    else{
        if(this.id=='buttonPrevious'){
        if(i>0){
        i--;
        document.getElementById('catalogImage').src='./images/'+i+'.jpg';
        }
        else{
            document.getElementById('catalogImage').src='./images/'+6+'.jpg';
            i=6;
        }
        }
    }
}

function init(){
    for(let i = 0 ; i<7; i++){
    let img = new Image();   
    img.src = './images/' + i + '.jpg';
    document.getElementById('allProducts').appendChild(img);
    }
}