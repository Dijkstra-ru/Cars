namespace Cars.ModalForms
{
  partial class FormCreateModifyCarModel
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
      this.comboBoxCarProducers = new System.Windows.Forms.ComboBox();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.comboBoxEngines = new System.Windows.Forms.ComboBox();
      this.labelName = new System.Windows.Forms.Label();
      this.labelProducer = new System.Windows.Forms.Label();
      this.labelEngine = new System.Windows.Forms.Label();
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // comboBoxCarProducers
      // 
      this.comboBoxCarProducers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxCarProducers.FormattingEnabled = true;
      this.comboBoxCarProducers.Location = new System.Drawing.Point(111, 38);
      this.comboBoxCarProducers.Name = "comboBoxCarProducers";
      this.comboBoxCarProducers.Size = new System.Drawing.Size(121, 21);
      this.comboBoxCarProducers.TabIndex = 1;
      this.comboBoxCarProducers.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarProducers_SelectedIndexChanged);
      // 
      // textBoxName
      // 
      this.textBoxName.Location = new System.Drawing.Point(111, 12);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(121, 20);
      this.textBoxName.TabIndex = 2;
      this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
      // 
      // comboBoxEngines
      // 
      this.comboBoxEngines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxEngines.FormattingEnabled = true;
      this.comboBoxEngines.Location = new System.Drawing.Point(111, 65);
      this.comboBoxEngines.Name = "comboBoxEngines";
      this.comboBoxEngines.Size = new System.Drawing.Size(121, 21);
      this.comboBoxEngines.TabIndex = 3;
      this.comboBoxEngines.SelectedIndexChanged += new System.EventHandler(this.comboBoxEngines_SelectedIndexChanged);
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Location = new System.Drawing.Point(17, 15);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(57, 13);
      this.labelName.TabIndex = 4;
      this.labelName.Text = "Название";
      // 
      // labelProducer
      // 
      this.labelProducer.AutoSize = true;
      this.labelProducer.Location = new System.Drawing.Point(17, 41);
      this.labelProducer.Name = "labelProducer";
      this.labelProducer.Size = new System.Drawing.Size(86, 13);
      this.labelProducer.TabIndex = 5;
      this.labelProducer.Text = "Производитель";
      // 
      // labelEngine
      // 
      this.labelEngine.AutoSize = true;
      this.labelEngine.Location = new System.Drawing.Point(17, 68);
      this.labelEngine.Name = "labelEngine";
      this.labelEngine.Size = new System.Drawing.Size(81, 13);
      this.labelEngine.TabIndex = 6;
      this.labelEngine.Text = "Тип двигателя";
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(38, 96);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 7;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(137, 96);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 8;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // FormCreateModifyCarModel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(258, 131);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.labelEngine);
      this.Controls.Add(this.labelProducer);
      this.Controls.Add(this.labelName);
      this.Controls.Add(this.comboBoxEngines);
      this.Controls.Add(this.textBoxName);
      this.Controls.Add(this.comboBoxCarProducers);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormCreateModifyCarModel";
      this.Text = "Модель машины";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBoxCarProducers;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.ComboBox comboBoxEngines;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelProducer;
    private System.Windows.Forms.Label labelEngine;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
  }
}