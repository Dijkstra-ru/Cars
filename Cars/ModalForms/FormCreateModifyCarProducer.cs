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
  public partial class FormCreateModifyCarProducer : Form {
    public string ProducerName { get; set; }

    public FormCreateModifyCarProducer(string enteredName = null) {
      InitializeComponent();
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
      ProducerName = textBoxName.Text;
    }
  }
}