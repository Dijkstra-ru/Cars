using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Cars.Models {
  /// <summary>
  /// Модель описывает работу, проведённую с автомобилем
  /// Класс содержит методы для работы с базой данных
  /// </summary>
  public class Job {
    /// <summary>
    /// Первичный ключ в базе данных
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Модель машины, над которой производилась работа
    /// </summary>
    public Car Car { get; set; }

    /// <summary>
    /// Дата проведения работы
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// Модель вида проведённой работы
    /// </summary>
    public JobType Type { get; set; }

    /// <summary>
    /// Создаёт таблицу в базе данных
    /// </summary>
    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("CREATE TABLE actions (");
      s("action_id INTEGER PRIMARY KEY AUTOINCREMENT,");
      s("car_id INTEGER NOT NULL,");
      s("job_id INTEGER NOT NULL,");
      s("timestamp DATETIME NOT NULL,");
      s("FOREIGN KEY (car_id) REFERENCES cars (car_id),");
      s("FOREIGN KEY (job_id) REFERENCES jobs (job_id)");
      s(")");
      DbConn.ExecuteNonQuery(sb);
    }

    /// <summary>
    /// Уничтожает таблицу в базе данных
    /// </summary>
    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS actions");
    }

    /// <summary>
    /// Добавляет новую запись о работе в базу данных
    /// </summary>
    /// <param name="carId">Идентификатор автомобиля, с которым была проведена работа</param>
    /// <param name="jobId">Идентификатор вида работы</param>
    /// <param name="timestamp">Дата проведения работы</param>
    /// <returns>Присвоенный идентификатор работы</returns>
    public static long InsertOne(long carId, long jobId, DateTime timestamp) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("INSERT INTO actions (car_id, job_id, timestamp)");
      s("VALUES (@car_id, @job_id, @timestamp);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb, new Dictionary<string, object>() {
        {"@car_id", carId},
        {"@job_id", jobId},
        {"@timestamp", timestamp}
      });
    }

    /// <summary>
    /// Возвращает список работ, проведённых с конкретным автомобилем
    /// </summary>
    /// <param name="car">Автомобиль, для которого необходимо вернуть список работ</param>
    /// <returns>Список работ, когда-либо проводимых с данным автомобилем</returns>
    public static List<Job> EnumerateJobs(Car car) {
      var sb = new StringBuilder();

      void s(string x) {
        sb.Append($"{x}\n");
      }

      s("SELECT timestamp, action_id, jobs.job_id, name");
      s("FROM (actions ");
      s("JOIN jobs ON actions.job_id = jobs.job_id)");
      s("WHERE car_id = @car_id");

      var reader = DbConn.ExecuteReader(sb, new Dictionary<string, object> {{"@car_id", car.Id}});
      var result = new List<Job>();
      while (reader.Read()) {
        var type = new JobType {
          EngineTypes = new[] {car.Model.EngineType},
          Id = (long) reader["job_id"],
          Name = (string) reader["name"],
        };
        var job = new Job {
          Car = car,
          TimeStamp = (DateTime) reader["timestamp"],
          Type = type,
        };
        result.Add(job);
      }

      return result;
    }

    /// <summary>
    /// Возвращает полный список работ
    /// </summary>
    /// <returns>Список когда-либо проводившихся работ</returns>
    public static List<Job> EnumerateJobs() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s(
        "SELECT action_id, timestamp, jobs.job_id, jobs.name AS job_name, cars.car_id, plate, car_model_id, car_models.name AS car_name,");
      s(
        "car_models.engine_type_id AS engine_id, engine_types.name AS engine_name, color, car_producers.car_producer_id,");
      s("car_producers.name AS producer_name");
      s("FROM actions");
      s("JOIN jobs ON actions.job_id = jobs.job_id");
      s("JOIN cars ON cars.car_id = actions.car_id");
      s("JOIN car_models ON cars.model_id = car_models.car_model_id");
      s("JOIN car_producers ON car_models.producer_id = car_producers.car_producer_id");
      s("JOIN engine_types ON car_models.engine_type_id = engine_types.engine_type_id");

      var reader = DbConn.ExecuteReader(sb);
      var result = new List<Job>();

      while (reader.Read()) {
        var producer = new CarProducer() {
          Id = (long) reader["car_producer_id"],
          Name = (string) reader["producer_name"]
        };
        var engine = new EngineType() {
          Id = (long) reader["engine_id"],
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
        var jobType = new JobType() {
          Id = (long) reader["job_id"],
          EngineTypes = null,
          Name = (string) reader["job_name"]
        };
        var job = new Job() {
          Id = (long) reader["action_id"],
          Car = car,
          TimeStamp = (DateTime) reader["timestamp"],
          Type = jobType,
        };
        result.Add(job);
      }

      return result;
    }

    /// <summary>
    /// Заполняет базу данных тестовыми значениями
    /// </summary>
    public static void SeedDb() {
      var r = new Random(42);
      var cars = Car.EnumerateCars();
      var ts = DateTime.Now;
      foreach (var car in cars) {
        var avaliable = JobType.EnumerateJobTypes(car.Model.EngineType);
        foreach (var jobType in avaliable) {
          var count = r.Next(5);
          for (int i = 0; i < count; i++) {
            InsertOne(car.Id, jobType.Id, ts);
            ts += TimeSpan.FromHours(r.Next(200));
            ts += TimeSpan.FromMinutes(r.Next(200));
          }
        }
      }
    }

    /// <summary>
    /// Удаляет работу из списка
    /// </summary>
    /// <param name="id"></param>
    public static void RemoveOne(long id) {
      DbConn.ExecuteNonQuery("DELETE FROM actions WHERE action_id = @aid",
        new Dictionary<string, object> {{"@aid", id}});
    }

    /// <summary>
    /// Обновляет запись о работе в базе данных
    /// </summary>
    /// <param name="id">Идентификатор работы</param>
    /// <param name="carId">Идентификатор автомобиля, с которым проводилась работа</param>
    /// <param name="jobId">Идентификатор типа работы</param>
    /// <param name="timestamp">Дата проведения работы</param>
    public static void ModifyOne(long id, long carId, long jobId, DateTime timestamp) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("UPDATE actions SET");
      s("car_id = @cid,");
      s("job_id = @jid,");
      s("timestamp = @ts");
      s("WHERE action_id = @aid");
      DbConn.ExecuteNonQuery(sb, new Dictionary<string, object> {
        {"@cid", carId},
        {"@jid", jobId},
        {"@ts", timestamp},
        {"@aid", id}
      });
    }
  }
}