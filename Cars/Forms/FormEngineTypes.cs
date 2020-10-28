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
  public partial class FormEngineTypes : Form {
    public FormEngineTypes() {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewEngineTypes);
      var olv = objectListViewEngineTypes;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      var nameColumn = new OLVColumn("Название", "Name");
      olv.Columns.Add(nameColumn);
      olv.FormatRow += (sender, args) => { args.UseCellFormatEvents = true; };
      olv.FormatCell += (sender, args) => {
        if (args.ColumnIndex == nameColumn.Index) {
          var val = (EngineType) args.Model;
          args.SubItem.BackColor = val.ColorEncoding;
        }
      };
    }

    private void FormEngineTypes_Load(object sender, EventArgs e) {
      RefreshObjects();
    }

    private void RefreshObjects() {
      var types = EngineType.EnumerateTypes();
      objectListViewEngineTypes.SetObjects(types);
      Tools.ResizeColumns(objectListViewEngineTypes);
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      var form = new FormCreateModifyEngineType();
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      EngineType.InsertOne(form.SelectedColor, form.EngineTypeName.Trim());
      RefreshObjects();
    }

    private void buttonRemove_Click(object sender, EventArgs e) {
      var selected = (EngineType) objectListViewEngineTypes.SelectedObject;
      if (selected == null) return;
      EngineType.RemoveOne(selected.Id);
      RefreshObjects();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var selected = (EngineType) objectListViewEngineTypes.SelectedObject;
      if (selected == null) return;
      var form = new FormCreateModifyEngineType(selected.Name, selected.ColorEncoding);
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      EngineType.ModifyOne(selected.Id, form.SelectedColor, form.EngineTypeName.Trim());
      RefreshObjects();
    }

    private void buttonRefresh_Click(object sender, EventArgs e) {
      RefreshObjects();
    }
  }
}
