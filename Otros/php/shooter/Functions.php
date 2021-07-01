<?php
include("Connection.php");
function InsertUser($username,$password) : void
{
	$con = Connect();
	$sql = "INSERT INTO `users` (`user_ID`, `user_name`, `user_password`) VALUES (NULL, '".$username."', '".$password."')";
	$query = $con->query($sql) or die("Username already exists :c");
	echo "Successfully created user <3";
}

function LoadUser($username,$password) : void//Devuelve un true si se hace correctamente
{
	$con = Connect();
	$sql = 'SELECT * FROM `users` WHERE user_name = "'.$username.'"';/*.'" AND user_password = "'.$password.'"';*/
	if ($con->multi_query($sql)) 
	{
        echo "Successfully logged in <3";
	}
}
function InserScore() : void
{
	//INSERT INTO `score` (`score_ID`, `score_name`, `score_points`, `score_death`) VALUES (NULL, '3', '100', '1')
	$con = Connect();
	$sql = "INSERT INTO `users` (`user_ID`, `user_name`, `user_password`) VALUES (NULL, '".$username."', '".$password."')";
	$query = $con->query($sql) or die("Username already exists :c");
	echo "Successfully created user <3";
}
function LoadScore() : void
{
	$con = Connect();
	$sql = 'SELECT * FROM `users` WHERE user_name = "'.$username.'"';/*.'" AND user_password = "'.$password.'"';*/
	if ($con->multi_query($sql)) 
	{
        if ($result = $con->store_result()) 
        {
            $row = $result->fetch_row();
            foreach ($row as &$key) 
            {
               	echo $key . " ";
            }
            $result->free();
        }
	}
}

?>