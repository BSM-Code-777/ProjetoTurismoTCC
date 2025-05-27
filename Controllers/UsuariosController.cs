using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using turismoTCC.Models;

public class UsuariosController : Controller
{
    private readonly UserManager<Usuario> _userManager;

    public UsuariosController(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var usuarios = _userManager.Users.ToList();
        return View(usuarios);
    }
}
