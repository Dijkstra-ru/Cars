namespace Cars.Forms
{
  partial class FormCarModels
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
      this.objectListViewCarModels = new BrightIdeasSoftware.ObjectListView();
      this.panelBottom = new System.Windows.Forms.Panel();
      this.panelTop = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCarModels)).BeginInit();
      this.SuspendLayout();
      // 
      // objectListViewCarModels
      // 
      this.objectListViewCarModels.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewCarModels.HideSelection = false;
      this.objectListViewCarModels.Location = new System.Drawing.Point(0, 37);
      this.objectListViewCarModels.Name = "objectListViewCarModels";
      this.objectListViewCarModels.Size = new System.Drawing.Size(800, 370);
      this.objectListViewCarModels.TabIndex = 5;
      this.objectListViewCarModels.UseCompatibleStateImageBehavior = false;
      this.objectListViewCarModels.View = System.Windows.Forms.View.Details;
      // 
      // panelBottom
      // 
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelBottom.Location = new System.Drawing.Point(0, 407);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(800, 43);
      this.panelBottom.TabIndex = 4;
      // 
      // panelTop
      // 
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(800, 37);
      this.panelTop.TabIndex = 3;
      // 
      // FormCarModels
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.objectListViewCarModels);
      this.Controls.Add(this.panelBottom);
      this.Controls.Add(this.panelTop);
      this.Name = "FormCarModels";
      this.Text = "Модели машин";
      this.Load += new System.EventHandler(this.FormCarModels_Load);
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCarModels)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView objectListViewCarModels;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Panel panelTop;
  }
}