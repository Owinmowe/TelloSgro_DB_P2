<?php
function Connect()
{
	$DB="parcial";
	$DBIP="localhost";
	$DBUser="root";
	$DBPass="root";

	$link = new mysqli($DBIP, $DBUser, $DBPass, $DB);

	if($link->connect_errno)
	{ //Si no se hace la conexion, sale posterior a mostrar el error.
 	   	echo "Invalid Database connection! " . PHP_EOL; //PHP_EOL es el fin de linea.
    	echo "Error: " . mysqli_connect_errno() . PHP_EOL;
 	   exit;
	}
	//echo "Database Successfully Connected! \n";

	return $link;
}
?>