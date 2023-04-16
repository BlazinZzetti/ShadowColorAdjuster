namespace ShadowColorAdjuster
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
            this.AccentColorPreview = new System.Windows.Forms.PictureBox();
            this.PreviewPicture = new System.Windows.Forms.PictureBox();
            this.SaveImage = new System.Windows.Forms.Button();
            this.PreviewPicture2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MainColorPreview = new System.Windows.Forms.PictureBox();
            this.PreviewPicture3 = new System.Windows.Forms.PictureBox();
            this.PreviewPicture4 = new System.Windows.Forms.PictureBox();
            this.MainColorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.AccentColorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.PreviewPicture5 = new System.Windows.Forms.PictureBox();
            this.PreviewPicture6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AccentColorPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainColorPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture6)).BeginInit();
            this.SuspendLayout();
            // 
            // AccentColorPreview
            // 
            this.AccentColorPreview.BackColor = System.Drawing.Color.White;
            this.AccentColorPreview.Location = new System.Drawing.Point(12, 172);
            this.AccentColorPreview.Name = "AccentColorPreview";
            this.AccentColorPreview.Size = new System.Drawing.Size(100, 100);
            this.AccentColorPreview.TabIndex = 3;
            this.AccentColorPreview.TabStop = false;
            // 
            // PreviewPicture
            // 
            this.PreviewPicture.Location = new System.Drawing.Point(12, 278);
            this.PreviewPicture.Name = "PreviewPicture";
            this.PreviewPicture.Size = new System.Drawing.Size(100, 100);
            this.PreviewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture.TabIndex = 21;
            this.PreviewPicture.TabStop = false;
            // 
            // SaveImage
            // 
            this.SaveImage.Location = new System.Drawing.Point(12, 384);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(100, 23);
            this.SaveImage.TabIndex = 23;
            this.SaveImage.Text = "Export Textures";
            this.SaveImage.UseVisualStyleBackColor = true;
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // PreviewPicture2
            // 
            this.PreviewPicture2.Location = new System.Drawing.Point(118, 278);
            this.PreviewPicture2.Name = "PreviewPicture2";
            this.PreviewPicture2.Size = new System.Drawing.Size(100, 100);
            this.PreviewPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture2.TabIndex = 24;
            this.PreviewPicture2.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 25;
            this.label7.Text = "Accent Color";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 45;
            this.label8.Text = "Main Color";
            // 
            // MainColorPreview
            // 
            this.MainColorPreview.BackColor = System.Drawing.Color.White;
            this.MainColorPreview.Location = new System.Drawing.Point(12, 43);
            this.MainColorPreview.Name = "MainColorPreview";
            this.MainColorPreview.Size = new System.Drawing.Size(100, 100);
            this.MainColorPreview.TabIndex = 27;
            this.MainColorPreview.TabStop = false;
            // 
            // PreviewPicture3
            // 
            this.PreviewPicture3.Location = new System.Drawing.Point(224, 278);
            this.PreviewPicture3.Name = "PreviewPicture3";
            this.PreviewPicture3.Size = new System.Drawing.Size(100, 100);
            this.PreviewPicture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture3.TabIndex = 46;
            this.PreviewPicture3.TabStop = false;
            // 
            // PreviewPicture4
            // 
            this.PreviewPicture4.Location = new System.Drawing.Point(330, 278);
            this.PreviewPicture4.Name = "PreviewPicture4";
            this.PreviewPicture4.Size = new System.Drawing.Size(100, 100);
            this.PreviewPicture4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture4.TabIndex = 47;
            this.PreviewPicture4.TabStop = false;
            // 
            // MainColorEditor
            // 
            this.MainColorEditor.Location = new System.Drawing.Point(118, 20);
            this.MainColorEditor.Name = "MainColorEditor";
            this.MainColorEditor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.MainColorEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MainColorEditor.ShowAlphaChannel = false;
            this.MainColorEditor.Size = new System.Drawing.Size(480, 123);
            this.MainColorEditor.TabIndex = 48;
            this.MainColorEditor.ColorChanged += new System.EventHandler(this.MainColorEditor_ColorChanged);
            // 
            // AccentColorEditor
            // 
            this.AccentColorEditor.Location = new System.Drawing.Point(118, 149);
            this.AccentColorEditor.Name = "AccentColorEditor";
            this.AccentColorEditor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.AccentColorEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AccentColorEditor.ShowAlphaChannel = false;
            this.AccentColorEditor.Size = new System.Drawing.Size(480, 123);
            this.AccentColorEditor.TabIndex = 49;
            this.AccentColorEditor.ColorChanged += new System.EventHandler(this.AccentColorEditor_ColorChanged);
            // 
            // PreviewPicture5
            // 
            this.PreviewPicture5.Location = new System.Drawing.Point(436, 278);
            this.PreviewPicture5.Name = "PreviewPicture5";
            this.PreviewPicture5.Size = new System.Drawing.Size(100, 100);
            this.PreviewPicture5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture5.TabIndex = 50;
            this.PreviewPicture5.TabStop = false;
            // 
            // PreviewPicture6
            // 
            this.PreviewPicture6.Location = new System.Drawing.Point(542, 278);
            this.PreviewPicture6.Name = "PreviewPicture6";
            this.PreviewPicture6.Size = new System.Drawing.Size(100, 100);
            this.PreviewPicture6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture6.TabIndex = 51;
            this.PreviewPicture6.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 418);
            this.Controls.Add(this.PreviewPicture6);
            this.Controls.Add(this.PreviewPicture5);
            this.Controls.Add(this.AccentColorEditor);
            this.Controls.Add(this.MainColorEditor);
            this.Controls.Add(this.PreviewPicture4);
            this.Controls.Add(this.PreviewPicture3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MainColorPreview);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PreviewPicture2);
            this.Controls.Add(this.SaveImage);
            this.Controls.Add(this.PreviewPicture);
            this.Controls.Add(this.AccentColorPreview);
            this.Name = "Form1";
            this.Text = "ShadowColorAdjuster";
            ((System.ComponentModel.ISupportInitialize)(this.AccentColorPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainColorPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture6)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox PreviewPicture5;
        private System.Windows.Forms.PictureBox PreviewPicture6;

        private Cyotek.Windows.Forms.ColorEditor AccentColorEditor;

        private Cyotek.Windows.Forms.ColorEditor MainColorEditor;

        private System.Windows.Forms.PictureBox PreviewPicture3;
        private System.Windows.Forms.PictureBox PreviewPicture4;

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox MainColorPreview;

        private System.Windows.Forms.PictureBox PreviewPicture2;

        private System.Windows.Forms.Button SaveImage;

        private System.Windows.Forms.PictureBox PreviewPicture;

        private System.Windows.Forms.PictureBox AccentColorPreview;

        #endregion
    }
}