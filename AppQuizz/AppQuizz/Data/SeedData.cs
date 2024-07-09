//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Linq;
//using AppQuizz.Data;
//using AppQuizz.Models;

//namespace AppQuizz.Data
//{
//    public static class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new ApplicationDbContext(
//                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
//            {
//                // Look for any existing data.
//                if (context.Quizs.Any())
//                {
//                    return;   // DB has been seeded
//                }

//                // Add Agents
//                var agent1 = new Agent { Name = "Agent 1", Email = "agent1@example.com" };
//                var agent2 = new Agent { Name = "Agent 2", Email = "agent2@example.com" };

//                // Add Candidates
//                var candidate1 = new Candidate { Name = "Candidate 1", Email = "candidate1@example.com" };
//                var candidate2 = new Candidate { Name = "Candidate 2", Email = "candidate2@example.com" };

//                // Add Technologies
//                var technology1 = new Technology { Name = "Technology 1" };
//                var technology2 = new Technology { Name = "Technology 2" };

//                // Add Quizzes
//                var quiz1 = new Quiz { Title = "Quiz 1", CreatedAt = DateTime.Now, Url = "http://example.com/quiz1", Agent = agent1, Candidate = candidate1, Technology = technology1 };
//                var quiz2 = new Quiz { Title = "Quiz 2", CreatedAt = DateTime.Now, Url = "http://example.com/quiz2", Agent = agent2, Candidate = candidate2, Technology = technology2 };

//                // Add Questions
//                var question1 = new Question { Title = "Question 1", TypeResponse = "Multiple Choice", ComplexityLevel = "Easy", Technology = technology1, Quiz = quiz1 };
//                var question2 = new Question { Title = "Question 2", TypeResponse = "True/False", ComplexityLevel = "Medium", Technology = technology2, Quiz = quiz2 };

//                // Add Responses
//                var response1 = new Response { Content = "Response 1" };
//                var response2 = new Response { Content = "Response 2" };

//                // Associate responses with questions
//                question1.Response = response1;
//                question2.Response = response2;

//                // Add entities to the context
//                context.Agents.AddRange(agent1, agent2);
//                context.Candidates.AddRange(candidate1, candidate2);
//                context.Technologies.AddRange(technology1, technology2);
//                context.Quizs.AddRange(quiz1, quiz2);
//                context.Questions.AddRange(question1, question2);
//                context.Responses.AddRange(response1, response2);

//                // Save changes
//                context.SaveChanges();
//            }
//        }
//    }
//}
