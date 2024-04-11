using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace OrchardCore.Trees.Migrations;
public class MembersListWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public MembersListWidgetMigrations(IContentDefinitionManager contentDefinitionManager)
    {
        _contentDefinitionManager = contentDefinitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync("MembersListPart", part => part
             .Attachable()    
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync("TeamMembersList", type => type
                .Stereotype("Widget")
                .WithPart("MembersListPart")
               );

        return 1;
    }

}
