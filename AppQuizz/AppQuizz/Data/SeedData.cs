using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppQuizz.Models;
using System;
using System.Linq;

namespace AppQuizz.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any agents.
                if (context.Agents.Any())
                {
                    return;   // DB has been seeded
                }

                // Agents
                var agents = new Agent[]
                {
                    new Agent { Name = "Agent 1", Email = "agent1@example.com" },
                    new Agent { Name = "Agent 2", Email = "agent2@example.com" },
                    new Agent { Name = "Agent 3", Email = "agent3@example.com" },
                    new Agent { Name = "Agent 4", Email = "agent4@example.com" }
                };

                // Candidates
                var candidates = new Candidate[]
                {
                    new Candidate { Name = "Candidate 1", Email = "candidate1@example.com" },
                    new Candidate { Name = "Candidate 2", Email = "candidate2@example.com" },
                    new Candidate { Name = "Candidate 3", Email = "candidate3@example.com" },
                    new Candidate { Name = "Candidate 4", Email = "candidate4@example.com" }
                };

                // Technologies
                var technologies = new Technology[]
                {
                    new Technology { Name = "Technology 1" },
                    new Technology { Name = "Technology 2" },
                    new Technology { Name = "Technology 3" },
                    new Technology { Name = "Technology 4" }
                };

                // Responses
                var responses = new Response[]
                {
                    new Response { Content = "Response 1" },
                    new Response { Content = "Response 2" },
                    new Response { Content = "Response 3" },
                    new Response { Content = "Response 4" }
                };

                // Questions
                var questions = new Question[]
                {
                    new Question { Title = "Question 1", Response = responses[0], TypeResponse = "Text", ComplexityLevel = "Easy", Technology = technologies[0], Quiz = null },
                    new Question { Title = "Question 2", Response = responses[1], TypeResponse = "Text", ComplexityLevel = "Medium", Technology = technologies[1], Quiz = null },
                    new Question { Title = "Question 3", Response = responses[2], TypeResponse = "Text", ComplexityLevel = "Hard", Technology = technologies[2], Quiz = null },
                    new Question { Title = "Question 4", Response = responses[3], TypeResponse = "Text", ComplexityLevel = "Easy", Technology = technologies[3], Quiz = null }
                };

                // Quizzes
                var quizzes = new Quiz[]
                {
                    new Quiz { Title = "Quiz 1", CreatedAt = DateTime.Now, Url = "url1.com", Agent = agents[0], Candidate = candidates[0], Technology = technologies[0], Questions = new List<Question> { questions[0] } },
                    new Quiz { Title = "Quiz 2", CreatedAt = DateTime.Now, Url = "url2.com", Agent = agents[1], Candidate = candidates[1], Technology = technologies[1], Questions = new List<Question> { questions[1] } },
                    new Quiz { Title = "Quiz 3", CreatedAt = DateTime.Now, Url = "url3.com", Agent = agents[2], Candidate = candidates[2], Technology = technologies[2], Questions = new List<Question> { questions[2] } },
                    new Quiz { Title = "Quiz 4", CreatedAt = DateTime.Now, Url = "url4.com", Agent = agents[3], Candidate = candidates[3], Technology = technologies[3], Questions = new List<Question> { questions[3] } }
                };

                context.Agents.AddRange(agents);
                context.Candidates.AddRange(candidates);
                context.Technologies.AddRange(technologies);
                context.Responses.AddRange(responses);
                context.Questions.AddRange(questions);
                context.Quizs.AddRange(quizzes);

                context.SaveChanges();
            }
        }
    }
}
