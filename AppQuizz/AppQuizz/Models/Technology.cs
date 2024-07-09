namespace AppQuizz.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

        public Technology()
        {
            Name = string.Empty;
            Questions = new List<Question>();
        }
    }
}
