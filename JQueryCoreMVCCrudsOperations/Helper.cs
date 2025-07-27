using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace JQueryCoreMVCCrudsOperations
{
    public static class Helper
    {
        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                // Get the view engine
                IViewEngine? viewEngine = controller.HttpContext.RequestServices
                    .GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;

                // Find the view
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                if (viewResult.View == null)
                {
                    // Try with shared views if not found
                    viewResult = viewEngine.GetView("~/", $"~/Views/Shared/{viewName}.cshtml", false);
                    if (viewResult.View == null)
                    {
                        throw new FileNotFoundException($"Could not find the view '{viewName}'");
                    }
                }

                // Create view context
                var viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );

                // Render the view
                viewResult.View.RenderAsync(viewContext).Wait();

                return sw.GetStringBuilder().ToString();
            }
        }
    }
    }
