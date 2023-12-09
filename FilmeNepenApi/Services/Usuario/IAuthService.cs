using FilmeNepenApi.Models;
using System.Threading.Tasks;

namespace FilmeNepenApi.Services
{
    public interface IAuthService
    {
        Usuario Login(string username, string password);
        Task<Usuario> Cadastrar(Usuario usuario);
        Usuario GetUsuario(string username);
        Task<Usuario> GetUsuarioById(int id);
        Task<Usuario> PutUsuario(int id, Usuario usuarioEditado);
        Task<bool> DeleteUsuario(int id);
        Task<Usuario> PutUsuarioAdm(int id, Usuario UsuarioEditado);
    }
}