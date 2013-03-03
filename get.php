<?php
if ($_GET['num'] > 0 && $_GET['num'] < 23) {
	header("Location: http://ec2-54-228-67-114.eu-west-1.compute.amazonaws.com/data/S3_BAF_Chrom" . $_GET['num']  . ".txt");
	die();
} else {
        echo $_GET['num'];
	echo "No file...";
}

?>
