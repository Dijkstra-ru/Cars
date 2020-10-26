using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Cars.Models {
  public class JobType {
    public long Id { get; set; }
    public EngineType[] EngineTypes { get; set; }
    public string Name { get; set; }

    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
       s("CREATE TABLE jobs (");
      s("job_id INTEGER PRIMARY KEY,");
      s("name TEXT NOT NULL");
      s(");");
      DbConn.ExecuteNonQuery(sb);
      sb.Clear();
      s("CREATE TABLE link__jobs__engine_types (");
      s("link_id INTEGER PRIMARY KEY,");
      s("job_id INTEGER NOT NULL,");
      s("engine_type_id INTEGER NOT NULL,");
      s("FOREIGN KEY (job_id) REFERENCES jobs (job_id),");
      s("FOREIGN KEY (engine_type_id) REFERENCES engine_types (engine_type_id)");
      s(");");
      DbConn.ExecuteNonQuery(sb);
    }

    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS link__jobs__engine_types");
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS jobs");
    }

    public static long InsertOne(EngineType[] engineTypes, string name) {
      var newId = DbConn.ExecuteScalar("INSERT INTO jobs (name) VALUES (@name); SELECT last_insert_rowid();",
        new Dictionary<string, object> {{"@name", name}});
      foreach (var engineType in engineTypes) {
        var sql = "INSERT INTO link__jobs__engine_types (job_id, engine_type_id) VALUES(@job_id, @eng_id)";
        DbConn.ExecuteNonQuery(sql, new Dictionary<string, object> {{ "@job_id", newId }, { "@eng_id", engineType.Id } });
      }

      return newId;
    }

    public static List<JobType> EnumerateJobTypes(EngineType type) {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
      s("SELECT* FROM jobs");
      s("INNER JOIN link__jobs__engine_types ON jobs.job_id = link__jobs__engine_types.job_id");
      s("WHERE engine_type_id = @eid");
      var reader = DbConn.ExecuteReader(sb, new Dictionary<string, object> {{"@eid", type.Id}});
      var result = new List<JobType>();
      while (reader.Read())
      {
        result.Add(new JobType
        {
          Id = (long)reader["job_id"],
          Name = (string)reader["name"],
          EngineTypes = new [] { type },
        });
      }
      return result;
    }

    public static void SeedDb() {
      var engines = EngineType.EnumerateTypes();
      InsertOne(new[] { engines[0], engines[1] }, "Прочистка форсунок");
      InsertOne(new[] { engines[0], engines[1] }, "Полировка поршней");
      InsertOne(new[] { engines[0] }, "Настройка карбюратора");
      InsertOne(new[] { engines[1] }, "Прочистка турбокомпрессора");
      InsertOne(new[] { engines[2] }, "Зарядка аккумулятора");

    }
  }
}