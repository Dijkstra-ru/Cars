using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Cars.Models;

namespace Cars {
  public static class DbConn {
    /// <summary>
    /// true, если подключение к базе данных открыто
    /// </summary>
    private static bool isOpened { get; set; }
    /// <summary>
    /// Объект подключения к базе данных
    /// </summary>
    private static SQLiteConnection connection { get; set; }
    /// <summary>
    /// Создать таблицы в базе данных
    /// </summary>
    private static void createTables() {
      EngineType.CreateTable();
      JobType.CreateTable();
      CarProducer.CreateTable();
      CarModel.CreateTable();
      Car.CreateTable();
    }
    /// <summary>
    /// Уничтожить таблицы в базе данных
    /// </summary>
    private static void dropTables() {
      Car.DropTable();
      CarModel.DropTable();
      CarProducer.DropTable();
      JobType.DropTable();
      EngineType.DropTable();
    }
    /// <summary>
    /// Открывает подключение к базе данных
    /// </summary>
    /// <param name="fileName">Имя файла с базой данных</param>
    public static void Open(string fileName) {
      try {
        if (!File.Exists(fileName)) {
          SQLiteConnection.CreateFile(fileName);
          createTables();
        }
        connection = new SQLiteConnection("Data Source=" + fileName + ";Version=3;");
        connection.Open();
      }
      catch (SQLiteException ex) {
        // TODO: Log fatal
        MessageBox.Show("Error: " + ex.Message);
        throw;
      }
    }
    /// <summary>
    /// Закрывает подключение к базе данных
    /// </summary>
    public static void Close() {
      isOpened = false;
      connection.Close();
      // Gracefully close connection
      // See https://stackoverflow.com/questions/8511901/system-data-sqlite-close-not-releasing-database-file
      GC.Collect();
      GC.WaitForPendingFinalizers();
      SQLiteConnection.ClearAllPools();
    }
    public static SQLiteConnection GetConnection() {
      if (!isOpened) Open("cars.sqlite");
      return connection;
    }

    public static void ExecuteNonQuery(StringBuilder sb, Dictionary<string, object> args = null) =>
      ExecuteNonQuery(sb.ToString(), args);
    public static void ExecuteNonQuery(string sql, Dictionary<string, object> args = null) {
      var conn = GetConnection();
      var command = new SQLiteCommand(sql, conn);
      if (args != null) {
        foreach (var arg in args) {
          command.Parameters.AddWithValue(arg.Key, arg.Value);
        }
      }
      command.ExecuteNonQuery();
    }
    public static long ExecuteScalar(StringBuilder sb, Dictionary<string, object> args = null) =>
      ExecuteScalar(sb.ToString(), args);
    public static long ExecuteScalar(string sql, Dictionary<string, object> args = null) {
      var conn = GetConnection();
      var command = new SQLiteCommand(sql, conn);
      if (args != null) {
        foreach (var arg in args) {
          command.Parameters.AddWithValue(arg.Key, arg.Value);
        }
      }

      return (long) command.ExecuteScalar();
    }
    public static SQLiteDataReader ExecuteReader(StringBuilder sb, Dictionary<string, object> args = null) =>
      ExecuteReader(sb.ToString(), args);
    public static SQLiteDataReader ExecuteReader(string sql, Dictionary<string, object> args = null) {
      var conn = GetConnection();
      var command = new SQLiteCommand(sql, conn);
      if (args != null) {
        foreach (var arg in args) {
          command.Parameters.AddWithValue(arg.Key, arg.Value);
        }
      }
      return command.ExecuteReader();
    }

  }
}