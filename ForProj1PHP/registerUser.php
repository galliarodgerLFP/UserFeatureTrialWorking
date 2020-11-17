<?php
//WORKS
require 'connectionSettings.php';

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
$extraStuff = $_POST["extraStuff"];

//Create connection
//$connection = new mysqli($servername, $username, $password, $databasename);

//Check connection
if ($connection->connect_error){ //if error
    die("Connection failed: " . $connection->connect_error);
}

echo "...connected successfully";

//SQL PART
$sql = "SELECT username FROM users WHERE username = '" . $loginUser . "'";
$result = $connection->query($sql);

if ($result->num_rows > 0){
    //Tell user that name is already taken
    echo "User already exists \n";
}
else
{    //insert into DB
    echo "Creating new user...";

    $sql2 = "INSERT INTO users(username, password, extra) VALUES ('" . $loginUser . "','" . $loginPass . "','" . $extraStuff . "')";
    if ($connection->query($sql2)===TRUE){
        echo "..creation successful";
    }
    else{
        echo "Error: " . $sql2 . "<br>" . $connection->error;
    }

}

$connection->close();

?>