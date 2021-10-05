public class ASN {
    private int asn_num;
    private String reg_date;
    private String country;
    private String region;
    private int reg_year;
    private String industry;
    private String org_category;
    private String asn_type;

    public ASN(int asn_num, String reg_date, String country, String region, int reg_year, String industry, String org_category, String asn_type) {
        this.asn_num = asn_num;
        this.reg_date = reg_date;
        this.country = country;
        this.region = region;
        this.reg_year = reg_year;
        this.industry = industry;
        this.org_category = org_category;
        this.asn_type = asn_type;
    }

    public void setAsn_num(int asn_num) {
        this.asn_num = asn_num;
    }

    public void setAsn_type(String asn_type) {
        this.asn_type = asn_type;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public void setIndustry(String industry) {
        this.industry = industry;
    }

    public void setOrg_category(String org_category) {
        this.org_category = org_category;
    }

    public void setReg_date(String reg_date) {
        this.reg_date = reg_date;
    }

    public void setReg_year(int reg_year) {
        this.reg_year = reg_year;
    }

    public void setRegion(String region) {
        this.region = region;
    }

    public int getAsn_num() {
        return asn_num;
    }

    public int getReg_year() {
        return reg_year;
    }

    public String getAsn_type() {
        return asn_type;
    }

    public String getCountry() {
        return country;
    }

    public String getIndustry() {
        return industry;
    }

    public String getOrg_category() {
        return org_category;
    }

    public String getReg_date() {
        return reg_date;
    }

    public String getRegion() {
        return region;
    }

    @Override
    public String toString() {
        return "ASN{" +
                "asn_num=" + asn_num +
                ", reg_date='" + reg_date + '\'' +
                ", country='" + country + '\'' +
                ", region='" + region + '\'' +
                ", reg_year=" + reg_year +
                ", industry='" + industry + '\'' +
                ", org_category='" + org_category + '\'' +
                ", asn_type='" + asn_type + '\'' +
                '}';
    }
}
