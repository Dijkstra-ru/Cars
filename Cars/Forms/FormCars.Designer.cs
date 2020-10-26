namespace Cars.Forms
{
  partial class FormCars
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
      this.panelTop = new System.Windows.Forms.Panel();
      this.panelBottom = new System.Windows.Forms.Panel();
      this.objectListViewCars = new BrightIdeasSoftware.ObjectListView();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCars)).BeginInit();
      this.SuspendLayout();
      // 
      // panelTop
      // 
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(800, 37);
      this.panelTop.TabIndex = 0;
      // 
      // panelBottom
      // 
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelBottom.Location = new System.Drawing.Point(0, 407);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(800, 43);
      this.panelBottom.TabIndex = 1;
      // 
      // objectListViewCars
      // 
      this.objectListViewCars.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewCars.HideSelection = false;
      this.objectListViewCars.Location = new System.Drawing.Point(0, 37);
      this.objectListViewCars.Name = "objectListViewCars";
      this.objectListViewCars.Size = new System.Drawing.Size(800, 370);
      this.objectListViewCars.TabIndex = 2;
      this.objectListViewCars.UseCompatibleStateImageBehavior = false;
      this.objectListViewCars.View = System.Windows.Forms.View.Details;
      // 
      // FormCars
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.objectListViewCars);
      this.Controls.Add(this.panelBottom);
      this.Controls.Add(this.panelTop);
      this.Name = "FormCars";
      this.Text = "Парк машин";
      this.Load += new System.EventHandler(this.FormCars_Load);
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCars)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Panel panelBottom;
    private BrightIdeasSoftware.ObjectListView objectListViewCars;
  }
}