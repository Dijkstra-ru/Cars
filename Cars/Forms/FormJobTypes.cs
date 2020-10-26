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
  public partial class FormJobTypes : Form
  {
    public FormJobTypes()
    {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewJobTypes);
      var olv = objectListViewJobTypes;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      olv.Columns.Add(new OLVColumn("Название", "Name"));
      var engineTypeColumn = new OLVColumn("Виды двигателей", "EngineTypes");
      engineTypeColumn.AspectToStringConverter += value => {
        var val = (EngineType[]) value;
        return new string(val.Aggregate("", (s, type) => s + ", " + type.Name).Skip(2).ToArray());
      };
      olv.Columns.Add(engineTypeColumn);

    }

    private void FormJobTypes_Load(object sender, EventArgs e) {
      var types = JobType.EnumerateJobTypes();
      objectListViewJobTypes.SetObjects(types);
      Tools.ResizeColumns(objectListViewJobTypes);
    }
  }
}
