namespace Cars.ModalForms
{
  partial class FormCreateModifyEngineType
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
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOk = new System.Windows.Forms.Button();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.labelName = new System.Windows.Forms.Label();
      this.colorDialog = new System.Windows.Forms.ColorDialog();
      this.labelColor = new System.Windows.Forms.Label();
      this.buttonColor = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(111, 68);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 14;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(12, 68);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 13;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // textBoxName
      // 
      this.textBoxName.Location = new System.Drawing.Point(75, 6);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(111, 20);
      this.textBoxName.TabIndex = 12;
      this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Location = new System.Drawing.Point(12, 9);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(57, 13);
      this.labelName.TabIndex = 11;
      this.labelName.Text = "Название";
      // 
      // labelColor
      // 
      this.labelColor.AutoSize = true;
      this.labelColor.Location = new System.Drawing.Point(12, 38);
      this.labelColor.Name = "labelColor";
      this.labelColor.Size = new System.Drawing.Size(32, 13);
      this.labelColor.TabIndex = 15;
      this.labelColor.Text = "Цвет";
      // 
      // buttonColor
      // 
      this.buttonColor.Location = new System.Drawing.Point(75, 32);
      this.buttonColor.Name = "buttonColor";
      this.buttonColor.Size = new System.Drawing.Size(75, 24);
      this.buttonColor.TabIndex = 16;
      this.buttonColor.Text = "...";
      this.buttonColor.UseVisualStyleBackColor = true;
      this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
      // 
      // FormCreateModifyEngineType
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(212, 103);
      this.Controls.Add(this.buttonColor);
      this.Controls.Add(this.labelColor);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.textBoxName);
      this.Controls.Add(this.labelName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormCreateModifyEngineType";
      this.Text = "FormCreateModifyEngineType";
      this.Load += new System.EventHandler(this.FormCreateModifyEngineType_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.ColorDialog colorDialog;
    private System.Windows.Forms.Label labelColor;
    private System.Windows.Forms.Button buttonColor;
  }
}