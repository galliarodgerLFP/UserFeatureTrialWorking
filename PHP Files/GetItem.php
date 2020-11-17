<?php
require 'connectionSettings.php';

//$itemID =$_POST["itemID"];
$itemID = 1;

if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}

$sqlLogin = "SELECT dbID, content_name, description FROM usercontent WHERE dbID = '" . $itemID . "'";
$result = $connection->query($sqlLogin);

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