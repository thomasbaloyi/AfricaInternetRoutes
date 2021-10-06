// Include namespace system
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

/**
	* Collects and filters data from sources
	* Builds database using data.
	*
	* @author Thomas Baloyi
	*/
public class DataController
{
	static string AFRINIC_URI = "https://stats.afrinic.net/index.php/download/asndata.csv" ;

	static string CAIDA_URI = "https://publicdata.caida.org/datasets/as-relationships/serial-2/20210901.as-rel2.txt.bz2";
	
	static string PCH_URI = "https://www.pch.net/ixp/data" ;

	static string ripe = "https://www.maxmind.com/en/geoip2-services-and-databases" ;

	static string max = "https://www.maxmind.com/en/geoip2-services-and-databases";

	public static void Main(String[] args)
	{

		downloadData(AFRINIC_URI, "asndata.csv");
		downloadData(CAIDA_URI, "20210901.as-rel2.txt.bz2");
		
		List<ASN> asns = processAfrinicData();
		SerializeASNs(asns, "ASNData.json");
		Console.Write("Done");
	}

	private static void SerializeASNs(List<ASN> list, string filename)
    {
		JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
		string json = JsonSerializer.Serialize(list, options);
		File.WriteAllText("../ProcessedData/" + filename, json);
		Console.WriteLine(File.ReadAllText("../ProcessedData/" + filename));
	}
	
	/// <summary>
    /// Adds data from asndata.csv into a list 
    /// </summary>
    /// <returns></returns>
	private static List<ASN> processAfrinicData() 
	{
		StreamReader afrinic = DataController.readData("asndata.csv");
		afrinic.ReadLine();
		List<ASN> list = new List<ASN>(0);
		while (!afrinic.EndOfStream)
		{
			String[] asn = afrinic.ReadLine().Split(",");
			if (asn.Length == 8)
			{
				ASN asnObject = new ASN
				{
					asn_num = int.Parse(asn[0]),
					reg_date = asn[1],
					country = asn[2],
					region = asn[3],
					reg_year = int.Parse(asn[4]),
					industry = asn[5],
					org_category = asn[6],
					asn_type = asn[7]
				};
				list.Add(asnObject);
			}
		}
		afrinic.Close();
		return list;
	}

	/// <summary>
	/// Downloads data from the internet and adds it to a ../RawData directory
	/// </summary>
	/// <param name="link"></param>
	/// <param name="filename"></param>
	private static void downloadData(String link, String filename)
	{
		WebClient webClient = new WebClient();
		webClient.DownloadFile(link, "../RawData/" + filename);
	}
	
	/// <summary>
    ///  Reads file data to a StreamReader
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
	private static StreamReader readData(String filename) 
	{
		StreamReader reader = new StreamReader("../RawData/" + filename);
		return reader;
	}
}