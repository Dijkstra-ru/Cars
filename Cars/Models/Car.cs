using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace Cars.Models {
  public class Car {
    public long Id { get; set; }
    public CarModel Model { get; set; }
    public string LicensePlate { get; set; }

    public static void CreateTable() {
      var sb = new StringBuilder();

      void s(string x) {
        sb.Append($"{x}\n");
      }

      s("CREATE TABLE cars (");
      s("car_id INTEGER PRIMARY KEY,");
      s("model_id INTEGER NOT NULL,");
      s("plate TEXT NOT NULL,");
      s("FOREIGN KEY (model_id) REFERENCES car_models (car_model_id)");
      s(")");
      DbConn.ExecuteNonQuery(sb);
    }

    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS cars");
    }

    public static long InsertOne(long modelId, string licensePlate) {
      var sb = new StringBuilder();

      void s(string x) {
        sb.Append($"{x}\n");
      }

      s("INSERT INTO cars (plate, model_id)");
      s("VALUES (@plate, @model_id);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb, new Dictionary<string, object> {
        {"@plate", licensePlate},
        {"@model_id", modelId}
      });
    }

    public static List<Car> EnumerateCars() {
      var sb = new StringBuilder();

      void s(string x)
      {
        sb.Append($"{x}\n");
      }

      s("SELECT car_id, plate, car_model_id, car_producer_id, car_producers.name AS producer, car_models.name AS car_name,");
      s("engine_types.engine_type_id, engine_types.name AS engine_name, color");
      s("FROM cars ");
      s("JOIN car_models ON car_models.car_model_id = cars.model_id");
      s("JOIN car_producers ON car_models.producer_id = car_producers.car_producer_id");
      s("JOIN engine_types ON car_models.engine_type_id = engine_types.engine_type_id");
      var reader = DbConn.ExecuteReader(sb);
      var result = new List<Car>();
      while (reader.Read())
      {
        var producer = new CarProducer()
        {
          Id = (long)reader["car_producer_id"],
          Name = (string)reader["producer"]
        };
        var engine = new EngineType()
        {
          Id = (long)reader["engine_type_id"],
          ColorEncoding = Color.FromArgb((int)(long)reader["color"]),
          Name = (string)reader["engine_name"],
        };
        var model = new CarModel()
        {
          Id = (long)reader["car_model_id"],
          Name = (string)reader["car_name"],
          CarProducer = producer,
          EngineType = engine,
        };
        var car = new Car() {
          Id = (long)reader["car_id"],
          LicensePlate = (string) reader["plate"],
          Model = model,
        };
        result.Add(car);
      }
      return result;
    }

    public static void SeedDb() {
      var r = new Random(42);
      string RandomPlate() {
        var validLetters = new[] {'А', 'В', 'Е', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х'};
        char RandomLetter() => validLetters[r.Next(validLetters.Length)];
        char RandomDigit() => r.Next(10).ToString()[0];
        return $"{RandomLetter()}{RandomDigit()}{RandomDigit()}{RandomDigit()}{RandomLetter()}{RandomLetter()}66";
      }
      var models = CarModel.EnumerateCarModels();
      InsertOne(models[0].Id, RandomPlate());
      InsertOne(models[0].Id, RandomPlate());
      InsertOne(models[1].Id, RandomPlate());
      InsertOne(models[1].Id, RandomPlate());
      InsertOne(models[2].Id, RandomPlate());
      InsertOne(models[2].Id, RandomPlate());
      InsertOne(models[3].Id, RandomPlate());
      InsertOne(models[3].Id, RandomPlate());
      InsertOne(models[4].Id, RandomPlate());
      InsertOne(models[4].Id, RandomPlate());
      InsertOne(models[5].Id, RandomPlate());
      InsertOne(models[5].Id, RandomPlate());
    }

  }
}