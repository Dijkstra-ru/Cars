namespace Cars.ModalForms
{
  partial class FormCreateModifyJob
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
      this.comboBoxJobType = new System.Windows.Forms.ComboBox();
      this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.labelDate = new System.Windows.Forms.Label();
      this.labelCar = new System.Windows.Forms.Label();
      this.comboBoxCar = new System.Windows.Forms.ComboBox();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOk = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // labelProducer
      // 
      this.labelProducer.AutoSize = true;
      this.labelProducer.Location = new System.Drawing.Point(11, 42);
      this.labelProducer.Name = "labelProducer";
      this.labelProducer.Size = new System.Drawing.Size(66, 13);
      this.labelProducer.TabIndex = 7;
      this.labelProducer.Text = "Вид работы";
      // 
      // comboBoxJobType
      // 
      this.comboBoxJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxJobType.FormattingEnabled = true;
      this.comboBoxJobType.Location = new System.Drawing.Point(117, 39);
      this.comboBoxJobType.Name = "comboBoxJobType";
      this.comboBoxJobType.Size = new System.Drawing.Size(232, 21);
      this.comboBoxJobType.TabIndex = 6;
      this.comboBoxJobType.SelectedIndexChanged += new System.EventHandler(this.comboBoxJobType_SelectedIndexChanged);
      // 
      // dateTimePicker
      // 
      this.dateTimePicker.Location = new System.Drawing.Point(117, 69);
      this.dateTimePicker.Name = "dateTimePicker";
      this.dateTimePicker.Size = new System.Drawing.Size(232, 20);
      this.dateTimePicker.TabIndex = 8;
      this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
      // 
      // labelDate
      // 
      this.labelDate.AutoSize = true;
      this.labelDate.Location = new System.Drawing.Point(11, 69);
      this.labelDate.Name = "labelDate";
      this.labelDate.Size = new System.Drawing.Size(96, 13);
      this.labelDate.TabIndex = 9;
      this.labelDate.Text = "Дата проведения";
      // 
      // labelCar
      // 
      this.labelCar.AutoSize = true;
      this.labelCar.Location = new System.Drawing.Point(11, 13);
      this.labelCar.Name = "labelCar";
      this.labelCar.Size = new System.Drawing.Size(69, 13);
      this.labelCar.TabIndex = 11;
      this.labelCar.Text = "Автомобиль";
      // 
      // comboBoxCar
      // 
      this.comboBoxCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxCar.FormattingEnabled = true;
      this.comboBoxCar.Location = new System.Drawing.Point(117, 10);
      this.comboBoxCar.Name = "comboBoxCar";
      this.comboBoxCar.Size = new System.Drawing.Size(232, 21);
      this.comboBoxCar.TabIndex = 10;
      this.comboBoxCar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCar_SelectedIndexChanged);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Location = new System.Drawing.Point(202, 95);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 16;
      this.buttonCancel.Text = "Отмена";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(103, 95);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 15;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // FormCreateModifyJob
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(393, 128);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.labelCar);
      this.Controls.Add(this.comboBoxCar);
      this.Controls.Add(this.labelDate);
      this.Controls.Add(this.dateTimePicker);
      this.Controls.Add(this.labelProducer);
      this.Controls.Add(this.comboBoxJobType);
      this.Name = "FormCreateModifyJob";
      this.Text = "Работа";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelProducer;
    private System.Windows.Forms.ComboBox comboBoxJobType;
    private System.Windows.Forms.DateTimePicker dateTimePicker;
    private System.Windows.Forms.Label labelDate;
    private System.Windows.Forms.Label labelCar;
    private System.Windows.Forms.ComboBox comboBoxCar;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOk;
  }
}