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
        //Widgets

        // testing api calls
        services.AddHttpClient();

    }
}
