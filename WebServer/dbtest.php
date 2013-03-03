<?php

        $username = "hackathon";
        $password = "password";
        $hostname = "hackathondbinstance.cy4gr78jxorz.eu-west-1.rds.amazonaws.com";

        $con = mysql_connect($hostname, $username, $password) or die("Unable to connect to MYSQL");
        echo "Connected to database";

?>
