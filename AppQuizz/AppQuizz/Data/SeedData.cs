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
                // Check if any data exists
                if (context.Agents.Any() || context.Candidates.Any() || context.Technologies.Any() || context.Quizs.Any() || context.Questions.Any() || context.Responses.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed Agents
                for (int i = 1; i <= 60; i++)
                {
                    context.Agents.Add(new Agent
                    {
                        Name = $"Agent {i}",
                        Email = $"agent{i}@example.com",
                        Password = $"password{i}" // Note: Use hashed passwords in production
                    });
                }
                context.SaveChanges();

                // Seed Candidates
                for (int i = 1; i <= 60; i++)
                {
                    context.Candidates.Add(new Candidate
                    {
                        Name = $"Candidate {i}",
                        Email = $"candidate{i}@example.com"
                    });
                }
                context.SaveChanges();

                // Seed Technologies
                for (int i = 1; i <= 60; i++)
                {
                    context.Technologies.Add(new Technology
                    {
                        Name = $"Technology {i}"
                    });
                }
                context.SaveChanges();

                // Seed Quizzes
                var agents = context.Agents.ToList();
                var candidates = context.Candidates.ToList();
                var technologies = context.Technologies.ToList();

                for (int i = 1; i <= 60; i++)
                {
                    context.Quizs.Add(new Quiz
                    {
                        Title = $"Quiz {i}",
                        CreatedAt = DateTime.Now,
                        Url = $"http://example.com/quiz{i}",
                        AgentId = agents[i % agents.Count].Id,
                        CandidateId = candidates[i % candidates.Count].Id,
                        TechnologyId = technologies[i % technologies.Count].Id
                    });
                }
                context.SaveChanges();

                // Seed Questions
                var quizzes = context.Quizs.ToList();

                for (int i = 1; i <= 60; i++)
                {
                    context.Questions.Add(new Question
                    {
                        Title = $"Question {i}",
                        TypeResponse = "Multiple Choice",
                        ComplexityLevel = "Easy",
                        TechnologyId = technologies[i % technologies.Count].Id,
                        QuizId = quizzes[i % quizzes.Count].Id
                    });
                }
                context.SaveChanges();

                // Seed Responses
                for (int i = 1; i <= 60; i++)
                {
                    context.Responses.Add(new Response
                    {
                        Content = $"Response {i}"
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
