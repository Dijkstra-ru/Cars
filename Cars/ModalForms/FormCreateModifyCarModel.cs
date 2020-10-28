using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cars.Models;

namespace Cars.ModalForms {
  public partial class FormCreateModifyCarModel : Form {
    public string ModelName { get; set; }
    public EngineType Engine { get; set; }
    public CarProducer Producer { get; set; }

    public FormCreateModifyCarModel(EngineType selectedEngine = null, CarProducer selectedProducer = null,
      string enteredName = null) {
      InitializeComponent();
      comboBoxEngines.Items.AddRange(EngineType.EnumerateTypes().ToArray());
      if (comboBoxEngines.Items.Count > 0) {
        comboBoxEngines.SelectedItem = selectedEngine ?? comboBoxEngines.Items[0];
      }
      comboBoxCarProducers.Items.AddRange(CarProducer.EnumerateCarProducers().ToArray());
      if (comboBoxCarProducers.Items.Count > 0) {
        comboBoxCarProducers.SelectedItem = selectedProducer ?? comboBoxCarProducers.Items[0];
      }
      textBoxName.Text = enteredName ?? "";
    }

    private void textBoxName_TextChanged(object sender, EventArgs e) {
      ModelName = textBoxName.Text;
    }

    private void buttonOk_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void comboBoxCarProducers_SelectedIndexChanged(object sender, EventArgs e) {
      Producer = (CarProducer) comboBoxCarProducers.SelectedItem;
    }

    private void comboBoxEngines_SelectedIndexChanged(object sender, EventArgs e) {
      Engine = (EngineType) comboBoxEngines.SelectedItem;
    }
  }
}
