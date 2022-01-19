
let vm = 0
let currentVm = 0

function checkAlarm(temp)  {
    
    if(vm <= 0){
        vm = parseInt(document.getElementById("cbmin").value) ;
        currentVm = parseInt(document.getElementById("cbmin").value)        
    } 

    if (currentVm != parseInt(document.getElementById("cbmin").value)){

        vm +=  parseInt(document.getElementById("cbmin").value - currentVm)
        currentVm = parseInt(document.getElementById("cbmin").value)       
    }
    
    tempVm = vm * 1000

    if (temp > tempVm ){
        AlertDIV()
        playAudio()  
        vm += parseInt(document.getElementById("cbmin").value);       
    }   
    
    currentVm = parseInt(document.getElementById("cbmin").value)
}

let startTime = 0
let currentTime = 0

function inicia(){ 

    const timeHourMinSec = new Date()   
    
    if(startTime <= 0){
        startTime = Date.now() 
    } else{
        startTime = Date.now() - currentTime
    }  

    let posAlarmTime = 0

    document.getElementById("btn1").disabled = true    
    
	interval = setInterval(() => {
        currentTime = Date.now() - startTime
        timeHourMinSec.setTime(currentTime)
        document.getElementById("tempo1").innerHTML = timeHourMinSec.toISOString().substr(11, 8)

        checkAlarm(currentTime)

    },1000);
}

function zera(){
    startTime = 0
    currentTime = 0
}

function para(){  
    
	clearInterval(interval);
	document.getElementById("btn1").disabled = false;   
}


function playAudio() { 
    var x = document.getElementById("myAudio"); 
    x.play(); 
}

function pauseAudio() { 
    var x = document.getElementById("myAudio"); 
    x.pause(); 
}

function AlertDIV() {
  var x = document.getElementById("alerta");
    x.style.display = "block";
} 
function fecharDIV() {
  var x = document.getElementById("alerta");
    x.style.display = "none";
} 

function getCurrentTime(){
    return (currentTime /1000) | 0
}

