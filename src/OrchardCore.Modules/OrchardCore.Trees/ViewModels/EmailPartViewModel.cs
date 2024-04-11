using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Trees.Models;

namespace OrchardCore.Trees.ViewModels;

public class EmailPartViewModel
{
    public string Email { get; set; }

    public EmailPart EmailPart { get; set; }

    public string ContentItemId { get; set; }
}
