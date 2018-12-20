<?php
session_start();
require 'includes/dbh.inc.php';
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
        <link rel="stylesheet" href="index.css">
        <title>E-SHOP</title>
        <?php
        if(isset($_SESSION['trust'])){
            if($_SESSION['trust']>0){
             echo '<script src="webController.js"></script>';
            }
        }
        ?>
    </head>
    <body>
        <div class="container-fluid">
            <div class="row">
                <div class="topnov">
                    <a class="active" href="index.php">Home</a>
                    <a href="includes/news.inc.php">News</a>
                    <a href="includes/contact.inc.php">Contact</a>
                    <a href="includes/about.inc.php">About</a>
                </div>
                    <?php
                    if(isset($_SESSION['email'])){
                        echo '
                        <form action="includes/logout.inc.php" method="post">
                        <a>';
                        echo $_SESSION["email"];
                        echo '
                        </a>
                        <button type="submit" name="logout-submit">Logout</button>
                        </form>
                        ';
                    }else{
                        echo '
                        <form action="includes/login.inc.php" method="post">
                        <input id="Email" name="mail" class="login" type="text" placeholder="Email">
                        <input class="login" name="pwd" type="password" placeholder="Password">
                        <button type="submit" name="login-submit" id="buttonLogin">Login</button>
                        <button id="buttonRegister"><a href="register.php">Register</a></button>
                        </form> 
                        ';
                    }
                    ?>        
            </div>

            <div class="row">
                <div class="col-6">
                    <div class="container" id="productList">
                        <h1>PRODUCTS</h1> 
                        <form action="includes/addRent.inc.php" method="post"> 
                        <?php
                        if(isset($_SESSION['email'])){
                           echo '<button type="submit" name="confirm-submit">RENT</button>';
                        }else{
                            echo '<h4>Log in in order to rent a product</h4>';
                        }
                        ?>
                        
                        
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Model</th>
                                    <th scope="col">Price</th>
                                    <th scope="col">Rent</th>
                                </tr> 
                            </thead>
                        <tbody>

                        <?php
                        $sql = "SELECT id,alias, model, price FROM products";
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
                                <td>
                                <input name="radio" value="';
                                echo $row['id'];
                                echo '" type="radio">
                                </td>
                                </tr>
                                ';
                            }
                        }   
                        ?>
                        </tbody>
                    </table>
                    </form>
                    </div>
                </div>
                <div class="col-4">
                    <div class="container" id="catalog">
                        <h1>CATALOG</h1>
                        <table id="catalogTable">

                    <?php
                     $sql = "SELECT id,alias, model, price FROM products";
                     $result = $conn->query($sql);
                     if($result->num_rows > 0){
                         while($row = $result->fetch_assoc()){
                            echo '
                            <div class="card" style="width: 560px;">
                            <img class="card-img-top" src="images/0.png" alt="Product image">
                            <div class="card-body">
                            <h5 class="card-title">';
                            echo $row['alias'];
                            echo'
                            </h5>
                            <p class="card-text">';
                            echo $row['model'];
                            echo'
                            </p>
                            <a href="#"></a>
                            </div>
                            </div>
                            ';
                         }
                     } 
                    ?>
                        </table>

                    </div>
                </div>
                <div class="col-2">
                    <div class="container" id="orderedProducts">
                        <h1>CART</h1>
                        <table id="cartTable">
                            
                            <button id="buttonBuy">BUY</button>
                            <input type="text" id="adressInput" placeholder="Adress">
                            
                        </table>

                    </div>
                </div>
            </div>
            <?php
            if(isset($_SESSION['trust'])){
                if($_SESSION['trust']>0){
                echo '
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
                ';
                }
            }else{

            }
            ?>
        </div>
    </body>
</html>
