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
  public partial class FormJobTypes : Form {
    public FormJobTypes() {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewJobTypes);
      var olv = objectListViewJobTypes;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      olv.Columns.Add(new OLVColumn("Название", "Name"));
      var engineTypeColumn = new OLVColumn("Виды двигателей", "EngineTypes");
      engineTypeColumn.AspectToStringConverter += value => {
        var val = (EngineType[]) value;
        if (val.Length == 0) return "";
        return new string(val.Aggregate("", (s, type) => s + ", " + type.Name).Skip(2).ToArray());
      };
      olv.Columns.Add(engineTypeColumn);

    }

    private void FormJobTypes_Load(object sender, EventArgs e) {
      RefreshObjects();
    }

    private void RefreshObjects() {
      var types = JobType.EnumerateJobTypes();
      objectListViewJobTypes.SetObjects(types);
      Tools.ResizeColumns(objectListViewJobTypes);
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      var form = new FormCreateModifyJobType();
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      JobType.InsertOne(form.SelectedEngines, form.JobName);
      RefreshObjects();
    }

    private void buttonRemove_Click(object sender, EventArgs e) {
      var selected = (JobType) objectListViewJobTypes.SelectedObject;
      if (selected == null) return;
      JobType.RemoveOne(selected.Id);
      RefreshObjects();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var selected = (JobType) objectListViewJobTypes.SelectedObject;
      if (selected == null) return;
      var form = new FormCreateModifyJobType(selected.Name, selected.EngineTypes);
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      JobType.ModifyOne(selected.Id, form.SelectedEngines, form.JobName);
      RefreshObjects();
    }

    private void buttonRefresh_Click(object sender, EventArgs e) {
      RefreshObjects();
    }
  }
}