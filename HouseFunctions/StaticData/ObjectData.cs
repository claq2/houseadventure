using System.Collections.Generic;
using System.Text;
using System;
namespace HouseCore
{
    /// <summary>
    /// All data relating to items in the house
    /// </summary>
    public sealed class ObjectData
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectData"/> class.
        /// </summary>
        private ObjectData()
        {
        }

        private static readonly ReadOnlyInanimateObjectInfoCollection objectInfoCollection = new ReadOnlyInanimateObjectInfoCollection(InitializeObjectInfo());

        private static List<InanimateObjectInfo> InitializeObjectInfo()
        {
            List<InanimateObjectInfo> result = new List<InanimateObjectInfo>();
            result.Add(new BagOfGoldInfo("a bag of gold", "gol", 5, Floor.Basement));
            result.Add(new BanjoInfo("a banjo", "ban", 7, Floor.SecondFloor));
            result.Add(new BatteriesInfo("a set of batteries", "bat", 2, Floor.ThirdFloor, 40));
            result.Add(new BrushInfo("a hairbrush", "hai", 6, Floor.SecondFloor));
            result.Add(new SprayInfo("a can of bug spray", "can", 2, Floor.Basement, 3));
            result.Add(new DiamondInfo("a small diamond", "dia", 1, Floor.SecondFloor));
            result.Add(new MagicDimeInfo("an aluminum dime", "dim", 4, Floor.FirstFloor, false));
            result.Add(new DryIceInfo("a block of dry ice", "ice", 3, Floor.ThirdFloor));
            result.Add(new FlashlightInfo("a flashlight", "fla", 3, Floor.FirstFloor));
            result.Add(new GarlicInfo("a clove of garlic", "gar", 0, Floor.Basement, false));
            result.Add(new GloveInfo("an old leather glove", "glo", 8, Floor.Basement));
            result.Add(new CoinsInfo("100's of gold coins", "coi", 8, Floor.SecondFloor));
            result.Add(new KnifeInfo("a carving knife", "kni", 6, Floor.FirstFloor));
            result.Add(new VaseInfo("a ming vase", "vas", 3, Floor.SecondFloor));
            result.Add(new DocumentInfo("a wrinkled parchment", "par", 7, Floor.Basement, CreateParchmentText(), "The parchment is torn"));
            result.Add(new PillowInfo("a silk pillow", "pil", 7, Floor.ThirdFloor));
            result.Add(new KeyInfo("a rusted key", "key", 0, Floor.Basement, false));
            result.Add(new ShovelInfo("a shovel", "sho", 4, Floor.ThirdFloor));
            result.Add(new DocumentInfo("a sorcerer's hand book", "boo", 1, Floor.ThirdFloor, CreateBookText(), "The writing is blurry"));
            result.Add(new BoxInfo("a wooden box", "box", 1, Floor.FirstFloor));

            result.Add(new LockableDoorObjectInfo("a locked door", "doo", 1, Floor.FirstFloor, new RoomExit(Direction.South, 0)));
            result.Add(new StationaryObjectInfo("a brass bathtub", 4, Floor.SecondFloor));
            result.Add(new StationaryObjectInfo("the front yard", 0, Floor.FirstFloor));
            result.Add(new StationaryObjectInfo("a king sized bed", 2, Floor.SecondFloor));
            result.Add(new StationaryObjectInfo("a unitron 30/50 mainframe", 4, Floor.ThirdFloor));
            result.Add(new StationaryObjectInfo("a dusty moose head", 7, Floor.SecondFloor));
            result.Add(new StationaryObjectInfo("a set of stocks", 5, Floor.Basement));

            result.Add(new NullObjectInfo());
            return result;
        }

        private static string CreateBookText()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            stringBuilderMessage.Append("magic words to make objects . . . one of the following.\r\n");
            string[] stringArrayMagicWords = Enum.GetNames(typeof(MagicWord));
            int intMagicWordCount = stringArrayMagicWords.Length;
            for (int i = 1; i < intMagicWordCount; i++)
            {
                stringBuilderMessage.Append(stringArrayMagicWords[i]);
                stringBuilderMessage.Append(Environment.NewLine);
            }

