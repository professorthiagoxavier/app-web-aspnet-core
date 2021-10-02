using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IAtividadeService
    {
        Task<Dominio.Model.Atividade> SalvarAtividade(Dominio.Model.Atividade atividade);

        Task<IEnumerable<Dominio.Model.Atividade>> BuscarAtividades();
    }
}
