using System.Collections.Generic;
using AbpBookApp.Roles.Dto;

namespace AbpBookApp.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
