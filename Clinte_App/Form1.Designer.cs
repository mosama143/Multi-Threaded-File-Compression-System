using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client_App
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Label lblTitle;
        private Button btnSelect;
        private Button btnCompress;
        private Label lblFile;
        private Label lblSize;
        private Label lblStatus;
        private ProgressBar progressBar1;
        private Panel cardPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            btnSelect = new Button();
            btnCompress = new Button();
            lblFile = new Label();
            lblSize = new Label();
            lblStatus = new Label();
            progressBar1 = new ProgressBar();
            cardPanel = new Panel();

            panelTop.SuspendLayout();
            SuspendLayout();

            // ====================================
            // FORM
            // ====================================

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.FromArgb(245, 247, 250);

            ClientSize = new Size(900, 620);

            Font = new Font("Segoe UI", 9F);

            FormBorderStyle = FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            StartPosition = FormStartPosition.CenterScreen;

            Text = "Compression Client";

            // ====================================
            // TOP PANEL
            // ====================================

            panelTop.BackColor = Color.White;

            panelTop.Dock = DockStyle.Top;

            panelTop.Height = 90;

            panelTop.BorderStyle = BorderStyle.FixedSingle;

            panelTop.Controls.Add(lblTitle);

            // ====================================
            // TITLE
            // ====================================

            lblTitle.AutoSize = true;

            lblTitle.Font = new Font(
                "Segoe UI",
                22F,
                FontStyle.Bold);

            lblTitle.ForeColor =
                Color.FromArgb(0, 120, 215);

            lblTitle.Location = new Point(170, 22);

            lblTitle.Text =
                "FILE COMPRESSION CLIENT";

            // ====================================
            // CARD PANEL
            // ====================================

            cardPanel.BackColor = Color.White;

            cardPanel.Location = new Point(120, 130);

            cardPanel.Size = new Size(650, 400);

            cardPanel.BorderStyle = BorderStyle.FixedSingle;

            // ====================================
            // SELECT BUTTON
            // ====================================

            btnSelect.BackColor =
                Color.FromArgb(0, 120, 215);

            btnSelect.FlatStyle =
                FlatStyle.Flat;

            btnSelect.FlatAppearance.BorderSize = 0;

            btnSelect.ForeColor = Color.White;

            btnSelect.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            btnSelect.Cursor = Cursors.Hand;

            btnSelect.Size =
                new Size(220, 55);

            btnSelect.Location =
                new Point(210, 40);

            btnSelect.Text =
                "SELECT FILE";

            btnSelect.Click += btnSelect_Click;

            btnSelect.MouseEnter += (s, e) =>
            {
                btnSelect.BackColor =
                    Color.DodgerBlue;
            };

            btnSelect.MouseLeave += (s, e) =>
            {
                btnSelect.BackColor =
                    Color.FromArgb(0, 120, 215);
            };

            // ====================================
            // FILE LABEL
            // ====================================

            lblFile.ForeColor =
                Color.FromArgb(50, 50, 50);

            lblFile.Font =
                new Font("Segoe UI", 11F);

            lblFile.Location =
                new Point(60, 130);

            lblFile.Size =
                new Size(530, 35);

            lblFile.Text =
                "Selected File : None";

            // ====================================
            // SIZE LABEL
            // ====================================

            lblSize.ForeColor =
                Color.Gray;

            lblSize.Font =
                new Font("Segoe UI", 10F);

            lblSize.Location =
                new Point(60, 180);

            lblSize.Size =
                new Size(400, 30);

            lblSize.Text =
                "Original Size : 0 KB";

            // ====================================
            // COMPRESS BUTTON
            // ====================================

            btnCompress.BackColor =
                Color.MediumSeaGreen;

            btnCompress.FlatStyle =
                FlatStyle.Flat;

            btnCompress.FlatAppearance.BorderSize = 0;

            btnCompress.ForeColor = Color.White;

            btnCompress.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            btnCompress.Cursor = Cursors.Hand;

            btnCompress.Size =
                new Size(220, 55);

            btnCompress.Location =
                new Point(210, 240);

            btnCompress.Text =
                "COMPRESS & SEND";

            btnCompress.Click += btnCompress_Click;

            btnCompress.MouseEnter += (s, e) =>
            {
                btnCompress.BackColor =
                    Color.SeaGreen;
            };

            btnCompress.MouseLeave += (s, e) =>
            {
                btnCompress.BackColor =
                    Color.MediumSeaGreen;
            };

            // ====================================
            // PROGRESS BAR
            // ====================================

            progressBar1.Location =
                new Point(70, 330);

            progressBar1.Size =
                new Size(500, 30);

            progressBar1.Style =
                ProgressBarStyle.Continuous;

            // ====================================
            // STATUS
            // ====================================

            lblStatus.ForeColor =
                Color.FromArgb(0, 120, 215);

            lblStatus.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblStatus.Location =
                new Point(200, 370);

            lblStatus.Size =
                new Size(300, 40);

            lblStatus.Text =
                "Status : Waiting...";

            // ====================================
            // ADD CONTROLS
            // ====================================

            cardPanel.Controls.Add(btnSelect);
            cardPanel.Controls.Add(lblFile);
            cardPanel.Controls.Add(lblSize);
            cardPanel.Controls.Add(btnCompress);
            cardPanel.Controls.Add(progressBar1);
            cardPanel.Controls.Add(lblStatus);

            Controls.Add(panelTop);
            Controls.Add(cardPanel);

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();

            ResumeLayout(false);
        }
    }
}