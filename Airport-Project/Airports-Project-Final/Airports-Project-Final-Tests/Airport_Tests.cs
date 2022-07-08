using NUnit.Framework;
using Airports_Project_Final.Data;
using Airports_Project_Final.Services;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Airports_Project_Final.Controllers;
using Microsoft.AspNetCore.Mvc;
using Airports_Project_Final.Models;

namespace Airports_Project_Final_Tests
{
    public class Airport_Tests
    {
        private AirportService _service;
        private AirportDbContext _context;
        private AirportsController _controller;
        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AirportDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new AirportDbContext(dbContextOptions);
            _service = new AirportService(_context);
            _controller = new AirportsController(_service);
        }
        [Test]
        public void Adding_Airport_Works()
        {
            // ARRANGE
            var airport = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };

            // ACT
            _service.Add(airport);

            // ASSERT
            if (_context.Airport.Any(a => a.ID == airport.ID)) Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Adding_ExistingAirport_Throws()
        {
            // ARRANGE
            var airport1 = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };
            var airport2 = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };

            // ACT + ASSERT
            _service.Add(airport1);
            Assert.Throws<InvalidOperationException>(() => _service.Add(airport2));
        }
        [Test]
        public void Deleting_Airport_Works()
        {
            // ARRANGE
            var airport = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };

            // ACT
            _service.Add(airport);
            _service.Delete(airport);

            // ASSERT
            if (_context.Airport.Any(a => a.ID == airport.ID)) Assert.Fail();
            Assert.Pass();
        }
        [Test]
        public void Deleting_NonExistingAirport_Throws()
        {
            // ARRANGE
            var airport = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };

            // ACT + ASSERT
            Assert.Throws<DbUpdateConcurrencyException>(() => _service.Delete(airport));
        }
        [Test]
        public void Editing_Airport_Works()
        {
            // ARRANGE
            var airport = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };
            var airportNew = new Airport { ID = 1, PORT_ID = "1", Name = "123", Adress = "1", City = "1", Country = "1" };

            // ACT
            _service.Add(airport);
            _service.Edit(airportNew);

            // ASSERT
            if (_context.Airport.FirstOrDefault(a => a.ID == 1).Name == "123") Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Getting_Airport_Works()
        {
            // ARRANGE
            var airport = new Airport { ID = 1, PORT_ID = "1", Name = "1", Adress = "1", City = "1", Country = "1" };

            // ACT
            _service.Add(airport);

            // ASSERT
            if (_service.Get(airport.ID).Country == airport.Country) Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Getting_NonExistingAirport_Throws()
        {
            // ARRANGE + ACT
            var test = _service.Get(1);

            // ASSERT
            if (test == null) Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void GetAll_Airports_Works()
        {
            Assert.AreEqual(_context.Airport, _service.GetAll());
        }
        [Test]
        public void Controller_Create_Returns_View()
        {
            // ARRANGE + ACT
            var result = _controller.Create();

            // ASSERT
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void Controller_Create_IsNotNull()
        {
            // ACT + ARRANGE
            var result = _controller.Create();

            // ASSERT
            Assert.NotNull(result);
        }
        [Test]
        public void Controller_Create_WithArgument_Throws()
        {
            // ACT + ASSERT
            Assert.Throws<NullReferenceException>(() => _controller.Create(null));
        }
        [Test]
        public void Controller_Create_WithArgument_ReturnsView()
        {
            // ACT + ASSERT
            Assert.IsInstanceOf<IActionResult>(_controller.Create(new AirportFormModel { Adress = "", City = "", Country = "", Name = "", PORT_ID = "" }));
        }
        [Test]
        public void Controller_Index_Returns_View()
        {
            var result = _controller.Index();
            Assert.IsInstanceOf<IActionResult>(result);
        }
        [Test]
        public void Controller_Index_IsNotNull()
        {
            // ACT + ARRANGE
            var result = _controller.Index();

            // ASSERT
            Assert.NotNull(result);
        }
        [Test]
        public void Controller_Index_Throws_WhenServiceIsNull()
        {
            // ACT + ARRANGE
            _controller = new AirportsController(null);

            // ASSERT
            Assert.Throws<NullReferenceException>(() => _controller.Index());
        }
        [Test]
        public void Controller_Delete_ReturnsNotFound()
        {
            // ASSERT
            Assert.IsInstanceOf<NotFoundResult>(_controller.Delete(-1));
        }
        [Test]
        public void Controller_Delete_ReturnsRedirection()
        {
            // ARRANGE + ACT
            _service.Add(new Airport { ID = 1, Adress = "", City = "", Country = "", Name = "", PORT_ID = "" });

            // ASSERT
            Assert.IsInstanceOf<RedirectToActionResult>(_controller.Delete(1));
        }
        [Test]
        public void Controller_Edit_ReturnsNotFound()
        {
            Assert.IsInstanceOf<NotFoundResult>(_controller.Edit(-1));
        }
        [Test]
        public void Controller_Edit_ReturnsRedirection()
        {
            _service.Add(new Airport { ID = 1, Adress = "", City = "", Country = "", Name = "", PORT_ID = "" });
            Assert.IsInstanceOf<ViewResult>(_controller.Edit(1));
        }
        [Test]
        public void Controller_Edit_WithAirportParameter_ReturnsRedirection()
        {
            _service.Add(new Airport { ID = 1, Adress = "", City = "", Country = "", Name = "", PORT_ID = "" });
            Assert.IsInstanceOf<RedirectToActionResult>(_controller.Edit(new Airport { ID = 1, Adress = "", City = "", Country = "", Name = "", PORT_ID = "" }));
        }
    }
}