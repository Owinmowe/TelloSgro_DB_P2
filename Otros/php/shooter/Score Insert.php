<?php
include("Functions.php");

/*$username = "admin";
$score = "100";
$deaths = "0";*/
$username = $_POST["username"];
$score = $_POST["score"];
$deaths = $_POST["deaths"];

if(is_null($username) {echo "*Username is null.";exit;}
if(is_null($score) {echo "*score is null.";exit;}
if(is_null($deaths) {echo "*death is null.";exit;}

InsertScore($username,$score,$deaths);

?>