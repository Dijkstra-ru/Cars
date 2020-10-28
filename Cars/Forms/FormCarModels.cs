using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Cars.ModalForms;
using Cars.Models;

namespace Cars.Forms {
  public partial class FormCarModels : Form {
    public FormCarModels() {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewCarModels);
      var olv = objectListViewCarModels;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      var carProducerColumn = new OLVColumn("Производитель", "CarProducer");
      carProducerColumn.AspectToStringConverter += value => {
        var val = (CarProducer) value;
        return val.Name;
      };
      olv.Columns.Add(carProducerColumn);
      var carNameColumn = new OLVColumn("Название", "Name");
      olv.Columns.Add(carNameColumn);
      var engineColumn = new OLVColumn("Тип двигателя", "EngineType");
      engineColumn.AspectToStringConverter = value => {
        var val = (EngineType) value;
        return $"{val.Name}";
      };
      olv.Columns.Add(engineColumn);
      olv.FormatRow += (sender, args) => { args.UseCellFormatEvents = true; };
      olv.FormatCell += (sender, args) => {
        if (args.ColumnIndex == engineColumn.Index) {
          var val = (EngineType) args.CellValue;
          args.SubItem.BackColor = val.ColorEncoding;
        }
      };
    }

    private void FormCarModels_Load(object sender, EventArgs e) {
      RefreshObjects();
    }

    private void RefreshObjects() {
      var models = CarModel.EnumerateCarModels();
      objectListViewCarModels.SetObjects(models);
      Tools.ResizeColumns(objectListViewCarModels);
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      if (EngineType.EnumerateTypes().Count == 0 || CarProducer.EnumerateCarProducers().Count == 0) {
        MessageBox.Show("Невозможно добавить модель машины: не заполнены необходимые данные");
        return;
      }
      var form = new FormCreateModifyCarModel();
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      CarModel.InsertOne(form.ModelName.Trim(), form.Producer.Id, form.Engine.Id);
      RefreshObjects();
    }

    private void buttonRemove_Click(object sender, EventArgs e) {
      var selected = (CarModel) objectListViewCarModels.SelectedObject;
      if (selected == null) return;
      CarModel.RemoveOne(selected.Id);
      RefreshObjects();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var selected = (CarModel) objectListViewCarModels.SelectedObject;
      if (selected == null) return;
      var form = new FormCreateModifyCarModel(selected.EngineType, selected.CarProducer, selected.Name);
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      CarModel.ModifyOne(selected.Id, form.ModelName.Trim(), form.Producer.Id, form.Engine.Id);
      RefreshObjects();
    }

    private void buttonRefresh_Click(object sender, EventArgs e) {
      RefreshObjects();
    }
  }
}
