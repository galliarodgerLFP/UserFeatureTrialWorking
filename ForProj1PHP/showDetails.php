<?php

require 'connectionSettings.php';

$loginUser = $_POST["loginUser"];

//Create connection
//$connection = new mysqli($servername, $username, $password, $databasename);

//Check connection
if ($connection->connect_error){ //if error
    die("Connection failed: " . $connection->connect_error);
}

//echo "...connected successfully";

//SQL PART
$sql = "SELECT id, username, password, extra FROM users WHERE username = '" . $loginUser . "'";
$result = $connection->query($sql);

if ($result->num_rows > 0){
    //output data of each row
    $rows = array();
    while($row = $result->fetch_assoc()){
        $rows[] = $row;
    } 
    //after whole array is created
    echo json_encode($rows); //passing array of stuff to Unity
}else{
        echo "0 results";
    }

$connection->close();
?>