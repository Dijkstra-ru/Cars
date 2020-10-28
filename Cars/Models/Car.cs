using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;

namespace Cars.Models {
  /// <summary>
  /// Модель описывает обслуживаемый автомобиль.
  /// Класс содержит методы для работы с базой данных
  /// </summary>
  public class Car {
    /// <summary>
    /// Первичный ключ в базе данных
    /// </summary>
    public long Id { get; set; }

    public CarModel Model { get; set; }

    /// <summary>
    /// Гос. номер автомобиля
    /// </summary>
    public string LicensePlate { get; set; }

    /// <summary>
    /// Создаёт таблицу в базе данных
    /// </summary>
    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("CREATE TABLE cars (");
      s("car_id INTEGER PRIMARY KEY,");
      s("model_id INTEGER NOT NULL,");
      s("plate TEXT NOT NULL,");
      s("FOREIGN KEY (model_id) REFERENCES car_models (car_model_id)");
      s(")");
      DbConn.ExecuteNonQuery(sb);
    }

    /// <summary>
    /// Уничтожает таблицу в базе данных
    /// </summary>
    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS cars");
    }

    /// <summary>
    /// Добавляет запись об автомобиле в базу данных
    /// </summary>
    /// <param name="modelId">Идентификатор модели автомобиля</param>
    /// <param name="licensePlate">Гос. номер</param>
    /// <returns>Присвоенный идентификатор автомобиля</returns>
    public static long InsertOne(long modelId, string licensePlate) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("INSERT INTO cars (plate, model_id)");
      s("VALUES (@plate, @model_id);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb, new Dictionary<string, object> {
        {"@plate", licensePlate},
        {"@model_id", modelId}
      });
    }

    /// <summary>
    /// Возвращает список автомобилей в базе данных
    /// </summary>
    /// <returns>Список автомобилей в базе данных</returns>
    public static List<Car> EnumerateCars() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s(
        "SELECT car_id, plate, car_model_id, car_producer_id, car_producers.name AS producer, car_models.name AS car_name,");
      s("engine_types.engine_type_id, engine_types.name AS engine_name, color");
      s("FROM cars ");
      s("JOIN car_models ON car_models.car_model_id = cars.model_id");
      s("JOIN car_producers ON car_models.producer_id = car_producers.car_producer_id");
      s("JOIN engine_types ON car_models.engine_type_id = engine_types.engine_type_id");
      var reader = DbConn.ExecuteReader(sb);
      var result = new List<Car>();
      while (reader.Read()) {
        var producer = new CarProducer() {
          Id = (long) reader["car_producer_id"],
          Name = (string) reader["producer"]
        };
        var engine = new EngineType() {
          Id = (long) reader["engine_type_id"],
          ColorEncoding = Color.FromArgb((int) (long) reader["color"]),
          Name = (string) reader["engine_name"],
        };
        var model = new CarModel() {
          Id = (long) reader["car_model_id"],
          Name = (string) reader["car_name"],
          CarProducer = producer,
          EngineType = engine,
        };
        var car = new Car() {
          Id = (long) reader["car_id"],
          LicensePlate = (string) reader["plate"],
          Model = model,
        };
        result.Add(car);
      }

      return result;
    }

    /// <summary>
    /// Заполняет базу данных тестовыми значениями
    /// </summary>
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

    /// <summary>
    /// Обновляет запись об автомобиле в базе данных
    /// </summary>
    /// <param name="id">Идентификатор автомобиля</param>
    /// <param name="plate">Гос. номер</param>
    /// <param name="modelId">Идентификатор модели автомобиля</param>
    public static void ModifyOne(long id, string plate, long modelId) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("UPDATE cars SET");
      s("plate = @plate,");
      s("model_id = @mid");
      s("WHERE car_id = @cid");
      DbConn.ExecuteNonQuery(sb, new Dictionary<string, object> {
        {"@plate", plate},
        {"@mid", modelId},
        {"@cid", id}
      });
    }

    /// <summary>
    /// Удаляет автомобиль из базы данных
    /// </summary>
    /// <param name="id">Идентификатор автомобиля</param>
    public static void RemoveOne(long id) {
      DbConn.ExecuteNonQuery("DELETE FROM cars WHERE car_id = @cid",
        new Dictionary<string, object> {{"@cid", id}});
    }

    public override string ToString() {
      return $"{LicensePlate} {Model}";
    }

    public override bool Equals(object obj) {
      switch (obj) {
        case null:
          return false;
        case Car car:
          return Id == car.Id;
        default:
          return false;
      }
    }
  }
}