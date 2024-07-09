namespace AppQuizz.Models
{
    public class Response
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Response()
        {
            Content = string.Empty;
        }
    }
}
