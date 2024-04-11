using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Taxonomies.Indexing;
using OrchardCore.Trees.Indexes;
using OrchardCore.Trees.Models;
using OrchardCore.Trees.ViewModels;
using YesSql;

namespace OrchardCore.Trees.Drivers;


public class TreesListPartDisplayDriver : ContentPartDisplayDriver<TreesListPart>
{
    private readonly ISession _session;

    public TreesListPartDisplayDriver(ISession session)
    {
        _session = session;
    }

    public override IDisplayResult Display(TreesListPart model)
    {
        return Initialize<TreesListViewModel>("TreesListPart", async model =>
        {
            model.ContentItems = await _session.Query<ContentItem, ContentItemIndex>(x => x.ContentType == "TreeFarm" && x.Published && x.DisplayText == "Retail")
            //.With<TaxonomyIndex>(x => x.ContentType == "TreeFarm" && x.ContentField == "LeafType" && x.TermContentItemId == "42kg1gaws51fm5a5jmagnpeqwe")
            .Take(50)
            .ListAsync();
        }).Location("Content");
    }
}
