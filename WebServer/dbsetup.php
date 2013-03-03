<?php

	$username = "hackathon";
        $password = "password";
        $hostname = "hackathondbinstance.cy4gr78jxorz.eu-west-1.rds.amazonaws.com";

        $con = mysql_connect($hostname, $username, $password) or die("Unable to connect to MYSQL");
        echo "Connected to database!";

	$database       = "hackathon";
	$createDatabase = "CREATE DATABASE IF NOT EXISTS $database";
	mysql_query($createDatabase) or die(mysql_error());
	mysql_select_db($database) or die(mysql_error());	
	echo '<br>Database created and selected!';

	$objTable       = "objTable";
	$createObjTable = "CREATE TABLE IF NOT EXISTS $objTable
			   (id BIGINT NOT NULL AUTO_INCREMENT,
			    PRIMARY KEY (id),
			    chrom BIGINT NOT NULL,
			    file TEXT NOT NULL)";
	mysql_query($createObjTable) or die(mysql_error());
	echo '<br>objTable created.';

?>
