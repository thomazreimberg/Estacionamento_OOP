using Estacionamento_Application;

namespace Estacionamento.Test
{
    /// <summary>
    /// Testes para fins de validação de resultados finais.
    /// </summary>
    [TestFixture]
    public class ParkingLotTest
    {
        private ParkingLot _parkingLot;

        private void SetupSpots(int motorcycleSpots = 5, int carSpots = 10, int vanSpots = 5)
        {
            _parkingLot = new ParkingLot(motorcycleSpots, carSpots, vanSpots);
        }

        [SetUp]
        public void Setup()
        {
            SetupSpots();
        }

        [Order(1)]
        [Test]
        public void ParkingLotTest_LoadValidValues_ShouldHaveAvailableSpots()
        {
            SetupSpots();
            Assert.That(_parkingLot.TotalSpacesLeft, Is.GreaterThan(0), "ParkingLot should have available spots.");
        }

        [Order(2)]
        [Test]
        public void ParkingLotTest_LoadValidValue_ReturnNumber()
        {
            SetupSpots();
            Assert.That(_parkingLot.TotalSpacesLeft, Is.GreaterThan(0), "ParkingLot should have available spots.");
        }

        [Order(3)]
        [Test]
        public void ParkingLotTest_LoadNegativeValues_ReturnZeroToNegativeValues()
        {
            SetupSpots(-10, 5, 0);
            Assert.That(_parkingLot.TotalMotorcycleSpots, Is.EqualTo(0), "ParkingLot.TotalMotorcycleSpots should return 0.");
        }

