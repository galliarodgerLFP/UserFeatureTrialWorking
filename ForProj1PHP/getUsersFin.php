<?php

require 'connectionSettings.php';

//Create connection
//$connection = new mysqli($servername, $username, $password, $databasename);

//Check connection
if ($connection->connect_error){ //if error
    die("Connection failed: " . $connection->connect_error);
}

echo "...connected successfully";

//SQL PART
$sql = "SELECT username, password, extra FROM users";
$result = $connection->query($sql);

if ($result->num_rows > 0){
    //output data of each row
    while($row = $result->fetch_assoc()){
        echo "username: " . $row["username"] . " - password: " . $row["password"] . " - extra: " . $row["extra"] . "<br>";
    } 
}else{
        echo "0 results";
    }

$connection->close();
?>