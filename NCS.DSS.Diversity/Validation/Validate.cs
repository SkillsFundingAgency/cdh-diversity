﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NCS.DSS.Diversity.Validation
{
    public class Validate
    {
        public List<ValidationResult> ValidateResource<T>(T resource)
        {
            var context = new ValidationContext(resource, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(resource, context, results, true);

            return isValid ? null : results;
        }
    }
}
