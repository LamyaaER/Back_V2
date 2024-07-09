namespace AppQuizz.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Quiz> Quizs { get; set; }
        public ICollection<Candidate> Candidates { get; set; }

        public Agent()
        {
            Name = string.Empty;
            Email = string.Empty;
            Quizs = new List<Quiz>();
            Candidates = new List<Candidate>();
        }
    }
}
