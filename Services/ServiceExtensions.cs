using Microsoft.Extensions.DependencyInjection;
using Services.ClassTable.Customer;
using Services.ClassTable.FuncInRole;
using Services.ClassTable.Function;
using Services.ClassTable.Module;
using Services.ClassTable.Role;
using Services.ClassTable.User;
using Services.ClassTable.UserInRole;

namespace Services
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IModuleService, ModuleService>();
            service.AddScoped<IFunctionService, FunctionService>();
            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IUserInRoleService, UserInRoleService>();
            service.AddScoped<IFuncInRoleService, FuncInRoleService>();
        }
    }
}
