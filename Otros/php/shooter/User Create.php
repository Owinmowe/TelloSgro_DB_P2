<?php
include("Functions.php");

$username = $_POST["username"];
$password = $_POST["password"];

if(is_null($username) {echo "*Username is null.";exit;}
if(is_null($password) {echo "*Password is null.";exit;}
	
InsertUser($username,$password);
/*
$username = $_POST["username"];
$password = $_POST["password"];
*/

?>