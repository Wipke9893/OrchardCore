using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Trees.Models;

namespace OrchardCore.Trees.ViewModels;
public class WeatherWidgetPartViewModel
{
    public WeatherResponse WeatherResponse { get; set; }
    public string City { get; set; }
    public List<string> AvailableCities { get; set; }
}

// ViewModels/WeatherWidgetPartViewModel.cs
