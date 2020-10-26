﻿using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Cars.Models {
  public class CarModel {
    public long Id { get; set; }
    public CarProducer CarProducer { get; set; }
    public EngineType EngineType { get; set; }
    public string Name { get; set; }

    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
      s("CREATE TABLE car_models (");
      s("car_model_id INTEGER PRIMARY KEY,");
      s("name TEXT NOT NULL,");
      s("producer_id INTEGER NOT NULL,");
      s("engine_type_id INTEGER NOT NULL,");
      s("FOREIGN KEY (producer_id) REFERENCES car_producers (car_producer_id),");
      s("FOREIGN KEY (engine_type_id) REFERENCES engine_types (engine_type_id)");
      s(");");
      DbConn.ExecuteNonQuery(sb);
    }

    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS car_models");
    }

    public static long InsertOne(string name, long producerId, long engineTypeId)
    {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }
      s("INSERT INTO car_models (name, engine_type_id, producer_id) ");
      s("VALUES (@name, @engine_id, @producer_id);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb,
        new Dictionary<string, object> {{"@name", name}, {"@engine_id", engineTypeId}, {"@producer_id", producerId}});
    }

    public static List<CarModel> EnumerateCarModels()
    {
      var sb = new StringBuilder();
      void s(string x) { sb.Append($"{x}\n"); }

      s("SELECT car_model_id, car_producer_id, car_producers.name AS producer, car_models.name AS car_name,");
      s("engine_types.engine_type_id, engine_types.name AS engine_name, color");
      s("FROM car_models ");
      s("JOIN car_producers ON car_models.producer_id = car_producers.car_producer_id");
      s("JOIN engine_types ON car_models.engine_type_id = engine_types.engine_type_id");
      var reader = DbConn.ExecuteReader(sb);
      var result = new List<CarModel>();
      while (reader.Read()) {
        var producer = new CarProducer() {
          Id = (long)reader["car_model_id"],
          Name = (string)reader["producer"]
        };
        var engine = new EngineType() {
          Id = (long) reader["engine_type_id"],
          ColorEncoding = Color.FromArgb((int) (long) reader["color"]),
          Name = (string) reader["engine_name"],
        };
        var newModel = new CarModel()
        {
          Id = (long)reader["car_model_id"],
          Name = (string)reader["car_name"],
          CarProducer = producer,
          EngineType = engine,
        };
        result.Add(newModel);
      }
      return result;
    }

    public static void SeedDb() {
      var engines = EngineType.EnumerateTypes();
      var producers = CarProducer.EnumerateCarProducers();
      InsertOne("Веста", producers[0].Id, engines[0].Id);
      InsertOne("Гранта", producers[0].Id, engines[1].Id);
      InsertOne("Cayene", producers[1].Id, engines[0].Id);
      InsertOne("Polo", producers[2].Id, engines[1].Id);
      InsertOne("Touareg", producers[2].Id, engines[0].Id);
      InsertOne("Ria", producers[3].Id, engines[1].Id);

    }
  }
}