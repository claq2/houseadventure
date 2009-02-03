using System;
using System.Collections.Generic;
using System.Text;

namespace House
{
    using HouseFunctions.Interfaces;
    class ActionHelper:IInventoryAction, ILookAction, IGameEndingArgumentAction, IAction, IArgumentAction
    {
        #region IInventoryAction Members

        public IList<string> Inventory
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IAction Members

        public StringBuilder Message
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Action
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool ClearScreen
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region ILookAction Members

        public IList<string> Adversaries
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public IList<string> Items
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public IList<string> ExitDirections
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string RoomName
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }
        #endregion

        #region IGameEnded Members

        public bool GameEnded
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region IArgumentAction Members

        public string Argument
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region IAction Members


        public HouseFunctions.HouseType House
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public HouseFunctions.Player Player
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
