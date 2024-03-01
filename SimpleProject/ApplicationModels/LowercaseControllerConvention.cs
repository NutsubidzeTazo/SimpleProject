using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace SimpleProject.ApplicationModels
{
    public class LowercaseControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.ToLower();
        }
    }
}
