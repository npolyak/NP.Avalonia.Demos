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
            this.SuspendLayout();
            // 
            // MyButton
            // 
            this.MyButton.Location = new System.Drawing.Point(151, 123);
            this.MyButton.Name = "MyButton";
            this.MyButton.Size = new System.Drawing.Size(75, 23);
            this.MyButton.TabIndex = 0;
            this.MyButton.Text = "ClickMe";
            this.MyButton.UseVisualStyleBackColor = true;
            // 
            // MyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MyButton);
            this.Name = "MyControl";
            this.Size = new System.Drawing.Size(369, 283);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MyButton;
    }
}