            stringBuilderMessage.Append("Note:  Be sure to use the right word in the . . .");
            return stringBuilderMessage.ToString();
        }

        private static string CreateParchmentText()
        {
            StringBuilder stringBuilderMessage = new StringBuilder();
            stringBuilderMessage.Append(". . . is the place to use them:\r\n");
                foreach (NormalRoomInfo room in RoomData.MagicRooms)
                {
                    stringBuilderMessage.Append(room.Name);
                    stringBuilderMessage.Append(Environment.NewLine);
                }

                // One non-magic decoy room to make things a little harder
                stringBuilderMessage.Append(RoomData.Rooms[29].Name);
                return stringBuilderMessage.ToString();
        }

        private const string bagOfGoldName = "a bag of gold";
        private const string bagOfGoldShortName = "gol";
        private const string banjoName = "a banjo";
        private const string banjoShortName = "ban";
        private const string bathtubName = "a brass bathtub";
        private const string batteriesName = "a set of batteries";
        private const string batteriesShortName = "bat";
        private const string bedName = "a king sized bed";
        private const string bookName = "a sorcerer's hand book";
        private const string bookShortName = "boo";
        private const string boxName = "a wooden box";
        private const string boxShortName = "box";
        private const string brushName = "a hairbrush";
        private const string brushShortName = "hai";
        private const string bugSprayName = "a can of bug spray";
        private const string bugSprayShortName = "can";
        private const string coinsName = "100's of gold coins";
        private const string coinsShortName = "coi";
        private const string diamondName = "a small diamond";
        private const string diamondShortName = "dia";
        private const string dimeName = "an aluminum dime";
        private const string dimeShortName = "dim";
        private const string dryIceName = "a block of dry ice";
        private const string dryIceShortName = "ice";
        private const string flashlightName = "a flashlight";
        private const string flashlightShortName = "fla";
        private const string frontYardName = "the front yard";
        private const string garlicName = "a clove of garlic";
        private const string garlicShortName = "gar";
        private const string gloveName = "an old leather glove";
        private const string gloveShortName = "glo";
        private const string knifeName = "a carving knife";
        private const string knifeShortName = "kni";
        private const string lockedDoorName = "a locked door";
        private const string lockedDoorShortName = "doo";
        private const string mainframeName = "a unitron 30/50 mainframe";
        private const string mooseHeadName = "a dusty moose head";
        private const string parchmentName = "a wrinkled parchment";
        private const string parchmentShortName = "par";
        private const string pillowName = "a silk pillow";
        private const string pillowShortName = "pil";
        private const string rustedKeyName = "a rusted key";
        private const string rustedKeyShortName = "key";
        private const string shovelName = "a shovel";
        private const string shovelShortName = "sho";
        private const string stocksName = "a set of stocks";
        private const string vaseName = "a ming vase";
        private const string vaseShortName = "vas";

        /// <summary>
        /// Gets the name of the bag of gold.
        /// </summary>
        /// <value>The name of the bag of gold.</value>
        public static string BagOfGoldName
        {
            get { return bagOfGoldName; }
        }

        /// <summary>
        /// Gets the short name of the bag of gold.
        /// </summary>
        /// <value>The short name of the bag of gold.</value>
        public static string BagOfGoldShortName
        {
            get { return bagOfGoldShortName; }
        }

        /// <summary>
        /// Gets the name of the banjo.
        /// </summary>
        /// <value>The name of the banjo.</value>
        public static string BanjoName
        {
            get { return banjoName; }
        }

        /// <summary>
        /// Gets the short name of the banjo.
        /// </summary>
        /// <value>The short name of the banjo.</value>
        public static string BanjoShortName
        {
            get { return banjoShortName; }
        }

        /// <summary>
        /// Gets the name of the bathtub.
        /// </summary>
        /// <value>The name of the bathtub.</value>
        public static string BathtubName
        {
            get { return bathtubName; }
        }

        /// <summary>
        /// Gets the name of the batteries.
        /// </summary>
        /// <value>The name of the batteries.</value>
        public static string BatteriesName
        {
            get { return batteriesName; }
        }

        /// <summary>
        /// Gets the short name of the batteries.
        /// </summary>
        /// <value>The short name of the batteries.</value>
        public static string BatteriesShortName
        {
            get { return batteriesShortName; }
        }

        /// <summary>
        /// Gets the name of the bed.
        /// </summary>
        /// <value>The name of the bed.</value>
        public static string BedName
        {
            get { return bedName; }
        }

        /// <summary>
        /// Gets the name of the book.
        /// </summary>
        /// <value>The name of the book.</value>
        public static string BookName
        {
            get { return bookName; }
        }

        /// <summary>
        /// Gets the short name of the book.
        /// </summary>
        /// <value>The short name of the book.</value>
        public static string BookShortName
        {
            get { return bookShortName; }
        }

        /// <summary>
        /// Gets the name of the box.
        /// </summary>
        /// <value>The name of the box.</value>
        public static string BoxName
        {
            get { return boxName; }
        }

        /// <summary>
        /// Gets the short name of the box.
        /// </summary>
        /// <value>The short name of the box.</value>
        public static string BoxShortName
        {
            get { return boxShortName; }
        }

        /// <summary>
        /// Gets the name of the brush.
        /// </summary>
        /// <value>The name of the brush.</value>
        public static string BrushName
        {
            get { return brushName; }
        }

        /// <summary>
        /// Gets the short name of the brush.
        /// </summary>
        /// <value>The short name of the brush.</value>
        public static string BrushShortName
        {
            get { return brushShortName; }
        }

        /// <summary>
        /// Gets the name of the bug spray.
        /// </summary>
        /// <value>The name of the bug spray.</value>
        public static string BugSprayName
        {
            get { return bugSprayName; }
        }

        /// <summary>
        /// Gets the short name of the bug spray.
        /// </summary>
        /// <value>The short name of the bug spray.</value>
        public static string BugSprayShortName
        {
            get { return bugSprayShortName; }
        }

        /// <summary>
        /// Gets the name of the coins.
        /// </summary>
        /// <value>The name of the coins.</value>
        public static string CoinsName
        {
            get { return coinsName; }
        }

        /// <summary>
        /// Gets the short name of the coins.
        /// </summary>
        /// <value>The short name of the coins.</value>
        public static string CoinsShortName
        {
            get { return coinsShortName; }
        }

        /// <summary>
        /// Gets the name of the diamond.
        /// </summary>
        /// <value>The name of the diamond.</value>
        public static string DiamondName
        {
            get { return diamondName; }
        }

        /// <summary>
        /// Gets the short name of the diamond.
        /// </summary>
        /// <value>The short name of the diamond.</value>
        public static string DiamondShortName
        {
            get { return diamondShortName; }
        }

        /// <summary>
        /// Gets the name of the dime.
        /// </summary>
        /// <value>The name of the dime.</value>
        public static string DimeName
        {
            get { return dimeName; }
        }

        /// <summary>
        /// Gets the short name of the dime.
        /// </summary>
        /// <value>The short name of the dime.</value>
        public static string DimeShortName
        {
            get { return dimeShortName; }
        }

        /// <summary>
        /// Gets the name of the dry ice.
        /// </summary>
        /// <value>The name of the dry ice.</value>
        public static string DryIceName
        {
            get { return dryIceName; }
        }

        /// <summary>
        /// Gets the short name of the dry ice.
        /// </summary>
        /// <value>The short name of the dry ice.</value>
        public static string DryIceShortName
        {
            get { return dryIceShortName; }
        }

        /// <summary>
        /// Gets the name of the flashlight.
        /// </summary>
        /// <value>The name of the flashlight.</value>
        public static string FlashlightName
        {
            get { return flashlightName; }
        }

        /// <summary>
        /// Gets the short name of the flashlight.
        /// </summary>
        /// <value>The short name of the flashlight.</value>
        public static string FlashlightShortName
        {
            get { return flashlightShortName; }
        }

        /// <summary>
        /// Gets the name of the front yard.
        /// </summary>
        /// <value>The name of the front yard.</value>
        public static string FrontYardName
        {
            get { return frontYardName; }
        }

        /// <summary>
        /// Gets the name of the garlic.
        /// </summary>
        /// <value>The name of the garlic.</value>
        public static string GarlicName
        {
            get { return garlicName; }
        }

        /// <summary>
        /// Gets the short name of the garlic.
        /// </summary>
        /// <value>The short name of the garlic.</value>
        public static string GarlicShortName
        {
            get { return garlicShortName; }
        }

        /// <summary>
        /// Gets the name of the glove.
        /// </summary>
        /// <value>The name of the glove.</value>
        public static string GloveName
        {
            get { return gloveName; }
        }

        /// <summary>
        /// Gets the short name of the glove.
        /// </summary>
        /// <value>The short name of the glove.</value>
        public static string GloveShortName
        {
            get { return gloveShortName; }
        }

        /// <summary>
        /// Gets the name of the knife.
        /// </summary>
        /// <value>The name of the knife.</value>
        public static string KnifeName
        {
            get { return knifeName; }
        }

        /// <summary>
        /// Gets the short name of the knife.
        /// </summary>
        /// <value>The short name of the knife.</value>
        public static string KnifeShortName
        {
            get { return knifeShortName; }
        }

        /// <summary>
        /// Gets the name of the locked door.
        /// </summary>
        /// <value>The name of the locked door.</value>
        public static string LockedDoorName
        {
            get { return lockedDoorName; }
        }

        /// <summary>
        /// Gets the short name of the locked door.
        /// </summary>
        /// <value>The short name of the locked door.</value>
        public static string LockedDoorShortName
        {
            get { return lockedDoorShortName; }
        }

        /// <summary>
        /// Gets the name of the mainframe.
        /// </summary>
        /// <value>The name of the mainframe.</value>
        public static string MainframeName
        {
            get { return mainframeName; }
        }

        /// <summary>
        /// Gets the name of the moose head.
        /// </summary>
        /// <value>The name of the moose head.</value>
        public static string MooseHeadName
        {
            get { return mooseHeadName; }
        }

        /// <summary>
        /// The object data collecition
        /// </summary>
        public static ReadOnlyInanimateObjectInfoCollection ObjectInfoCollection
        {
            get
            {
                return objectInfoCollection;
            }
        }

        /// <summary>
        /// Gets the name of the parchment.
        /// </summary>
        /// <value>The name of the parchment.</value>
        public static string ParchmentName
        {
            get { return parchmentName; }
        }

        /// <summary>
        /// Gets the short name of the parchment.
        /// </summary>
        /// <value>The short name of the parchment.</value>
        public static string ParchmentShortName
        {
            get { return parchmentShortName; }
        }

        /// <summary>
        /// Gets the name of the pillow.
        /// </summary>
        /// <value>The name of the pillow.</value>
        public static string PillowName
        {
            get { return pillowName; }
        }

        /// <summary>
        /// Gets the short name of the pillow.
        /// </summary>
        /// <value>The short name of the pillow.</value>
        public static string PillowShortName
        {
            get { return pillowShortName; }
        }

        /// <summary>
        /// Gets the name of the rusted key.
        /// </summary>
        /// <value>The name of the rusted key.</value>
        public static string RustedKeyName
        {
            get { return rustedKeyName; }
        }

        /// <summary>
        /// Gets the short name of the rusted key.
        /// </summary>
        /// <value>The short name of the rusted key.</value>
        public static string RustedKeyShortName
        {
            get { return rustedKeyShortName; }
        }

        /// <summary>
        /// Gets the name of the shovel.
        /// </summary>
        /// <value>The name of the shovel.</value>
        public static string ShovelName
        {
            get { return shovelName; }
        }

        /// <summary>
        /// Gets the short name of the shovel.
        /// </summary>
        /// <value>The short name of the shovel.</value>
        public static string ShovelShortName
        {
            get { return shovelShortName; }
        }

        /// <summary>
        /// Gets the name of the stocks.
        /// </summary>
        /// <value>The name of the stocks.</value>
        public static string StocksName
        {
            get { return stocksName; }
        }

        /// <summary>
        /// Gets the name of the vase.
        /// </summary>
        /// <value>The name of the vase.</value>
        public static string VaseName
        {
            get { return vaseName; }
        }

        /// <summary>
        /// Gets the short name of the vase.
        /// </summary>
        /// <value>The short name of the vase.</value>
        public static string VaseShortName
        {
            get { return vaseShortName; }
        }
    }
}
