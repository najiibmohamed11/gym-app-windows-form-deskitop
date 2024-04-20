
namespace gym_navigator
{
    partial class frmnetincom
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
            this.GYMDataSet4 = new gym_navigator.GYMDataSet4();
            this.reveniuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reveniuTableAdapter = new gym_navigator.GYMDataSet4TableAdapters.reveniuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GYMDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reveniuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reveniuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "gym_navigator.netincomrepo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1241, 698);
            this.reportViewer1.TabIndex = 0;
            // 
            // GYMDataSet4
            // 
            this.GYMDataSet4.DataSetName = "GYMDataSet4";
            this.GYMDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reveniuBindingSource
            // 
            this.reveniuBindingSource.DataMember = "reveniu";
            this.reveniuBindingSource.DataSource = this.GYMDataSet4;
            // 
            // reveniuTableAdapter
            // 
            this.reveniuTableAdapter.ClearBeforeFill = true;
            // 
            // frmnetincom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 698);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmnetincom";
            this.Text = "frmnetincom";
            this.Load += new System.EventHandler(this.frmnetincom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GYMDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reveniuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reveniuBindingSource;
        private GYMDataSet4 GYMDataSet4;
        private GYMDataSet4TableAdapters.reveniuTableAdapter reveniuTableAdapter;
    }
}