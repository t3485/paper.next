﻿using Paper.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Paper.Permissions
{
    public class PaperPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PaperPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(PaperPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PaperResource>(name);
        }
    }
}
