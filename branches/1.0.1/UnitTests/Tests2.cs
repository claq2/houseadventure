using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HouseCore.Presenters;
using HouseCore;

namespace UnitTests
{
    [TestClass]
    class Tests2
    {
        /// <summary>
        /// The presenter object
        /// </summary>
        private HousePresenter housePresenter;
        private Player player;
        private HouseType house;
        /// <summary>
        /// The mock view
        /// </summary>
        private MockView view;

        /// <summary>
        /// Sets up the tests.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.view = new MockView();
            this.player = new Player();
            this.house = new HouseType(true);
            this.housePresenter = new HousePresenter(this.view, player, house);
        }

        [TestMethod]
        public void DieInDark()
        {
            this.housePresenter.West();
            this.housePresenter.West();
            this.housePresenter.Down();
            Assert.AreEqual(RoomData.BasementElevatorName, this.view.RoomName);
            this.housePresenter.North();
            this.housePresenter.North();
            Assert.AreEqual(false, this.view.GameEnded);
            this.housePresenter.West();
            Assert.AreEqual(true, this.view.GameEnded);
        }
    }
}
