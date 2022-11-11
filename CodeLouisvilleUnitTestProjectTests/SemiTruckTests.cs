using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Diagnostics;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class SemiTruckTests
    {       

        //Verify that the SemiTruck constructor creates a new SemiTruck
        //object which is also a Vehicle and has 18 wheels. Verify that the
        //Cargo property for the newly created SemiTruck is a List of
        //CargoItems which is empty, but not null.
        [Fact]
        public void NewSemiTruckIsAVehicleAndHas18TiresAndEmptyCargoTest()
        {
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            using (new AssertionScope())
            {
                truck.Should().BeOfType<SemiTruck>();
                truck.Should().BeAssignableTo<Vehicle>();
                truck.NumberOfTires.Should().Be(18);
                truck.Cargo.Should().BeEmpty();

            } 
        }

        //Verify that adding a CargoItem using LoadCargo does successfully add
        //that CargoItem to the Cargo. Confirm both the existence of the new
        //CargoItem in the Cargo and also that the count of Cargo increased to 1.
        [Fact]
        public void LoadCargoTest()
        {
            var cargo = new CargoItem("TP", "Toilet Paper", 1000);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo);
            using (new AssertionScope())
            {
                truck.Cargo.Should().Contain(cargo);
                truck.Cargo.Count.Should().Be(1);
            }
        }

        //Verify that unloading a cargo item that is in the Cargo does
        //remove it from the Cargo and return the matching CargoItem
        [Fact]
        public void UnloadCargoWithValidCargoTest()
        {
            var cargo = new CargoItem("TP", "Toilet Paper", 1000);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo);
            var result = truck.UnloadCargo("TP");
            using (new AssertionScope())
            {
                truck.Cargo.Should().NotContain(cargo);
                truck.Cargo.Count.Should().Be(0);
                result.Should().Be(cargo);
            }
        }

        //Verify that attempting to unload a CargoItem that does not
        //appear in the Cargo throws a System.ArgumentException
        [Fact]
        public void UnloadCargoWithInvalidCargoTest()
        {
            var cargo = new CargoItem("TP", "Toilet Paper", 1000);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            Action act = () => truck.UnloadCargo("TP");
            act.Should().Throw<ArgumentException>();
        }

        //Verify that getting cargo items by name returns all items
        //in Cargo with that name.
        [Fact]
        public void GetCargoItemsByNameWithValidName()
        {
            var cargo1 = new CargoItem("TP", "Toilet Paper part 1", 1000);
            var cargo2 = new CargoItem("TP", "Toilet Paper part 2", 1000);
            var cargo3 = new CargoItem("Watch", "Casio Watches", 500);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo1);
            truck.LoadCargo(cargo2);
            truck.LoadCargo(cargo3);
            var result = truck.GetCargoItemsByName("TP");
            result.Count.Should().Be(2);
        }

        //Verify that searching the Cargo list for an item that does not
        //exist returns an empty list
        [Fact]
        public void GetCargoItemsByNameWithInvalidName()
        {
            var cargo1 = new CargoItem("TP", "Toilet Paper part 1", 1000);
            var cargo2 = new CargoItem("TP", "Toilet Paper part 2", 1000);
            var cargo3 = new CargoItem("Watch", "Casio Watches", 500);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo1);
            truck.LoadCargo(cargo2);
            truck.LoadCargo(cargo3);
            var result = truck.GetCargoItemsByName("Wood");
            result.Should().BeEmpty();
        }

        //Verify that searching the Cargo list by description for an item
        //that does exist returns all matched items that contain that description.
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithValidDescription()
        {
            var cargo1 = new CargoItem("TP", "Toilet Paper part 1", 1000);
            var cargo2 = new CargoItem("TP", "Toilet Paper part 2", 1000);
            var cargo3 = new CargoItem("Watch", "Casio Watches", 500);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo1);
            truck.LoadCargo(cargo2);
            truck.LoadCargo(cargo3);
            var result = truck.GetCargoItemsByPartialDescription("Toilet");
            result.Count.Should().Be(2);
        }

        //Verify that searching the Cargo list by description for an item
        //that does not exist returns an empty list
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithInvalidDescription()
        {
            var cargo1 = new CargoItem("TP", "Toilet Paper part 1", 1000);
            var cargo2 = new CargoItem("TP", "Toilet Paper part 2", 1000);
            var cargo3 = new CargoItem("Watch", "Casio Watches", 500);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo1);
            truck.LoadCargo(cargo2);
            truck.LoadCargo(cargo3);
            var result = truck.GetCargoItemsByPartialDescription("Wood");
            result.Should().BeEmpty();
        }

        //Verify that the method returns the sum of all quantities of all
        //items in the Cargo
        [Fact]
        public void GetTotalNumberOfItemsReturnsSumOfAllQuantities()
        {
            var cargo1 = new CargoItem("TP", "Toilet Paper part 1", 1000);
            var cargo2 = new CargoItem("TP", "Toilet Paper part 2", 1000);
            var cargo3 = new CargoItem("Watch", "Casio Watches", 500);
            var truck = new SemiTruck(150, "Volvo", "VNL", 5);
            truck.LoadCargo(cargo1);
            truck.LoadCargo(cargo2);
            truck.LoadCargo(cargo3);
            var result = truck.GetTotalNumberOfItems();
            result.Should().Be(2500);

        }
    }
}
