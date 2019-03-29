using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.DefaultData
{
    public class ExperienceOfWorkDefault
    {
    public static Guid TwoYears = Guid.Parse("963380f5-2d0d-486f-84c8-f0067046655d");
    public static Guid ThreeYears = Guid.Parse("da7c84eb-a0ef-4867-bbb8-89d20559af80");
    public static Guid FiveYears = Guid.Parse("34c1d4e6-d963-460d-ae8b-80e8ccfad5c0");

    public static DateTime TwoYearsValue = new DateTime().AddYears(2);
    public static DateTime ThreeYearsValue = new DateTime().AddYears(3);
    public static DateTime FiveYearsValue = new DateTime().AddYears(5);
  }
}
