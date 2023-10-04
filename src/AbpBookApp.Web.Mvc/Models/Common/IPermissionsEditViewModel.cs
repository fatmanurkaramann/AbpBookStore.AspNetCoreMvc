using System.Collections.Generic;
using AbpBookApp.Roles.Dto;

namespace AbpBookApp.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}