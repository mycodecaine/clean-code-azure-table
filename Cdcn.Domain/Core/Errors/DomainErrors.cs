﻿using Cdcn.Domain.Core.Primitives;

namespace Cdcn.Domain.Core.Errors
{
    public static class DomainErrors
    {
        public static class General
        {
            public static Error UnProcessableRequest => new Error(
                "General.UnProcessableRequest",
                "The server could not process the request.");

            public static Error ServerError => new Error("General.ServerError", "The server encountered an unrecoverable error.");
        }

        public static class Currency
        {
            public static Error DuplicateCode => new Error("Currency.DuplicateCode", "Duplicate Code");
            public static Error CurrencyNotExist => new Error("Currency.CurrencyNotExist", "Currency Not Exist");
        }
    }
}
