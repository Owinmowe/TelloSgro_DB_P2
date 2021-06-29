<?php
include("CONEXION.php");
$clase=$_POST['clase'];
if($clase=!"-------------"){
	}
if(  ($clase=="Todas" && $parte=="-------------" && $nivel=="-------------") || 
     ($clase=="Todas" && $parte=="Todas" && $nivel=="-------------") || 
     ($clase=="Todas" && $parte=="Todas" && $nivel=="Todos")   ){
	
	$sql="SELECT * from t_mf WHERE 1";
}

if($clase=="Guerrero" && $parte=="Cabeza" && $nivel=="20"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}
if($clase=="Guerrero"){
	$sql="SELECT * from t_mf WHERE tmf_clase=1";
}







$sql="SELECT * from datos WHERE usuario='$usuario'";//consulta
$consulta= mysql_query($sql,$conexion); //necesita la consulta y la conexion a la base de datos
$registro=mysql_fetch_row($consulta); //devuelve registros($Xconsulta)  

echo $registro[0];
echo "<br>".$registro[1];


/*echo "<table border=1 cellspacing=0 cellpadding=0>";
while($registro=mysql_fetch_row($consulta)){
echo "<tr>";
foreach ($registro as $dato){
echo "<td>".$dato."</td>";
}
echo "</tr>";
}
echo "</table>";



/*

%ham     .............. termine con ham nothinham
ham%     .............. empiece con ham  hamburgo
%ham% .............. southampton hamburgo nothinham
*/
?>