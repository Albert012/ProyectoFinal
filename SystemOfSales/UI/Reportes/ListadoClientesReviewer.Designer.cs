namespace SystemOfSales.UI.Reportes
{
    partial class ListadoClientesReviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoClientesReviewer));
            this.ListadoClientesCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ListadoClientesCrystalReportViewer
            // 
            this.ListadoClientesCrystalReportViewer.ActiveViewIndex = -1;
            this.ListadoClientesCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListadoClientesCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListadoClientesCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListadoClientesCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ListadoClientesCrystalReportViewer.Name = "ListadoClientesCrystalReportViewer";
            this.ListadoClientesCrystalReportViewer.Size = new System.Drawing.Size(463, 484);
            this.ListadoClientesCrystalReportViewer.TabIndex = 0;
            this.ListadoClientesCrystalReportViewer.Load += new System.EventHandler(this.ListadoClientesCrystalReportViewer_Load);
            // 
            // ListadoClientesReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 484);
            this.Controls.Add(this.ListadoClientesCrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoClientesReviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Clientes Reviewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ListadoClientesCrystalReportViewer;
    }
}