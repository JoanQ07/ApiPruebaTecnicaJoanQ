using Microsoft.EntityFrameworkCore;
using apiScProsoft.Models;
using ruleta_api.Context;
using ruleta_api.Models;

namespace ruleta_api.Services
{
    public interface IUsuario
    {
        Task<ServiceResponse<Usuarios>> SaveUsuario(Usuarios usuario);
        Task<ServiceResponse<Usuarios>> GetUsuario(string nombre);
    }

    public class UsuariosServices : IUsuario
    {
        private readonly DataContext _context;

        public UsuariosServices(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Usuarios>> SaveUsuario(Usuarios usuario)
        {
            ServiceResponse<Usuarios> response = new();
            try
            {
                Usuarios? dbUsuario = await _context.Usuarios
                            .FirstOrDefaultAsync(el => EF.Functions.Like(el.nombre, usuario.nombre));

                if (dbUsuario != null)
                {
                    _context.Entry(dbUsuario).State = EntityState.Detached;
                    usuario.id = dbUsuario.id;
                    _context.Entry(usuario).State = EntityState.Modified;
                }
                else _context.Usuarios.Add(usuario);

                await _context.SaveChangesAsync();

                response.Success = true;
                response.Data = usuario;
                response.Message = $"Datos del usuario '{usuario.nombre}' han sido registrados";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
        public async Task<ServiceResponse<Usuarios>> GetUsuario(string nombre)
        {
            ServiceResponse<Usuarios> response = new();
            try
            {
                Usuarios? dbUsuario = await _context.Usuarios
                            .FirstOrDefaultAsync(el => EF.Functions.Like(el.nombre, nombre));

                if (dbUsuario == null)
                {
                    response.Success = true;
                    response.Message = $"Usuario '{nombre}' sin identificar";
                    return response;
                }

                response.Success = true;
                response.Data = dbUsuario;
                response.Message = $"Datos del usuario '{nombre}' recuperados";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
