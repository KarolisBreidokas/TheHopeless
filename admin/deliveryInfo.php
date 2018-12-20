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
                </div>
            </div>

            <div class="row">
                    <div class="col-3"></div>
                    <div class="col-6">
                        <h1> Delivery Info </h1>
                    </div>
                    <div class="col-3"></div>
                 </div>

                 <div class="row">
                    <div class="col"></div>
                    <div class="col">
                            <table class="table table-bordered">
                                    <thead>
                                            <tr>
                                                <th scope="col">#</th>
                                                <th scope="col">Vardas</th>
                                                <th scope="col">Numeris</th>
                                                <th scope="col">Pastas</th>
                                                <th scope="col">Uzsakymas</th>
                                                <th scope="col">Adresas</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">1</th>
                                                <td>Juozas Antanavicius</td>
                                                <td>860500403</td>
                                                <td>JuozasAn@gmail.com</td>
                                                <td>ID_2 GB</td>
                                                <td>Juozapaviciaus 22 Kaunas</td>
                                       
                                            </tr>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>Martynas Urbonavicius</td>
                                                <td>865423521</td>
                                                <td>MUrbonavicius@gmail.com</td>
                                                <td>ID_12 LTU</td>
                                                <td>Juozapaviciaus 22 Kaunas</td>
                             
                                            </tr>
                                            <tr>
                                                <th scope="row">3</th>
                                                <td>Tadas Vasiliauskas</td>
                                                <td>860554234</td>
                                                <td>TDVasilij@gmail.com</td>
                                                <td>ID_7 USA</td>
                                                <td>Juozapaviciaus 22 Kaunas</td>
                                               
                                            </tr>
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
