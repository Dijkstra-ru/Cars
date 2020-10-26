namespace Cars.Forms
{
  partial class FormEngineTypes
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
      this.objectListViewEngineTypes = new BrightIdeasSoftware.ObjectListView();
      this.panelBottom = new System.Windows.Forms.Panel();
      this.panelTop = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewEngineTypes)).BeginInit();
      this.SuspendLayout();
      // 
      // objectListViewEngineTypes
      // 
      this.objectListViewEngineTypes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewEngineTypes.HideSelection = false;
      this.objectListViewEngineTypes.Location = new System.Drawing.Point(0, 37);
      this.objectListViewEngineTypes.Name = "objectListViewEngineTypes";
      this.objectListViewEngineTypes.Size = new System.Drawing.Size(800, 370);
      this.objectListViewEngineTypes.TabIndex = 14;
      this.objectListViewEngineTypes.UseCompatibleStateImageBehavior = false;
      this.objectListViewEngineTypes.View = System.Windows.Forms.View.Details;
      // 
      // panelBottom
      // 
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelBottom.Location = new System.Drawing.Point(0, 407);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(800, 43);
      this.panelBottom.TabIndex = 13;
      // 
      // panelTop
      // 
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(800, 37);
      this.panelTop.TabIndex = 12;
      // 
      // FormEngineTypes
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.objectListViewEngineTypes);
      this.Controls.Add(this.panelBottom);
      this.Controls.Add(this.panelTop);
      this.Name = "FormEngineTypes";
      this.Text = "Виды двигателей";
      this.Load += new System.EventHandler(this.FormEngineTypes_Load);
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewEngineTypes)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView objectListViewEngineTypes;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Panel panelTop;
  }
}