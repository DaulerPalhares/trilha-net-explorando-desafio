namespace DesafioProjetoHospedagem.Models
{
  public class Reserva
  {
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
      DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
      if(hospedes?.Count == 0){
        throw new Exception("Favor informar a quantidade de hospedes");
      }
      if (Suite != null)
      {
        if (Suite.Capacidade >= hospedes.Count)
        {
          Hospedes = hospedes;
        }
        else
        {
          throw new Exception("Quantidade de hospedes maior que a capacidade da suite");
        }
      }
    }

    public void CadastrarSuite(Suite suite)
    {
      Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
      return Hospedes?.Count ?? 0;
    }

    public decimal CalcularValorDiaria()
    {
      decimal valor = 0M;

      valor = DiasReservados * Suite.ValorDiaria;
      if (DiasReservados >= 10)
      {
        valor -= (valor*0.10M);
      }

      return valor;
    }
  }
}
