namespace HRSolutions.Domain.Errors
{
    public static class EntityErrors
    {
        public const string Duplicated = "The entity already exists";
        public const string NotFound = "The entity does not exists";
        public static string InvalidInputParam(string property) => string.Format("The parameter {0} is invald", property);

    }
}
