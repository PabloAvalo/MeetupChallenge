using Meetup.Dto.Models;
using System.Threading.Tasks;

namespace Meetup.BussinesLogic.Controllers
{
    public interface IUsuarioController
    {
        Task AddTopicoFavorito(ConfiguracionNuevaDto configuracion);
        Task HacerCheckIn(int inscripcionId);
        Task<UsuarioDto> Login(UsuarioLoginDto usu);
        Task RegistrarInscripcion(InscripcionNuevaDto inscripcion);
        Task SignUp(UsuarioNuevoDto usu);
    }
}