using Internationalization.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internationalization.Data
{
    public class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.Migrate();

            if (context.Movies.Any())
            {
                return;
            }

            context.Movies.Add(new Movie { Title = "2001: A Space Odyssey", Director = "Stanley Kubrick", ReleaseDate = DateTime.Parse("1968-04-02") });
            context.SaveChanges();
        }
    }
}
