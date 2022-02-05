<?php
/*
* Change the value of $password if you have set a password on the root userid
* Change NULL to port number to use DBMS other than the default using port 3306
*
*/
$user = 'root';
$password = ''; //To be completed if you have set a password to root
$database = 'test_technique_unity'; //To be completed to connect to a database. The database must exist.
$port = NULL; //Default must be NULL to use default port
$mysqli = new mysqli('127.0.0.1', $user, $password, $database, $port);


//Variable submited by the user
$_POST = json_decode(file_get_contents('php://input'), true);
$id = $_POST["id"];

$lvlClickCollect = $_POST["lvlClickCollect"];
$lvlAutoCollect = $_POST["lvlAutoCollect"];
$ressources = $_POST["ressources"];
$tiles = $_POST["tiles"];

//Connexion
if ($mysqli->connect_error) {
    die('Connect Error (' . $mysqli->connect_errno . ') '
            . $mysqli->connect_error);
}

//REQUEST 
$tilesId=uniqid();

$sql = "INSERT INTO  gamesave (id, lvlClickCollect, lvlAutoCollect, ressources, tilesId)
VALUES ('".$id."', $lvlClickCollect, $lvlAutoCollect, $ressources, '".$tilesId."') ";

$result=$mysqli->query($sql);
echo $sql;

if ($result=== TRUE) {
    foreach ($tiles as $tree) {
        $tileId=uniqid();
        $sql= " INSERT INTO  tile ( tileId, cat , coordX, coordY , tilesId )
        VALUES ('".$tileId."', ".$tree['cat'].", ".$tree['coordX'].",".$tree['coordY'].", '".$tilesId."')" ;
        echo $sql;
        $result=$mysqli->query($sql);
        if ($result!= TRUE) { http_response_code(404);}
    }
    http_response_code(200);

} else {
  echo "Query Failed! SQL: $sql - Error: ".mysqli_error($mysqli), E_USER_ERROR ;
  http_response_code(404);
}

$mysqli->close();

?>

