namespace SystemOfSales.UI.Reportes
{
    partial class ListadoProductosReviewer
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
            this.ListadoProductosCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ListadoProductosCrystalReportViewer
            // 
            this.ListadoProductosCrystalReportViewer.ActiveViewIndex = -1;
            this.ListadoProductosCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListadoProductosCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListadoProductosCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListadoProductosCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ListadoProductosCrystalReportViewer.Name = "ListadoProductosCrystalReportViewer";
            this.ListadoProductosCrystalReportViewer.Size = new System.Drawing.Size(456, 412);
            this.ListadoProductosCrystalReportViewer.TabIndex = 0;
            this.ListadoProductosCrystalReportViewer.Load += new System.EventHandler(this.ListadoProductosCrystalReportViewer_Load);
            // 
            // ListadoProductosReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 412);
            this.Controls.Add(this.ListadoProductosCrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListadoProductosReviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Productos Reviewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ListadoProductosCrystalReportViewer;
    }
}