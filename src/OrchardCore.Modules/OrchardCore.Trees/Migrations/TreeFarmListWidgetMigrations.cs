using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace OrchardCore.Trees.Migrations;

public class TreeFarmListWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public TreeFarmListWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync("TreesListPart", part => part
            .Attachable()
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync("MyTreeList", type => type
            .Stereotype("Widget")
            .WithPart("TreesListPart")
        );

        return 1;
    }
}
