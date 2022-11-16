using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Diagnostics;
using Xunit;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class CarTests
    {
        [Fact]
        public void CreatedCarIsValidWith4Tires_EmptyParams()
        {
            var car = new Car();
            using (new AssertionScope())
            {
                car.Should().NotBeNull();
                car.NumberOfTires.Should().Be(4);
            }
        }

        [Fact]
        public void CreatedCarIsValidWith4Tires_Params()
        {
            var car = new Car(15, "Honda", "Civic", 30);
            using (new AssertionScope())
            {
                car.Should().NotBeNull();
                car.NumberOfTires.Should().Be(4);
                car.Make.Should().Be("Honda");
                car.Model.Should().Be("Civic");
                car.MilesPerGallon.Should().Be(30);


            }
        }

        [Theory]
        [InlineData("Honda", "Civic", true)]
        [InlineData("Honda", "Camry", false)]

        public async Task ValidModelForMake(string make, string model, bool expected)
        {
            var car = new Car(15, make, model, 30);
            bool result = await car.IsValidModelForMakeAsync();
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Car", "Camry", 2000, false)]
        [InlineData("Honda", "Camry", 2000, false)]
        [InlineData("Subaru", "WRX", 2000, false)]
        [InlineData("Subaru", "WRX", 2020, true)]

        public async Task ModelMadeInYear(string make, string model, int year, bool expected)
        {
            var car = new Car(15, make, model, 30);
            bool result = await car.WasModelMadeInYearAsync(year);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Honda", "Civic", 1995)]
        [InlineData("Honda", "Civic", 1994)]
        [InlineData("Honda", "Civic", 0)]
        public async Task ModelMadeInYear_Before1995(string make, string model, int year)
        {
            var car = new Car(15, make, model, 30);
            Func<Task> act = async () => { await car.WasModelMadeInYearAsync(year); };
            act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Sorry, no data is available for years before 1995.");
        }

        //[Fact]
        //public async Task ChangeTireWithoutFlatTest()
        //{
        //    Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

        //    // added test method to Vehicle class
        //    Func<Task> act = async () => { await vehicle.Test_ChangeTireAsync(); };

        //    await act.Should().ThrowAsync<NoTireToChangeException>();
        //}

    }
}
