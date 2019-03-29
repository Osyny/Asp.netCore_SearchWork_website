
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.Helper
{
    public static class FieldsMonth
  {

    public static FildMonth Year { get; set; } = new FildMonth() { Id = YearId, NameFild = "за pік" };
    public static FildMonth Month { get; set; } = new FildMonth() { Id = MonthId, NameFild = "за місяць" };
    public static FildMonth Weеk { get; set; } = new FildMonth() { Id = WeеkId, NameFild = "за 7 днів" };
    public static FildMonth Day { get; set; } = new FildMonth() { Id = DayId, NameFild = "за день" };

    public const string YearId = "YearId";

    public const string MonthId = "MonthId";

    public const string WeеkId = "WeеkId";

    public const string DayId = "DayId";



  }


  public class FildMonth
  {
    public string Id { get; set; }
    public string NameFild { get; set; }

  }
}


