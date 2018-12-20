window.onload = load;

function load(){
    let buttonAcounts = document.getElementById('buttonAcounts');
    let buttonRent = document.getElementById('buttonRent');
    let buttonTransport =document.getElementById('buttonTransport');
    let buttonMissing = document.getElementById('buttonMissing');
    let buttonDelivery = document.getElementById('buttonDelivery');

    buttonDelivery.addEventListener('click', buttonDeliveryHandler);
    buttonMissing.addEventListener('click', buttonMissingHandler);
    buttonTransport.addEventListener('click', buttonTransportHandler);
    buttonAcounts.addEventListener('click', buttonAcountHandler);
    buttonRent.addEventListener('click', buttonRentHandler);
}

function buttonDeliveryHandler(){
    location.replace('deliveryInfo.php');
}

function buttonMissingHandler(){
    location.replace('missingProducts.php');
}

function buttonTransportHandler(){
    location.replace('assignTransport.php');
}

function buttonAcountHandler(){
    location.replace('accounts.php');
}

function buttonRentHandler(){
    location.replace('rentAccounts.php');
}