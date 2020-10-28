using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Cars.ModalForms;
using Cars.Models;

namespace Cars.Forms {
  public partial class FormCars : Form {
    public FormCars() {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewCars);
      var olv = objectListViewCars;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      olv.Columns.Add(new OLVColumn("Гос. Номер", "LicensePlate"));
      var modelColumn = new OLVColumn("Модель", "Model");
      modelColumn.AspectToStringConverter = value => {
        var val = (CarModel) value;
        return $"{val.CarProducer.Name} {val.Name}";
      };
      olv.Columns.Add(modelColumn);
      var engineColumn = new OLVColumn("Тип двигателя", "Model");
      engineColumn.AspectToStringConverter = value => {
        var val = (CarModel) value;
        return $"{val.EngineType.Name}";
      };
      olv.Columns.Add(engineColumn);
      olv.FormatRow += (sender, args) => { args.UseCellFormatEvents = true; };
      olv.FormatCell += (sender, args) => {
        if (args.ColumnIndex == engineColumn.Index) {
          var val = (CarModel) args.CellValue;
          args.SubItem.BackColor = val.EngineType.ColorEncoding;
        }
      };
    }

    private void FormCars_Load(object sender, EventArgs e) {
      RefreshObjects();
    }

    private void RefreshObjects() {
      var cars = Car.EnumerateCars();
      objectListViewCars.SetObjects(cars);
      Tools.ResizeColumns(objectListViewCars);
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      var form = new FormCreateModifyCar();
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      Car.InsertOne(form.Model.Id, form.LicensePlate.Trim());
      RefreshObjects();
    }

    private void buttonRemove_Click(object sender, EventArgs e) {
      var selected = (Car) objectListViewCars.SelectedObject;
      if (selected == null) return;
      Car.RemoveOne(selected.Id);
      RefreshObjects();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var selected = (Car) objectListViewCars.SelectedObject;
      if (selected == null) return;
      var form = new FormCreateModifyCar(selected.LicensePlate, selected.Model);
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      Car.ModifyOne(selected.Id, form.LicensePlate.Trim(), form.Model.Id);
      RefreshObjects();
    }

    private void buttonRefresh_Click(object sender, EventArgs e) {
      RefreshObjects();
    }
  }
}
