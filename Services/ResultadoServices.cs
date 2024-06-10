using apiScProsoft.Models;
using ruleta_api.Dtos;

namespace ruleta_api.Services
{
    public interface IResultado
    {
        Task<ServiceResponse<Resultado>> GetResultado();
    }

    public class ResultadoServices : IResultado
    {
        private readonly Random _random;

        public ResultadoServices()
        {
            _random = new Random();
        }

        public Task<ServiceResponse<Resultado>> GetResultado()
        {
            ServiceResponse<Resultado> response = new();

            int numero = _random.Next(0, 37);
            string color = numero % 2 == 0 ? "negro" : "rojo";
            string tipo = numero % 2 == 0 ? "par" : "impar";

            response.Data = new Resultado() { Color = color, Numero = numero, Tipo = tipo };
            response.Success = true;

            return Task.FromResult(response);
        }
    }
}
