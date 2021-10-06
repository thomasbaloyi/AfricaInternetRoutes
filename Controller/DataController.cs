// Include namespace system
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;

/**
	* Collects and filters data from sources
	* Builds database using data.
	*
	* @author Thomas Baloyi
	*/
public class DataController
{
	/** Stores all unique ASNs */
	private static Dictionary<int, ASN> dictionary;

	static string AFRINIC_URI = "https://stats.afrinic.net/index.php/download/asndata.csv" ;

	static string CAIDA_URI = "https://publicdata.caida.org/datasets/as-relationships/serial-2/20210901.as-rel2.txt.bz2";
	
	static string PCH_URI = "https://www.pch.net/ixp/data" ;

	static string ripe = "https://www.maxmind.com/en/geoip2-services-and-databases" ;

	static string max = "https://www.maxmind.com/en/geoip2-services-and-databases";

	public static void Main(String[] args)
	{

		downloadData(AFRINIC_URI, "asndata.csv");
		downloadData(CAIDA_URI, "20210901.as-rel2.txt.bz2");
		processAfrinicData();


		Console.Write("Done");
	}
	
	/// <summary>
    /// Adds data from asndata.csv to a dictionary
    /// </summary>
	private static void processAfrinicData() 
	{
		StreamReader afrinic = DataController.readData("asndata.csv");
		dictionary = new Dictionary < int, ASN > (0);
		afrinic.ReadLine();
		while (!afrinic.EndOfStream)
		{
			String[] asn = afrinic.ReadLine().Split(",");
			if (asn.Length == 8)
			{
				dictionary.Add(int.Parse(asn[0]), new ASN(int.Parse(asn[0]), asn[1], asn[2], asn[3], int.Parse(asn[4]), asn[5], asn[6], asn[7]));
			}
		}
		afrinic.Close();
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