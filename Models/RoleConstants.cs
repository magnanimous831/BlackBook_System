namespace BlackBook_System.Models
{
    public static class RoleConstants
    {
        public const string Admin = "Admin";
        public const string Principal = "Principal";
        public const string DeputyPrincipal = "DeputyPrincipal";
        public const string Teacher = "Teacher";

        public static readonly string[] AllRoles = new[]
        {
            Admin,
            Principal,
            DeputyPrincipal,
            Teacher
        };
    }
} 