namespace HouseForms
{
    partial class FormHouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxRoomContents = new System.Windows.Forms.ListBox();
            this.listBoxInventory = new System.Windows.Forms.ListBox();
            this.buttonNorth = new System.Windows.Forms.Button();
            this.buttonSouth = new System.Windows.Forms.Button();
            this.buttonWest = new System.Windows.Forms.Button();
            this.buttonEast = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.listBoxActions = new System.Windows.Forms.ListBox();
            this.buttonPerformAction = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.labelISee = new System.Windows.Forms.Label();
            this.labelYouCarrying = new System.Windows.Forms.Label();
            this.labelYouAre = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.buttonLook = new System.Windows.Forms.Button();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.groupBoxMove = new System.Windows.Forms.GroupBox();
            this.listBoxExits = new System.Windows.Forms.ListBox();
            this.labelExitDirections = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.groupBoxMove.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxRoomContents
            // 
            this.listBoxRoomContents.FormattingEnabled = true;
            this.listBoxRoomContents.Location = new System.Drawing.Point(410, 91);
            this.listBoxRoomContents.Name = "listBoxRoomContents";
            this.listBoxRoomContents.Size = new System.Drawing.Size(120, 95);
            this.listBoxRoomContents.TabIndex = 0;
            // 
            // listBoxInventory
            // 
            this.listBoxInventory.FormattingEnabled = true;
            this.listBoxInventory.Location = new System.Drawing.Point(407, 348);
            this.listBoxInventory.Name = "listBoxInventory";
            this.listBoxInventory.Size = new System.Drawing.Size(120, 95);
            this.listBoxInventory.TabIndex = 1;
            // 
            // buttonNorth
            // 
            this.buttonNorth.Location = new System.Drawing.Point(102, 49);
            this.buttonNorth.Name = "buttonNorth";
            this.buttonNorth.Size = new System.Drawing.Size(75, 23);
            this.buttonNorth.TabIndex = 2;
            this.buttonNorth.Text = "North";
            this.buttonNorth.UseVisualStyleBackColor = true;
            this.buttonNorth.Click += new System.EventHandler(this.buttonNorth_Click);
            // 
            // buttonSouth
            // 
            this.buttonSouth.Location = new System.Drawing.Point(102, 111);
            this.buttonSouth.Name = "buttonSouth";
            this.buttonSouth.Size = new System.Drawing.Size(75, 23);
            this.buttonSouth.TabIndex = 3;
            this.buttonSouth.Text = "South";
            this.buttonSouth.UseVisualStyleBackColor = true;
            this.buttonSouth.Click += new System.EventHandler(this.buttonSouth_Click);
            // 
            // buttonWest
            // 
            this.buttonWest.Location = new System.Drawing.Point(57, 77);
            this.buttonWest.Name = "buttonWest";
            this.buttonWest.Size = new System.Drawing.Size(75, 23);
            this.buttonWest.TabIndex = 4;
            this.buttonWest.Text = "West";
            this.buttonWest.UseVisualStyleBackColor = true;
            this.buttonWest.Click += new System.EventHandler(this.buttonWest_Click);
            // 
            // buttonEast
            // 
            this.buttonEast.Location = new System.Drawing.Point(147, 77);
            this.buttonEast.Name = "buttonEast";
            this.buttonEast.Size = new System.Drawing.Size(75, 23);
            this.buttonEast.TabIndex = 5;
            this.buttonEast.Text = "East";
            this.buttonEast.UseVisualStyleBackColor = true;
            this.buttonEast.Click += new System.EventHandler(this.buttonEast_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(102, 20);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 6;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(102, 140);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 7;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // listBoxActions
            // 
            this.listBoxActions.FormattingEnabled = true;
            this.listBoxActions.Location = new System.Drawing.Point(13, 13);
            this.listBoxActions.Name = "listBoxActions";
            this.listBoxActions.Size = new System.Drawing.Size(75, 212);
            this.listBoxActions.TabIndex = 8;
            // 
            // buttonPerformAction
            // 
            this.buttonPerformAction.Location = new System.Drawing.Point(12, 247);
            this.buttonPerformAction.Name = "buttonPerformAction";
            this.buttonPerformAction.Size = new System.Drawing.Size(85, 23);
            this.buttonPerformAction.TabIndex = 9;
            this.buttonPerformAction.Text = "Perform Action";
            this.buttonPerformAction.UseVisualStyleBackColor = true;
            this.buttonPerformAction.Click += new System.EventHandler(this.buttonPerformAction_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 426);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(95, 426);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 11;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // labelISee
            // 
            this.labelISee.AutoSize = true;
            this.labelISee.Location = new System.Drawing.Point(410, 72);
            this.labelISee.Name = "labelISee";
            this.labelISee.Size = new System.Drawing.Size(33, 13);
            this.labelISee.TabIndex = 12;
            this.labelISee.Text = "I see:";
            // 
            // labelYouCarrying
            // 
            this.labelYouCarrying.AutoSize = true;
            this.labelYouCarrying.Location = new System.Drawing.Point(407, 329);
            this.labelYouCarrying.Name = "labelYouCarrying";
            this.labelYouCarrying.Size = new System.Drawing.Size(129, 13);
            this.labelYouCarrying.TabIndex = 13;
            this.labelYouCarrying.Text = "You are presently carrying";
            // 
            // labelYouAre
            // 
            this.labelYouAre.AutoSize = true;
            this.labelYouAre.Location = new System.Drawing.Point(410, 30);
            this.labelYouAre.Name = "labelYouAre";
            this.labelYouAre.Size = new System.Drawing.Size(47, 13);
            this.labelYouAre.TabIndex = 14;
            this.labelYouAre.Text = "You are:";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(410, 47);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(64, 13);
            this.labelLocation.TabIndex = 15;
            this.labelLocation.Text = "some where";
            // 
            // buttonLook
            // 
            this.buttonLook.Location = new System.Drawing.Point(537, 91);
            this.buttonLook.Name = "buttonLook";
            this.buttonLook.Size = new System.Drawing.Size(75, 23);
            this.buttonLook.TabIndex = 16;
            this.buttonLook.Text = "Look";
            this.buttonLook.UseVisualStyleBackColor = true;
            this.buttonLook.Click += new System.EventHandler(this.buttonLook_Click);
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(534, 348);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(75, 23);
            this.buttonInventory.TabIndex = 17;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // groupBoxMove
            // 
            this.groupBoxMove.Controls.Add(this.buttonEast);
            this.groupBoxMove.Controls.Add(this.buttonNorth);
            this.groupBoxMove.Controls.Add(this.buttonSouth);
            this.groupBoxMove.Controls.Add(this.buttonWest);
            this.groupBoxMove.Controls.Add(this.buttonUp);
            this.groupBoxMove.Controls.Add(this.buttonDown);
            this.groupBoxMove.Location = new System.Drawing.Point(106, 209);
            this.groupBoxMove.Name = "groupBoxMove";
            this.groupBoxMove.Size = new System.Drawing.Size(273, 180);
            this.groupBoxMove.TabIndex = 18;
            this.groupBoxMove.TabStop = false;
            this.groupBoxMove.Text = "Move";
            // 
            // listBoxExits
            // 
            this.listBoxExits.FormattingEnabled = true;
            this.listBoxExits.HorizontalScrollbar = true;
            this.listBoxExits.Location = new System.Drawing.Point(410, 215);
            this.listBoxExits.Name = "listBoxExits";
            this.listBoxExits.Size = new System.Drawing.Size(120, 56);
            this.listBoxExits.TabIndex = 19;
            // 
            // labelExitDirections
            // 
            this.labelExitDirections.AutoSize = true;
            this.labelExitDirections.Location = new System.Drawing.Point(410, 193);
            this.labelExitDirections.Name = "labelExitDirections";
            this.labelExitDirections.Size = new System.Drawing.Size(91, 13);
            this.labelExitDirections.TabIndex = 20;
            this.labelExitDirections.Text = "Obvious exits are:";
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(176, 426);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 21;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.labelMessage);
            this.groupBoxOutput.Location = new System.Drawing.Point(106, 13);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(273, 190);
            this.groupBoxOutput.TabIndex = 22;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Messages";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(7, 20);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(72, 13);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "labelMessage";
            // 
            // FormHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 462);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.labelExitDirections);
            this.Controls.Add(this.listBoxExits);
            this.Controls.Add(this.groupBoxMove);
            this.Controls.Add(this.buttonInventory);
            this.Controls.Add(this.buttonLook);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelYouAre);
            this.Controls.Add(this.labelYouCarrying);
            this.Controls.Add(this.labelISee);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPerformAction);
            this.Controls.Add(this.listBoxActions);
            this.Controls.Add(this.listBoxInventory);
            this.Controls.Add(this.listBoxRoomContents);
            this.Name = "FormHouse";
            this.Text = "House Adventure";
            this.Load += new System.EventHandler(this.FormHouse_Load);
            this.groupBoxMove.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRoomContents;
        private System.Windows.Forms.ListBox listBoxInventory;
        private System.Windows.Forms.Button buttonNorth;
        private System.Windows.Forms.Button buttonSouth;
        private System.Windows.Forms.Button buttonWest;
        private System.Windows.Forms.Button buttonEast;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.ListBox listBoxActions;
        private System.Windows.Forms.Button buttonPerformAction;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label labelISee;
        private System.Windows.Forms.Label labelYouCarrying;
        private System.Windows.Forms.Label labelYouAre;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button buttonLook;
        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.GroupBox groupBoxMove;
        private System.Windows.Forms.ListBox listBoxExits;
        private System.Windows.Forms.Label labelExitDirections;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Label labelMessage;
    }
}

