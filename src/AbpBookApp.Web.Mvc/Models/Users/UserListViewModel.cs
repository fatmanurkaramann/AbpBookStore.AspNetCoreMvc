using System.Collections.Generic;
using AbpBookApp.Roles.Dto;

namespace AbpBookApp.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
