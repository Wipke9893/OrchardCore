using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Trees.Models;
using OrchardCore.Trees.ViewModels;
using YesSql;

namespace OrchardCore.Trees.Drivers;
public class MembersListPartDisplayDriver : ContentPartDisplayDriver<MembersListPart>
{
    private readonly ISession _session;

    public MembersListPartDisplayDriver(ISession session)
    {
        _session = session;
    }

    public override IDisplayResult Display(MembersListPart model)
    {
        return Initialize<MembersListPartViewModel>("MembersListPart", async model =>
        {
            model.ContentItems = await _session.Query<ContentItem, ContentItemIndex>(x => x.ContentType == "TeamMember" && x.Published)
            .Take(50)
            .ListAsync();
        }).Location("Content");
    }
}
