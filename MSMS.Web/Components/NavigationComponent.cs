using Microsoft.AspNetCore.Mvc;

namespace MSMS.Web.Components
{
    public class NavigationComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
