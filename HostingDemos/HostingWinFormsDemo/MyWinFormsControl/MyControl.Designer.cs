namespace MyWinFormsControl
{
    partial class MyControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyButton = new System.Windows.Forms.Button();
            this.ClickCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MyButton
            // 
            this.MyButton.Location = new System.Drawing.Point(176, 142);
            this.MyButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MyButton.Name = "MyButton";
            this.MyButton.Size = new System.Drawing.Size(88, 27);
            this.MyButton.TabIndex = 0;
            this.MyButton.Text = "ClickMe";
            this.MyButton.UseVisualStyleBackColor = true;
            // 
            // ClickCounter
            // 
            this.ClickCounter.AutoSize = true;
            this.ClickCounter.Location = new System.Drawing.Point(176, 112);
            this.ClickCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClickCounter.Name = "ClickCounter";
            this.ClickCounter.Size = new System.Drawing.Size(0, 15);
            this.ClickCounter.TabIndex = 1;
            // 
            // MyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClickCounter);
            this.Controls.Add(this.MyButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MyControl";
            this.Size = new System.Drawing.Size(430, 327);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MyButton;
        private System.Windows.Forms.Label ClickCounter;
    }
}
