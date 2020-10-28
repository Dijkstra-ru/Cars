using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cars.Models;

namespace Cars.ModalForms {
  public partial class FormCreateModifyCar : Form {
    public string LicensePlate { get; set; }
    public CarModel Model { get; set; }

    public FormCreateModifyCar(string plate = null, CarModel selectedModel = null) {
      InitializeComponent();
      comboBoxCarModels.Items.AddRange(CarModel.EnumerateCarModels().ToArray());
      if (comboBoxCarModels.Items.Count > 0) {
        comboBoxCarModels.SelectedItem = selectedModel ?? comboBoxCarModels.Items[0];
      }
      textBoxPlate.Text = plate ?? "";
    }

    private void textBoxName_TextChanged(object sender, EventArgs e) {
      LicensePlate = textBoxPlate.Text;
    }

    private void buttonOk_Click(object sender, EventArgs e) {
      if (!validatePlate(textBoxPlate.Text.Trim())) {
        MessageBox.Show("Неверный гос. номер!");
        return;
      }

      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void comboBoxCarModels_SelectedIndexChanged(object sender, EventArgs e) {
      Model = (CarModel) comboBoxCarModels.SelectedItem;
    }

    /// <summary>
    /// Функция для валидации гос. номеров автомобилей
    /// </summary>
    /// <param name="text">Текст гос. номера</param>
    /// <returns>true, если такой номер существует</returns>
    private bool validatePlate(string text) {
      var validLetters = new[] {'А', 'В', 'Е', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х'};
      var validDigits = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
      var validSymbols = validDigits.Concat(validLetters).ToArray();
      var validPatterns = new[] {
        @"^\D\d\d\d\D\D\d\d$", // Стандартный номер, 2 знака региона
        @"^\D\d\d\d\D\D\d\d\d$", // Стандартный номер, 3 знака региона
        @"^\D\D\d\d\d\d\d$", // Такси, 2 знака региона
        @"^\D\D\d\d\d\d\d\d$", // Такси, 3 знака региона
        @"^\d\d\d\d\D\D\d\d$", // Трактор или военный, 2 знака региона
        @"^\d\d\d\d\D\D\d\d\d$", // Трактор или военный, 3 знака региона
        @"^\D\d\d\d\d\d\d$", // Милицейский, 2 знака региона
        @"^\D\d\d\d\d\d\d\d$", // Милицейский, 3 знака региона
      };
      var regexes = validPatterns.Select(x => new Regex(x));
      if (!text.Trim().ToUpper().All(validSymbols.Contains)) return false;
      if (regexes.Any(x => x.IsMatch(text.Trim().ToUpper()))) return true;
      return false;
    }
  }
}