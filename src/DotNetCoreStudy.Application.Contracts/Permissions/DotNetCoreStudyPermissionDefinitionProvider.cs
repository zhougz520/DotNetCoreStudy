using DotNetCoreStudy.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DotNetCoreStudy.Permissions;

public class DotNetCoreStudyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DotNetCoreStudyPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DotNetCoreStudyPermissions.MyPermission1, L("Permission:MyPermission1"));
        var booksPermission = myGroup.AddPermission(DotNetCoreStudyPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(DotNetCoreStudyPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(DotNetCoreStudyPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(DotNetCoreStudyPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = myGroup.AddPermission(DotNetCoreStudyPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(DotNetCoreStudyPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(DotNetCoreStudyPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(DotNetCoreStudyPermissions.Authors.Delete, L("Permission:Authors.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DotNetCoreStudyResource>(name);
    }
}
