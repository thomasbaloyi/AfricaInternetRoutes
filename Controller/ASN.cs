using System;

public class ASN
{
	private int asn_num { get; set; }
	private String reg_date { get; set; }
	private String country { get; set; }
	private String region { get; set; }
	private int reg_year { get; set; }
	private String industry { get; set; }
	private String org_category { get; set; }
	private String asn_type { get; set; }

	public ASN(int asn_num, String reg_date, String country, String region, int reg_year, String industry, String org_category, String asn_type)
	{
		this.asn_num = asn_num;
		this.reg_date = reg_date;
		this.country = country;
		this.region = region;
		this.reg_year = reg_year;
		this.industry = industry;
		this.org_category = org_category;
		this.asn_type = asn_type;
	}
}