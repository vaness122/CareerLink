namespace CareerLinkPort.Wins
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            pictureBox1 = new PictureBox();
            ApplyFirstPage = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-4, -7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(789, 463);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ApplyFirstPage
            // 
            ApplyFirstPage.BackColor = SystemColors.ButtonHighlight;
            ApplyFirstPage.BackgroundImageLayout = ImageLayout.None;
            ApplyFirstPage.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ApplyFirstPage.ForeColor = Color.DarkOliveGreen;
            ApplyFirstPage.Location = new Point(260, 338);
            ApplyFirstPage.Name = "ApplyFirstPage";
            ApplyFirstPage.Size = new Size(240, 47);
            ApplyFirstPage.TabIndex = 1;
            ApplyFirstPage.Text = "Search Job Openings";
            ApplyFirstPage.UseVisualStyleBackColor = false;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 455);
            Controls.Add(ApplyFirstPage);
            Controls.Add(pictureBox1);
            Name = "HomePage";
            Text = "HomePage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button ApplyFirstPage;
    }
}