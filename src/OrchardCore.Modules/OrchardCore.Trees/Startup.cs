using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Data;
using OrchardCore.Modules;
using OrchardCore.Trees.Models;
using OrchardCore.Trees.Migrations;
using OrchardCore.Trees.Drivers;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Trees.Indexes;
using OrchardCore.Contents.Services;
using OrchardCore.Trees.Services;

namespace OrchardCore.Trees;

public class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        // EmailContentType
        services.AddContentPart<EmailPart>()
            .UseDisplayDriver<EmailPartDisplayDriver>();
        services.AddDataMigration<EmailPartMigrations>();
        services.AddIndexProvider<EmailPartIndexProvider>();
        // EmailContentType
        // TreeFarmContentType
        services.AddContentPart<TreeFarmPart>()
            .UseDisplayDriver<TreeFarmPartDisplayDriver>();
        services.AddDataMigration<TreeFarmPartMigrations>();
        services.AddIndexProvider<TreeFarmPartIndexProvider>();
        // TreeFarmContentType
        // Widgets
        services.AddContentPart<TreesListPart>()
            .UseDisplayDriver<TreesListPartDisplayDriver>();
        services.AddDataMigration<TreeFarmListWidgetMigrations>();

        services.AddContentPart<TreeListWholeSalePart>()
            .UseDisplayDriver<TreeListWholeSalePartDisplayDriver>();
        services.AddDataMigration<TreeFarmListWholeSaleWidgetMigrations>();


          services.AddContentPart<MembersListPart>()
                .UseDisplayDriver<MembersListPartDisplayDriver>();
        services.AddDataMigration<MembersListWidgetMigrations>();

        services.AddContentPart<WeatherWidgetPart>()
            .UseDisplayDriver<WeatherWidgetPartDisplayDriver>();
        services.AddDataMigration<WeatherWidgetMigrations>();
        // Widgets
        // testing api calls
        services.AddHttpClient();
        services.AddHttpContextAccessor();
        // testing api calls
        // Services for the Trees module Filtering
        services.AddTransient<IContentsAdminListFilterProvider, TreeListFilter>();
        // Services for the Trees module Filtering


    }
}
