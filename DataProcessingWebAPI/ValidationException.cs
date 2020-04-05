using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DataProcessingWebAPI
{
    /// <summary>
    /// Class that allows to process validation exceptions of any sub datatype
    /// </summary>
    /// <typeparam name="TValidationError">Can by any type from string to object</typeparam>
    public class ValidationException<TValidationError> : Exception
    {
        /// <summary>
        /// The internal array that contains the "Exceptions"
        /// </summary>
        public List<TValidationError> Exceptions;

        /// <summary>
        /// Constructor that initializes the underlying Exception class
        /// </summary>
        /// <param name="message"></param>
        public ValidationException(string message) : base(message)
        {
            Exceptions = new List<TValidationError>();
        }

        /// <summary>
        /// Constructor that takes a message and a list of your own exceptions
        /// </summary>
        /// <param name="message"></param>
        /// <param name="Items"></param>
        public ValidationException(string message, List<TValidationError> Items) : base(message)
        {
            Exceptions = Items;
        }

        /// <summary>
        /// Adds a list of exceptions to the internal list
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public ValidationException<TValidationError> AddDataList(List<TValidationError> Items)
        {
            Exceptions.AddRange(Items);
            return this;
        }
    }
}