using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        private HttpClient _client;
        private string _baseAddress = "https://vpic.nhtsa.dot.gov/api/";
        public int NumberOfPassengers { get; set; }

        public Car() 
            : this(0, "", "", 0)
        {

        }

        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
            : base(4, gasTankCapacity, make, model, milesPerGallon)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseAddress);
        }

    }
}
