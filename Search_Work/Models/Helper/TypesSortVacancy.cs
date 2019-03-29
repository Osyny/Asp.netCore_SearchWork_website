using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.Helper
{
  public static class TypesSortVacancy
  {
    public static TypeSort Data { get; set; } = new TypeSort() { Id = DataId, NameFild = "По даті" };
    public static TypeSort Response { get; set; } = new TypeSort() { Id = ResponseId, NameFild = "По відзивам" };
    public static TypeSort NameVacancy { get; set; } = new TypeSort() { Id = NameId, NameFild = "По назві" };
    //public static TypeSort Region { get; set; } = new TypeSort() { Id = NameId, Name = "По регіону" };


    public const string ResponseId = "ResponseId";
    public const string DataId = "DataId";
    public const string NameId = "NameId";
    //public const string RegionId = "RegionId";

  }

  
}
