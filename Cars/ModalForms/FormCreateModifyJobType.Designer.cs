namespace Cars.ModalForms
{
  partial class FormCreateModifyJobType
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
      this.objectListViewEngineTypes = new BrightIdeasSoftware.ObjectListView();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.labelName = new System.Windows.Forms.Label();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOk = new System.Windows.Forms.Button();
      this.panelTop.SuspendLayout();
      this.panelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewEngineTypes)).BeginInit();
      this.SuspendLayout();
      // 
      // panelTop
      // 
      this.panelTop.Controls.Add(this.textBoxName);
      this.panelTop.Controls.Add(this.labelName);
      this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelTop.Location = new System.Drawing.Point(0, 0);
      this.panelTop.Name = "panelTop";
      this.panelTop.Size = new System.Drawing.Size(329, 47);
      this.panelTop.TabIndex = 0;
      // 
      // panelBottom
      // 
      this.panelBottom.Controls.Add(this.buttonCancel);
      this.panelBottom.Controls.Add(this.buttonOk);
      this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelBottom.Location = new System.Drawing.Point(0, 408);
      this.panelBottom.Name = "panelBottom";
      this.panelBottom.Size = new System.Drawing.Size(329, 40);
      this.panelBottom.TabIndex = 1;
      // 
      // objectListViewEngineTypes
      // 
      this.objectListViewEngineTypes.CheckBoxes = true;
      this.objectListViewEngineTypes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListViewEngineTypes.HideSelection = false;
      this.objectListViewEngineTypes.Location = new System.Drawing.Point(0, 47);
      this.objectListViewEngineTypes.Name = "objectListViewEngineTypes";
      this.objectListViewEngineTypes.Size = new System.Drawing.Size(329, 361);
      this.objectListViewEngineTypes.TabIndex = 2;
      this.objectListViewEngineTypes.UseCompatibleStateImageBehavior = false;
      this.objectListViewEngineTypes.View = System.Windows.Forms.View.Details;
      this.objectListViewEngineTypes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.objectListViewEngineTypes_ItemChecked);
      // 
      // textBoxName
      // 
      this.textBoxName.Location = new System.Drawing.Point(74, 12);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(243, 20);
      this.textBoxName.TabIndex = 14;
      this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Location = new System.Drawing.Point(11, 15);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(57, 13);
      this.labelName.TabIndex = 13;
      this.labelName.Text = "Название";
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(172, 6);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 18;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(73, 6);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 17;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // FormCreateModifyJobType
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(329, 448);
      this.Controls.Add(this.objectListViewEngineTypes);
      this.Controls.Add(this.panelBottom);
      this.Controls.Add(this.panelTop);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormCreateModifyJobType";
      this.Text = "Вид работ";
      this.Load += new System.EventHandler(this.FormCreateModifyJobType_Load);
      this.panelTop.ResumeLayout(false);
      this.panelTop.PerformLayout();
      this.panelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.objectListViewEngineTypes)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panelTop;
    private System.Windows.Forms.Panel panelBottom;
    private BrightIdeasSoftware.ObjectListView objectListViewEngineTypes;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOk;
  }
}