using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars.ModalForms {
  public partial class FormCreateModifyEngineType : Form {
    public Color SelectedColor { get; set; }
    public string EngineTypeName { get; set; }

    public FormCreateModifyEngineType(string enteredName = null, Color? enteredColor = null) {
      InitializeComponent();
      if (enteredColor == null) enteredColor = Color.White;
      buttonColor.BackColor = enteredColor.Value;
      SelectedColor = buttonColor.BackColor;
      textBoxName.Text = enteredName ?? "";
    }

    private void buttonOk_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void textBoxName_TextChanged(object sender, EventArgs e) {
      EngineTypeName = textBoxName.Text;
    }

    private void FormCreateModifyEngineType_Load(object sender, EventArgs e) { }

    private void buttonColor_Click(object sender, EventArgs e) {
      var result = colorDialog.ShowDialog();
      if (result != DialogResult.OK) return;
      SelectedColor = colorDialog.Color;
      buttonColor.BackColor = SelectedColor;
    }
  }
}