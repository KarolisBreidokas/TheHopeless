<?php
if(isset($_POST['login-submit'])){
     require 'dbh.inc.php';

     $email = $_POST['mail'];
     $password = $_POST['pwd'];

     $sql = "SELECT email, pwd, trust FROM users";
     $result = $conn->query($sql);

     if($result->num_rows > 0){
         while($row = $result->fetch_assoc()){

            if($row['email']==$email){
                $pwdCheck = password_verify($password, $row['pwd']);
                if($pwdCheck==true){
                    session_start();
                    $_SESSION['id']=$row['id'];
                    $_SESSION['email']=$row['email'];
                    $_SESSION['trust']=$row['trust'];

                    header("Location: ../index.php?login=success");
                    exit();
                }else{
                    header("Location: ../index.php?error=nopwd");
                    exit();
                }
            }
         }
     } 
     header("Location: ../index.php?error=nouser");
     exit();
     

} else{
    header("Location: ../index.php");
    exit();
}