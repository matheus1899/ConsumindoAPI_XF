namespace ConsumindoAPI_XF.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Turma { get; set; }
        public Aluno(string Nome, string Sobrenome, string Turma)
        {
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.Turma = Turma;
        }
    }
}
