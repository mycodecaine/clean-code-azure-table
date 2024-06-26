﻿namespace Cdcn.Webapi
{
    public static class ApiRoutes
    {
        public static class Countries
        {
            public const string Create = "";
            public const string Update = "{countryId:guid}";
            public const string GetById = "{countryId:guid}";
            public const string GetByCode = "{code}";
            public const string Delete = "{countryId:guid}";


        }

        public static class Currencies
        {
            public const string Create = "";
            public const string Delete = "";
            public const string Update = "";
            public const string GetByCode = "/Code/{code}";


        }
    }
}