        [Order(4)]
        [Test]
        public void ParkingLotTest_ParkVehicleMotorcycle_CompareTotalMotorcycleSpots()
        {
            SetupSpots(5, 5, 5);
            _parkingLot.ParkVehicle(new Motorcycle());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Motorcycle>(), Is.EqualTo(1), "ParkingLot.OccupiedSpaces() should return 1.");
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(4), "ParkingLot.AvailableSpaces() should return 4.");
            });
        }

        [Order(5)]
        [Test]
        public void ParkingLotTest_ParkVehicleCar_CompareTotalCarSpots()
        {
            SetupSpots(5, 5, 5);
            _parkingLot.ParkVehicle(new Car());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(1), "ParkingLot.OccupiedSpaces() should return 1.");
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(4), "ParkingLot.AvailableSpaces() should return 4.");
            });
        }

        [Order(6)]
        [Test]
        public void ParkingLotTest_ParkVehicleVan_CompareTotalVanSpots()
        {
            SetupSpots(5, 5, 5);
            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(1), "ParkingLot.OccupiedSpaces() should return 1.");
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(4), "ParkingLot.AvailableSpaces() should return 4.");
            });
        }

        [Order(7)]
        [Test]
        public void ParkingLotTest_ParkMultipleVehicleMotorcycle_CompareTotalMotorcycleSpots()
        {
            SetupSpots(5, 5, 5);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Motorcycle());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Motorcycle>(), Is.EqualTo(2), "ParkingLot.OccupiedSpaces() should return 2.");
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(3), "ParkingLot.AvailableSpaces() should return 3.");
            });
        }

        [Order(8)]
        [Test]
        public void ParkingLotTest_RemoveParkedVehicleMotorcycle_CompareTotalMotorcycleSpots()
        {
            SetupSpots(5, 5, 5);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Motorcycle());

            _parkingLot.RemoveVehicle();

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Motorcycle>(), Is.EqualTo(1), "ParkingLot.OccupiedSpaces() should return 1.");
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(4), "ParkingLot.AvailableSpaces() should return 4.");
            });
        }

        [Order(9)]
        [Test]
        public void ParkingLotTest_ParkVehicleCar_CompareTotalVanSpots()
        {
            SetupSpots(0, 0, 1);

            _parkingLot.ParkVehicle(new Car());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(0), "ParkingLot.OccupiedSpaces() should return 0.");
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");

                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(1), "ParkingLot.OccupiedSpaces() should return 1.");
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");
            });
        }

        [Order(10)]
        [Test]
        public void ParkingLotTest_ParkVehicleMotorcycle_CompareTotalCarSpots()
        {
            SetupSpots(0, 1, 0);

            _parkingLot.ParkVehicle(new Motorcycle());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Motorcycle>(), Is.EqualTo(0), "ParkingLot.OccupiedSpaces() should return 0.");
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");

                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(1), "ParkingLot.OccupiedSpaces() should return 1.");
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");
            });
        }

        [Order(11)]
        [Test]
        public void ParkingLotTest_ParkVehicleVan_CompareTotalCarSpots()
        {
            SetupSpots(1, 6, 0);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Van());
            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(0), "ParkingLot.OccupiedSpaces() should return 0.");
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");

                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(6), "ParkingLot.OccupiedSpaces() should return 6.");
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");
            });
        }

        [Order(12)]
        [Test]
        public void ParkingLotTest_ParkVehicleVan_CompareTotalMotorcycleSpots()
        {
            SetupSpots(3, 0, 0);

            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(0), "ParkingLot.OccupiedSpaces() should return 0.");
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0), "ParkingLot.AvailableSpaces() should return 0.");

                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(0), "ParkingLot.OccupiedSpaces() should return 0.");
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(3), "ParkingLot.AvailableSpaces() should return 3.");
            });
        }

        [Order(13)]
        [Test]
        public void ParkingLotTest_ParkVehicleMotorcycleInOneSpotLeft_ReturnIsFull()
        {
            SetupSpots(1, 0, 0);

            _parkingLot.ParkVehicle(new Motorcycle());

            Assert.That(_parkingLot.IsFull, Is.True);
        }

        [Order(14)]
        [Test]
        public void ParkingLotTest_RemoveParkedVehicleMotorcycleInFullSpots_ReturnIsEmpty()
        {
            SetupSpots(1, 0, 0);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.RemoveVehicle();

            Assert.That(_parkingLot.IsEmpty, Is.True);
        }

        [Order(15)]
        [Test]
        public void ParkingLotTest_GetSpotsLeft_ReturnNumber()
        {
            SetupSpots(2, 3, 1);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Car());
            _parkingLot.ParkVehicle(new Van());

            Assert.That(_parkingLot.TotalSpacesInParkingLot, Is.EqualTo(6), "ParkingLot.TotalSpacesInParkingLot should return 6.");
        }

        [Order(16)]
        [Test]
        public void ParkingLotTest_ParkVehicleVanInFullCarSpots_ReturnVanNotAvailable()
        {
            SetupSpots(2, 1, 0);

            _parkingLot.ParkVehicle(new Van());

            Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0));
        }

        [Order(17)]
        [Test]
        public void ParkingLotTest_ParkVehicleVanInFullMotorcycleAndCarSpots_ReturnVanNotAvailable()
        {
            SetupSpots(1, 1, 0);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Car());
            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(0));
            });
        }

        [Order(18)]
        [Test]
        public void ParkingLotTest_ParkVehicleInFullParkingLot_ReturnIsFull()
        {
            SetupSpots(1, 1, 1);

            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Car());
            _parkingLot.ParkVehicle(new Van());

            Assert.That(_parkingLot.IsFull, Is.True);
        }

        [Order(19)]
        [Test]
        public void ParkingLotTest_ParkCarInMotorcycleSpot_ReturnsCarNotAvailable()
        {
            SetupSpots(2, 0, 0);

            _parkingLot.ParkVehicle(new Car());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(0));
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(2));
                Assert.That(_parkingLot.OccupiedSpaces<Motorcycle>(), Is.EqualTo(0));
            });
        }
        
        [Order(20)]
        [Test]
        public void ParkingLotTest_ParkMultipleVehicle_ReturnsValidAvailableSpacesAndOccupiedSpaces()
        {
            SetupSpots(2, 10, 1);

            _parkingLot.ParkVehicle(new Car());
            _parkingLot.ParkVehicle(new Motorcycle());
            _parkingLot.ParkVehicle(new Van());
            _parkingLot.ParkVehicle(new Car());
            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Motorcycle>(), Is.EqualTo(1));
                Assert.That(_parkingLot.OccupiedSpaces<Motorcycle>(), Is.EqualTo(1));
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(5));
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(5));
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(1));
            });
        }

        [Order(21)]
        [Test]
        public void ParkingLotTest_ParkVehicleCar_ReturnsTypeIsFull()
        {
            SetupSpots(0, 1, 0);

            _parkingLot.ParkVehicle(new Car());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(1));
                Assert.That(_parkingLot.IsTypeFull<Van>(), Is.True);
            });
        }

        [Order(22)]
        [Test]
        public void ParkingLotTest_ParkMultipleVehicleCar_ReturnsTypeIsFull()
        {
            SetupSpots(0, 2, 0);

            _parkingLot.ParkVehicle(new Car());
            _parkingLot.ParkVehicle(new Car());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(2));
                Assert.That(_parkingLot.IsTypeFull<Van>(), Is.True);
            });
        }

        [Order(23)]
        [Test]
        public void ParkingLotTest_ParkMultipleVehicleVan_ReturnsTypeIsFull()
        {
            SetupSpots(0, 0, 3);

            _parkingLot.ParkVehicle(new Van());
            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(1));
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(2));
                Assert.That(_parkingLot.IsTypeFull<Van>(), Is.False);
            });
        }

        [Order(24)]
        [Test]
        public void ParkingLotTest_ParkVehicleVanInCarSpots_ReturnsTypeIsFull()
        {
            SetupSpots(0, 3, 0);

            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(0));
                Assert.That(_parkingLot.IsTypeFull<Van>(), Is.True);

                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(3));
                Assert.That(_parkingLot.IsTypeFull<Car>(), Is.True);
            });
        }

        [Order(25)]
        [Test]
        public void ParkingLotTest_ParkMultipleVehicleVanInCarSpots_ReturnsTypeIsFull()
        {
            SetupSpots(0, 6, 0);

            _parkingLot.ParkVehicle(new Van());
            _parkingLot.ParkVehicle(new Van());

            Assert.Multiple(() =>
            {
                Assert.That(_parkingLot.AvailableSpaces<Van>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Van>(), Is.EqualTo(0));
                Assert.That(_parkingLot.IsTypeFull<Van>(), Is.True);

                Assert.That(_parkingLot.AvailableSpaces<Car>(), Is.EqualTo(0));
                Assert.That(_parkingLot.OccupiedSpaces<Car>(), Is.EqualTo(6));
                Assert.That(_parkingLot.IsTypeFull<Car>(), Is.True);
            });
        }
    }
}