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
        private Player player;
        private HouseType house;
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
            this.player = new Player();
            this.house = new HouseType(true);
            this.housePresenter = new HousePresenter(this.view, player, house);
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
        public void GetTests()
        {
            this.view.Argument = TheHouseObjectData.BoxShortName;
            this.housePresenter.Get();
            this.housePresenter.PopulateInventory();
            Assert.AreEqual(true, this.view.Inventory.Contains(TheHouseObjectData.BoxName));
            Assert.AreEqual(false, this.house.Rooms[this.player.Location].Items.Contains(TheHouseObjectData.BoxShortName));
            Assert.AreEqual("box taken", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.view.Argument = TheHouseObjectData.LockedDoorShortName;
            this.housePresenter.Get();
            Assert.AreEqual(false, this.view.Inventory.Contains(TheHouseObjectData.LockedDoorName));
            Assert.AreEqual(true, this.house.Rooms[this.player.Location].Items.Contains(TheHouseObjectData.LockedDoorShortName));
            Assert.AreEqual("You can't take the doo", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.view.Argument = TheHouseObjectData.KnifeShortName;
            this.housePresenter.Get();
            Assert.AreEqual("I see no kni here", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.player.Location = TheHouseRoomData.LocationFirstFloorKitchen;
            this.view.Argument = TheHouseObjectData.KnifeShortName;
            this.housePresenter.Get();
            Assert.AreEqual("This room's occupant seems to have grown very attached to the kni and won't let you have it", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.player.Location = TheHouseRoomData.LocationSecondFloorSewingRoom;
            this.view.Argument = TheHouseObjectData.BagOfGoldShortName;
            this.housePresenter.Get();
            Assert.AreEqual(true, this.view.Message.Contains("Remember?!"));
            Assert.AreEqual(true, this.view.GameEnded);

        }
    }
}
