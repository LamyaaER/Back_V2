namespace AppQuizz.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Quiz> Quizs { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        public Candidate()
        {
            Name = string.Empty;
            Email = string.Empty;
            Quizs = new List<Quiz>();
        }
    }
}
