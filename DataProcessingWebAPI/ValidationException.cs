using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DataProcessingWebAPI
{
    public class ValidationException<TValidationError> : Exception
    {
        public List<TValidationError> Exceptions;
        public ValidationException(string message) : base(message)
        {
            Exceptions = new List<TValidationError>();
        }

        public ValidationException(string message, List<TValidationError> Items) : base(message)
        {
            Exceptions = Items;
        }

        public ValidationException<TValidationError> AddDataList(List<TValidationError> Items)
        {
            Exceptions.AddRange(Items);
            return this;
        }
    }
}