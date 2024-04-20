
namespace gym_navigator
{
    partial class coachreport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GYMDataSet1 = new gym_navigator.GYMDataSet1();
            this.CoachesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CoachesTableAdapter = new gym_navigator.GYMDataSet1TableAdapters.CoachesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GYMDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CoachesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "gym_navigator.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // GYMDataSet1
            // 
            this.GYMDataSet1.DataSetName = "GYMDataSet1";
            this.GYMDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CoachesBindingSource
            // 
            this.CoachesBindingSource.DataMember = "Coaches";
            this.CoachesBindingSource.DataSource = this.GYMDataSet1;
            // 
            // CoachesTableAdapter
            // 
            this.CoachesTableAdapter.ClearBeforeFill = true;
            // 
            // coachreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "coachreport";
            this.Text = "coachreport";
            this.Load += new System.EventHandler(this.coachreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GYMDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CoachesBindingSource;
        private GYMDataSet1 GYMDataSet1;
        private GYMDataSet1TableAdapters.CoachesTableAdapter CoachesTableAdapter;
    }
}