using Meetup.Dto.Models;
using System.Threading.Tasks;

namespace Meetup.BussinesLogic.Controllers
{
    public interface IUsuarioController
    {
        Task AddTopicoFavorito(int usuarioId, int topicoId);
        Task HacerCheckIn(int inscripcionId);
        Task<UsuarioDto> Login(string usuario, string contraseña);
        Task RegistrarInscripcion(int usuarioId, int eventoId);
        Task SignUp(string correo, string contraseña, bool isAdmin, string nombre);
    }
}