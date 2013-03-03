<?php
        if (empty($_FILES)
            || !file_exists($_FILES["file"]["tmp_name"])
            || !is_uploaded_file($_FILES["file"]["tmp_name"]) 
            || $_FILES["file"]["error"] > 0) {
                echo 'No Upload.';
        } else {
		$path = 'uploads/' . rand() . $_FILES['file']['name'];
		while (file_exists($path)) {
			$path = rand() . $path;
		}
                if (move_uploaded_file($_FILES['file']['tmp_name'], $path)) {
			echo "WOOOO!";
		 	$username = "hackathon";
        		$password = "password";
        		$hostname = "hackathondbinstance.cy4gr78jxorz.eu-west-1.rds.amazonaws.com";
			$database = "hackathon";

        		$con = mysql_connect($hostname, $username, $password) or die("Unable to connect to MYSQL");
        		echo "Connected to database";
			
			mysql_select_db($database) or die(mysql_error());
			if (isset ($_GET['num'])) {
				$num = $_GET['num'];
			} else {
				$num = 1;
			}
			$query = "INSERT INTO objTable (chrom, file) VALUES ($num, '$path')";
			mysql_query($query) or die (mysql_error());
		} else {
			echo "NOOOOO!";
		}
	}
?>

<html>
<body>

<form action="send.php" method="post"
enctype="multipart/form-data">
<label for="file">Filename:</label>
<input type="file" name="file" id="file"><br>
<input type="submit" name="submit" value="Submit">
</form>

</body>
</html>

