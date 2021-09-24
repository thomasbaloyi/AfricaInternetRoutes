using System;


namespace AfricaInternetRoutes.Models {
	public class Nations {
		public string officialName { get; set; }  // The official name of the country
		private var alternativeNames = new ArrayList();

		public bool checkName(string nameToCheck) {
			bool answer = false;  // value of whether name is an alternative title for a country.
			// check each alternative name for this country and compare with name to check.
			foreach(string country in alternativeNames)
            {
                if (nameToCheck.Equals(country, StringComparison.OrdinalIgnoreCase))
                {
					answer = true;
					break;
                }
            }
			return answer; 
		}

		//public void addAlternative
	}
}