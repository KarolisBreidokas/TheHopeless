<?php
session_start();

$option = $_POST['radio'];
echo $option;
$email = $_SESSION['email'];
echo $email;
require 'dbh.inc.php';
$sql = "INSERT INTO rents (product_id, buyer) VALUES (?,?)";

$stmt = mysqli_stmt_init($conn);
if(!mysqli_stmt_prepare($stmt, $sql)){
    header("Location: ../index.php?error=sqlerror");
    exit();
} else{
    mysqli_stmt_bind_param($stmt, "ss", $option, $email);
    mysqli_stmt_execute($stmt);
    header("Location: ../index.php?rent=success");
    exit();
}