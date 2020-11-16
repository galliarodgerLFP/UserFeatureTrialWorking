<?php
require 'connectionSettings.php';

$loginUsername = $_POST["loginUsername"];
$loginPassword = $_POST["loginPassword"];

if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}

$sqlLogin = "SELECT userID, username, password FROM USERS WHERE username = '" . $loginUsername . "'";
$result = $connection->query($sqlLogin);

if ($result->num_rows > 0){
    //output data of each row
    while($row = $result->fetch_assoc()){ //finding username
        if ($row["password"] == $loginPassword){
            echo $row["userID"]; //if -1 there is an error
        }
        else{
            echo "Wrong";
        }
    }
}else{
        echo "User DNE";
    }

    $connection->close();
?>