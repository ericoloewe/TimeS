namespace TimeS.Model.ViewModels
{
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Inicio { get; set; }
        public string Hora_Inicio { get; set; }
        public string Entrega { get; set; }
        public string Hora_Entrega { get; set; }
        public string Responsavel_Id { get; set; }
        public int Status_Id { get; set; }
        public string Status { get; set; }
        public string Tempo { get; set; }

        public virtual string[] Seguidores { get; set; }
    }

    public class TempoViewModel
    {
        public int Id { get; set; }
        public string Horas { get; set; }
        public string Data { get; set; }
        public int Tarefa_Id { get; set; }
        public string Autor_Id { get; set; }
    }
}
