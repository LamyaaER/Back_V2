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

                // Seed Agents
                var agents = new Agent[]
                {
                    new Agent { Name = "Agent 1", Email = "agent1@example.com" },
                    new Agent { Name = "Agent 2", Email = "agent2@example.com" },
                    new Agent { Name = "Agent 3", Email = "agent3@example.com" },
                    new Agent { Name = "Agent 4", Email = "agent4@example.com" }
                };

                context.Agents.AddRange(agents);
                context.SaveChanges();

                // Seed Candidates
                var candidates = new Candidate[]
                {
                    new Candidate { Name = "Candidate 1", Email = "candidate1@example.com" },
                    new Candidate { Name = "Candidate 2", Email = "candidate2@example.com" },
                    new Candidate { Name = "Candidate 3", Email = "candidate3@example.com" },
                    new Candidate { Name = "Candidate 4", Email = "candidate4@example.com" }
                };

                context.Candidates.AddRange(candidates);
                context.SaveChanges();

                // Seed Technologies
                var technologies = new Technology[]
                {
                    new Technology { Name = "Technology 1" },
                    new Technology { Name = "Technology 2" },
                    new Technology { Name = "Technology 3" },
                    new Technology { Name = "Technology 4" }
                };

                context.Technologies.AddRange(technologies);
                context.SaveChanges();

                // Seed Quizzes
                var quizzes = new Quiz[]
                {
                    new Quiz { Title = "Quiz 1", CreatedAt = DateTime.Now, Url = "http://example.com/quiz1", AgentId = agents[0].Id, CandidateId = candidates[0].Id, TechnologyId = technologies[0].Id },
                    new Quiz { Title = "Quiz 2", CreatedAt = DateTime.Now, Url = "http://example.com/quiz2", AgentId = agents[1].Id, CandidateId = candidates[1].Id, TechnologyId = technologies[1].Id },
                    new Quiz { Title = "Quiz 3", CreatedAt = DateTime.Now, Url = "http://example.com/quiz3", AgentId = agents[2].Id, CandidateId = candidates[2].Id, TechnologyId = technologies[2].Id },
                    new Quiz { Title = "Quiz 4", CreatedAt = DateTime.Now, Url = "http://example.com/quiz4", AgentId = agents[3].Id, CandidateId = candidates[3].Id, TechnologyId = technologies[3].Id }
                };

                context.Quizs.AddRange(quizzes);
                context.SaveChanges();

                // Seed Questions
                var questions = new Question[]
                {
                    new Question { Title = "Question 1", TypeResponse = "Multiple Choice", ComplexityLevel = "Easy", TechnologyId = technologies[0].Id, QuizId = quizzes[0].Id },
                    new Question { Title = "Question 2", TypeResponse = "True/False", ComplexityLevel = "Medium", TechnologyId = technologies[1].Id, QuizId = quizzes[1].Id },
                    new Question { Title = "Question 3", TypeResponse = "Short Answer", ComplexityLevel = "Hard", TechnologyId = technologies[2].Id, QuizId = quizzes[2].Id },
                    new Question { Title = "Question 4", TypeResponse = "Essay", ComplexityLevel = "Very Hard", TechnologyId = technologies[3].Id, QuizId = quizzes[3].Id }
                };

                context.Questions.AddRange(questions);
                context.SaveChanges();

                // Seed Responses
                var responses = new Response[]
                {
                    new Response { Content = "Response 1" },
                    new Response { Content = "Response 2" },
                    new Response { Content = "Response 3" },
                    new Response { Content = "Response 4" }
                };

                context.Responses.AddRange(responses);
                context.SaveChanges();
            }
        }
    }
}
