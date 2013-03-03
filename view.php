<?php	
	$username = "hackathon";
        $password = "password";
        $hostname = "hackathondbinstance.cy4gr78jxorz.eu-west-1.rds.amazonaws.com";
	$database = "hackathon";

        $con = mysql_connect($hostname, $username, $password) or die("Unable to connect to MYSQL");
        echo "Connected to database";

	mysql_select_db($database);
	
	$query  = "SELECT * FROM objTable";
	$result = mysql_query($query);
	echo $result;
	while ($row = mysql_fetch_array($result)) {
		echo '<br>' . $row['id'] . ':' . $row['chrom'] . ':' . $row['file'];
	}
?>
