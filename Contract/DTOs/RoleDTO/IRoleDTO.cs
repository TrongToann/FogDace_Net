﻿namespace Contract.DTOs.RoleDTO
{
    public interface IRoleDTO
    {
        public string Member { get; set; }
        public int Value { get; set; }
        public int Permission { get; set; }
        public string Action { get; set; }
    }
}
