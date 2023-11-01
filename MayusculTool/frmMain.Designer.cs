namespace MayusTool
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.btnDale = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.cbWordUpper = new System.Windows.Forms.CheckBox();
            this.cbReverse = new System.Windows.Forms.CheckBox();
            this.cbLetterUpper = new System.Windows.Forms.CheckBox();
            this.cbNum = new System.Windows.Forms.CheckBox();
            this.gbModifiers = new System.Windows.Forms.GroupBox();
            this.tbxOutput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.cmSecret = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miSecret = new System.Windows.Forms.ToolStripMenuItem();
            this.gbModifiers.SuspendLayout();
            this.cmSecret.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxInput
            // 
            this.tbxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInput.Location = new System.Drawing.Point(12, 32);
            this.tbxInput.Multiline = true;
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxInput.Size = new System.Drawing.Size(343, 341);
            this.tbxInput.TabIndex = 0;
            this.tbxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxInput_KeyDown);
            // 
            // btnDale
            // 
            this.btnDale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDale.Location = new System.Drawing.Point(36, 439);
            this.btnDale.Name = "btnDale";
            this.btnDale.Size = new System.Drawing.Size(75, 23);
            this.btnDale.TabIndex = 1;
            this.btnDale.Text = "Dale";
            this.btnDale.UseVisualStyleBackColor = true;
            this.btnDale.Click += new System.EventHandler(this.btnDale_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(597, 439);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Vaciar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClipboard
            // 
            this.btnClipboard.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClipboard.Location = new System.Drawing.Point(321, 439);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(82, 23);
            this.btnClipboard.TabIndex = 3;
            this.btnClipboard.Text = "Portapapeles";
            this.btnClipboard.UseVisualStyleBackColor = true;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // cbWordUpper
            // 
            this.cbWordUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWordUpper.AutoSize = true;
            this.cbWordUpper.Checked = true;
            this.cbWordUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWordUpper.Location = new System.Drawing.Point(6, 18);
            this.cbWordUpper.Name = "cbWordUpper";
            this.cbWordUpper.Size = new System.Drawing.Size(125, 17);
            this.cbWordUpper.TabIndex = 4;
            this.cbWordUpper.Text = "Palabras mayúsculas";
            this.cbWordUpper.UseVisualStyleBackColor = true;
            // 
            // cbReverse
            // 
            this.cbReverse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbReverse.AutoSize = true;
            this.cbReverse.Location = new System.Drawing.Point(402, 18);
            this.cbReverse.Name = "cbReverse";
            this.cbReverse.Size = new System.Drawing.Size(58, 17);
            this.cbReverse.TabIndex = 5;
            this.cbReverse.Text = "Invertir";
            this.cbReverse.UseVisualStyleBackColor = true;
            // 
            // cbLetterUpper
            // 
            this.cbLetterUpper.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbLetterUpper.AutoSize = true;
            this.cbLetterUpper.Location = new System.Drawing.Point(195, 18);
            this.cbLetterUpper.Name = "cbLetterUpper";
            this.cbLetterUpper.Size = new System.Drawing.Size(113, 17);
            this.cbLetterUpper.TabIndex = 6;
            this.cbLetterUpper.Text = "Letras mayúsculas";
            this.cbLetterUpper.UseVisualStyleBackColor = true;
            // 
            // cbNum
            // 
            this.cbNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNum.AutoSize = true;
            this.cbNum.Checked = true;
            this.cbNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNum.Location = new System.Drawing.Point(587, 18);
            this.cbNum.Name = "cbNum";
            this.cbNum.Size = new System.Drawing.Size(68, 17);
            this.cbNum.TabIndex = 7;
            this.cbNum.Text = "Numeros";
            this.cbNum.UseVisualStyleBackColor = true;
            // 
            // gbModifiers
            // 
            this.gbModifiers.Controls.Add(this.cbWordUpper);
            this.gbModifiers.Controls.Add(this.cbNum);
            this.gbModifiers.Controls.Add(this.cbLetterUpper);
            this.gbModifiers.Controls.Add(this.cbReverse);
            this.gbModifiers.Location = new System.Drawing.Point(12, 383);
            this.gbModifiers.Name = "gbModifiers";
            this.gbModifiers.Size = new System.Drawing.Size(674, 44);
            this.gbModifiers.TabIndex = 8;
            this.gbModifiers.TabStop = false;
            this.gbModifiers.Text = "Alteraciones";
            // 
            // tbxOutput
            // 
            this.tbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxOutput.Location = new System.Drawing.Point(361, 32);
            this.tbxOutput.Multiline = true;
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.ReadOnly = true;
            this.tbxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxOutput.Size = new System.Drawing.Size(347, 341);
            this.tbxOutput.TabIndex = 9;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(9, 14);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(56, 13);
            this.lblInput.TabIndex = 10;
            this.lblInput.Text = "Right Text";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(358, 14);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(49, 13);
            this.lblOutput.TabIndex = 11;
            this.lblOutput.Text = "Left Text";
            // 
            // cmSecret
            // 
            this.cmSecret.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSecret});
            this.cmSecret.Name = "cmSecret";
            this.cmSecret.Size = new System.Drawing.Size(146, 26);
            // 
            // miSecret
            // 
            this.miSecret.Name = "miSecret";
            this.miSecret.Size = new System.Drawing.Size(145, 22);
            this.miSecret.Text = "¿Qué es esto?";
            this.miSecret.Click += new System.EventHandler(this.miSecret_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 480);
            this.ContextMenuStrip = this.cmSecret;
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.tbxOutput);
            this.Controls.Add(this.gbModifiers);
            this.Controls.Add(this.btnClipboard);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDale);
            this.Controls.Add(this.tbxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "MayusculTool";
            this.gbModifiers.ResumeLayout(false);
            this.gbModifiers.PerformLayout();
            this.cmSecret.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.Button btnDale;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClipboard;
        private System.Windows.Forms.CheckBox cbWordUpper;
        private System.Windows.Forms.CheckBox cbReverse;
        private System.Windows.Forms.CheckBox cbLetterUpper;
        private System.Windows.Forms.CheckBox cbNum;
        private System.Windows.Forms.GroupBox gbModifiers;
        private System.Windows.Forms.TextBox tbxOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.ContextMenuStrip cmSecret;
        private System.Windows.Forms.ToolStripMenuItem miSecret;
    }
}

