using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HouseForms
{
    /// <summary>
    /// Form for collecting action argument
    /// </summary>
    public partial class Input : Form
    {

        /// <summary>
        /// Gets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument
        {
            get { return this.textBoxInput.Text; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        public Input()
        {
            InitializeComponent();
        }

        private void Input_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Input"/> class.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        public Input(string actionName) : this()
        {
            this.Text = actionName + " what?";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
