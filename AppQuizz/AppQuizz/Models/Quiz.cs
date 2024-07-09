namespace AppQuizz.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Quiz()
        {
            Title = string.Empty;
            CreatedAt = DateTime.Now;
            Url = string.Empty;
            Agent = new Agent();
            Candidate = new Candidate();
            Technology = new Technology();
            Questions = new List<Question>();
        }
    }
}
