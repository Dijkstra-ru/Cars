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
  public partial class FormCarProducers : Form
  {
    public FormCarProducers()
    {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewCarProducers);
      var olv = objectListViewCarProducers;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      olv.Columns.Add(new OLVColumn("Название", "Name"));
    }

    private void FormCarProducers_Load(object sender, EventArgs e) {
      var producers = CarProducer.EnumerateCarProducers();
      objectListViewCarProducers.SetObjects(producers);
      Tools.ResizeColumns(objectListViewCarProducers);
    }
  }
}
