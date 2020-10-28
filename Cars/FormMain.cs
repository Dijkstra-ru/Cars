using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cars.Forms;
using Cars.Models;

namespace Cars {
  public partial class FormMain : Form {
    /// <summary>
    /// Делает активным окно заданного типа
    /// </summary>
    /// <typeparam name="TFormType">Тип окна для активации</typeparam>
    /// <returns>true, если окно необходимо открыть заново</returns>
    private bool FocusChild<TFormType>() where TFormType : Form {
      var ot = MdiChildren.OfType<TFormType>().ToArray();
      if (ot.Length == 0) return true;
      var form = ot.First();
      if (form.Visible) form.Focus();
      return false;
    }

    /// <summary>
    /// Открывает окно заданного типа или делает уже открытое окно активным
    /// </summary>
    /// <typeparam name="TFormType"></typeparam>
    public void OpenForm<TFormType>() where TFormType : Form, new() {
      if (FocusChild<TFormType>()) {
        var f = new TFormType() {
          MdiParent = this
        };
        f.Show();
        f.WindowState = FormWindowState.Maximized;
      }
    }

    public FormMain() {
      InitializeComponent();
    }

    private void машиныToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenForm<FormCars>();
    }

    private void маркиМашинToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenForm<FormCarModels>();
    }

    private void производителиМашинToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenForm<FormCarProducers>();
    }

    private void видыРаботToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenForm<FormJobTypes>();
    }

    private void работыToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenForm<FormJobs>();
    }

    private void типыДвигателейToolStripMenuItem_Click(object sender, EventArgs e) {
      OpenForm<FormEngineTypes>();
    }

    private void сброситьБДToolStripMenuItem_Click(object sender, EventArgs e) {
      EngineType.DropTable();
      EngineType.CreateTable();
      EngineType.SeedDb();

      JobType.DropTable();
      JobType.CreateTable();
      JobType.SeedDb();

      CarProducer.DropTable();
      CarProducer.CreateTable();
      CarProducer.SeedDb();

      CarModel.DropTable();
      CarModel.CreateTable();
      CarModel.SeedDb();

      Car.DropTable();
      Car.CreateTable();
      Car.SeedDb();

      Job.DropTable();
      Job.CreateTable();
      Job.SeedDb();
    }
  }
}
