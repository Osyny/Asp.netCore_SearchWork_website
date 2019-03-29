using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.Helper
{
    public static class TypesSortResume
    {
      public static TypeSort Salary { get; set; } = new TypeSort() { Id = SalaryId, NameFild = "По з/п" };
      public static TypeSort Data { get; set; } = new TypeSort() { Id = DataId, NameFild = "По даті" };

      public const string SalaryId = "SalaryId";

      public const string DataId = "DataId";
    }

    public class TypeSort
    {
      public string Id { get; set; }
      public string NameFild { get; set; }
    }
  }
