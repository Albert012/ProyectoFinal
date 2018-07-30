namespace SystemOfSales.UI.Reportes
{
    partial class ListadoUsuariosReviewer
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
            this.ListadoUsuariosCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ListadoUsuariosCrystalReportViewer
            // 
            this.ListadoUsuariosCrystalReportViewer.ActiveViewIndex = -1;
            this.ListadoUsuariosCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListadoUsuariosCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListadoUsuariosCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListadoUsuariosCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ListadoUsuariosCrystalReportViewer.Name = "ListadoUsuariosCrystalReportViewer";
            this.ListadoUsuariosCrystalReportViewer.Size = new System.Drawing.Size(407, 399);
            this.ListadoUsuariosCrystalReportViewer.TabIndex = 0;
            this.ListadoUsuariosCrystalReportViewer.Load += new System.EventHandler(this.ListadoUsuariosCrystalReportViewer_Load);
            // 
            // ListadoUsuariosReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 399);
            this.Controls.Add(this.ListadoUsuariosCrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListadoUsuariosReviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Usuarios Reviewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ListadoUsuariosCrystalReportViewer;
    }
}