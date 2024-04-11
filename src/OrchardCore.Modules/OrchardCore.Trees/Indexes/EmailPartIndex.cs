using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;
using OrchardCore.Trees.Models;
using YesSql.Indexes;

namespace OrchardCore.Trees.Indexes;

public class EmailPartIndex : MapIndex
{
    public string Email { get; set; }
    public string ContentItemId { get; set; }
}

public class EmailPartIndexProvider : IndexProvider<ContentItem>
{
    public override void Describe(DescribeContext<ContentItem> context)
    {
        context.For<EmailPartIndex>()
        .Map(contentItem =>
        {
            var emailPart = contentItem.As<EmailPart>();
            if (emailPart != null)
            {
                return new EmailPartIndex
                {
                    ContentItemId = contentItem.ContentItemId,
                    Email = emailPart.Email
                };
            }
            return null;
        });
    }
}
