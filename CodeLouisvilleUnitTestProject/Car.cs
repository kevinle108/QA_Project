using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        private HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
        };

        public int NumberOfPassengers { get; }

        public Car() 
            : this(0, "", "", 0)
        {
        }

        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
            : base(4, gasTankCapacity, make, model, milesPerGallon)
        {
        }

        public async Task<bool> IsValidModelForMakeAsync()
        {
            string endpoint = $"vehicles/getmodelsformake/{base.Make}?format=json";
            string response = await _client.GetStringAsync(endpoint);
            RootResponse resObject = JsonSerializer.Deserialize<RootResponse>(response);
            List<Result> models = resObject.Results.ToList();
            bool isValid = models.Any(x => x.Model_Name == base.Model);
            return isValid;
        }

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            if (year < 1995) throw new ArgumentException("Sorry, no data is available for years before 1995.");
            else {
                //https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformakeyear/make/honda/modelyear/2015?format=json
                string endpoint = $"vehicles/getmodelsformakeyear/make/{base.Make}/modelyear/{year}?format=json";
                string response = await _client.GetStringAsync(endpoint);
                RootResponse resObject = JsonSerializer.Deserialize<RootResponse>(response);
                List<Result> models = resObject.Results.ToList();
                bool isValid = models.Any(x => x.Model_Name == base.Model);
                return isValid;
            }
            
        }


    }
}
