using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Text;

namespace Cars.Models {
  /// <summary>
  /// Модель описывает тип двигателя автомобиля
  /// Класс содержит методы для работы с базой данных
  /// </summary>
  public class EngineType {
    /// <summary>
    /// Первичный ключ в базе данных
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// Цвет, которым кодируется вид двигателя в таблицах
    /// </summary>
    public Color ColorEncoding { get; set; }
    /// <summary>
    /// Название типа двигателя
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Создаёт таблицу в базе данных
    /// </summary>
    public static void CreateTable() {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("CREATE TABLE engine_types (");
      s("engine_type_id INTEGER PRIMARY KEY,");
      s("color INTEGER NOT NULL,");
      s("name TEXT NOT NULL");
      s(")");
      DbConn.ExecuteNonQuery(sb);
    }
    /// <summary>
    /// Уничтожает таблицу в базе данных
    /// </summary>
    public static void DropTable() {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS engine_types");
    }
    /// <summary>
    /// Добавляет новую запись о типе двигателя в базу данных
    /// </summary>
    /// <param name="colorEncoding">Цвет, которым тип двигателя кодируется в таблице</param>
    /// <param name="name">Название типа двигателя</param>
    /// <returns>Присвоенный идентификатор типа двигателя</returns>
    public static long InsertOne(Color colorEncoding, string name) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n");
      s("INSERT INTO engine_types");
      s("(color, name)");
      s("VALUES (@color, @name);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb,
        new Dictionary<string, object> {{"@color", colorEncoding.ToArgb()}, {"@name", name}});
    }
    /// <summary>
    /// Возвращает список типов двигателей в базе данных
    /// </summary>
    /// <returns>Список типов двигателей из базы данных</returns>
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
    /// <summary>
    /// Заполняет базу данных тестовыми значениями
    /// </summary>
    public static void SeedDb() {
      InsertOne(Color.Yellow, "Дизельный");
      InsertOne(Color.GreenYellow, "Бензиновый");
      InsertOne(Color.Salmon, "Электрический");
    }

    public override string ToString() {
      return Name;
    }

    public override bool Equals(object obj) {
      switch (obj) {
        case null:
          return false;
        case EngineType engineType:
          return Id == engineType.Id;
        default:
          return false;
      }
    }
    /// <summary>
    /// Обновляет запись о типе двигателя в базе данных
    /// </summary>
    /// <param name="id">Идентификатор типа двигателя</param>
    /// <param name="color">Цвет, которым тип двигателя кодируется в таблицах</param>
    /// <param name="name">Название типа двигателя</param>
    public static void ModifyOne(long id, Color color, string name) {
      var sb = new StringBuilder();
      void s(string x) => sb.Append($"{x}\n"); 
      s("UPDATE engine_types SET");
      s("name = @name,");
      s("color = @color");
      s("WHERE engine_type_id = @etid");
      DbConn.ExecuteNonQuery(sb, new Dictionary<string, object> {
        {"@name", name},
        {"@color", color.ToArgb()},
        {"@etid", id }
      });
    }
    /// <summary>
    /// Удаляет запись о типе двигателя из базы данных
    /// </summary>
    /// <param name="id">Идентификатор типа двигателя</param>
    public static void RemoveOne(long id) {
      DbConn.ExecuteNonQuery("DELETE FROM engine_types WHERE engine_type_id = @etid",
        new Dictionary<string, object> { { "@etid", id } });
    }

    public override int GetHashCode() {
      return (int) Id;
    }
  }
}