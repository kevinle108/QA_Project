using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit.Abstractions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class VehicleTests
    {

        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void VehicleParameterlessConstructorTest()
        {
            Vehicle vehicle = new Vehicle();

            using (new AssertionScope())
            {
                vehicle.Should().NotBeNull();
                vehicle.NumberOfTires.Should().Be(0);
                vehicle.GasTankCapacity.Should().Be(0);
                vehicle.Make.Should().Be("");
                vehicle.Model.Should().Be("");
                vehicle.MilesPerGallon.Should().Be(0);
            }
        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact]
        public void VehicleConstructorTest()
        {
            Vehicle vehicle = new Vehicle(4, 15, "Toyota", "Avalon", 30);

            using (new AssertionScope())
            {
                vehicle.Should().NotBeNull();
                vehicle.NumberOfTires.Should().Be(4);
                vehicle.GasTankCapacity.Should().Be(15);
                vehicle.Make.Should().Be("Toyota");
                vehicle.Model.Should().Be("Avalon");
                vehicle.MilesPerGallon.Should().Be(30);
            }

        }

        //Verify that the parameterless AddGas method fills the gas tank
        //to 100% of its capacity
        [Fact]
        public void AddGasParameterlessFillsGasToMax()
        {
            Vehicle vehicle = new Vehicle(4, 15, "Toyota", "Avalon", 30);

            vehicle.Drive(30);
            vehicle.AddGas();

            vehicle.GasLevel.Should().Be("100%");
        }

        //Verify that the AddGas method with a parameter adds the
        //supplied amount of gas to the gas tank.
        [Fact]
        public void AddGasWithParameterAddsSuppliedAmountOfGas()
        {
            Vehicle vehicle = new Vehicle(4, 15, "Toyota", "Avalon", 30);

            vehicle.AddGas();
            vehicle.Drive(90);

            vehicle.GasLevel.Should().Be("80%");
        }

        //Verify that the AddGas method with a parameter will throw
        //a GasOverfillException if too much gas is added to the tank.
        [Fact]
        public void AddingTooMuchGasThrowsGasOverflowException()
        {
            Vehicle vehicle = new Vehicle(4, 15, "Toyota", "Avalon", 30);

            Action act = () => vehicle.AddGas(16).Should();

            act.Should().Throw<GasOverfillException>()
                .WithMessage("Unable to add 16 gallons to tank because it would exceed the capacity of 15 gallons");
        }

        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData(0, "0%")]
        [InlineData(2.5, "25%")]
        [InlineData(5, "50%")]
        [InlineData(7.5, "75%")]
        [InlineData(10, "100%")]
        public void GasLevelPercentageIsCorrectForAmountOfGas(float gasAmountToAdd, string gasLevel)
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

            vehicle.AddGas(gasAmountToAdd);

            vehicle.GasLevel.Should().Be(gasLevel);
        }

        /*
         * Using a Theory (or data-driven test), or a combination of several 
         * individual Fact tests, test the following functionality of the 
         * Drive method:
         *      a. Attempting to drive a car without gas returns the status 
         *      string “Cannot drive, out of gas.”.
         *      b. Attempting to drive a car with a flat tire returns 
         *      the status string “Cannot drive due to flat tire.”.
         *      c. Drive the car 10 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled, 
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      d. Drive the car 100 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      e. Drive the car until it runs out of gas. Verify that the 
         *      correct amount of gas was used, that the correct distance 
         *      was traveled, that GasLevel is correct, that MilesRemaining
         *      is correct, and that the total mileage on the vehicle is 
         *      correct. Verify that the status reports the car is out of gas.
        */

        //a. Attempting to drive a car without gas returns the status string “Cannot drive, out of gas.”.
        [Fact]
        public void DriveCarWithNoGas()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

            string status = vehicle.Drive(10);

            status.Should().Be("Cannot drive, out of gas.");
        }

        //b. Attempting to drive a car with a flat tire returns the status string “Cannot drive due to flat tire.”.
        [Fact]
        public void DriveCarWithFlatTire()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

            vehicle.AddGas();
            vehicle.Test_InduceFlatTire();
            string status = vehicle.Drive(10);

            status.Should().Be("Cannot drive due to flat tire.");
        }

        // c.Drive the car 10 miles.Verify that the correct amount
        // of gas was used, that the correct distance was traveled,
        // that GasLevel is correct, that MilesRemaining is correct, 
        // and that the total mileage on the vehicle is correct.
        [Fact]
        public void DriveCarCertainDistance_10()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);
            vehicle.AddGas();
            string status = vehicle.Drive(10);

            using (new AssertionScope())
            {
                status.Should().Be("Drove 10 miles using 0.33 gallons of gas.");
                vehicle.GasLevel.Should().Be("96%"); //changed GasLevel to round down to nearest int
                vehicle.MilesRemaining.Should().Be(290);
                vehicle.Mileage.Should().Be(10);
            }
        }

        // d.Drive the car 100 miles.Verify that the correct amount
        // of gas was used, that the correct distance was traveled,
        // that GasLevel is correct, that MilesRemaining is correct, 
        // and that the total mileage on the vehicle is correct.
        [Fact]
        public void DriveCarCertainDistance_100()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);
            vehicle.AddGas();
            string status = vehicle.Drive(100);

            using (new AssertionScope())
            {
                status.Should().Be("Drove 100 miles using 3.33 gallons of gas.");
                vehicle.GasLevel.Should().Be("66%"); 
                vehicle.MilesRemaining.Should().BeApproximately(200, 0.01);
                vehicle.Mileage.Should().Be(100);
            }
        }

        // d.Drive the car until it runs out of gas. Verify that the 
        // correct amount of gas was used, that the correct distance
        // was traveled, that GasLevel is correct, that MilesRemaining
        // is correct, and that the total mileage on the vehicle is 
        // correct.Verify that the status reports the car is out of gas.
        [Fact]
        public void DriveCarToRunOutOfGas()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);
            vehicle.AddGas();
            string status = vehicle.Drive(300);

            using (new AssertionScope())
            {
                status.Should().Contain("Drove 300 miles, then ran out of gas.");
                vehicle.GasLevel.Should().Be("0%"); //changed GasLevel to round down to nearest int
                vehicle.MilesRemaining.Should().Be(0);
                vehicle.Mileage.Should().Be(300);
            }
        }

        //[Theory]
        //[InlineData("MysteryParamValue")]
        //public void DriveNegativeTests(params object[] yourParamsHere)
        //{
        //    //arrange
        //    throw new NotImplementedException();
        //    //act

        //    //assert

        //}

        //[Theory]
        //[InlineData("MysteryParamValue")]
        //public void DrivePositiveTests(params object[] yourParamsHere)
        //{
        //    //arrange
        //    throw new NotImplementedException();
        //    //act

        //    //assert

        //}

        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

            // added test method to Vehicle class
            Func<Task> act = async () => { await vehicle.Test_ChangeTireAsync(); };

            await act.Should().ThrowAsync<NoTireToChangeException>();
        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            Vehicle vehicle = new Vehicle(4, 10, "Toyota", "Camry", 30);

            vehicle.Test_InduceFlatTire();
            await vehicle.Test_ChangeTireAsync();

            vehicle.HasFlatTire.Should().Be(false);
        }

        //BONUS: Write a unit test that verifies that a flat
        //tire will occur after a certain number of miles.
        //[Theory]
        //[InlineData("MysteryParamValue")]
        //public void GetFlatTireAfterCertainNumberOfMilesTest(params object[] yourParamsHere)
        //{
        //    //arrange
        //    throw new NotImplementedException();
        //    //act

        //    //assert

        //}
    }
}