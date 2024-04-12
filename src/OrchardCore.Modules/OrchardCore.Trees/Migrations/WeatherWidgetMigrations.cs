using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace OrchardCore.Trees.Migrations;
public class WeatherWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public WeatherWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync("WeatherWidgetPart", part => part
                   .Attachable()
                   );

        await _contentDefinitionManager.AlterTypeDefinitionAsync("WeatherWidget", type => type
                   .Stereotype("Widget")
                   .WithPart("WeatherWidgetPart")
                   );

        return 1;
    }
}

// Migrations/WeatherWidgetMigrations.cs
