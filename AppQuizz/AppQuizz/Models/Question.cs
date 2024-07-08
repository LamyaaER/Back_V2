namespace AppQuizz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ReponseId { get; set; }
        public Response Response { get; set; }
        public string TypeResponse { get; set; }
        public string ComplexityLevel { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public Question()
        {
            Title = string.Empty;
            Response = new Response();
            TypeResponse = string.Empty;
            ComplexityLevel = string.Empty;
            Technology = new Technology();
            Quiz = new Quiz();
        }
    }
    }
