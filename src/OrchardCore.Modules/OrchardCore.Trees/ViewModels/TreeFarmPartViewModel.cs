using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrchardCore.Trees.Models;

namespace OrchardCore.Trees.ViewModels;

public class TreeFarmPartViewModel
{
    public string ScientificName { get; set; }
    public TreeFarmPart TreeFarmPart { get; set; }
    public string ContentItemId { get; set; }

    [BindNever]
    public IEnumerable<SelectListItem> ScientificNames { get; set; }
}
