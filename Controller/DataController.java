import java.io.*;
import java.sql.*;
import java.util.Calendar;
import java.util.Hashtable;
import java.util.Scanner;
import java.net.URL;

/**
 * Collects and filters data from sources
 * Builds database using data.
 *
 * @author Thomas Baloyi
 */
public class DataController {

    /** Stores all unique ASNs */
    private static Hashtable<Integer,ASN> hashTable;

    private final static String AFRINIC_LINK = "https://stats.afrinic.net/index.php/download/asndata.csv";

    private final static String CAIDA_LINK = "https://publicdata.caida.org/datasets/as-relationships/serial-2/20210901.as-rel2.txt.bz2";

    /** Contains data from: https://www.pch.net/ixp/data */
    private static Scanner pch;

    /** Contains data from: https://www.ripe.net/analyse/internet-measurements/routing-information-service-ris */
    private static Scanner ripe;

    /** Contains data from: https://www.maxmind.com/en/geoip2-services-and-databases */
    private static Scanner max;

    public static void main(String[] args) throws FileNotFoundException {
        downloadDatasets();

        // process data
        processAfrinic();

        System.out.print("Done");
    }

    /**
     * Downloads all relevant datasets if they are absent or out of date.
     */
    private static void downloadDatasets() {
        File relData = new File("datasets/20210901.as-rel2.txt.bz2");
        if (!relData.exists()) {
            try {
                getData(new URL(CAIDA_LINK),  "20210901.as-rel2.txt.bz2"); // update monthly
            } catch (IOException e) {
                System.out.println(e.toString());
            }
        }

        File afrinicData = new File("../data/" + "asndata.csv");
        if (!afrinicData.exists()) {
            try {
                getData(new URL(AFRINIC_LINK), "asndata.csv");
            } catch (IOException e) {
                System.out.println(e.toString());
            }
        }
    }

    /**
     * Processes eligible data from asndata.csv and adds to hash table.
     *
     * @throws FileNotFoundException
     */
    private static void processAfrinic() throws FileNotFoundException {
        Scanner afrinic = readData("asndata.csv");
        hashTable = new Hashtable<Integer, ASN>(0);
        afrinic.next();
        while (afrinic.hasNext()) {
            String[] asn = afrinic.next().split(",");
            if (asn.length==8) {
                hashTable.put(Integer.parseInt(asn[0]),new ASN(Integer.parseInt(asn[0]), asn[1], asn[2], asn[3], Integer.parseInt(asn[4]), asn[5], asn[6], asn[7]));
            } else {
                // Only one element does not fit criteria
            }
        }
        afrinic.close();
    }

    /**
     * Downloads data from the internet and stores it locally.
     *
     * @param link Represents the link where data is found.
     * @param filename represents the name the data is to be saved in.
     */
    private static void getData(URL link, String filename) {
        try {
            BufferedInputStream inputStream = new BufferedInputStream(link.openStream());
            FileOutputStream outputStream = new FileOutputStream("../data/"+filename);
            byte[] data = new byte[1024];
            int byteContent;
            while ((byteContent = inputStream.read(data, 0, 1024)) != -1) {
                outputStream.write(data, 0, byteContent);
            }
        } catch (IOException e) {
            System.out.println(e.toString());
        }
    }

    /**
     * Given filename, reads data from a file the dataset directory into a scanner
     *
     * @return scanner containing data with data from file.
     * @throws FileNotFoundException
     */
    private static Scanner readData(String filename) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File("../data/"+filename));
        scanner.useDelimiter("\n");
        return scanner;
    }

    /**
     * @return today's date.
     */
    private static String getDate() {
        Calendar calendar = Calendar.getInstance();
        String date;

        String YEAR = "" + calendar.get(calendar.YEAR);
        String MONTH = "" + (calendar.get(calendar.MONTH)+1);

        if ( (calendar.get(calendar.MONTH)+1) < 10 ) {
            date = YEAR + "0" + MONTH + "01";
        } else {
            date = YEAR + MONTH + "01";
        }

        return date;
    }
}
