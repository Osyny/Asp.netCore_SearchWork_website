
using System.Linq;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Search_Work.Helpers
{
  public static class ModelStateExtensions
  {
    public static ResultStatusHelper AllErrors(this ModelStateDictionary modelState, ResultStatusHelper rsh = null)
    {
      if (rsh == null)
      {
        rsh = new ResultStatusHelper(false);
      }


      var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
          .Select(x => new { x.Key, x.Value.Errors });

      foreach (var erroneousField in erroneousFields)
      {
        var fieldKey = erroneousField.Key;
        var fieldErrors = erroneousField.Errors
            .Select(error => new ResultStatusItem(fieldKey, error.ErrorMessage));
        rsh.ResultStatuses.AddRange(fieldErrors);
      }

      return rsh;
    }
  }
}
