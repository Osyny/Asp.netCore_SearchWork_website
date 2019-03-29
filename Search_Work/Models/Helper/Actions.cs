using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Models.Helper
{
    public class Actions
  {
    public static FildAction Additionally { get; set; } = new FildAction() { Id = AdditionallyId, NameFild = "Додатково" };
    public static FildAction Edit { get; set; } = new FildAction() { Id = EditId, NameFild = "редагувати" };
    public static FildAction Delete { get; set; } = new FildAction() { Id = DeleteId, NameFild = "удалити" };
    public static FildAction Send { get; set; } = new FildAction() { Id = SendId, NameFild = "відправити" };
    public static FildAction Print { get; set; } = new FildAction() { Id = PrintId, NameFild = "роздрукувати" };
    public static FildAction Duplikate { get; set; } = new FildAction() { Id = DuplikateId, NameFild = "дублювати" };
    public static FildAction StopPublikate { get; set; } = new FildAction() { Id = StopPublikateId, NameFild = "зупинити публікацію" };
    public static FildAction MakeMain { get; set; } = new FildAction() { Id = MakeMainId, NameFild = "зробити основним" };

    public const string AdditionallyId = "AdditionallyId";
    public const string EditId = "EditId";
    public const string DeleteId = "DeleteId";
    public const string SendId = "SendId";
    public const string PrintId = "PrintId";
    public const string DuplikateId = "DuplikateId";
    public const string StopPublikateId = "StopPublikateId";
    public const string MakeMainId = "MakeMainId";

  }


  public class FildAction
  {
    public string Id { get; set; }
    public string NameFild { get; set; }

  }

}

