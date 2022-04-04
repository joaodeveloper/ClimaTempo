using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClimaTempoSimples.Abstractions.Repositories
{
    using ClimaTempoSimples.Models;
    public interface IPrevisaoClimaRepository
    {
        Task<List<PrevisaoClima>> GetCidadesMaisQuentes();
        Task<List<PrevisaoClima>> GetCidadesMaisFrias();
        Task<IEnumerable<PrevisaoClima>> GetTemperaturaSemanalPorCidade(int idCidade);
    }
}