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
        <title>E-SHOP</title>
    </head>
    <body>
        <div class="container-fluid">
            <div class="row">
                <div class="topnov">
                    <a href="../index.php">Home</a>
                    <a href="news.inc.php">News</a>
                    <a class="active"  href="contact.inc.php">Contact</a>
                    <a href="about.inc.php">About</a>
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
                    }
                    ?>        
            </div>

<div class="row">
                <h1>Kontaktai: </h1>
</div>
              <div class="row">
                    <h4>Benas Klimašauskas +3706111111</h4>
                    </div>
                    <div class="row">
                    <h4>Evaldas Valiūnas +37062222222</h4>
                    </div>
                    <div class="row">
                    <h4>Edgaras Kolesnikas +3706333333</h4>
                    </div>
                    <div class="row">
                    <h4>Karolis Breidokas +37064444444</h4>
                    </div>
                    <div class="row">
                    <h4>Mantvydas Čiuklys +3706555555</h4>
                    </div>
            </div>

            <div class="row">

            </div>
         

        </div>
    </body>
</html>
