//-----------------------------------------------------------------------
// <copyright file="Tests.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTests
{
    using System;
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
            this.view.Argument = "box";
            this.housePresenter.Get();
            this.housePresenter.PopulateInventory();
            Assert.AreEqual(true, this.view.Inventory.Contains(ObjectData.BoxName));
            Assert.AreEqual(false, this.house.Rooms[this.player.Location].Items.Contains(ObjectData.BoxShortName));
            Assert.AreEqual("box taken", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);
            this.housePresenter.Drop();
            this.view.Argument = "door";
            this.housePresenter.Get();
            Assert.AreEqual(false, this.view.Inventory.Contains(ObjectData.LockedDoorName));
            Assert.AreEqual(true, this.house.Rooms[this.player.Location].Items.Contains(ObjectData.LockedDoorShortName));
            Assert.AreEqual("You can't take the door", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.view.Argument = "knife";
            this.housePresenter.Get();
            Assert.AreEqual("I see no knife here", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.player.Location = RoomData.LocationFirstFloorKitchen;
            this.view.Argument = "knife";
            this.housePresenter.Get();
            Assert.AreEqual("This room's occupant seems to have grown very attached to the knife and won't let you have it", this.view.Message);
            Assert.AreEqual(false, this.view.GameEnded);

            this.player.Location = RoomData.LocationSecondFloorSewingRoom;
            this.view.Argument = "gold";
            this.housePresenter.Get();
            Assert.AreEqual(true, this.view.Message.Contains("Remember?!"));
            Assert.AreEqual(true, this.view.GameEnded);
            this.player.Location = RoomData.LocationSecondFloorTelephoneBooth;
            this.view.Argument = "coins";
            this.housePresenter.Get();
            Assert.AreEqual("Don't be silly!  You can't carry that many small items!", this.view.Message);
            ContainerObject containerObjectBox = this.house.InanimateObjects[ObjectData.BoxShortName] as ContainerObject;
            this.house.AddToInventory(containerObjectBox);
            this.view.Argument = "coins";
            this.housePresenter.Get();
            Assert.AreEqual("coins taken", this.view.Message);
            this.player.Location = RoomData.LocationThirdFloorBarroom;
            this.view.Argument = "ice";
            this.housePresenter.Get();
            Assert.AreEqual("Ouch!!  That hurts!!  You can't pick that up!", this.view.Message);
            ProtectiveObject protectiveObjectGlove = this.house.InanimateObjects[ObjectData.GloveShortName] as ProtectiveObject;
            this.house.AddToInventory(protectiveObjectGlove);
            this.view.Argument = "ice";
            this.housePresenter.Get();
            Assert.AreEqual("ice taken", this.view.Message);
            Assert.AreEqual(4, this.house.Inventory.Count);
            this.player.Location = RoomData.LocationThirdFloorTrophyRoom;
            Assert.IsTrue(this.house.Rooms[this.player.Location].Items.Contains("bat"));
            this.view.Argument = "batteries";
            this.housePresenter.Get();
            Assert.AreEqual("You can't carry that much, you'll have to drop something.", this.view.Message);
            Assert.IsTrue(this.house.Rooms[this.player.Location].Items.Contains("bat"));
            Assert.IsFalse(this.house.Inventory.Contains("bat"));




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
            this.view.Argument = "parch";
            this.housePresenter.Read();
            Assert.AreEqual("The parchment is torn -- it reads:\r\n. . . is the place to use them:\r\nin a telephone booth\r\nin the dining room\r\nin the living room", this.view.Message);
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void SayTestException()
        {
            this.housePresenter.Say();
        }

        [Test]
        public void SayTests()
        {
            this.view.Argument = "blah";
            this.housePresenter.Say();
            Assert.AreEqual("Nothing happened", this.view.Message);
            this.view.Argument = "seersucker";
            this.housePresenter.Say();
            Assert.AreEqual("Nothing happened", this.view.Message);
            this.player.Location = RoomData.LocationFirstFloorDiningRoom;
            this.view.Argument = "abracadabra";
            this.housePresenter.Say();
            Assert.AreEqual("You experience disortientation", this.view.Message);
            Assert.IsTrue(RoomData.LocationFirstFloorBedroom == this.player.Location);
            this.player.Location = RoomData.LocationFirstFloorDiningRoom;
            this.view.Argument = "shazaam";
            this.housePresenter.Say();
            Assert.AreEqual("You experience disortientation", this.view.Message);
            Assert.IsTrue(RoomData.LocationFirstFloorBedroom == this.player.Location);
            this.player.Location = RoomData.LocationFirstFloorDiningRoom;
            this.view.Argument = "ugaboom";
            this.housePresenter.Say();
            Assert.AreEqual("You experience disortientation", this.view.Message);
            Assert.IsTrue(RoomData.LocationFirstFloorBedroom == this.player.Location);
            this.player.Location = RoomData.LocationFirstFloorDiningRoom;
            this.view.Argument = "na";
            this.housePresenter.Say();
            Assert.AreEqual("Nothing happened", this.view.Message);
            this.player.Location = RoomData.LocationFirstFloorDiningRoom;
            this.housePresenter.Look();
            Assert.IsFalse(this.view.ItemsInRoom.Contains("an aluminum dime"));
            this.view.Argument = "seersucker";
            this.housePresenter.Say();
            Assert.AreEqual("The air shimmers", this.view.Message);
            this.housePresenter.Look();
            Assert.IsTrue(this.view.ItemsInRoom.Contains("an aluminum dime"));
            this.player.Location = RoomData.LocationBasementTelephoneBooth;
            this.housePresenter.Look();
            Assert.IsFalse(this.view.ItemsInRoom.Contains("an old leather glove"));
            this.view.Argument = "seersucker";
            this.housePresenter.Say();
            Assert.AreEqual("The air shimmers", this.view.Message);
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[ObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[ObjectData.BatteriesShortName] as ConsumableObject;
            this.house.AddToInventory(consumableObjectBatteries);
            this.house.AddToInventory(onOffObjectFlashlight);
            this.view.Argument = "";
            this.housePresenter.Light();
            this.housePresenter.Look();
            Assert.IsTrue(this.view.ItemsInRoom.Contains("an old leather glove"));
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void SprayTestException()
        {
            this.housePresenter.Spray();
        }

        [Test]
        public void SprayTests()
        {
            this.view.Argument = "blah";
            this.housePresenter.Spray();
            Assert.AreEqual("You have nothing with which to spray the blah!!", this.view.Message);
            ConsumableObject consumableObjectBugSpray = this.house.InanimateObjects[ObjectData.BugSprayShortName] as ConsumableObject;
            this.house.AddToInventory(consumableObjectBugSpray);
            this.view.Argument = "blah";
            this.housePresenter.Spray();
            Assert.AreEqual("You can't spray that!", this.view.Message);
            Assert.AreEqual(0, consumableObjectBugSpray.TimesUsed);
            this.view.Argument = "vampire";
            this.housePresenter.Spray();
            Assert.AreEqual("I see no vampire here", this.view.Message);
            Assert.AreEqual(0, consumableObjectBugSpray.TimesUsed);
            this.player.Location = RoomData.LocationFirstFloorKitchen;
            this.view.Argument = "vampire";
            this.housePresenter.Spray();
            Assert.AreEqual("The vampire will become angry if you continue to act this way", this.view.Message);
            Assert.AreEqual(1, consumableObjectBugSpray.TimesUsed);
            Assert.IsTrue(house.Rooms[RoomData.LocationFirstFloorKitchen].Adversaries.Contains("vam"));
            this.player.Location = RoomData.LocationBasementFreezer;
            Assert.IsTrue(house.Rooms[RoomData.LocationBasementFreezer].Adversaries.Contains("blo"));
            this.view.Argument = "blob";
            this.housePresenter.Spray();
            Assert.AreEqual("Through the spray's mist, you can see the blob disappear down a crevice in the floor", this.view.Message);
            Assert.AreEqual(2, consumableObjectBugSpray.TimesUsed);
            Assert.IsFalse(house.Rooms[RoomData.LocationBasementFreezer].Adversaries.Contains("blo"));
            Assert.IsTrue(house.Rooms[RoomData.LocationMonsterHangout].Adversaries.Contains("blo"));
            this.player.Location = RoomData.LocationFirstFloorKitchen;
            this.view.Argument = "vampire";
            this.housePresenter.Spray();
            Assert.AreEqual("The vampire will become angry if you continue to act this way", this.view.Message);
            Assert.AreEqual(3, consumableObjectBugSpray.TimesUsed);
            this.view.Argument = "vampire";
            this.housePresenter.Spray();
            Assert.AreEqual("The can is empty", this.view.Message);
            Assert.AreEqual(3, consumableObjectBugSpray.TimesUsed);


        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void StabTestException()
        {
            this.housePresenter.Stab();
        }

        [Test]
        public void StabTests()
        {
            this.view.Argument = "blah";
            this.housePresenter.Stab();
            Assert.AreEqual("You can't kill that!", this.view.Message);
            this.view.Argument = "vampire";
            this.housePresenter.Stab();
            Assert.AreEqual("I see no vampire here!", this.view.Message);
            this.player.Location = RoomData.LocationFirstFloorKitchen;
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains("vam"));
            this.view.Argument = "vampire";
            this.housePresenter.Stab();
            Assert.AreEqual("You have nothing with which to kill the vampire", this.view.Message);
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains("vam"));
            PortableObject portableObjectKnife = this.house.PortableObjects[ObjectData.KnifeShortName] as PortableObject;
            this.house.AddToInventory(portableObjectKnife);
            this.view.Argument = "vampire";
            this.housePresenter.Stab();
            Assert.AreEqual("The vampire will become angry if you persist!", this.view.Message);
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains("vam"));
            this.player.Location = RoomData.LocationSecondFloorGuestroom1;
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains("mon"));
            this.view.Argument = "monk";
            this.housePresenter.Stab();
            Assert.AreEqual("The monk has become frightened and run away", this.view.Message);
            Assert.IsFalse(this.house.Rooms[this.player.Location].Adversaries.Contains("mon"));
            Assert.IsTrue(this.house.Rooms[RoomData.LocationMonsterHangout].Adversaries.Contains("mon"));
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void WaveTestException()
        {
            this.housePresenter.Wave();
        }

        [Test]
        public void WaveTests()
        {
            this.view.Argument = "blah";
            this.housePresenter.Wave();
            Assert.AreEqual("You can't wave that!", this.view.Message);
            this.view.Argument = "flashlight";
            this.housePresenter.Wave();
            Assert.AreEqual("You have no flashlight to wave!", this.view.Message);
            this.view.Argument = "garlic";
            this.housePresenter.Wave();
            Assert.AreEqual("You have no garlic to wave!", this.view.Message);
            this.view.Argument = "batteries";
            this.housePresenter.Wave();
            Assert.AreEqual("You have no batteries to wave!", this.view.Message);
            PortableObject portableObjectGarlic = this.house.InanimateObjects[ObjectData.GarlicShortName] as PortableObject;
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[ObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[ObjectData.BatteriesShortName] as ConsumableObject;
            this.house.AddToInventory(portableObjectGarlic);
            this.house.AddToInventory(onOffObjectFlashlight);
            this.house.AddToInventory(consumableObjectBatteries);
            this.view.Argument = "flashlight";
            this.housePresenter.Wave();
            Assert.AreEqual("Waving the flashlight had no effect", this.view.Message);
            this.view.Argument = "garlic";
            this.housePresenter.Wave();
            Assert.AreEqual("Waving the garlic had no effect", this.view.Message);
            this.view.Argument = "batteries";
            this.housePresenter.Wave();
            Assert.AreEqual("That was fun!! But it had no effect.", this.view.Message);
            this.player.Location = RoomData.LocationFirstFloorKitchen;
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains("vam"));
            this.view.Argument = "flashlight";
            onOffObjectFlashlight.State = Switch.On;
            this.housePresenter.Wave();
            Assert.AreEqual("The vampire coverd its eyes and flew away!", this.view.Message);
            Assert.IsFalse(this.house.Rooms[this.player.Location].Adversaries.Contains("vam"));
            Assert.IsTrue(this.house.Rooms[RoomData.LocationMonsterHangout].Adversaries.Contains("vam"));
            this.player.Location = RoomData.LocationThirdFloorArtHall;
            Assert.IsTrue(this.house.Rooms[this.player.Location].Adversaries.Contains("wer"));
            this.view.Argument = "garlic";
            this.housePresenter.Wave();
            Assert.AreEqual("The werewolf howled and ran away in terror!", this.view.Message);
            Assert.IsFalse(this.house.Rooms[this.player.Location].Adversaries.Contains("wer"));
            Assert.IsTrue(this.house.Rooms[RoomData.LocationMonsterHangout].Adversaries.Contains("wer"));
        }

        [Test]
        public void QuitTest()
        {
            this.housePresenter.Quit();
            Assert.IsTrue(this.view.GameEnded);
            Assert.AreEqual("You got 0 items out of the house in 0 moves", this.view.Message);
        }

        [Test]
        [ExpectedException(ExpectedExceptionName = "HouseCore.Exceptions.NullViewArgumentException", ExpectedMessage = "The view's Argument property is null")]
        public void DropTestException()
        {
            this.housePresenter.Drop();
        }

        [Test]
        public void DropTests()
        {
            this.player.Location = RoomData.LocationFirstFloorFrontPorch;
            this.view.Argument = "blah";
            this.housePresenter.Drop();
            Assert.AreEqual("You can't drop the blah", this.view.Message);
            this.view.Argument = "flashlight";
            this.housePresenter.Drop();
            Assert.AreEqual("You have no flashlight to drop", this.view.Message);
            OnOffObject onOffObjectFlashlight = this.house.InanimateObjects[ObjectData.FlashlightShortName] as OnOffObject;
            ConsumableObject consumableObjectBatteries = this.house.InanimateObjects[ObjectData.BatteriesShortName] as ConsumableObject;
            this.house.AddToInventory(onOffObjectFlashlight);
            this.house.AddToInventory(consumableObjectBatteries);
            this.view.Argument = "flashlight";
            onOffObjectFlashlight.State = Switch.On;
            this.housePresenter.Drop();
            Assert.AreEqual("flashlight dropped", this.view.Message);
            Assert.IsTrue(onOffObjectFlashlight.State == Switch.Off);
            Assert.IsFalse(this.house.Inventory.Contains(onOffObjectFlashlight));
            this.house.AddToInventory(onOffObjectFlashlight);
            this.view.Argument = "batteries";
            onOffObjectFlashlight.State = Switch.On;
            this.housePresenter.Drop();
            Assert.AreEqual("batteries dropped", this.view.Message);
            Assert.IsTrue(onOffObjectFlashlight.State == Switch.Off);
            Assert.IsFalse(this.house.Inventory.Contains(consumableObjectBatteries));
            MultiplePieceObject multiplePieceObjectCoins = this.house.InanimateObjects[ObjectData.CoinsShortName] as MultiplePieceObject;
            this.house.AddToInventory(multiplePieceObjectCoins);
            ContainerObject containerObjectBox = this.house.InanimateObjects[ObjectData.BoxShortName] as ContainerObject;
            this.house.AddToInventory(containerObjectBox);
            this.view.Argument = "box";
            this.housePresenter.Drop();
            Assert.AreEqual("Try dropping the following items first:  100's of gold coins", this.view.Message);
            Assert.IsTrue(this.house.Inventory.Contains(containerObjectBox));
            Assert.IsTrue(this.house.Inventory.Contains(multiplePieceObjectCoins));
            this.view.Argument = "coins";
            this.housePresenter.Drop();
            Assert.AreEqual("coins dropped", this.view.Message);
            Assert.IsFalse(this.house.Inventory.Contains(multiplePieceObjectCoins));
            this.view.Argument = "box";
            this.housePresenter.Drop();
            Assert.AreEqual("box dropped", this.view.Message);
            Assert.IsFalse(this.house.Inventory.Contains(containerObjectBox));
            ProtectiveObject protectiveObjectGlove = this.house.InanimateObjects[ObjectData.GloveShortName] as ProtectiveObject;
            PainfulObject painfulObjectDryIce = this.house.InanimateObjects[ObjectData.DryIceShortName] as PainfulObject;
            this.house.AddToInventory(protectiveObjectGlove);
            this.house.AddToInventory(painfulObjectDryIce);
            this.view.Argument = "glove";
            this.housePresenter.Drop();
            Assert.AreEqual("You'll hurt yourself if you drop the glove now!", this.view.Message);
            Assert.IsTrue(this.house.Inventory.Contains(protectiveObjectGlove));
            Assert.IsTrue(this.house.Inventory.Contains(painfulObjectDryIce));
            this.view.Argument = "ice";
            this.housePresenter.Drop();
            Assert.AreEqual("ice dropped", this.view.Message);
            Assert.IsFalse(this.house.Inventory.Contains(painfulObjectDryIce));
            this.view.Argument = "glove";
            this.housePresenter.Drop();
            Assert.AreEqual("glove dropped", this.view.Message);
            Assert.IsFalse(this.house.Inventory.Contains(protectiveObjectGlove));
            DelicateObject delicateObjectMingVase = this.house.InanimateObjects[ObjectData.VaseShortName] as DelicateObject;
            CushioningObject cushioningObjectPillow = this.house.InanimateObjects[ObjectData.PillowShortName] as CushioningObject;
            this.house.AddToInventory(delicateObjectMingVase);
            this.house.AddToInventory(cushioningObjectPillow);
            this.view.Argument = "vase";
            this.housePresenter.Drop();
            Assert.AreEqual("You can't drop that--it'll break", this.view.Message);
            Assert.IsTrue(this.house.Inventory.Contains(delicateObjectMingVase));
            Assert.IsTrue(this.house.Inventory.Contains(cushioningObjectPillow));
            this.view.Argument = "pillow";
            this.housePresenter.Drop();
            Assert.AreEqual("pillow dropped", this.view.Message);
            Assert.IsFalse(this.house.Inventory.Contains(cushioningObjectPillow));
            this.view.Argument = "vase";
            this.housePresenter.Drop();
            Assert.AreEqual("vase dropped", this.view.Message);
            Assert.IsFalse(this.house.Inventory.Contains(delicateObjectMingVase));
            Assert.AreEqual(8, this.player.ItemsRemovedFromHouse);
            PortableObject portableObjectBagOfGold = this.house.InanimateObjects[ObjectData.BagOfGoldShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBagOfGold);
            this.view.Argument = "gold";
            this.housePresenter.Drop();
            Assert.AreEqual(9, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectBanjo = this.house.InanimateObjects[ObjectData.BanjoShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBanjo);
            this.view.Argument = "banjo";
            this.housePresenter.Drop();
            Assert.AreEqual(10, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectBrush = this.house.InanimateObjects[ObjectData.BrushShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBrush);
            this.view.Argument = "hairbrush";
            this.housePresenter.Drop();
            Assert.AreEqual(11, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectBugSpray = this.house.InanimateObjects[ObjectData.BugSprayShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBugSpray);
            this.view.Argument = "can";
            this.housePresenter.Drop();
            Assert.AreEqual(12, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectDiamond = this.house.InanimateObjects[ObjectData.DiamondShortName] as PortableObject;
            this.house.AddToInventory(portableObjectDiamond);
            this.view.Argument = "diamond";
            this.housePresenter.Drop();
            Assert.AreEqual(13, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectDime = this.house.InanimateObjects[ObjectData.DimeShortName] as PortableObject;
            this.house.AddToInventory(portableObjectDime);
            this.view.Argument = "dime";
            this.housePresenter.Drop();
            Assert.AreEqual(14, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectGarlic = this.house.InanimateObjects[ObjectData.GarlicShortName] as PortableObject;
            this.house.AddToInventory(portableObjectGarlic);
            this.view.Argument = "garlic";
            this.housePresenter.Drop();
            Assert.AreEqual(15, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectKnife = this.house.InanimateObjects[ObjectData.KnifeShortName] as PortableObject;
            this.house.AddToInventory(portableObjectKnife);
            this.view.Argument = "knife";
            this.housePresenter.Drop();
            Assert.AreEqual(16, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectParchment = this.house.InanimateObjects[ObjectData.ParchmentShortName] as PortableObject;
            this.house.AddToInventory(portableObjectParchment);
            this.view.Argument = "parchment";
            this.housePresenter.Drop();
            Assert.AreEqual(17, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectKey = this.house.InanimateObjects[ObjectData.RustedKeyShortName] as PortableObject;
            this.house.AddToInventory(portableObjectKey);
            this.view.Argument = "key";
            this.housePresenter.Drop();
            Assert.AreEqual(18, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectShovel = this.house.InanimateObjects[ObjectData.ShovelShortName] as PortableObject;
            this.house.AddToInventory(portableObjectShovel);
            this.view.Argument = "shovel";
            this.housePresenter.Drop();
            Assert.AreEqual(19, this.player.ItemsRemovedFromHouse);
            Assert.IsFalse(this.view.GameEnded);
            PortableObject portableObjectBook = this.house.InanimateObjects[ObjectData.BookShortName] as PortableObject;
            this.house.AddToInventory(portableObjectBook);
            this.view.Argument = "book";
            this.housePresenter.Drop();
            Assert.AreEqual(20, this.player.ItemsRemovedFromHouse);
            Assert.IsTrue(this.view.GameEnded);
            Assert.AreEqual("book dropped\r\n\r\nCongratulations--you have successfully completed House Adventure \r\nYou removed all 20 objects in 0 moves", this.view.Message);
        }

        [Test]
        public void LookTests()
        { 
            Assert.IsTrue(this.view.ExitDirections.Count == 0);
            Assert.IsTrue(this.view.ItemsInRoom.Count == 0);
            Assert.IsTrue(this.view.ItemsInRoomShortNames.Count == 0);
            Assert.IsTrue(this.view.AdversariesInRoom.Count == 0);
            Assert.AreEqual(null, this.view.RoomName);
            this.housePresenter.Look();
            Assert.AreEqual("East", this.view.ExitDirections[0]);
            Assert.AreEqual("West", this.view.ExitDirections[1]);
            Assert.IsTrue(this.view.ExitDirections.Count == 2);
            Assert.AreEqual("a wooden box", this.view.ItemsInRoom[0]);
            Assert.AreEqual("a locked door", this.view.ItemsInRoom[1]);
            Assert.AreEqual("box", this.view.ItemsInRoomShortNames[0]);
            Assert.AreEqual("doo", this.view.ItemsInRoomShortNames[1]);
            Assert.AreEqual("in the foyer", this.view.RoomName);
            this.player.Location = RoomData.LocationFirstFloorTelephoneBooth;
            this.housePresenter.Look();
            Assert.IsTrue(this.player.Location == RoomData.LocationFirstFloorTelephoneBooth);
            PortableObject inanimateObjectDime = this.house.InanimateObjects[ObjectData.DimeShortName] as PortableObject;
            this.house.AddToInventory(inanimateObjectDime);
            this.player.Location = RoomData.LocationFirstFloorTelephoneBooth;
            this.housePresenter.Look();
            Assert.IsFalse(this.player.Location == RoomData.LocationFirstFloorTelephoneBooth);
            Assert.IsTrue(this.player.Location == RoomData.LocationThirdFloorTelephoneBooth);
            this.player.Location = RoomData.LocationBasementWorkshop;
            Assert.AreEqual(0, this.player.TimesLookedInDark);
            this.housePresenter.Look();
            Assert.AreEqual("nothing--it's too dark!", this.view.Message);
            Assert.AreEqual(1, this.player.TimesLookedInDark);
        }

        //TODO:  Inventory tests

        //TODO: Save and load tests
    }
}
