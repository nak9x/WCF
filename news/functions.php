<?php		
define('NEWS_URL', 'http://stox.vn/iFrameStoxEN/rss/VNNews.aspx?ID=6002&chuyendeID=0');
define('EXPERT_URL', 'http://stox.vn/iFrameStoxEN/rss/VNNews.aspx?ID=173&chuyendeID=0');

include_once('connectVars.php');

$type = $_GET['type'];

//Retrieve rss from url
function GetFeed($feedUrl) 
{  
	$result = null;
	$content = file_get_contents($feedUrl);
	$parser = xml_parser_create('UTF-8');
	if(xml_parse($parser, $content, true))
	{
		$result = new SimpleXMLElement($content);
		xml_parser_free($parser);
	}

	return $result;
}  

function ImportFeed($type)
{
	$url = '';
	$table = '';

	switch($type)
	{
		case 'news':
			$url = NEWS_URL;
			$table = 'stock_news';
			break;
		
		case 'expert':
			$url = EXPERT_URL;
			$table = 'stock_expert_analysis';
			break;
	}

	$dbc = mysqli_connect(DB_HOST, DB_USER, DB_PASSWORD, DB_NAME);

	$rssFile = GetFeed($url);

	if($rssFile != null)
	{

		foreach($rssFile->channel->item as $rssItem)
		{			
			$query = "insert into ".$table." (title, pub_date, description, link) values ";
			$query = $query."(N'".mysqli_real_escape_string($dbc, $rssItem->title)."',";
			$query = $query."STR_TO_DATE('".$rssItem->pubDate."', '%a, %d %b %Y %H:%i:%s GMT'),N'";
			$query = $query.mysqli_real_escape_string($dbc, $rssItem->description)."','";
			$query = $query.mysqli_real_escape_string($dbc, $rssItem->link)."')";

			mysqli_query($dbc, $query);
		}
			
		mysqli_close($dbc);
	}
}

ImportFeed($type);

echo 'Success';
?>
