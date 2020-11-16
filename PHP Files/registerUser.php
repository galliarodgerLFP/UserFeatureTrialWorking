<?php
require 'connectionSettings.php';

$regUsername = $_POST["regUsername"];
$regPassw = $_POST["regPassw"];
$regLevel = $_POST["regLevel"];

//checking connection
if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}
echo "...connected successfully...";

//check if username is already taken
$sqlReg = "SELECT username FROM USERS WHERE username = '" . $regUsername . "'";
$result = $connection->query($sqlReg);

if ($result->num_rows > 0){
    echo "user already exists \n";
} 
else 
{
    //sqlReg = "INSERT INTO USERS(username, password, extra) VALUES (' . $regUsername . "','" . $regPassw "','" . $regLevel . "')";
    //$sqlReg = "INSERT INTO USERS(username, password, extra) VALUES (' . $regUsername . "','" . $regPassw "', " . $regLevel . ")";
    $sqlReg = "INSERT INTO users(username, password, level) VALUES ('" . $regUsername . "','" . $regPassw . "'," . $regLevel . ")";

    if ($connection->query($sqlReg) === TRUE){
        echo "...creation successful";
    } else {
        echo "Error: " . $sqlReg . "<br>" . $connection->error;
    }
}

$connection->close();

?>