<?php
//get item id's from a specific user
require 'connectionSettings.php';

$userID = $_POST["userID"];

if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}

$sqlgetIDs = "SELECT contentID FROM users_content_bridge WHERE userID = '" . $userID . "'";
$result = $connection->query($sqlgetIDs);

if($result->num_rows > 0){
    $rows = array();
    while($row = $result->fetch_assoc()){
        $rows[] = $row;
    }
    echo json_encode($rows);
} else{
    echo "0";
}

$connection->close();
?>