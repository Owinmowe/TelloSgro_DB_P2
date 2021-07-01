<?php
include("Connection.php");

function InsertUser($username,$password) : void
{
	$con = Connect();
	$sql = "INSERT INTO `users` (`user_ID`, `user_name`, `user_password`) VALUES (NULL, '".$username."', '".$password."')";
	$query = $con->query($sql) or die("*Username already exists :c");
	echo "Successfully created user <3";
}

function LoadUser($username,$password) : void//Devuelve un true si se hace correctamente
{
	$con = Connect();
	$sql = 'SELECT * FROM `users` WHERE user_name = "'.$username.'" AND user_password = "'.$password.'"';
	if ($con->multi_query($sql)) 
	{
        if ($result = $con->store_result()) 
        {
            $row = $result->fetch_row();
            echo is_null($row)? "*Username or Password is invalid" : "Successfully logged in <3";
            $result->free();
        }
	}
}

function InsertScore($username,$score,$death) : void
{
	$con = Connect();
	$uid = GetUserID($username);
	$aux = 'SELECT * FROM `score` WHERE score_name = "'.$uid.'"';
	$sql = "0";
	if ($con->multi_query($aux)) 
	{
        if ($result = $con->store_result()) 
        {
            $row = $result->fetch_row();
            if(is_null($row))
            {
            	if(is_null($uid) && is_null($uid) && is_null($uid))
            	{
					echo "*Register does not been created. At least 1 register was null.";
            	}else
            	{
					$sql = "INSERT INTO `score` (`score_ID`, `score_name`, `score_points`, `score_death`) VALUES (NULL, '".$uid."', '".$score."', '".$death."')";
            		echo "Score created!";
            	}
            	
            }
            else
            {	
            	if(isActualGreater($username,$score))
            	{
            		$sql = "UPDATE `score` SET `score_points` = ".$score.", `score_death` = ".$death." WHERE `score_name` = '".$uid."'";
            		echo "Updated score!";
            	}
            	else
            	{
            		echo "*Not Updater cos' not higher.";
            	}
            }
            $result->free();
        }  
	}
	if($sql!="0")
	{
		$query = $con->query($sql) or die("*Not executed any query");
	}
}

function GetRanking() : void
{
	$con = Connect();
	$sql = 'SELECT users.user_name, score.score_death, score.score_points FROM `score` JOIN users ON users.user_ID = score.score_name ORDER BY score_points DESC LIMIT 10';
	$con->real_query($sql); 
		
    /* this was a select/show or describe query */
    $result = $con->store_result();

    /* process resultset */
    $row = $result->fetch_all();
    $cont = 0;
    foreach ($row as &$key)
    {
      	for ($i=0; $i < $con->field_count; $i++) 
      	{ 
      		echo $key[$i];
      		if($i != 2)
      		{
      			echo "-";
         		}
      		else{
      			echo "_";
      		}
    	}
    }
    /* free resultset */
    $result->free();
    $result->close();
}

function GetUserID($username)
{
	$con = Connect();
	$aux = 'SELECT user_ID FROM `users` WHERE user_name = "'.$username.'"';
	if ($con->multi_query($aux)) 
	{
        if ($result = $con->store_result()) 
        {
            $row = $result->fetch_row();
            $result->free();
            return $row[0];
        }
	}
}

function isActualGreater($username,$actualScore) 
{
	$con = Connect();
	$uid = GetUserID($username);
	$aux = 'SELECT score_points FROM `score` WHERE score_name = "'.$uid.'"';
	if ($con->multi_query($aux)) 
	{
        if ($result = $con->store_result()) 
        {
            $row = $result->fetch_row();
            $result->free();
            return ($actualScore > $row[0]);
        }
	}
	$AvoidCrash = "1";
	return $AvoidCrash;
}

?>