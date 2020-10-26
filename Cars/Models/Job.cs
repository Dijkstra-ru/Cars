using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Cars.Models {
  public class Job {
    public Car Car { get; set; }
    public DateTime TimeStamp { get; set; }
    public JobType Type { get; set; }

    public static void CreateTable()
    {
      var sb = new StringBuilder();

      void s(string x)
      {
        sb.Append($"{x}\n");
      }

      s("CREATE TABLE actions (");
      s("action_id INTEGER PRIMARY KEY,");
      s("car_id INTEGER NOT NULL,");
      s("job_id INTEGER NOT NULL,");
      s("timestamp DATETIME NOT NULL,");
      s("FOREIGN KEY (car_id) REFERENCES cars (car_id),");
      s("FOREIGN KEY (job_id) REFERENCES jobs (job_id)");
      s(")");
      DbConn.ExecuteNonQuery(sb);
    }

    public static void DropTable()
    {
      DbConn.ExecuteNonQuery("DROP TABLE IF EXISTS actions");
    }

    public static long InsertOne(long carId, long jobId, DateTime timestamp) {
      var sb = new StringBuilder();

      void s(string x)
      {
        sb.Append($"{x}\n");
      }

      s("INSERT INTO actions (car_id, job_id, timestamp)");
      s("VALUES (@car_id, @job_id, @timestamp);");
      s("SELECT last_insert_rowid();");
      return DbConn.ExecuteScalar(sb, new Dictionary<string, object>() {
        {"@car_id", carId},
        {"@job_id", jobId},
        {"@timestamp", timestamp}
      });
    }

    public static List<Job> EnumerateJobs(Car car)
    {
      var sb = new StringBuilder();

      void s(string x)
      {
        sb.Append($"{x}\n");
      }

      s("SELECT timestamp, action_id, jobs.job_id, name");
      s("FROM (actions ");
      s("JOIN jobs ON actions.job_id = jobs.job_id)");
      s("WHERE car_id = @car_id");

      var reader = DbConn.ExecuteReader(sb, new Dictionary<string, object> {{"@car_id", car.Id} });
      var result = new List<Job>();
      while (reader.Read()) {
        var type = new JobType {
          EngineTypes = new[]{ car.Model.EngineType},
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
            ts += TimeSpan.FromHours(1);
          }
        }
      }
    }

  }
}