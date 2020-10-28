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
  public partial class FormJobs : Form {
    public FormJobs() {
      InitializeComponent();
      Tools.SetUpOlv(objectListViewJobs);
      var olv = objectListViewJobs;
      olv.Columns.Add(new OLVColumn("Артикул", "Id"));
      var dateColumn = new OLVColumn("Дата", "TimeStamp");
      dateColumn.AspectToStringConverter = value => {
        var val = (DateTime) value;
        return val.ToShortDateString();
      };
      olv.Columns.Add(dateColumn);

      var plateColumn = new OLVColumn("Гос.Номер", "Car");
      plateColumn.AspectToStringConverter += value => {
        var val = (Car) value;
        return val.LicensePlate;
      };
      olv.Columns.Add(plateColumn);

      var modelColumn = new OLVColumn("Модель", "Car");
      modelColumn.AspectToStringConverter += value => {
        var val = (Car) value;
        return val.Model.ToString();
      };
      olv.Columns.Add(modelColumn);

      var nameColumn = new OLVColumn("Вид работы", "Type");
      nameColumn.AspectToStringConverter = value => {
        var val = (JobType) value;
        return val.Name;
      };
      olv.Columns.Add(nameColumn);
    }

    private void FormJobs_Load(object sender, EventArgs e) {
      RefreshObjects();
    }

    private void RefreshObjects() {
      var jobs = Job.EnumerateJobs();
      objectListViewJobs.SetObjects(jobs);
      Tools.ResizeColumns(objectListViewJobs);
    }

    private void buttonCreate_Click(object sender, EventArgs e) {
      var form = new FormCreateModifyJob();
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      Job.InsertOne(form.SelectedCar.Id, form.SelectedJob.Id, form.SelectedDate);
      RefreshObjects();
    }

    private void buttonRemove_Click(object sender, EventArgs e) {
      var selected = (Job) objectListViewJobs.SelectedObject;
      if (selected == null) return;
      Job.RemoveOne(selected.Id);
      RefreshObjects();
    }

    private void buttonUpdate_Click(object sender, EventArgs e) {
      var selected = (Job) objectListViewJobs.SelectedObject;
      if (selected == null) return;
      var form = new FormCreateModifyJob(selected.Car, selected.Type, selected.TimeStamp);
      var result = form.ShowDialog();
      if (result != DialogResult.OK) return;
      Job.ModifyOne(selected.Id, form.SelectedCar.Id, form.SelectedJob.Id, form.SelectedDate);
      RefreshObjects();
    }

    private void buttonRefresh_Click(object sender, EventArgs e) {
      RefreshObjects();
    }
  }
}