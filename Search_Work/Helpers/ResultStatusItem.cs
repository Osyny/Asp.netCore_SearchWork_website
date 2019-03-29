using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Helpers
{
    public class ResultStatusItem
    {
    public ResultStatusItem(string fieldKey, string errorErrorMessage)
    {
      this.Value = errorErrorMessage;
      Key = fieldKey;
    }

    public string Key { get; set; }
    public string Value { get; set; }
  }
}
