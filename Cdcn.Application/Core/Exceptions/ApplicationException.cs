using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdcn.Domain.Core.Primitives;
using FluentValidation.Results;

namespace Cdcn.Application.Core.Exceptions
{
    public sealed class ApplicationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="failures">The collection of validation failures.</param>
        public ApplicationException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation failures has occurred.") =>
            Errors = failures
                .Distinct()
                .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage))
                .ToList();

        public ApplicationException(Error error)
           : base(error.Message)
           => Error = error;

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        public IReadOnlyCollection<Error> Errors { get; }
    }
}
