namespace Tawreed.DAL.Consts;

public static class Permissions
{
    public static string Type { get; } = "permissions";


    // 1. ADMIN - USERS MANAGEMENT

    public const string GetUsers = "users:read";
    public const string SuspendUsers = "users:suspend";
    public const string ReactivateUsers = "users:reactivate";
    public const string ResetPasswordUsers = "users:reset-password";

    // 2. ADMIN - SUPPLIERS VETTING

    public const string GetSuppliers = "suppliers:read";
    public const string ApproveSuppliers = "suppliers:approve";
    public const string RejectSuppliers = "suppliers:reject";
    public const string SuspendSuppliers = "suppliers:suspend";
    public const string ReactivateSuppliers = "suppliers:reactivate";

    // 3. ADMIN & BUYER & SUPPLIER - ORDERS
    public const string Getorders = "orders:read";
    public const string CreateOrders = "orders:create";
    public const string UpdateOrders = "orders:update";
    public const string ForceCloseOrders = "orders:force-close";
    public const string JoinOrders = "orders:join";
    public const string LeaveOrders = "orders:leave";
    public const string AcceptOrders = "orders:accept";
    public const string DeclineOrders = "orders:decline";

    // 4. ADMIN & PUBLIC - CATEGORIES
    public const string GetCategories = "categories:read";
    public const string CreateCategories = "categories:create";
    public const string UpdateCategories = "categories:update";
    public const string ActivateCategories = "categories:activate";
    public const string DeactivateCategories = "categories:deactivate";
    public const string DeleteCategories = "categories:delete";


    // 5. ADMIN & PUBLIC - REGIONS
    public const string GetRegions = "regions:read";
    public const string CreateRegions = "regions:create";
    public const string UpdateRegions = "regions:update";
    public const string DeleteRegions = "regions:delete";
    public const string ToggleRegions = "regions:toggle";


    // 6. SUPPLIER & PUBLIC - PRODUCTS & TIERS
    public const string GetProducts = "products:read";
    public const string CreateProducts = "products:create";
    public const string UpdateProducts = "products:update";
    public const string DeleteProducts = "products:delete";
    public const string ManageTiersProducts = "products:manage-tiers";

    // 7. SUPPLIER - DELIVERIES

    public const string GetDeliveries = "deliveries:read";
    public const string UpdateStatusDeliveries = "deliveries:update-status";


    // 8. GROUP ORDERS
    public const string GetGroupOrders = "group-orders:read";
    public const string CreateGroupOrders = "group-orders:create";
    public const string UpdateStatusGroupOrders = "group-orders:update-status";
    public const string DeleteGroupOrders = "group-orders:delete";

    // 9. DASHBOARDS & PROFILES
    public const string ViewAdminDashboard = "dashboard:admin";
    public const string ViewBuyerDashboard = "dashboard:buyer";
    public const string ViewSupplierDashboard = "dashboard:supplier";

    public static IList<string?> GetAllPermissions() =>
        typeof(Permissions).GetFields().Select(x => x.GetValue(x) as string).ToList();
}