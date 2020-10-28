namespace Cars.ModalForms
{
  partial class FormCreateModifyCar
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
      this.labelProducer = new System.Windows.Forms.Label();
      this.labelPlate = new System.Windows.Forms.Label();
      this.textBoxPlate = new System.Windows.Forms.TextBox();
      this.comboBoxCarModels = new System.Windows.Forms.ComboBox();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOk = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // labelProducer
      // 
      this.labelProducer.AutoSize = true;
      this.labelProducer.Location = new System.Drawing.Point(6, 39);
      this.labelProducer.Name = "labelProducer";
      this.labelProducer.Size = new System.Drawing.Size(86, 13);
      this.labelProducer.TabIndex = 9;
      this.labelProducer.Text = "Производитель";
      // 
      // labelPlate
      // 
      this.labelPlate.AutoSize = true;
      this.labelPlate.Location = new System.Drawing.Point(6, 13);
      this.labelPlate.Name = "labelPlate";
      this.labelPlate.Size = new System.Drawing.Size(63, 13);
      this.labelPlate.TabIndex = 8;
      this.labelPlate.Text = "Гос. номер";
      // 
      // textBoxPlate
      // 
      this.textBoxPlate.Location = new System.Drawing.Point(100, 10);
      this.textBoxPlate.Name = "textBoxPlate";
      this.textBoxPlate.Size = new System.Drawing.Size(121, 20);
      this.textBoxPlate.TabIndex = 7;
      this.textBoxPlate.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
      // 
      // comboBoxCarModels
      // 
      this.comboBoxCarModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxCarModels.FormattingEnabled = true;
      this.comboBoxCarModels.Location = new System.Drawing.Point(100, 36);
      this.comboBoxCarModels.Name = "comboBoxCarModels";
      this.comboBoxCarModels.Size = new System.Drawing.Size(121, 21);
      this.comboBoxCarModels.TabIndex = 6;
      this.comboBoxCarModels.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarModels_SelectedIndexChanged);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(128, 63);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 11;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(29, 63);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 10;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // FormCreateModifyCar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(234, 94);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.labelProducer);
      this.Controls.Add(this.labelPlate);
      this.Controls.Add(this.textBoxPlate);
      this.Controls.Add(this.comboBoxCarModels);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormCreateModifyCar";
      this.Text = "Автомобиль";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelProducer;
    private System.Windows.Forms.Label labelPlate;
    private System.Windows.Forms.TextBox textBoxPlate;
    private System.Windows.Forms.ComboBox comboBoxCarModels;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOk;
  }
}