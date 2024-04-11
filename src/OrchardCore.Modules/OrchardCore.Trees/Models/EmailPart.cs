using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;

namespace OrchardCore.Trees.Models;

public class EmailPart : ContentPart
{
    public string Email { get; set; }
}
