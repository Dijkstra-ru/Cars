namespace Cars
{
  partial class FormMain
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.машиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.маркиМашинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.производителиМашинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.видыРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.работыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.типыДвигателейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.машиныToolStripMenuItem,
            this.маркиМашинToolStripMenuItem,
            this.производителиМашинToolStripMenuItem,
            this.видыРаботToolStripMenuItem,
            this.работыToolStripMenuItem,
            this.типыДвигателейToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // машиныToolStripMenuItem
      // 
      this.машиныToolStripMenuItem.Name = "машиныToolStripMenuItem";
      this.машиныToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
      this.машиныToolStripMenuItem.Text = "Машины";
      this.машиныToolStripMenuItem.Click += new System.EventHandler(this.машиныToolStripMenuItem_Click);
      // 
      // маркиМашинToolStripMenuItem
      // 
      this.маркиМашинToolStripMenuItem.Name = "маркиМашинToolStripMenuItem";
      this.маркиМашинToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
      this.маркиМашинToolStripMenuItem.Text = "Марки машин";
      this.маркиМашинToolStripMenuItem.Click += new System.EventHandler(this.маркиМашинToolStripMenuItem_Click);
      // 
      // производителиМашинToolStripMenuItem
      // 
      this.производителиМашинToolStripMenuItem.Name = "производителиМашинToolStripMenuItem";
      this.производителиМашинToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
      this.производителиМашинToolStripMenuItem.Text = "Производители машин";
      this.производителиМашинToolStripMenuItem.Click += new System.EventHandler(this.производителиМашинToolStripMenuItem_Click);
      // 
      // видыРаботToolStripMenuItem
      // 
      this.видыРаботToolStripMenuItem.Name = "видыРаботToolStripMenuItem";
      this.видыРаботToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
      this.видыРаботToolStripMenuItem.Text = "Виды работ";
      this.видыРаботToolStripMenuItem.Click += new System.EventHandler(this.видыРаботToolStripMenuItem_Click);
      // 
      // работыToolStripMenuItem
      // 
      this.работыToolStripMenuItem.Name = "работыToolStripMenuItem";
      this.работыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
      this.работыToolStripMenuItem.Text = "Работы";
      this.работыToolStripMenuItem.Click += new System.EventHandler(this.работыToolStripMenuItem_Click);
      // 
      // типыДвигателейToolStripMenuItem
      // 
      this.типыДвигателейToolStripMenuItem.Name = "типыДвигателейToolStripMenuItem";
      this.типыДвигателейToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
      this.типыДвигателейToolStripMenuItem.Text = "Типы двигателей";
      this.типыДвигателейToolStripMenuItem.Click += new System.EventHandler(this.типыДвигателейToolStripMenuItem_Click);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FormMain";
      this.Text = "Тестовое задание \"Автопарк\"";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem машиныToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem маркиМашинToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem производителиМашинToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem видыРаботToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem работыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem типыДвигателейToolStripMenuItem;
  }
}

