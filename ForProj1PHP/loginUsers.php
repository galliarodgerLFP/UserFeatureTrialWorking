<?php
//WORKS

$connection = new mysqli("localhost", "root", "", "testproj");
//submitted by user

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

//Create connection
//$connection = new mysqli($servername, $username, $password, $databasename);

//Check connection
if ($connection->connect_error){ //if error
    die("Connection failed: " . $connection->connect_error);
}



//SQL PART
$sql = "SELECT id, username, password FROM users WHERE username = '" . $loginUser . "'";
$result = $connection->query($sql);

if ($result->num_rows > 0){
    //output data of each row
    while($row = $result->fetch_assoc()){ //finding username
        if ($row["password"] == $loginPass){
            echo $row["id"]; //if -1 there is an error
            //GET USER DATA HERE
            //GET PLAYER INFO HERE

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