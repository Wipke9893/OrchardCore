using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Trees.Indexes;
using YesSql.Sql;

namespace OrchardCore.Trees.Migrations;
public class TreeFarmPartMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public TreeFarmPartMigrations(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync("TreeFarmPart", part => part
        .WithField<TextField>("GrowType", field => field
        .WithEditor("TextArea")
        .WithSettings(new TextFieldSettings
        {
            Hint = "Trees Grow Type",
        }))
    );
        await SchemaBuilder.CreateMapIndexTableAsync<TreeFarmPartIndex>(table => table
         .Column<string>("ScientificName", column => column.WithLength(50))
         .Column<int>("Zone", column => column.WithLength(5))
         .Column<string>("ContentItemId", column => column.WithLength(26))
         );

        await _contentDefinitionManager.AlterTypeDefinitionAsync("TreeFarm", type => type
        .Creatable()
        .Listable()
        .WithPart("TreeFarmPart")
        );
        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await _contentDefinitionManager.AlterTypeDefinitionAsync("TreeFarmWidget", type => type
       .WithPart("TreeFarmPart")
       .Stereotype("Widget")
       );
        return 2;
    }
}
