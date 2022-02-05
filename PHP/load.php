<?php
$user = 'root';
$password = ''; //To be completed if you have set a password to root
$database = 'test_technique_unity'; //To be completed to connect to a database. The database must exist.
$port = NULL; //Default must be NULL to use default port
$mysqli = new mysqli('127.0.0.1', $user, $password, $database, $port);

//Value submited by user
$id = $_POST['id'];

//Connexion
if ($mysqli->connect_error) {
    die('Connect Error (' . $mysqli->connect_errno . ') '
            . $mysqli->connect_error);
}

//REQUEST 
//FIRST REQUEST TO ACCESS DATA
$sql = "SELECT lvlClickCollect, lvlAutoCollect, ressources, tilesId FROM gamesave WHERE id = '".$id."' ";
$result = $mysqli->query($sql);

if ($result->num_rows > 0) {
  $data = $result->fetch_assoc();

  //SECOND REQUEST TO ACCESS DATA ON TREE
  $sql = "SELECT cat , coordX , coordY FROM tile WHERE tilesID='".$data['tilesId']."'"; 
  $result = $mysqli->query($sql);

  $array=[];
  if ($result->num_rows > 0) {
      while($row = $result->fetch_assoc()){
        $array[]= $row;
      } 
  }
  $aux=[];
  $aux["tiles"]=$array;
  $result= array_merge($data, $aux);
  
  echo json_encode( $result );

} else {
    http_response_code(404);
}

$mysqli->close();
?>
