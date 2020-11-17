<?php
require 'connectionSettings.php';

$loginUsername = $_POST["loginUsername"]; //only need username for details

if ($connection->connect_error){
    die("Connection failed: " . $connection->connect_error);
}
/* WHAT SHOULD HAPPEN
    - show what content (from the contents table) the logged in user can see (via bridge entity)


*/

?>