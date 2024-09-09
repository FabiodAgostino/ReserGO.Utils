namespace ReserGO.Utils.DTO.Utils
{
    public static class UserTypeConst
        {
            public static (string NAME, int ID) CUSTOMER = ("customer",1);
            public static (string NAME, int ID) GUEST = ("guest",0);
            public static (string NAME, int ID) ADMIN = ("admin",2);

        public static bool HasPermission(this IEnumerable<string> userPermissions, RoleConst permission)
        {
            return userPermissions.Contains(Convert.ToString((int)permission));
        }

    }

    public enum RoleConst
    {
        GUEST,
        CUSTOMER,
        ADMIN
    }

}
