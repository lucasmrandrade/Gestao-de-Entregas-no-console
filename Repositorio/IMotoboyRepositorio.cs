using GestaoDeEntregas.Modelos;

namespace GestaoDeEntregas.Repositorio;
internal interface IMotoboyRepositorio
{
    Motoboy? BuscarPorNome(string nome);
}
