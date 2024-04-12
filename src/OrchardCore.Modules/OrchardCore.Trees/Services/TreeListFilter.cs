using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.Contents.Services;
using YesSql;
using YesSql.Filters.Query;

namespace OrchardCore.Trees.Services;
public class TreeListFilter : IContentsAdminListFilterProvider
{
    public void Build(QueryEngineBuilder<ContentItem> builder)
    {
        builder.WithNamedTerm("Retail", builder => builder
            .OneCondition((val, query, ctx) =>
            {
                // Search for the "Retail" substring in the DisplayText field of ContentItemIndex.
                if (!string.IsNullOrEmpty(val))
                {
                    query.With<ContentItemIndex>(x => x.DisplayText.Contains(val, StringComparison.OrdinalIgnoreCase));
                }
                return new ValueTask<IQuery<ContentItem>>(query);
            })
        );
    }
}
