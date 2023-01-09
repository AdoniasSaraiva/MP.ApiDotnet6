using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MP.ApiDotnet6.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public bool ValidatePermission(List<string> permissionUser, List<string> permissionNeeded)
        {
            return permissionNeeded.Any(x => permissionUser.Contains(x));
        }

        [NonAction]
        public IActionResult Forbidden()
        {
            var obj = new
            {
                code = "Permissão Negada",
                message = "Usuário não tem permissão para acessar esse recurso"
            };

            return new ObjectResult(obj) { StatusCode = 403 };
        }
    }
}
