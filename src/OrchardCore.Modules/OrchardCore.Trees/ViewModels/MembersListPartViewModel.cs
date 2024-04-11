using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;

namespace OrchardCore.Trees.ViewModels;
public class MembersListPartViewModel
{
    public IEnumerable<ContentItem> ContentItems { get; set; }
}
