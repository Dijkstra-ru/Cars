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
using Cars.Models;

namespace Cars.Forms
{
  public partial class FormCars : Form
  {
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
      var cars = Car.EnumerateCars();
      objectListViewCars.SetObjects(cars);
      Tools.ResizeColumns(objectListViewCars);
    }
  }
}
