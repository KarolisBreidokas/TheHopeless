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
                    <a id="rentAccounts">Accounts</a>
                    <a id="rentEdit">Rent Edit</a>
                    <a id="rentPayment">Rent Payment</a>
                </div>
                <form>
                        <input class="login" type="date" placeholder="Data FROM">
                        <input class="login" type="date" placeholder="Data TO">
                        <button type="button" id="buttonSearch">SEARCH</button>
                    </form>
            </div>

                <table id="rentList">
                <tr>
                    <td>Product name</td>
                    <td>Product model</td>
                    <td>Client</td>
                </tr>
                <?php
                $query = "SELECT id, product_id, renter FROM rents";
                $result = conn->query($query);
                if($result->num_rows > 0) {
                    while($row = $result->fetch_assoc()) {
                        $p_id = $result['product_id'];
                    $query = "SELECT alias, model FROM products WHERE id = {$p_id}";
                    $product = conn->query($query);
?>
                <tr>
                    <td><?=$product[0]['alias']?></td>
                    <td><?=$product[0]['model']?></td>
                    <td><?=$result[0]['renter']?></td>
                </tr>
<?php
                    }
                }
                ?>
                </table>
                          




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
