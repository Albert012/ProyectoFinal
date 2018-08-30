namespace SystemOfSales.UI.Reportes
{
    partial class ReciboReviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciboReviewer));
            this.ReciboCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReciboCrystalReportViewer
            // 
            this.ReciboCrystalReportViewer.ActiveViewIndex = -1;
            this.ReciboCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReciboCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReciboCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReciboCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReciboCrystalReportViewer.Name = "ReciboCrystalReportViewer";
            this.ReciboCrystalReportViewer.Size = new System.Drawing.Size(577, 424);
            this.ReciboCrystalReportViewer.TabIndex = 0;
            this.ReciboCrystalReportViewer.Load += new System.EventHandler(this.ReciboCrystalReportViewer_Load);
            // 
            // ReciboReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 424);
            this.Controls.Add(this.ReciboCrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReciboReviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReciboReviewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReciboCrystalReportViewer;
    }
}