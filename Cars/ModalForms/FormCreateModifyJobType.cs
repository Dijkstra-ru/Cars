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

namespace Cars.ModalForms {
  public partial class FormCreateModifyJobType : Form {
    public string JobName { get; set; }
    public EngineType[] SelectedEngines { get; set; }

    public FormCreateModifyJobType(string enteredName = null, EngineType[] selectedEngineTypes = null) {
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

      SelectedEngines = selectedEngineTypes ?? new EngineType[] { };
      objectListViewEngineTypes.SetObjects(EngineType.EnumerateTypes());
      Tools.ResizeColumns(objectListViewEngineTypes);
      foreach (var engineType in selectedEngineTypes) {
        objectListViewEngineTypes.CheckObject(engineType);
      }

      JobName = enteredName ?? "";
      textBoxName.Text = JobName;
    }

    private void FormCreateModifyJobType_Load(object sender, EventArgs e) { }

    private void buttonOk_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e) {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void objectListViewEngineTypes_ItemChecked(object sender, ItemCheckedEventArgs e) {
      SelectedEngines = objectListViewEngineTypes.CheckedObjects.OfType<EngineType>().ToArray();
    }

    private void textBoxName_TextChanged(object sender, EventArgs e) {
      JobName = textBoxName.Text;
    }
  }
}
