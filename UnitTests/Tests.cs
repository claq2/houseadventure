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
    using HouseCore.Exceptions;

    /// <summary>
    /// Tests for the project
    /// </summary>
    [TestFixture]
    public class Tests
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
            Assert.AreEqual(RoomData.BasementElevatorName, this.view.RoomName);
            this.housePresenter.North();
            this.housePresenter.North();
            Assert.AreEqual(false, this.view.GameEnded);
            this.housePresenter.West();
            Assert.AreEqual(true, this.view.GameEnded);
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void GetTestException()
        {
            this.housePresenter.Get();
        }

        /// <summary>
        /// Try getting the box.
        /// </summary>
        [Test]
        public void GetTests()
        {
            this.view.Argument = ObjectData.BoxShortName;
            this.housePresenter.Get();
            this.housePresenter.PopulateInventory();
            Assert.AreEqual(true, this.view.Inventory.Contains(ObjectData.BoxName));
            Assert.AreEqual(false, this.house.Rooms[this.player.Location].Items.Contains(ObjectData.BoxShortName));
            Assert.AreEqual("box taken", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.view.Argument = ObjectData.LockedDoorShortName;
            this.housePresenter.Get();
            Assert.AreEqual(false, this.view.Inventory.Contains(ObjectData.LockedDoorName));
            Assert.AreEqual(true, this.house.Rooms[this.player.Location].Items.Contains(ObjectData.LockedDoorShortName));
            Assert.AreEqual("You can't take the doo", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.view.Argument = ObjectData.KnifeShortName;
            this.housePresenter.Get();
            Assert.AreEqual("I see no kni here", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.player.Location = RoomData.LocationFirstFloorKitchen;
            this.view.Argument = ObjectData.KnifeShortName;
            this.housePresenter.Get();
            Assert.AreEqual("This room's occupant seems to have grown very attached to the kni and won't let you have it", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.player.Location = RoomData.LocationSecondFloorSewingRoom;
            this.view.Argument = ObjectData.BagOfGoldShortName;
            this.housePresenter.Get();
            Assert.AreEqual(true, this.view.Message.Contains("Remember?!"));
            Assert.AreEqual(true, this.view.GameEnded);
        }

        [Test]
        public void MoveTests()
        {
            Assert.AreEqual(RoomData.LocationFirstFloorFoyer.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorFoyer.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.West();
            Assert.AreEqual(RoomData.LocationFirstFloorCoatCloset.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorCoatCloset.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.West();
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.West();
            Assert.AreEqual(RoomData.LocationFirstFloorDiningRoom.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorDiningRoom.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.East();
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.North();
            Assert.AreEqual(RoomData.LocationFirstFloorKitchen.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorKitchen.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.South();
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.Up();
            Assert.AreEqual(RoomData.LocationSecondFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationSecondFloorElevator.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.Down();
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.South();
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.RoomNumber, this.player.Location.RoomNumber);
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void BrushTestException()
        {
            this.housePresenter.Brush();
        }

        [Test]
        public void BrushTests()
        {
            Assert.AreEqual(RoomData.LocationFirstFloorFoyer.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorFoyer.RoomNumber, this.player.Location.RoomNumber);
            this.view.Argument = "fla";
            this.housePresenter.Brush();
            Assert.AreEqual("You can't brush that", this.view.Message);
            this.view.Argument = "vampire";
            this.housePresenter.Brush();
            Assert.AreEqual("I see no vampire here", this.view.Message);
            this.housePresenter.West();
            Assert.AreEqual(RoomData.LocationFirstFloorCoatCloset.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorCoatCloset.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.West();
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorElevator.RoomNumber, this.player.Location.RoomNumber);
            this.housePresenter.North();
            Assert.AreEqual(RoomData.LocationFirstFloorKitchen.Floor, this.player.Location.Floor);
            Assert.AreEqual(RoomData.LocationFirstFloorKitchen.RoomNumber, this.player.Location.RoomNumber);
            this.view.Argument = "vampire";
            this.housePresenter.Brush();
            Assert.AreEqual("You have nothing with which to brush the vampire", this.view.Message);
            PortableObject portableObjectTarget = this.house.InanimateObjects[ObjectData.BrushShortName] as PortableObject;
            house.AddToInventory(portableObjectTarget);
            this.view.Argument = "vampire";
            this.housePresenter.Brush();
            Assert.AreEqual("The vampire will become angry if you persist!", this.view.Message);
            this.player.Location = RoomData.LocationThirdFloorLibrary;
            this.view.Argument = "leopard";
            Assert.AreEqual(true, this.house.Rooms[this.player.Location].Adversaries.Contains("leo"));
            this.housePresenter.Brush();
            Assert.AreEqual("Purrrrrrr!!!!!!!!  The leopard is very gratified for the grooming and leaves", this.view.Message);
            Assert.AreEqual(false, this.house.Rooms[this.player.Location].Adversaries.Contains("leo"));
            Assert.AreEqual(true, this.house.Rooms[RoomData.LocationMonsterHangout].Adversaries.Contains("leo"));
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void DigTestException()
        { 
            this.housePresenter.Dig();
        }

        [Test]
        public void DigTests()
        {
            this.view.Argument = "dib";
            this.housePresenter.Dig();
            Assert.AreEqual("You can't dig the dib.", this.view.Message);
            this.view.Argument = "dirt";
            this.housePresenter.Dig();
            Assert.AreEqual("I see no dirt to dig here.", this.view.Message);
            this.player.Location = RoomData.LocationBasementDirtFlooredRoom;
            this.view.Argument = "dirt";
            this.housePresenter.Dig();
            Assert.AreEqual("You don't have anything with which to dig.", this.view.Message);
            PortableObject shovel = this.house.InanimateObjects[ObjectData.ShovelShortName] as PortableObject;
            this.house.AddToInventory(shovel);
            this.player.Location = RoomData.LocationBasementDirtFlooredRoom;
            this.housePresenter.Look();
            Assert.AreEqual(0, this.view.ItemsInRoom.Count);
            this.view.Argument = "dirt";
            this.housePresenter.Dig();
            Assert.AreEqual("Digging... I found something!", this.view.Message);
            //TODO: light flashlight and look
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[ObjectData.FlashlightShortName] as OnOffObject;
            onOffObjectFlashlight.State = Switch.On;
            this.housePresenter.Look();
            Assert.AreEqual(1, this.view.ItemsInRoom.Count);
            Assert.AreEqual("a clove of garlic", this.view.ItemsInRoom[0]);
            this.housePresenter.Dig();
            Assert.AreEqual("Digging... I found something!", this.view.Message);
            this.housePresenter.Look();
            Assert.AreEqual(2, this.view.ItemsInRoom.Count);
            Assert.AreEqual("a rusted key", this.view.ItemsInRoom[1]);
            this.housePresenter.Dig();
            Assert.AreEqual("Digging... ", this.view.Message);
            this.housePresenter.Look();
            Assert.AreEqual(2, this.view.ItemsInRoom.Count);
        }

        [Test]
        public void LightTests()
        {
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[ObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[ObjectData.BatteriesShortName] as ConsumableObject;
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
            this.housePresenter.Light();
            Assert.AreEqual("You have no light to turn on!", this.view.Message);
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
            this.view.Argument = "on";
            this.housePresenter.Light();
            Assert.AreEqual("You have no light to turn on!", this.view.Message);
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
            this.view.Argument = "off";
            this.housePresenter.Light();
            Assert.AreEqual("You have no light to turn off!", this.view.Message);
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
            this.house.AddToInventory(onOffObjectFlashlight);
            this.view.Argument = "";
            this.housePresenter.Light();
            Assert.AreEqual("It doesn't work", this.view.Message);
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
            this.view.Argument = "off";
            this.housePresenter.Light();
            Assert.AreEqual("It doesn't work anyway -- so why turn it off!", this.view.Message);
            this.house.AddToInventory(consumableObjectBatteries);
            consumableObjectBatteries.TimesUsed = consumableObjectBatteries.UsageLimit + 1;
            this.view.Argument = "";
            this.housePresenter.Light();
            Assert.AreEqual("The batteries are exhausted", this.view.Message);
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
            this.view.Argument = "off";
            this.housePresenter.Light();
            Assert.AreEqual("The batteries are already dead!", this.view.Message);
            consumableObjectBatteries.TimesUsed = 0;
            this.view.Argument = "";
            this.housePresenter.Light();
            Assert.AreEqual("Light on", this.view.Message);
            Assert.AreEqual(Switch.On, onOffObjectFlashlight.State);
            Assert.AreEqual(0, this.player.TimesLookedInDark);
            this.housePresenter.Light();
            Assert.AreEqual("Light off", this.view.Message);
            Assert.AreEqual(Switch.Off, onOffObjectFlashlight.State);
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void OpenTestException()
        {
            this.housePresenter.Open();
        }

        [Test]
        public void OpenTests()
        {
            this.view.Argument = "blah";
            this.housePresenter.Open();
            Assert.AreEqual("I'm sorry, I only know how to unlock doors and drawers.", this.view.Message);
            this.housePresenter.Look();
            Assert.IsFalse(this.view.ExitDirections.Contains("South"));
            this.view.Argument = "drawer";
            this.housePresenter.Open();
            Assert.AreEqual("Show me a drawer and I'll open it!!!", this.view.Message);
            this.view.Argument = "door";
            this.housePresenter.Open();
            Assert.AreEqual("I need something first!", this.view.Message);
            this.housePresenter.West();
            this.view.Argument = "door";
            this.housePresenter.Open();
            Assert.AreEqual("I see no door that needs opening!", this.view.Message);
            this.housePresenter.East();
            this.housePresenter.Look();
            Assert.IsFalse(this.view.ExitDirections.Contains("South"));
            PortableObject portableObjectKey = this.house.PortableObjects[ObjectData.RustedKeyShortName] as PortableObject;
            this.house.AddToInventory(portableObjectKey);
            this.view.Argument = "door";
            this.housePresenter.Open();
            Assert.AreEqual("<<<<C-L-I-C-K>>>>\r\nOK, it's open now", this.view.Message);
            this.view.Argument = "door";
            this.housePresenter.Open();
            Assert.AreEqual("I see no door that needs opening!", this.view.Message);
            this.housePresenter.Look();
            Assert.IsTrue(this.view.ExitDirections.Contains("South"));
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void PlayTestException()
        {
            this.housePresenter.Play();
        }

        [Test]
        public void PlayTests()
        {
            this.view.Argument = "aaa";
            this.housePresenter.Play();
            Assert.AreEqual("You can't play that!", this.view.Message);
            this.view.Argument = "dim";
            this.housePresenter.Play();
            Assert.AreEqual("You can't play that!", this.view.Message);
            this.view.Argument = "banjo";
            this.housePresenter.Play();
            Assert.AreEqual("You have no banjo to play", this.view.Message);
            PortableObject portableObjectBanjo = this.house.PortableObjects[ObjectData.BanjoShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBanjo);
            this.view.Argument = "banjo";
            this.housePresenter.Play();
            Assert.AreEqual("", this.view.Message);
            this.player.Location = RoomData.LocationBasementPumpRoom;
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains(AdversaryData.BeastShortName));
            this.view.Argument = "banjo";
            this.housePresenter.Play();
            Assert.AreEqual("Music hath charm to soothe the savage beast.  The beast wandered off in a state of bliss.", this.view.Message);
            Assert.IsFalse(this.house.Rooms[this.player.Location].Adversaries.Contains(AdversaryData.BeastShortName));
            Assert.IsTrue(this.house.Rooms[RoomData.LocationMonsterHangout].Adversaries.Contains(AdversaryData.BeastShortName));
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void ReadTestException()
        {
            this.housePresenter.Read();
        }

        [Test]
        public void ReadTests()
        {
            this.view.Argument = "aaa";
            this.housePresenter.Read();
            Assert.AreEqual("You can't read that", this.view.Message);
            this.view.Argument = "ban";
            this.housePresenter.Read();
            Assert.AreEqual("You don't have a ban to read.", this.view.Message);
            PortableObject portableObjectBanjo = this.house.PortableObjects[ObjectData.BanjoShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBanjo);
            this.view.Argument = "ban";
            this.housePresenter.Read();
            Assert.AreEqual("You can't read that", this.view.Message);
            this.view.Argument = "book";
            this.housePresenter.Read();
            Assert.AreEqual("You don't have a book to read.", this.view.Message);
            PortableObject portableObjectSorcerersBook = this.house.InanimateObjects[ObjectData.BookShortName] as PortableObject;
            this.house.AddToInventory(portableObjectSorcerersBook);
            this.view.Argument = "book";
            this.housePresenter.Read();
            Assert.AreEqual("The writing is blurry -- it reads:\r\nmagic words to make objects . . . one of the following.\r\nAbracadabra\r\nShazaam\r\nSeersucker\r\nUgaboom\r\nNote:  Be sure to use the right word in the . . .", this.view.Message);
            this.view.Argument = "parch";
            this.housePresenter.Read();
            Assert.AreEqual("You don't have a parch to read.", this.view.Message);
            PortableObject portableObjectParchment = this.house.InanimateObjects[ObjectData.ParchmentShortName] as PortableObject;
            this.house.AddToInventory(portableObjectParchment);
            Assert.AreEqual("The parchment is torn -- it reads:\r\n. . . is the place to use them:\r\n", this.view.Message);
        }
    }
}
