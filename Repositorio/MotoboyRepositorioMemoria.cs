using GestaoDeEntregas.Modelos;

namespace GestaoDeEntregas.Repositorio;

internal class MotoboyRepositorioMemoria : IMotoboyRepositorio
{
    private Dictionary<string, Motoboy> nomeMotoboy = new();

    public MotoboyRepositorioMemoria(Dictionary<string, Motoboy> motoboysRegistrados)
    {
       nomeMotoboy = motoboysRegistrados;
    }

    public Motoboy? BuscarPorNome(string nome)
    {
        if (nomeMotoboy.ContainsKey(nome))
        {
            return nomeMotoboy[nome];
        }
        return null;
    }
}
