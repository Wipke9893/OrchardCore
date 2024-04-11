using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Trees.Models;
using OrchardCore.Trees.ViewModels;

namespace OrchardCore.Trees.Drivers;

public class EmailPartDisplayDriver : ContentPartDisplayDriver<EmailPart>
{
    public override IDisplayResult Display(EmailPart part, BuildPartDisplayContext context) =>
        Initialize<EmailPartViewModel>(GetDisplayShapeType(context), viewModel =>
        {
            PopulateViewModel(part, viewModel);
        })
        .Location("Detail", "Content")
        .Location("Summary", "Content");


    public override IDisplayResult Edit(EmailPart part, BuildPartEditorContext context) =>
         Initialize<EmailPartViewModel>(GetEditorShapeType(context), viewModel =>
         {
             PopulateViewModel(part, viewModel);
         });



    public override async Task<IDisplayResult> UpdateAsync(EmailPart part, IUpdateModel updater, UpdatePartEditorContext context)
    {
        var viewModel = new EmailPartViewModel();

        if (await updater.TryUpdateModelAsync(viewModel, Prefix))
        {
            part.Email = viewModel.Email;
        }
        return Edit(part, context);
    }


    private void PopulateViewModel(EmailPart part, EmailPartViewModel viewModel)
    {
        viewModel.Email = part.Email;
    }
}
