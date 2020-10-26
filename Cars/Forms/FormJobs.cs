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
  public partial class FormJobs : Form
  {
    public FormJobs()
    {
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
      var timeColumn = new OLVColumn("Время", "TimeStamp");
      timeColumn.AspectToStringConverter = value => {
        var val = (DateTime)value;
        return val.ToShortTimeString();
      };
      olv.Columns.Add(timeColumn);

      var plateColumn = new OLVColumn("Гос.Номер", "Car");
      plateColumn.AspectToStringConverter += value => {
        var val = (Car) value;
        return val.LicensePlate;
      };
      olv.Columns.Add(plateColumn);
      var nameColumn = new OLVColumn("Вид работы", "Type");
      nameColumn.AspectToStringConverter = value => {
        var val = (JobType) value;
        return val.Name;
      };
      olv.Columns.Add(nameColumn);
    }

    private void FormJobs_Load(object sender, EventArgs e) {
      var jobs = Job.EnumerateJobs();
      objectListViewJobs.SetObjects(jobs);
      Tools.ResizeColumns(objectListViewJobs);
    }
  }
}
