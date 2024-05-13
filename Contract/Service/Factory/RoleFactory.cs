using System.Collections.Concurrent;

namespace Contract.Service.Factory
{
    public static class RoleFactory
    {
        private static readonly ConcurrentDictionary<string, int> _roleRegistry = new ConcurrentDictionary<string, int>();

        public static void RegisterRoleType(string roleAction, int permission)
        {
            _roleRegistry.TryAdd(roleAction, permission);
        }

        public static int GetRolePermission(string roleAction)
        {
            _roleRegistry.TryGetValue(roleAction, out int permission);
            return permission;
        }

        public static IEnumerable<int> GetListRolePermission(IEnumerable<string> roleActions)
        {
            foreach (var roleAction in roleActions)
            {
                yield return GetRolePermission(roleAction);
            }
        }

        //public static async Task RegisterRoles()
        //{
        //    var roles = await RoleRepository.GetRolesAsync();
        //    foreach (var role in roles)
        //    {
        //        string roleAction = $"{role.Role}_{role.Action}";
        //        RegisterRoleType(roleAction, role.Permission);
        //    }
        //}

        public static void UnregisterRoleType(string roleAction)
        {
            _roleRegistry.TryRemove(roleAction, out _);
        }

        public static void UpdateRolePermission(string roleAction, int newPermission)
        {
            _roleRegistry.TryUpdate(roleAction, newPermission, _roleRegistry[roleAction]);
        }

        public static IEnumerable<int> GetPermissionArray(int role)
        {
            string binaryString = Convert.ToString((long)role, 2).PadLeft(32, '0');

            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                {
                    yield return _roleRegistry.Values.ElementAt(i);
                }
            }
        }

        //public static async Task<IEnumerable<Role>> ConvertRole(decimal role)
        //{
        //    string[] permissions = PermissionArray(role);
        //    if (permissions.Length == 0)
        //    {
        //        throw new NotFoundException("Role is invalid!");
        //    }
        //    return await RoleRepository.GetRolesByPermissionsAsync(permissions);
        //}

        //public static async Task<IEnumerable<Role>> ConvertRoleFromRangeId(IEnumerable<int> roleIds)
        //{
        //    // Assuming roleIds can be validated elsewhere:
        //    // foreach (int roleId in roleIds)
        //    // {
        //    //     // CheckValidId(roleId); // Implement validation if needed
        //    // }
        //    return await RoleRepository.GetRolesByRangeIdAsync(roleIds);
        //}

        //private static void CheckValidId(int roleId)
        //{
        //    // Implement validation for role IDs if necessary
        //}
    }
}
