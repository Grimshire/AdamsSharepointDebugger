namespace MySharePointDebugger
{
    partial class Form1
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
            this.btnDebugInit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblURLName = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lblListName = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDebugInit
            // 
            this.btnDebugInit.Location = new System.Drawing.Point(67, 12);
            this.btnDebugInit.Name = "btnDebugInit";
            this.btnDebugInit.Size = new System.Drawing.Size(75, 23);
            this.btnDebugInit.TabIndex = 3;
            this.btnDebugInit.Text = "Debug Me!";
            this.btnDebugInit.UseVisualStyleBackColor = true;
            this.btnDebugInit.Click += new System.EventHandler(this.btnDebugInit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Debug code by attaching it to debug button in the code behind.";
            // 
            // txtBoxOutput
            // 
            this.txtBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxOutput.BackColor = System.Drawing.Color.White;
            this.txtBoxOutput.Location = new System.Drawing.Point(67, 38);
            this.txtBoxOutput.Multiline = true;
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.ReadOnly = true;
            this.txtBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxOutput.Size = new System.Drawing.Size(573, 358);
            this.txtBoxOutput.TabIndex = 5;
            this.txtBoxOutput.Text = "Awaiting input...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(708, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "Ready Player 1.";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(197, 17);
            this.toolStripStatusLabel1.Text = "Ready Player 1 for SUPER FUN TIME!";
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(67, 407);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(413, 20);
            this.txtBoxInput.TabIndex = 9;
            this.txtBoxInput.Text = "...enter info to be stored in the tree here (Name of list, URL, etc.)";
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(486, 405);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(75, 23);
            this.btnStore.TabIndex = 12;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(320, 433);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 13;
            this.btnGet.Text = "Get Results";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // button1
            // 
            this.button1.Image = global::MySharePointDebugger.Properties.Resources.dumpTruckDown;
            this.button1.Location = new System.Drawing.Point(233, 571);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 75);
            this.button1.TabIndex = 14;
            this.button1.Text = "Erase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblURLName
            // 
            this.lblURLName.AutoSize = true;
            this.lblURLName.Location = new System.Drawing.Point(64, 464);
            this.lblURLName.Name = "lblURLName";
            this.lblURLName.Size = new System.Drawing.Size(29, 13);
            this.lblURLName.TabIndex = 15;
            this.lblURLName.Text = "URL";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Site",
            "Lists",
            "Items",
            "Properties"});
            this.checkedListBox1.Location = new System.Drawing.Point(520, 464);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 16;
            // 
            // lblListName
            // 
            this.lblListName.AutoSize = true;
            this.lblListName.Location = new System.Drawing.Point(64, 483);
            this.lblListName.Name = "lblListName";
            this.lblListName.Size = new System.Drawing.Size(54, 13);
            this.lblListName.TabIndex = 17;
            this.lblListName.Text = "List Name";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(64, 500);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(58, 13);
            this.lblItemName.TabIndex = 18;
            this.lblItemName.Text = "Item Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 671);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblListName);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.lblURLName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtBoxOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDebugInit);
            this.Name = "Form1";
            this.Text = "Adam\'s Sharepoint Debugger";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDebugInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblURLName;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label lblListName;
        private System.Windows.Forms.Label lblItemName;
    }
}

