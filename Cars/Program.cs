using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cars.Models;

namespace Cars
{
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main() {
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

      var cars = Car.EnumerateCars();
      var jobs = Job.EnumerateJobs(cars[0]);


      return;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
