using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using System.Security.Cryptography;
using System.Text;
namespace FilmeNepenApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Cadastrar(Usuario user)
        {
            try
            {
                var password = sha256_hash(user.Password);
                user.Password = password;
                user.Cargo = user.Cargo;
                user.Ativo = 1;
                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                user = new Usuario();
            }
            return user;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var admin = await _context.Usuarios.FindAsync(id);
            if (admin == null)
            {
                return false;
            }

            _context.Usuarios.Remove(admin);
            await _context.SaveChangesAsync();

            return true;
        }

        public Usuario GetUsuario(string username)
        {
            Usuario user = new Usuario();
            user = _context.Usuarios.FirstOrDefault(a => a.Username == username);

            return user;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            Usuario user = new Usuario();
            user = await _context.Usuarios.FindAsync(id);

            return user;
        }

        public Usuario Login(string username, string password)
        {
            Usuario user = new Usuario();
            var senha = sha256_hash(password);
            try
            {
                user = _context.Usuarios.FirstOrDefault(a => a.Username == username && a.Password == senha);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                user = new Usuario();
            }
            return user;
        }

        public async Task<Usuario> PutUsuario(int id, Usuario adminEditado)
        {
            Usuario user = new Usuario();

            try
            {
                user = await _context.Usuarios.FindAsync(id);
                if (adminEditado.Password != "" && adminEditado.Password != null)
                {
                    var password = sha256_hash(adminEditado.Password);
                    user.Password = password;
                }
                user.Nome = adminEditado.Nome;
                user.Username = adminEditado.Username;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                user = new Usuario();
            }

            return user;
        }

        public async Task<Usuario> PutUsuarioAdm(int id, Usuario adminEditado)
        {
            Usuario user = new Usuario();

            try
            {
                user = await _context.Usuarios.FindAsync(id);
                if (adminEditado.Password != "" && adminEditado.Password != null)
                {
                    var password = sha256_hash(adminEditado.Password);
                    user.Password = password;
                }
                user.Nome = adminEditado.Nome;
                user.Username = adminEditado.Username;
                user.Ativo = adminEditado.Ativo;
                user.Cargo = adminEditado.Cargo;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                user = new Usuario();
            }

            return user;
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

    }
}