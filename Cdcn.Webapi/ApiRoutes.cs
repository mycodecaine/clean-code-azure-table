namespace Cdcn.Webapi
{
    public static class ApiRoutes
    {
        public static class Countries
        {
            public const string Create = "";
            public const string Update = "{courtCaseId:guid}";
            public const string GetById = "{courtCaseId:guid}";
           

        }
    }
}
