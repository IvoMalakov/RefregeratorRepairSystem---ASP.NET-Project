using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefregeratorRepairSystem.App.Areas.Parts.Controllers;
using RefregeratorRepairSystem.Data.Interfaces;
using RefregeratorRepairSystem.Data.Mocks;
using RefregeratorRepairSystem.Services;
using RefregeratorRepairSystem.Services.Interfaces;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Parts;
using Part = RefregeratorRepairSystem.Models.EntityModels.Part;

namespace RefregeratorRepairSystem.Tests.Controllers
{
    [TestClass]
    public class PartsControllerTest
    {
        private List<Models.EntityModels.Part> _parts;
        private PartsController _controller;
        private IPartsService _service;
        private IRefregeratorRepairSystemContext _context;

        [TestInitialize]
        public void Init()
        {
            this._service = new PartsService();
            this._controller = new PartsController(this._service);
            this._parts = new List<Part>()
            {
                new Part()
                {
                    Id = 1,
                    Name = "Capacitor",
                    Model = "Texas Instruments",
                    Price = 10.00m,
                    Quantity = 1
                },

                new Part()
                {
                    Id = 2,
                    Name = "Motor",
                    Model = "DC Motor",
                    Price = 150.50m,
                    Quantity = 1
                }
            };

            this._context = new FakeRefregeratorRepairSystemContext();

            foreach (var part in _parts)
            {
                this._context.Parts.Add(part);
            }

            this._service = new PartsService();
            this._controller = new PartsController(this._service);

        }

        [TestMethod]
        public void ListAllParts_ShouldReturnsOk()
        {
            var data = this._controller.AllParts() as ViewResult;
            Assert.IsNotNull(data);
        }
    }
}
