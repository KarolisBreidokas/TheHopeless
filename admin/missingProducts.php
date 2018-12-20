<?php
session_start();
require '../includes/dbh.inc.php';
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
                </div>
            </div>

            <div class="row">
                    <div class="col-3"></div>
                    <div class="col-6">
                        <h1> Missing Products </h1>
                    </div>
                    <div class="col-3"></div>
            </div>

            <div class="row">
                <div class="col"></div>
                <div class="col">

                        <table id="productTable" class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Name</th>
                                        <th scope="col">Description</th>
                                        <th scope="col">Price</th>
                                        <th scope="col">Quantity</th>

                                    </tr>
                                </thead>
                            <tbody>
                               
                                    <?php

                                    $sql = "SELECT id,alias,model, price FROM products WHERE quantity=0";
                                    $result = $conn->query($sql);
                                    
                                    if($result->num_rows > 0){
                                        while($row = $result->fetch_assoc()){
                                            echo '
                                            <tr>
                                            <th scope="row">
                                            '; echo $row['id'];
                                            echo '
                                            </th>
                                            <td>
                                            '; echo $row['alias'];
                                            echo '
                                            </td>
                                            <td>
                                            '; echo $row['model'];
                                            echo '
                                            </td>
                                            <td>
                                            '; echo $row['price'];
                                            echo '
                                            </td>
                                            <td>0
                                            </td>
                                            </tr>
                                            ';
                                }
                            }  
                                   ?>
                                </tbody>
                            </table>

                </div>
                <div class="col"></div>
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
