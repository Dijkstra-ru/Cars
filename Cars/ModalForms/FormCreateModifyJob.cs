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
  public partial class FormCreateModifyJob : Form {
    public Car SelectedCar { get; set; }
    public JobType SelectedJob { get; set; }
    public DateTime SelectedDate { get; set; }

    public FormCreateModifyJob(Car selectedCar = null, JobType selectedJobType = null, DateTime? selectedDate = null) {
      InitializeComponent();
      comboBoxCar.Items.AddRange(Car.EnumerateCars().ToArray());
      comboBoxCar.SelectedItem = selectedCar ?? comboBoxCar.Items[0];
      comboBoxJobType.SelectedItem = selectedJobType ?? comboBoxJobType.Items[0];
      if (selectedDate.HasValue) {
        dateTimePicker.Value = selectedDate.Value;
      }
      else {
        dateTimePicker.Value = DateTime.Today;
      }
    }

    private void comboBoxCar_SelectedIndexChanged(object sender, EventArgs e) {
      SelectedCar = (Car) comboBoxCar.SelectedItem;
      comboBoxJobType.Items.Clear();
      comboBoxJobType.Items.AddRange(JobType.EnumerateJobTypes(SelectedCar.Model.EngineType).ToArray());
      SelectedJob = null;
    }

    private void comboBoxJobType_SelectedIndexChanged(object sender, EventArgs e) {
      SelectedJob = (JobType) comboBoxJobType.SelectedItem;
    }

    private void buttonOk_Click(object sender, EventArgs e) {
      if (SelectedJob == null) {
        MessageBox.Show("Выберите вид работ.");
        return;
      }

      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void dateTimePicker_ValueChanged(object sender, EventArgs e) {
      SelectedDate = dateTimePicker.Value;
    }
  }
}