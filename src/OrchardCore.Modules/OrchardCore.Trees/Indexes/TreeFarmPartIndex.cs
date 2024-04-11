using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.Trees.Models;
using YesSql.Indexes;

namespace OrchardCore.Trees.Indexes;
public class TreeFarmPartIndex : MapIndex
{
    public string ScientificName { get; set; }
    public string ContentItemId { get; set; }
}

public class TreeFarmPartIndexProvider : IndexProvider<ContentItem>
{
    public override void Describe(DescribeContext<ContentItem> context)
    {
        context.For<TreeFarmPartIndex>()
            .Map(contentItem =>
            {
                var treeFarmPart = contentItem.As<TreeFarmPart>();
                if (treeFarmPart is not null)
                {
                    return new TreeFarmPartIndex
                    {
                        ScientificName = treeFarmPart.ScientificName,
                        ContentItemId = contentItem.ContentItemId
                    };
                }
                return null;
            });
    }
}

