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
  public partial class FormCarProducers : Form {
    public FormCarProducers() {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewCarProducers);
      var olv = objectListViewCarProducers;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      olv.Columns.Add(new OLVColumn("Название", "Name"));
    }

    private void FormCarProducers_Load(object sender, EventArgs e) {
      RefreshObjects();
    }

    private void RefreshObjects() {
      var producers = CarProducer.EnumerateCarProducers();
      objectListViewCarProducers.SetObjects(producers);
      Tools.ResizeColumns(objectListViewCarProducers);
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      var form = new FormCreateModifyCarProducer();
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      CarProducer.InsertOne(form.ProducerName.Trim());
      RefreshObjects();
    }

    private void buttonRemove_Click(object sender, EventArgs e) {
      var selected = (CarProducer) objectListViewCarProducers.SelectedObject;
      if (selected == null) return;
      CarProducer.RemoveOne(selected.Id);
      RefreshObjects();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var selected = (CarProducer) objectListViewCarProducers.SelectedObject;
      if (selected == null) return;
      var form = new FormCreateModifyCarProducer(selected.Name);
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      CarProducer.ModifyOne(selected.Id, form.ProducerName.Trim());
      RefreshObjects();
    }

    private void buttonRefresh_Click(object sender, EventArgs e) {
      RefreshObjects();
    }
  }
}