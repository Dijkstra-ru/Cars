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
  public partial class FormEngineTypes : Form
  {
    public FormEngineTypes()
    {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewEngineTypes);
      var olv = objectListViewEngineTypes;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      olv.Columns.Add(new OLVColumn("Название", "Name"));
    }

    private void FormEngineTypes_Load(object sender, EventArgs e) {
      var types = EngineType.EnumerateTypes();
      objectListViewEngineTypes.SetObjects(types);
      Tools.ResizeColumns(objectListViewEngineTypes);
    }
  }
}
