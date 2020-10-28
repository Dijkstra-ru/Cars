using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Cars.Models {
  /// <summary>
  /// Модель описывает вид работ, выполняемых с автомобилями
  /// Класс содержит методы для работы с базой данных
  /// </summary>
  public class JobType {
    /// <summary>
    /// Первичный ключ в базе данных
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Виды двигателей, для которых выполняется данный вид работ
    /// </summary>
    public EngineType[] EngineTypes { get; set; }

    /// <summary>
    /// Название работы
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Создаёт таблицу в базе данны
    /// </summary>
    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
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

    /// <summary>
    /// Уничтожает таблицу в базе данных
    /// </summary>
    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS link__jobs__engine_types");
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS jobs");
    }

    /// <summary>
    /// Добавляет запись о виде работ в базу данных
    /// </summary>
    /// <param name="engineTypes">Типы двигателей, для которых проводится данный вид работ</param>
    /// <param name="name">Название работы</param>
    /// <returns>Присвоенный идентификатор вида работ</returns>
    public static long InsertOne(EngineType[] engineTypes, string name) {
      var newId = DbConn.ExecuteScalar("INSERT INTO jobs (name) VALUES (@name); SELECT last_insert_rowid();",
        new Dictionary<string, object> {{"@name", name}});
      foreach (var engineType in engineTypes) {
        var sql = "INSERT INTO link__jobs__engine_types (job_id, engine_type_id) VALUES(@job_id, @eng_id)";
        DbConn.ExecuteNonQuery(sql, new Dictionary<string, object> {{"@job_id", newId}, {"@eng_id", engineType.Id}});
      }

      return newId;
    }

    /// <summary>
    /// Возвращает список видов работ, выполняемых с конкретным видом двигателя
    /// </summary>
    /// <param name="type">Вид двигателя, для которого необходим список видов работ</param>
    /// <returns></returns>
    public static List<JobType> EnumerateJobTypes(EngineType type) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("SELECT * FROM jobs");
      s("INNER JOIN link__jobs__engine_types ON jobs.job_id = link__jobs__engine_types.job_id");
      s("WHERE engine_type_id = @eid");
      var reader = DbConn.ExecuteReader(sb, new Dictionary<string, object> {{"@eid", type.Id}});
      var result = new List<JobType>();
      while (reader.Read()) {
        result.Add(new JobType {
          Id = (long) reader["job_id"],
          Name = (string) reader["name"],
          EngineTypes = new[] {type},
        });
      }

      return result;
    }

    /// <summary>
    /// Возвращает полный список видов работ с автомобилями
    /// </summary>
    /// <returns>Полный список видов работ с автомобилями</returns>
    public static List<JobType> EnumerateJobTypes() {
      var possibleEngineTypes = EngineType.EnumerateTypes();
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s(
        "SELECT jobs.job_id, jobs.name, COALESCE(GROUP_CONCAT(engine_types.engine_type_id,','), '') as engine_types FROM jobs");
      s("LEFT OUTER JOIN link__jobs__engine_types ON jobs.job_id = link__jobs__engine_types.job_id");
      s("LEFT OUTER JOIN engine_types ON link__jobs__engine_types.engine_type_id = engine_types.engine_type_id");
      s("GROUP BY jobs.job_id");
      var reader = DbConn.ExecuteReader(sb);
      var result = new List<JobType>();
      while (reader.Read()) {
        var typesString = (string) reader["engine_types"];
        var types = new EngineType[0];
        if (typesString != "") {
          types = typesString.Split(',')
            .Select(x => possibleEngineTypes.First(y => y.Id.ToString() == x))
            .ToArray();
        }

        result.Add(new JobType {
          Id = (long) reader["job_id"],
          Name = (string) reader["name"],
          EngineTypes = types,
        });
      }

      return result;
    }

    /// <summary>
    /// Заполняет базу данных тестовыми значениями
    /// </summary>
    public static void SeedDb() {
      var engines = EngineType.EnumerateTypes();
      InsertOne(new[] {engines[0], engines[1]}, "Прочистка форсунок");
      InsertOne(new[] {engines[0], engines[1]}, "Полировка поршней");
      InsertOne(new[] {engines[0]}, "Прочистка турбокомпрессора");
      InsertOne(new[] {engines[1]}, "Настройка карбюратора");
      InsertOne(new[] {engines[2]}, "Зарядка аккумулятора");
    }

    public override string ToString() {
      return Name;
    }

    public override bool Equals(object obj) {
      switch (obj) {
        case null:
          return false;
        case JobType jobType:
          return Id == jobType.Id;
        default:
          return false;
      }
    }

    /// <summary>
    /// Удаляет запись о виде работ из базы данных
    /// </summary>
    /// <param name="id"></param>
    public static void RemoveOne(long id) {
      DbConn.ExecuteNonQuery("DELETE FROM jobs WHERE job_id = @jid",
        new Dictionary<string, object> {{"@jid", id}});

    }

    /// <summary>
    /// Обновляет запись о типе работ в базе данных
    /// </summary>
    /// <param name="id">Идентификатор типа работ</param>
    /// <param name="engineTypes">Типы двигателей, для которых выполняется данный тип работ</param>
    /// <param name="name">Название типа работ</param>
    public static void ModifyOne(long id, EngineType[] engineTypes, string name) {
      DbConn.ExecuteNonQuery("UPDATE jobs SET name = @name WHERE job_id = @jid",
        new Dictionary<string, object> {{"@name", name}, {"@jid", id}});
      DbConn.ExecuteNonQuery("DELETE FROM link__jobs__engine_types WHERE job_id = @jid",
        new Dictionary<string, object> {{"@jid", id}});
      foreach (var engineType in engineTypes) {
        var sql = "INSERT INTO link__jobs__engine_types (job_id, engine_type_id) VALUES(@job_id, @eng_id)";
        DbConn.ExecuteNonQuery(sql, new Dictionary<string, object> {{"@job_id", id}, {"@eng_id", engineType.Id}});
      }
    }
  }
}