using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin.Models;
using OrchardCore.Data;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation.Core;
using OrchardCore.Notifications.Activities;
using OrchardCore.Notifications.Drivers;
using OrchardCore.Notifications.Handlers;
using OrchardCore.Notifications.Indexes;
using OrchardCore.Notifications.Migrations;
using OrchardCore.Notifications.Models;
using OrchardCore.Notifications.Services;
using OrchardCore.ResourceManagement;
using OrchardCore.Security.Permissions;
using OrchardCore.Users.Models;
using OrchardCore.Workflows.Helpers;
using YesSql.Filters.Query;

namespace OrchardCore.Notifications;

public class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<INotificationMethodProviderAccessor, NotificationMethodProviderAccessor>();

        services.AddDataMigration<NotificationMigrations>();
        services.AddIndexProvider<NotificationIndexProvider>();
        services.AddScoped<INotificationsAdminListQueryService, DefaultNotificationsAdminListQueryService>();
        services.Configure<StoreCollectionOptions>(o => o.Collections.Add(NotificationConstants.NotificationCollection));
        services.AddScoped<INotificationEvents, CoreNotificationEventsHandler>();

        services.AddScoped<IPermissionProvider, NotificationPermissionsProvider>();
        services.AddScoped<IDisplayDriver<ListNotificationOptions>, ListNotificationOptionsDisplayDriver>();
        services.AddScoped<IDisplayDriver<Notification>, NotificationDisplayDriver>();
        services.AddTransient<INotificationAdminListFilterProvider, DefaultNotificationsAdminListFilterProvider>();
        services.AddSingleton<INotificationAdminListFilterParser>(sp =>
        {
            var filterProviders = sp.GetServices<INotificationAdminListFilterProvider>();
            var builder = new QueryEngineBuilder<Notification>();
            foreach (var provider in filterProviders)
            {
                provider.Build(builder);
            }

            var parser = builder.Build();

            return new DefaultNotificationAdminListFilterParser(parser);
        });

        services.AddTransient<IConfigureOptions<ResourceManagementOptions>, NotificationOptionsConfiguration>();
        services.AddScoped<IDisplayDriver<User>, UserNotificationPreferencesPartDisplayDriver>();
        services.AddScoped<IDisplayDriver<Navbar>, NotificationNavbarDisplayDriver>();
    }
}

[RequireFeatures("OrchardCore.Workflows")]
public class WorkflowsStartup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddActivity<NotifyUserTask, NotifyUserTaskDisplayDriver>();
    }
}

[RequireFeatures("OrchardCore.Workflows", "OrchardCore.Users", "OrchardCore.Contents")]
public class UsersWorkflowStartup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddActivity<NotifyContentOwnerTask, NotifyContentOwnerTaskDisplayDriver>();
    }
}

[Feature("OrchardCore.Notifications.Email")]
public class EmailNotificationsStartup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<INotificationMethodProvider, EmailNotificationProvider>();
    }
}
