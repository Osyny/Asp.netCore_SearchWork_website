using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Helpers
{
    public class ResultStatusHelper
    {
    public ResultStatusHelper(bool success = false, string returnUrl = null, string message = null)
    {
      this.ReturnUrl = returnUrl;
      this.ResultStatuses = new List<ResultStatusItem>();
      this.Success = success;
      this.Message = message;
    }

    public string ReturnUrl { get; set; }

    public bool Success { get; set; }

    public string Message { get; set; }

    public List<ResultStatusItem> ResultStatuses { get; }
  }
}
