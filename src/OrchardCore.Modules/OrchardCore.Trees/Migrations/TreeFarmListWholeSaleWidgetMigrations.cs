using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace OrchardCore.Trees.Migrations;
public class TreeFarmListWholeSaleWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public TreeFarmListWholeSaleWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }
    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync("TreeListWholeSalePart", part => part
            .Attachable()
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync("WholeSaleTreeList", type => type
            .Stereotype("Widget")
            .WithPart("TreeListWholeSalePart")
        );

        return 1;
    }
}
