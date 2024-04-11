using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Trees.Models;
using OrchardCore.Trees.ViewModels;

namespace OrchardCore.Trees.Drivers;

public class TreeFarmPartDisplayDriver : ContentPartDisplayDriver<TreeFarmPart>
{
    // TreeFarmPart   Content-TreeFarmPart
    public override IDisplayResult Display(TreeFarmPart part, BuildPartDisplayContext context)
        => Initialize<TreeFarmPartViewModel>(GetDisplayShapeType(context), viewModel =>
        {
            PopulateViewModel(part, viewModel);
        }).Location("Detail", "Content")
        .Location("Summary", "Content")
        .Location("SummaryAdmin", "Meta:10");

    public override IDisplayResult Edit(TreeFarmPart part, BuildPartEditorContext context)
        => Initialize<TreeFarmPartViewModel>(GetEditorShapeType(context), viewModel =>
        {
            PopulateViewModel(part, viewModel);
            viewModel.ScientificNames =
            [
                new SelectListItem { Text = "Autumn Blaze Maple", Value = "Autumn Blaze Maple" },
                new SelectListItem { Text = "American Dream White/Red Oak", Value = "American Dream White/Red Oak" },
                new SelectListItem { Text = "Eastern Redbud", Value = "Eastern Redbud" },
                new SelectListItem { Text = "Exclamation London Planetree", Value = "Exclamation London Planetree" },
                new SelectListItem { Text = "Forest Pansy", Value = "Forest Pansy" },
                new SelectListItem { Text = "Frontier Elm", Value = "Frontier Elm" }
            ];
        });

    public override async Task<IDisplayResult> UpdateAsync(TreeFarmPart part, IUpdateModel updater, UpdatePartEditorContext context)
    {
        var viewModel = new TreeFarmPartViewModel();
        if (await updater.TryUpdateModelAsync(viewModel, Prefix))
        {
            part.ScientificName = viewModel.ScientificName;
        }
        return Edit(part, context);
    }
    private void PopulateViewModel(TreeFarmPart part, TreeFarmPartViewModel viewModel)
    {
        viewModel.ScientificName = part.ScientificName;

    }
}
