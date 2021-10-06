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

	static string AFRINIC_LINK = "https://stats.afrinic.net/index.php/download/asndata.csv" ;

	static string CAIDA_LINK = "https://publicdata.caida.org/datasets/as-relationships/serial-2/20210901.as-rel2.txt.bz2";
	
	static string pch = "https://www.pch.net/ixp/data" ;

	static string ripe = "https://www.maxmind.com/en/geoip2-services-and-databases" ;

	static string max = "https://www.maxmind.com/en/geoip2-services-and-databases";

	public static void Main(String[] args)
	{

		downloadData(AFRINIC_LINK, "asndata.csv");
		// process data
		//DataController.processAfrinic();
		Console.Write("Done");
	}
	
	/// <summary>
    /// Adds data from asndata.csv to a dictionary
    /// </summary>
	private static void processAfrinic() 
	{
		StreamReader afrinic = DataController.readData("asndata.csv");
		dictionary = new Dictionary < int, ASN > (0);
		afrinic.ReadLine();
		while (!afrinic.EndOfStream)
		{
			String[] asn = afrinic.ReadLine().Split(",");
			Console.WriteLine(asn[0]);
			if (asn.Length == 8)
			{
				dictionary[int.Parse(asn[0])] = new ASN(int.Parse(asn[0]), asn[1], asn[2], asn[3], int.Parse(asn[4]), asn[5], asn[6], asn[7]);
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
		
		
		/*try
		{
			var inputStream = new java.io.BufferedInputStream(link.openStream());
			var outputStream = new FileStream("../RawData/" + filename);
			byte[] data = new byte[1024];
			int byteContent;
			while ((byteContent = inputStream.read(data, 0, 1024)) != -1)
			{
				outputStream.Write(data, 0, byteContent);
			}
		}
		catch (java.io.IOException e)
		{
			Console.WriteLine(e.toString());
		} */
	}
	/**
		* Given filename, reads data from a file the dataset directory into a scanner
		*
		* @return scanner containing data with data from file.
		* @throws FileNotFoundException
		*/
	private static StreamReader readData(String filename) 
	{
		StreamReader reader = new StreamReader(filename);
		return reader;
	}
}