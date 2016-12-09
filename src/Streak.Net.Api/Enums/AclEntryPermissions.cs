namespace Streak.Net.Api.Enums
{
    public class AclEntryPermissions
    {
        private AclEntryPermissions(string value) { Value = value; }
        public string Value { get; set; }
        public static AclEntryPermissions EditAllPermissionSet => new AclEntryPermissions("__editAllPermissionSet__");
        public static AclEntryPermissions AdminPermissionSet => new AclEntryPermissions("__adminPermissionSet__");
        public static AclEntryPermissions EditAssignedBoxCreatePermissionSet => new AclEntryPermissions("__editAssignedBoxCreatePermissionSet__");
        public static AclEntryPermissions EditAssignedPermissionSet => new AclEntryPermissions("__editAssignedPermissionSet__");
        public static AclEntryPermissions ViewAllPermissionSet => new AclEntryPermissions("__viewAllPermissionSet__");
        public static AclEntryPermissions ViewAssignedPermissionSet => new AclEntryPermissions("__viewAssignedPermissionSet__");
    }
}
