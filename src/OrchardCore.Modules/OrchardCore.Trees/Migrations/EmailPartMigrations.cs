using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;
using OrchardCore.Trees.Indexes;

namespace OrchardCore.Trees.Migrations;

public class EmailPartMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public EmailPartMigrations(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync("EmailPart", part => part
        .Attachable()
        .WithDescription("Store Employee Email")
        );

        await SchemaBuilder.CreateMapIndexTableAsync<EmailPartIndex>(table => table
        .Column<string>("Email", column => column.WithLength(50))
        .Column<string>("ContentItemId", column => column.WithLength(26))
        );

        return 1;
    }
}
