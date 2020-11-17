<?php
require 'connectionSettings.php';

$regUsername = $_POST["regUsername"];
$regPassw = $_POST["regPassw"];
$regLevel = $_POST["regLevel"];

$regID = $_POST["regID"];
$regName = $_POST["regName"];
$regSurname = $_POST["regSurname"];
$regAddress = $_POST["regAddress"];
$regEmail = $_POST["regEmail"];
$regCell = $_POST["regCell"];
$regLandline = $_POST["regLandline"];
$regMaritialStatus = $_POST["regMaritialStatus"];
$regRace = $_POST["regRace"];
$regGender = $_POST["regGender"];
$regAffiliate = $_POST["regAffiliate"];



//checking connection
if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}
echo "...connected successfully...";

//check if username is already taken
$sqlReg = "SELECT username FROM usersusers WHERE username = '" . $regUsername . "'";
$result = $connection->query($sqlReg);

if ($result->num_rows > 0){
    echo "user already exists \n";
} 
else 
{
    //sqlReg = "INSERT INTO USERS(username, password, extra) VALUES (' . $regUsername . "','" . $regPassw "','" . $regLevel . "')";
    //$sqlReg = "INSERT INTO USERS(username, password, extra) VALUES (' . $regUsername . "','" . $regPassw "', " . $regLevel . ")";
    //$sqlReg = "INSERT INTO users(username, password, level) VALUES ('" . $regUsername . "','" . $regPassw . "'," . $regLevel . ")";

    $sqlReg = "INSERT INTO `usersusers`(ID, username, password, level, name, surname, address, email, cell, landline, maritial_status, race, gender, affiliate) VALUES ('". $regID ."','" . $regUsername . "','" . $regPassw . "'," . $regLevel . ",'" . $regName . "','" . $regSurname . "','" . $regAddress . "','". $regEmail . "','". $regCell . "','". $regLandline . "','". $regMaritialStatus . "','". $regRace . "','". $regGender . "','". $regAffiliate . "')";

    if ($connection->query($sqlReg) === TRUE){
        echo "...creation successful";
    } else {
        echo "Error: " . $sqlReg . "<br>" . $connection->error;
    }
}

$connection->close();

?>