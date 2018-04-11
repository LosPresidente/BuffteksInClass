using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Buffteks.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BuffteksContext(
                serviceProvider.GetRequiredService<DbContextOptions<BuffteksContext>>()))
            {
                // Look for any movies.
                if (context.Member.Any())
                {
                    return;   // DB has been seeded
                }

                context.Member.AddRange(
                     new BuffMember
                     {
                         FirstName = "Pro",
                         LastName = "Core"
                     },
                     new BuffMember
                     {
                         FirstName = "Aron",
                         LastName = "Aronson"
                     }


                );

                context.Client.AddRange(
                    new BuffClient{
                        ClientName = "Google"
                    },
                    
                    new BuffClient{
                        ClientName = "IBM"
                    },

                    new BuffClient{
                        ClientName = "Microsoft"
                    }
                );

                context.Project.AddRange(
                  new BuffProject{
                      ProjectName = "ASP.NET"
                  },  

                  new BuffProject{
                      ProjectName = "Core"
                  },  

                  new BuffProject{
                      ProjectName = "Pro"
                  },  
                  
                  new BuffProject{
                      ProjectName = "MVC 2"
                  }
                );
                context.SaveChanges();
            }
        }
    }
}