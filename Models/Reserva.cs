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
            //Verifica se a capacidade da suite comporta a quantidade de hóspedes recebido            
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                //Retorna uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Número de hospedes não pode exceder a capacidade da suite.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;                     
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula valor total da estada na suite                       
            decimal valor = DiasReservados * Suite.ValorDiaria;
            decimal desconto = 10;

            //Consede desconto caso os dias reservados forem maior ou igual 10 dias           
            if (DiasReservados >= 10)
            {
                decimal valorDesconto = (DiasReservados * Suite.ValorDiaria) * desconto/100;
                valor = (DiasReservados * Suite.ValorDiaria) - valorDesconto;
            }

            return valor;
        }
    }
}