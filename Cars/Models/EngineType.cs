using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Text;

namespace Cars.Models {
  public class EngineType {
    public long Id { get; set; }
    public Color ColorEncoding { get; set; }
    public string Name { get; set; }

    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
      s("CREATE TABLE engine_types (");
      s("engine_type_id INTEGER PRIMARY KEY,");
      s("color INTEGER NOT NULL,");
      s("name TEXT NOT NULL");
      s(")");
      DbConn.ExecuteNonQuery(sb);
    }

    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS engine_types");
    }

    public static long InsertOne(Color colorEncoding, string name) {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
      s("INSERT INTO engine_types");
      s("(color, name)");
      s("VALUES (@color, @name);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb,
        new Dictionary<string, object> {{ "@color", colorEncoding.ToArgb() }, {"@name", name}});
    }

    public static List<EngineType> EnumerateTypes() {
      var reader = DbConn.ExecuteReader("SELECT * FROM engine_types");
      var result = new List<EngineType>();
      while (reader.Read()) {
        result.Add(new EngineType {
          Id = (long) reader["engine_type_id"],
          ColorEncoding = Color.FromArgb((int) (long) reader["color"]),
          Name = (string) reader["name"],
        });
      }
      return result;
    }

    public static void SeedDb() {
      InsertOne(Color.Yellow, "Дизельный");
      InsertOne(Color.GreenYellow, "Бензиновый");
      InsertOne(Color.Salmon, "Электрический");
    }
  }
}