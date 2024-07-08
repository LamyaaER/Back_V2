namespace AppQuizz.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public DateTime CreatedAt { get; set; }

        public String Url { get; set; }
        public int QuestionId { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz()
        {
            Title = string.Empty;
            Agent = new Agent();
            Candidate = new Candidate();
            Questions = new List<Question>();
            Technology = new Technology();
            CreatedAt = DateTime.Now;
            Url = string.Empty;
        }
    }
    }
