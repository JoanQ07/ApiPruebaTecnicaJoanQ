using apiScProsoft.Models;
using ruleta_api.Dtos;

namespace ruleta_api.Services
{
    public interface IPreemio
    {
        Task<ServiceResponse<long>> GetPremio(string tipoApuesta, long montoApostar);
    }

    public class PremioServices : IPreemio
    {

        public PremioServices()
        {
        }

        public Task<ServiceResponse<long>> GetPremio(string tipoApuesta, long montoApostar)
        {
            ServiceResponse<long> response = new();
            long premio = 0;

            switch (tipoApuesta)
            {
                case "color": premio = montoApostar / 2; break;
                case "tipo": premio = montoApostar; break;
                case "numero": premio = montoApostar * 3; break;
            }

            response.Message = "Premio generado";
            response.Success = true;
            response.Data = premio;

            return Task.FromResult(response);
        }
    }
}
