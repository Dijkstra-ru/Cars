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
using Cars.Models;

namespace Cars.Forms
{
  public partial class FormCarModels : Form
  {
    public FormCarModels()
    {
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
        var val = (EngineType)value;
        return $"{val.Name}";
      };
      olv.Columns.Add(engineColumn);
      olv.FormatRow += (sender, args) => { args.UseCellFormatEvents = true; };
      olv.FormatCell += (sender, args) => {
        if (args.ColumnIndex == engineColumn.Index)
        {
          var val = (EngineType)args.CellValue;
          args.SubItem.BackColor = val.ColorEncoding;
        }
      };
    }

    private void FormCarModels_Load(object sender, EventArgs e)
    {
      var models = CarModel.EnumerateCarModels();
      objectListViewCarModels.SetObjects(models);
      Tools.ResizeColumns(objectListViewCarModels);
    }
  }
}
