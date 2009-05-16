//-----------------------------------------------------------------------
// <copyright file="Tests.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HouseCore;
    using HouseCore.Presenters;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the project
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// The GameEndingArgumentActionPresenter
        /// </summary>
        private HousePresenter housePresenter;

        /// <summary>
        /// The mock view
        /// </summary>
        private MockView view;

        /// <summary>
        /// Sets up the tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.view = new MockView();
            this.housePresenter = new HousePresenter(this.view);
        }

        [Test]
        public void DieInDark()
        {
            this.housePresenter.West();
            this.housePresenter.West();
            this.housePresenter.Down();
            Assert.AreEqual(TheHouseRoomData.BasementElevatorName, this.view.RoomName);
            this.housePresenter.North();
            this.housePresenter.North();
            Assert.AreEqual(false, this.view.GameEnded);
            this.housePresenter.West();
            Assert.AreEqual(true, this.view.GameEnded);
        }

        /// <summary>
        /// Try getting the box.
        /// </summary>
        [Test]
        public void GetBox()
        {
            this.view.Argument = TheHouseObjectData.BoxShortName;
            this.housePresenter.Get();
            this.housePresenter.PopulateInventory();
            Assert.AreEqual(true, this.view.Inventory.Contains(TheHouseObjectData.BoxName));
        }
    }
}
