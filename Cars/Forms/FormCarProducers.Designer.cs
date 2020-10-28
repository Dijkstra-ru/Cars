namespace Cars.Forms
{
  partial class FormCarProducers
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
      this.objectListViewCarProducers = new BrightIdeasSoftware.ObjectListView();
      this.panelBottom = new System.Windows.Forms.Panel();
      this.buttonUpdate = new System.Windows.Forms.Button();
      this.buttonRemove = new System.Windows.Forms.Button();
      this.buttonCreate = new System.Windows.Forms.Button();
      this.panelTop = new System.Windows.Forms.Panel();
      this.buttonRefresh = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCarProducers)).BeginInit();
      this.panelBottom.SuspendLayout();
      this.panelTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // objectListViewCarProducers
      // 
      this.objectListViewCarProducers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewCarProducers.HideSelection = false;
      this.objectListViewCarProducers.Location = new System.Drawing.Point(0, 37);
      this.objectListViewCarProducers.Name = "objectListViewCarProducers";
      this.objectListViewCarProducers.Size = new System.Drawing.Size(800, 370);
      this.objectListViewCarProducers.TabIndex = 5;
      this.objectListViewCarProducers.UseCompatibleStateImageBehavior = false;
      this.objectListViewCarProducers.View = System.Windows.Forms.View.Details;
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
      this.buttonUpdate.Location = new System.Drawing.Point(643, 6);
      this.buttonUpdate.Name = "buttonUpdate";
      this.buttonUpdate.Size = new System.Drawing.Size(145, 32);
      this.buttonUpdate.TabIndex = 5;
      this.buttonUpdate.Text = "Модифиировать";
      this.buttonUpdate.UseVisualStyleBackColor = true;
      this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
      // 
      // buttonRemove
      // 
      this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonRemove.Location = new System.Drawing.Point(492, 6);
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.Size = new System.Drawing.Size(145, 32);
      this.buttonRemove.TabIndex = 4;
      this.buttonRemove.Text = "Удалить";
      this.buttonRemove.UseVisualStyleBackColor = true;
      this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
      // 
      // buttonCreate
      // 
      this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCreate.Location = new System.Drawing.Point(341, 6);
      this.buttonCreate.Name = "buttonCreate";
      this.buttonCreate.Size = new System.Drawing.Size(145, 32);
      this.buttonCreate.TabIndex = 3;
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
      this.panelTop.Size = new System.Drawing.Size(800, 37);
      this.panelTop.TabIndex = 3;
      // 
      // buttonRefresh
      // 
      this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonRefresh.Location = new System.Drawing.Point(652, 3);
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.Size = new System.Drawing.Size(145, 32);
      this.buttonRefresh.TabIndex = 2;
      this.buttonRefresh.Text = "Обновить";
      this.buttonRefresh.UseVisualStyleBackColor = true;
      this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
      // 
      // FormCarProducers
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.objectListViewCarProducers);
      this.Controls.Add(this.panelBottom);
      this.Controls.Add(this.panelTop);
      this.Name = "FormCarProducers";
      this.Text = "Производители машин";
      this.Load += new System.EventHandler(this.FormCarProducers_Load);
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewCarProducers)).EndInit();
      this.panelBottom.ResumeLayout(false);
      this.panelTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private BrightIdeasSoftware.ObjectListView objectListViewCarProducers;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Button buttonUpdate;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.Button buttonCreate;
    private System.Windows.Forms.Button buttonRefresh;
  }
}