using System;


namespace AfricaInternetRoutes.Models {
	/// <summary>
    /// Class
    /// <c>Nations</c>
    /// represents an African and its recognizable titles
    /// </summary>
	public class Nations {
		public string officialName { get; set; }  // The official name of the country
		private var alternativeNames = new ArrayList();

		/// <summary>
        /// method
        /// <c>checkName</c>
        /// assesses a given name to see whether it is an alternative name for this country.
        /// </summary>
        /// <param name="nameToCheck"></param>
        /// <returns>True or false result of assessment of possible alternative name</returns>
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

        /// <summary>
        /// method
        /// <c>addAlternative</c>
        /// appends alternative country name to the list of country titles.
        /// </summary>
        /// <param name="alternativeTitle"></param>
		public void addAlternative(string alternativeTitle)
        {
			alternativeNames.Add(alternativeTitle);  // add name to list of alternative names.
        }

        /// <summary>
        /// method
        /// <c>addAlternative</c>
        /// appends list of alternative country names to the list of country titles.
        /// </summary>
        /// </summary>
        /// <param name="arrayList"></param>
        public void addAlternative(ArrayList arrayList)
        {
            alternativeNames.AddRange(arrayList);  // append arraylist to list of alternative names.
        }
	}
}