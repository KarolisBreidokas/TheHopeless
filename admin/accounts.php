<?php
session_start();
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
        <link rel="stylesheet" href="../index.css">
        <script src='../webControllerPanel.js'></script>
        <title>E-SHOP</title>
    </head>
    <body>
        <div class="container-fluid">
            <div class="row">
                <div class="topnov">
                    <a class="active" href="../index.php">Home</a>
                    <a id="orderAccounts">Order Accounts</a>
                </div>
            </div>

            <div class="row">
               <div class="col-3"></div>
               <div class="col-6">
                   <h1> Accounts </h1>
               </div>
               <div class="col-3"></div>
            </div>

            <div class="row" id="adminPanel">
                <div class="col">
                    <button id="buttonAcounts">Accounts</button> 
                </div>
                <div class="col">
                    <button id="buttonRent">Rent Accounts</button> 
                </div>
                <div class="col">
                    <button id="buttonTransport">Assign Transport</button>
                </div>
                <div class="col">
                    <button id="buttonMissing">Missing Product Account</button>
                </div>
                <div class="col">
                    <button id="buttonDelivery">Delivery Info</button>
                </div>
            </div>


        </div>
    </body>
</html>
