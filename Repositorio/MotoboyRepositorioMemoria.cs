using GestaoDeEntregas.Modelos;

namespace GestaoDeEntregas.Repositorio;

internal class MotoboyRepositorioMemoria : IMotoboyRepositorio
{
    private Dictionary<string, Motoboy> nomeMotoboy = new()!;  

    // passei uma variavel pra receber como parametro motoboyregistrados
    public MotoboyRepositorioMemoria(Dictionary<string, Motoboy> motoboysRegistrados)
    {
       nomeMotoboy = motoboysRegistrados;
    }

    public Motoboy? BuscarPorNome(string nome)
    {
        if (nomeMotoboy.ContainsKey(nome)) // se existe na lista 
        {
            return nomeMotoboy[nome]; 
        }
        return null;
    }
}
