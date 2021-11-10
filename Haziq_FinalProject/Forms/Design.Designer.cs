
namespace Haziq_FinalProject
{
    partial class Design
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Design));
            this.panelSushi = new System.Windows.Forms.Panel();
            this.pictureBoxSushi = new System.Windows.Forms.PictureBox();
            this.labelSushiName = new System.Windows.Forms.Label();
            this.labelSushiPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSushi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSushi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSushi
            // 
            this.panelSushi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelSushi.Controls.Add(this.button1);
            this.panelSushi.Controls.Add(this.labelSushiPrice);
            this.panelSushi.Controls.Add(this.labelSushiName);
            this.panelSushi.Controls.Add(this.pictureBoxSushi);
            this.panelSushi.Location = new System.Drawing.Point(61, 31);
            this.panelSushi.Name = "panelSushi";
            this.panelSushi.Size = new System.Drawing.Size(192, 179);
            this.panelSushi.TabIndex = 0;
            // 
            // pictureBoxSushi
            // 
            this.pictureBoxSushi.Image = global::Haziq_FinalProject.Properties.Resources.Sushi_19;
            this.pictureBoxSushi.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxSushi.Name = "pictureBoxSushi";
            this.pictureBoxSushi.Size = new System.Drawing.Size(132, 129);
            this.pictureBoxSushi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSushi.TabIndex = 0;
            this.pictureBoxSushi.TabStop = false;
            this.pictureBoxSushi.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelSushiName
            // 
            this.labelSushiName.AutoSize = true;
            this.labelSushiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSushiName.Location = new System.Drawing.Point(3, 139);
            this.labelSushiName.Name = "labelSushiName";
            this.labelSushiName.Size = new System.Drawing.Size(109, 16);
            this.labelSushiName.TabIndex = 2;
            this.labelSushiName.Text = "Grilled Salmon";
            // 
            // labelSushiPrice
            // 
            this.labelSushiPrice.AutoSize = true;
            this.labelSushiPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSushiPrice.ForeColor = System.Drawing.Color.Red;
            this.labelSushiPrice.Location = new System.Drawing.Point(4, 158);
            this.labelSushiPrice.Name = "labelSushiPrice";
            this.labelSushiPrice.Size = new System.Drawing.Size(43, 16);
            this.labelSushiPrice.TabIndex = 3;
            this.labelSushiPrice.Text = "Price";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(137, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 46);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelSushi);
            this.Name = "Design";
            this.Text = "Design";
            this.panelSushi.ResumeLayout(false);
            this.panelSushi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSushi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSushi;
        private System.Windows.Forms.PictureBox pictureBoxSushi;
        private System.Windows.Forms.Label labelSushiName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelSushiPrice;
    }
}