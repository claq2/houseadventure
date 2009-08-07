//-----------------------------------------------------------------------
// <copyright file="GameEntity.cs" company="James McLachlan">
//     Copyright (c) James McLachlan. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

[assembly: System.CLSCompliant(true)]
namespace HouseCore
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GameEntity : IEquatable<GameEntity>
    {
        //private LocationType location;
        private String name = String.Empty;

        /// <summary>
        /// The item's short name
        /// </summary>
        private string shortName = String.Empty;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntity"/> class.
        /// </summary>
        protected GameEntity()
        {
            //this.Location = new LocationType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected GameEntity(string name)
        {
            //this.Location = new LocationType();
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="shortName">The short name.</param>
        protected GameEntity(string name, string shortName)
        {
            //this.Location = new LocationType();
            this.name = name;
            this.shortName = shortName;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            if (String.IsNullOrEmpty(ShortName))
            {
                return Name;
            }
            else
            {
                return ShortName;
            }
        }

        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <value>The identity.</value>
        public string Identity
        {
            get
            {
                if (String.IsNullOrEmpty(ShortName))
                {
                    return Name;
                }
                else
                {
                    return ShortName;
                }
            }
        }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName
        {
            get { return this.shortName; }
            set
            {
            	this.shortName = value;
            }
        }

        #region IEquatable<GameEntity> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(GameEntity other)
        {
            if (String.IsNullOrEmpty(ShortName))
            {
                return this.Name == other.Name;
            }
            else
            {
                return this.ShortName == other.ShortName;
            }
        }

        #endregion


    }
}
