namespace Contract.DTOs.RoleDTO
{
    public class UpdateRoleDTO : IRoleDTO
    {
        public string Member { get; set; }
        public int Value { get; set; }
        public int Permission { get; set; }
        public string Action { get; set; }
    }
}
