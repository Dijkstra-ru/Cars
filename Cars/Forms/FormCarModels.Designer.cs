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
      this.buttonUpdate = new System.Windows.Forms.Button();
      this.buttonRemove = new System.Windows.Forms.Button();
      this.buttonCreate = new System.Windows.Forms.Button();
      this.panelTop = new System.Windows.Forms.Panel();
      this.buttonRefresh = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCarModels)).BeginInit();
      this.panelBottom.SuspendLayout();
      this.panelTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // objectListViewCarModels
      // 
      this.objectListViewCarModels.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewCarModels.HideSelection = false;
      this.objectListViewCarModels.Location = new System.Drawing.Point(0, 42);
      this.objectListViewCarModels.Name = "objectListViewCarModels";
      this.objectListViewCarModels.Size = new System.Drawing.Size(800, 365);
      this.objectListViewCarModels.TabIndex = 5;
      this.objectListViewCarModels.UseCompatibleStateImageBehavior = false;
      this.objectListViewCarModels.View = System.Windows.Forms.View.Details;
      // 
      // panelBottom
      // 
      this.panelBottom.Controls.Add(this.buttonUpdate);
      this.panelBottom.Controls.Add(this.buttonRemove);
      this.panelBottom.Controls.Add(this.buttonCreate);
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelBottom.Location = new System.Drawing.Point(0, 407);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(800, 43);
      this.panelBottom.TabIndex = 4;
      // 
      // buttonUpdate
      // 
      this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonUpdate.Location = new System.Drawing.Point(652, 6);
      this.buttonUpdate.Name = "buttonUpdate";
      this.buttonUpdate.Size = new System.Drawing.Size(145, 32);
      this.buttonUpdate.TabIndex = 2;
      this.buttonUpdate.Text = "Модифиировать";
      this.buttonUpdate.UseVisualStyleBackColor = true;
      this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
      // 
      // buttonRemove
      // 
      this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonRemove.Location = new System.Drawing.Point(501, 6);
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.Size = new System.Drawing.Size(145, 32);
      this.buttonRemove.TabIndex = 1;
      this.buttonRemove.Text = "Удалить";
      this.buttonRemove.UseVisualStyleBackColor = true;
      this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
      // 
      // buttonCreate
      // 
      this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCreate.Location = new System.Drawing.Point(350, 6);
      this.buttonCreate.Name = "buttonCreate";
      this.buttonCreate.Size = new System.Drawing.Size(145, 32);
      this.buttonCreate.TabIndex = 0;
      this.buttonCreate.Text = "Создать";
      this.buttonCreate.UseVisualStyleBackColor = true;
      this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.buttonRefresh);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(800, 42);
      this.panelTop.TabIndex = 3;
      // 
      // buttonRefresh
      // 
      this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonRefresh.Location = new System.Drawing.Point(643, 3);
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.Size = new System.Drawing.Size(145, 32);
      this.buttonRefresh.TabIndex = 1;
      this.buttonRefresh.Text = "Обновить";
      this.buttonRefresh.UseVisualStyleBackColor = true;
      this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
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
      this.panelBottom.ResumeLayout(false);
      this.panelTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView objectListViewCarModels;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Button buttonUpdate;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.Button buttonCreate;
    private System.Windows.Forms.Button buttonRefresh;
  }
}