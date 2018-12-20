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
                        <h1> Assign Transport </h1>
                        <table class="table table-bordered">
                                <thead>
                                        <tr>
                                            <th scope="col">ID</th>
                                            <th scope="col">Vardas</th>
                                            <th scope="col">Numeris</th>
                                            <th scope="col">Pastas</th>
                                            <th scope="col">Uzsakymai</th>
                                            <th scope="col">Priskirti</th>
                                        </tr>
                                    </thead>
                                    <tbody>
    
                                        <?php
                                            $sql = "SELECT DISTINCT id,alias,phone,email FROM transport";
                                            $result = $conn->query($sql);
                                            if($result->num_rows > 0){
                                                while($row=$result->fetch_assoc()){
                                                    echo '
                                                    <tr>
                                                    <th scope="row">';
                                                    echo $row['id'];
                                                    echo '</th>
                                                    <td>';
                                                    echo $row['alias'];
                                                    echo '</td>
                                                    <td>';
                                                    echo $row['phone'];
                                                    echo '</td>
                                                    <td>';
                                                    echo $row['email'];
                                                    echo '</td>
                                                    <td>
                                                        <form action="updateTransport.php" method="post">
                                                            <select name="orders">';
                                                           
                                                             

                                                            echo ' </select>
                                                        </form>
                                                    </td>
                                                    <td><button type="submit" class="btn btn-warning" name="submit-confirm">Priskirti</button></td>
                                                </tr>
                                            
                                            ';
                                                }
                                            }
                                            

                                        ?>
                                        
                                        
                                    </tbody>
                        </table>
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
