using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Entity;

public class AutorizeRoles : ActionFilterAttribute
{
    public string Rol { get; set; }
    public string Permiso { get; set; }
    public string Role { get; set; }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
        if(Rol != "Administrador")
        {
           
        }
        
    }
}