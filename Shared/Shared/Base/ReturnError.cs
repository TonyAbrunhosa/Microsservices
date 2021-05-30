using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Base
{
    public static class ReturnError
    {
        public static object CreateObjectError(IList<ValidationFailure> errors)
        {
            return errors.Select(x => new { x.PropertyName, x.ErrorMessage });
        }
    }
}
