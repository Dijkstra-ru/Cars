using System.Collections.Generic;
using System.Text;

namespace Cars.Models {
  public class CarProducer {
    public long Id { get; set; }
    public string Name { get; set; }
    public static void CreateTable()
    {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
      s("CREATE TABLE car_producers (");
      s("car_producer_id INTEGER PRIMARY KEY,");
      s("name TEXT NOT NULL");
      s(");");
      DbConn.ExecuteNonQuery(sb);
    }
    public static void DropTable()
    {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS car_producers");
    }

    public static long InsertOne(string name) {
      return DbConn.ExecuteScalar("INSERT INTO car_producers (name) VALUES (@name); SELECT last_insert_rowid();",
        new Dictionary<string, object> {{"@name", name}});
    }

    public static List<CarProducer> EnumerateCarProducers() {
      var reader = DbConn.ExecuteReader("SELECT * FROM car_producers");
      var result = new List<CarProducer>();
      while (reader.Read()) {
        result.Add(new CarProducer {
          Id = (long) reader["car_producer_id"],
          Name = (string) reader["name"],
        });
      }
      return result;
    }

    public static void SeedDb() {
      InsertOne("LADA");
      InsertOne("Porsche");
      InsertOne("Volkswagen");
      InsertOne("Kia");
    }
  }
}