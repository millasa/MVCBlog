namespace MVCBlog.Migrations
{
    using MVCBlog.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCBlog.Models.MVCBlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCBlog.Models.MVCBlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var users = new List<User>
            {
                new User { Login = "user1", Password = "qwerty1", EmailAddress = "user1@mail.com" },
                new User { Login = "user2", Password = "qwerty2", EmailAddress = "user2@mail.com" },
                new User { Login = "user3", Password = "qwerty3", EmailAddress = "user3@mail.com" },
                new User { Login = "user4", Password = "qwerty4", EmailAddress = "user4@mail.com" },
                new User { Login = "user5", Password = "qwerty5", EmailAddress = "user5@mail.com" }
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.Login, s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category { CategoryName = "Style"},
                new Category { CategoryName = "Health"},
                new Category { CategoryName = "Business"},
                new Category { CategoryName = "Market"},
                new Category { CategoryName = "Sport"},
                new Category { CategoryName = "Pets"}
            };

            categories.ForEach(s => context.Categories.AddOrUpdate(p => p.CategoryName, s));
            context.SaveChanges();

            var articles = new List<Article>
            {
                new Article { ArticleName = "Article 1", AuthorID = 1, CategoryID = 3, ArticleText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec lacinia a neque sagittis rutrum. Ut tincidunt metus lectus, at auctor metus porta ut. Quisque ultrices semper ipsum. Phasellus et gravida purus. Pellentesque eu ligula eget elit rhoncus sollicitudin non quis lectus. In et leo dolor. Pellentesque quis metus felis. Sed ultrices nulla vitae elit ullamcorper pellentesque. Nullam posuere pharetra imperdiet. Vestibulum augue arcu, lobortis in porttitor sit amet, sollicitudin non augue. Vestibulum in justo est. Ut mauris mi, pretium et eleifend eu, sollicitudin et purus. Praesent consectetur risus at egestas fermentum. Nulla mollis massa nec ante cursus, id vulputate nunc ultrices. Aliquam vel nunc nec sem sagittis consectetur. Integer auctor fermentum aliquam. Proin a lobortis tellus. Etiam gravida mauris tellus, ut venenatis ligula convallis eu. Aenean pulvinar erat quam, id condimentum tortor blandit in. Nullam ultricies vel turpis quis cursus. Integer suscipit mollis magna eget gravida. Proin luctus massa ut eros convallis, vitae convallis mauris pharetra. Donec aliquam, lorem quis ultrices consectetur, lorem mauris volutpat nibh, vel condimentum eros elit eget magna. In hac habitasse platea dictumst. Fusce blandit, nibh id feugiat euismod, lacus sapien consequat neque, at aliquam ipsum nisi ac magna. Duis porttitor ullamcorper arcu. Aenean a consequat eros. Aliquam erat volutpat. Aenean id ullamcorper nunc. Mauris eu magna mollis enim rutrum lacinia. Vestibulum auctor metus in dui faucibus feugiat. Aliquam fermentum leo a fringilla sodales. Nulla elementum semper semper. Suspendisse ut mi eu nulla molestie pellentesque in quis purus. Nunc nec est non lacus ornare tempor. Sed dictum molestie ante ut feugiat. Morbi venenatis nulla et erat accumsan, vestibulum cursus mi placerat. Aenean vehicula, purus a sollicitudin lobortis, ante lacus vulputate sapien, quis sagittis eros quam ac dolor. Pellentesque viverra a nibh quis vulputate. Aenean condimentum pulvinar neque, aliquet sagittis arcu bibendum in. Phasellus sed venenatis mauris. Pellentesque at pulvinar lectus. Sed condimentum ipsum eu sollicitudin egestas. Mauris eget quam nulla. Integer vulputate vitae arcu ut condimentum. Quisque at quam ut eros condimentum tincidunt et a odio. Vivamus laoreet nunc vel nisi vestibulum, at vestibulum mi tincidunt. Pellentesque pellentesque at nibh vitae eleifend." },
                new Article { ArticleName = "Article 2", AuthorID = 4, CategoryID = 5, ArticleText = "Lorem ipsum dolor sit amet, saperet nominavi expetendis mei at. Est dicit molestiae theophrastus an, et mel altera meliore, pro habeo viderer an. Per natum praesent eloquentiam ei, persius quaeque prodesset quo eu. Pro eleifend explicari at, mea dicat choro fabulas te, alii soluta tincidunt an ius. Per in etiam admodum, veri semper cu ius. Magna oblique dolorum sit ea, id his explicari voluptaria. Tempor evertitur in usu, usu ad cibo summo omnium. In feugiat eleifend incorrupte nec. No utamur expetenda vim, ei nec ponderum efficiantur. In cum utinam delenit salutandi, dolore suavitate ei vis. Wisi soluta putant te sit, ceteros adipiscing his ei, sanctus honestatis in mea. Ei usu iudicabit definiebas, latine alterum sit ex, posse consetetur est ne. Et mei feugait sadipscing, alii etiam offendit nec ex. Pri at scripta fierent, et eam case eius bonorum. Has eu possim meliore, ei eos everti tamquam fabellas, an mea quod error eruditi. Te ius eius minim omittam, usu an laoreet copiosae consequuntur, semper disputando eam eu. Cum quis legimus in, vis diam error simul te, sit ad harum menandri. Per et latine dolorem disputando, eu doming facilis tacimates vix, ad oblique platonem duo. Purto tritani ut qui, tantas evertitur constituam ius no, pro vidit audire adolescens ei. Autem dicat utroque in vel, et audiam indoctum salutatus usu." }
            };

            articles.ForEach(s => context.Articles.AddOrUpdate(p => p.ArticleID, s));
            context.SaveChanges();
        }
    }
}
