<?php

$servername = "localhost";
$dbUsername = "manciu2";
$dbPassword = "Eechoquoopoqua3o";
$dbName = "manciu2";

$conn = mysqli_connect($servername, $dbUsername, $dbPassword, $dbName);
if(!$conn){
    die("Connection failed: ".mysqli_connect_error());
}