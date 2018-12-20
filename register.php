<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
        <link rel="stylesheet" href="index.css">
        <title>E-SHOP</title>
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
                <form action="includes/signup.inc.php" method="post">
                        
                        <input class="form" name="mail" type="text" id="registerEmail" placeholder="Email">
                        <input class="form" name="pwd"  type="password" id="registerPassword" placeholder="Password">
                        <input class="form" name="pwd-repeat" type="password" id="registerPasswordRepeat" placeholder="Repeat Password">
                        <button type="submit" id="buttonRegister" name="signup-submit">Submit</button>
                        <h1>Register</h1>
                </form>
            </div>

            <div class="row">
                <div class="col-3">
                   
                </div>
                <div class="col-6">
                    
                </div>
                <div class="col-3">
                    
                  
                </div>
            </div>
            <div class="row" id="adminPanel">
               
            </div>


        </div>
    </body>
</html>
