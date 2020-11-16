<?php
require 'connectionSettings.php';

$loginUsername = $_POST["loginUsername"]; //only need username for details

if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}

$sqlShowDetails = "SELECT userID, username, password, level FROM USERS WHERE username = '" . $loginUsername . "'";
$result = $connection->query($sqlShowDetails);

if ($result->num_rows > 0){
    $rows = array();
    while($row = $result->fetch_assoc()){
        $rows[] = $row;
    }
    echo json_encode($rows); //returns JSON representation
}
else{
    echo "...0 results.";
}

$connection->close();
?>