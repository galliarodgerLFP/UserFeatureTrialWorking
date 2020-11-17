<?php

require 'connectionSettings.php';

$loginID = $_POST["loginID"];

if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}
echo "..connected successfully...<br>";

$sql = "SELECT id, username, password, extra FROM users WHERE id = '" . $loginID . "'";
$result = $connection->query($sql);

if ($result->num_rows > 0){
    $rows = array();;
    while($row = $result->fetch_assoc()){
        $rows[] = $row;
    }
    echo json_encode($rows);
}
else{
    echo "...0 results.";
}

$connection->close();

?>