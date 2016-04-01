using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace solo.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            if (!db.DbBoards.Any())
            {
                db.DbUsers.AddRange(
                    new User
                    {
                        Name = "Michael",
                        Signature = "Those who cannot remember the past are comdemned to repeat it.",
                        Comments = new List<Comment>(),
                        Posts = new List<Post>(),
                        ModdedBoards = new List<UserBoard>()
                    }    
                );

                db.DbBoards.AddRange(
                    new Board
                    {
                        Name = "Fun",
                        Posts = new List<Post>()
                    },
                    new Board
                    {
                        Name = "History",
                        Posts = new List<Post>()
                    },
                    new Board
                    {
                        Name = "Science",
                        Posts = new List<Post>()
                    },
                    new Board
                    {
                        Name = "Programming",
                        Posts = new List<Post>()
                    },
                    new Board
                    {
                        Name = "Discussion",
                        Posts = new List<Post>()
                    }
                );

                db.DbPosts.AddRange(
                    new Post()
                    {
                        Title = "Look at this cat",
                        Content = ":3",
                        Score = 100,
                        ParentBoard = db.DbBoards.First(b => b.Name == "Fun"),
                        Creator = db.DbUsers.First(u => u.Name == "Michael"),
                        Comments = new List<Comment>()
                    },
                    new Post()
                    {

                    }
                );



                db.SaveChanges();
            }
        }
    }
}
