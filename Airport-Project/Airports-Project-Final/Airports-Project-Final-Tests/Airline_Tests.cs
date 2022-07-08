using Airports_Project_Final.Controllers;
using Airports_Project_Final.Data;
using Airports_Project_Final.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Airports_Project_Final_Tests
{
    class Airline_Tests
    {
        private AirlineService _service;
        private AirportDbContext _context;
        private AirlinesController _controller;
        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AirportDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _context = new AirportDbContext(dbContextOptions);
            _service = new AirlineService(_context);
            _controller = new AirlinesController(_service);
        }
        [Test]
        public void Adding_Airline_Works()
        {
            var airline = new Airline { ID = 1, Name = "" };

            _service.Add(airline);

            if (_context.Airline.Any(a => a.ID == airline.ID)) Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Adding_Airline_Throws()
        {
            var airline = new Airline { ID = 1, Name = "" };

            _service.Add(airline);
            Assert.Throws<ArgumentException>(() => _service.Add(airline));
        }
        [Test]
        public void Controller_Create_ReturnsView()
        {
            Assert.IsInstanceOf<ViewResult>(_controller.Create());
        }
        [Test]
        public void GetAll_Works()
        {
            _service.Add(new Airline { ID = 1, Name = "1" });
            _service.Add(new Airline { ID = 2, Name = "2" });
            _service.Add(new Airline { ID = 3, Name = "3" });
            Assert.AreEqual(3, _service.GetAll().Count());
        }
        [Test]
        public void Get_Works()
        {
            _service.Add(new Airline { ID = 1, Name = "1" });
            if (_service.Get(1).Name == "1") Assert.Pass();
            Assert.Fail();
        }
        [Test]
        public void Delete_Works()
        {
            var a = new Airline { ID = 1, Name = "1" };
            _service.Add(a);
            _service.Delete(a);
            if (_context.Airline.Any(a => a.ID == 1)) Assert.Fail();
            Assert.Pass();
        }
        [Test]
        public void Edit_Works()
        {
            var a = new Airline { ID = 1, Name = "1" };
            _service.Add(a);
            _service.ReplaceInfoWith(new Airline { ID = 1, Name = "123" });
            if (_context.Airline.Any(a => a.Name == "123")) Assert.Pass();
            Assert.Fail();
        }
    }
}
