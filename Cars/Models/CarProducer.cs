using System.Collections.Generic;
using System.Text;

namespace Cars.Models {
  /// <summary>
  /// Модель описывает производителя автомобиля
  /// Класс содержит методы для работы с базой данных
  /// </summary>
  public class CarProducer {
    /// <summary>
    /// Первичный ключ в базе данных
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название производителя автомобилей
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Создаёт таблицу в базе данных
    /// </summary>
    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("CREATE TABLE car_producers (");
      s("car_producer_id INTEGER PRIMARY KEY AUTOINCREMENT,");
      s("name TEXT NOT NULL");
      s(");");
      DbConn.ExecuteNonQuery(sb);
    }

    /// <summary>
    /// Уничтожает таблицу в базе данных
    /// </summary>
    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS car_producers");
    }

    /// <summary>
    /// Добавляет новую запись о производителе автомобилей
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Присвоенный индентификатор производителя автомобилей</returns>
    public static long InsertOne(string name) {
      return DbConn.ExecuteScalar("INSERT INTO car_producers (name) VALUES (@name); SELECT last_insert_rowid();",
        new Dictionary<string, object> {{"@name", name}});
    }

    /// <summary>
    /// Возвращает список производителей автомобилей в базе данных
    /// </summary>
    /// <returns>Список производителей автомобилей</returns>
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

    /// <summary>
    /// Заполняет базу данных тестовыми значениями
    /// </summary>
    public static void SeedDb() {
      InsertOne("LADA");
      InsertOne("Porsche");
      InsertOne("Volkswagen");
      InsertOne("Kia");
    }

    public override string ToString() {
      return Name;
    }

    public override bool Equals(object obj) {
      switch (obj) {
        case null:
          return false;
        case CarProducer producer:
          return Id == producer.Id;
        default:
          return false;
      }
    }

    /// <summary>
    /// Удаляет запись о производителе автомобилей из базы данных
    /// </summary>
    /// <param name="id"></param>
    public static void RemoveOne(long id) {
      DbConn.ExecuteNonQuery("DELETE FROM car_producers WHERE car_producer_id = @cpid",
        new Dictionary<string, object> {{"@cpid", id}});
    }

    /// <summary>
    /// Обновляет запись о производителе автомобилей в базе данныъ
    /// </summary>
    /// <param name="id">Идентификатор производителя автомобилей</param>
    /// <param name="name">Название производителя автомобилей</param>
    public static void ModifyOne(long id, string name) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("UPDATE car_producers SET");
      s("name = @name");
      s("WHERE car_producer_id = @cpid");
      DbConn.ExecuteNonQuery(sb, new Dictionary<string, object> {
        {"@name", name},
        {"@cpid", id}
      });
    }
  }
}