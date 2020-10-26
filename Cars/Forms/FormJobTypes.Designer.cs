namespace Cars.Forms
{
  partial class FormJobTypes
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
      this.objectListViewJobTypes = new BrightIdeasSoftware.ObjectListView();
      this.panelBottom = new System.Windows.Forms.Panel();
      this.panelTop = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewJobTypes)).BeginInit();
      this.SuspendLayout();
      // 
      // objectListViewJobTypes
      // 
      this.objectListViewJobTypes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewJobTypes.HideSelection = false;
      this.objectListViewJobTypes.Location = new System.Drawing.Point(0, 37);
      this.objectListViewJobTypes.Name = "objectListViewJobTypes";
      this.objectListViewJobTypes.Size = new System.Drawing.Size(800, 370);
      this.objectListViewJobTypes.TabIndex = 8;
      this.objectListViewJobTypes.UseCompatibleStateImageBehavior = false;
      this.objectListViewJobTypes.View = System.Windows.Forms.View.Details;
      // 
      // panelBottom
      // 
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelBottom.Location = new System.Drawing.Point(0, 407);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(800, 43);
      this.panelBottom.TabIndex = 7;
      // 
      // panelTop
      // 
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(800, 37);
      this.panelTop.TabIndex = 6;
      // 
      // FormJobTypes
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.objectListViewJobTypes);
      this.Controls.Add(this.panelBottom);
      this.Controls.Add(this.panelTop);
      this.Name = "FormJobTypes";
      this.Text = "FormJobTypes";
      this.Load += new System.EventHandler(this.FormJobTypes_Load);
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewJobTypes)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView objectListViewJobTypes;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Panel panelTop;
  }
}