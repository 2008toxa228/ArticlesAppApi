using ArticlesAppApi.Entities;
using ArticlesAppApi.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ArticlesAppApi.DataBaseProvider
{
    /// <summary>
    /// Фабрика провайдеров к базе данных.
    /// </summary>
    public class MockDataBaseProvider : IDataBaseProvider
    {
        /// <summary>
        /// Статьи.
        /// </summary>
        private IEnumerable<Article> articles;

        /// <summary>
        /// Категории.
        /// </summary>
        private IEnumerable<Category> categories;

        /// <summary>
        /// Пользователи.
        /// </summary>
        private IEnumerable<User> users;

        /// <summary>
        /// Максимальынй размер страницы.
        /// </summary>
        private const int MaxPageSize = 100;
        public MockDataBaseProvider()
        {
            InitializeMockDataBase();
        }

        /// <summary>
        /// Создает нвоую статью.
        /// </summary>
        public Guid CreateNewArticle(Guid authorGuid)
        {
            var article = new Article() { Authors = new[] { authorGuid } };
            articles.Concat(new[] { article });

            return article.Id;
        }

        /// <summary>
        /// Получает статью по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор статьи.</param>
        /// <returns>Статью по указанному идентификатору.</returns>
        public Article GetArticleById(Guid id)
        {
            return articles.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получает категорию по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор категории.</param>
        /// <returns>Категорию по указанному идентификатору.</returns>
        public Category GetCategoryById(Guid id)
        {
            return categories.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получает пользователя по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователя по указанному идентификатору.</returns>
        public User GetUserById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление статей.</returns>
        public IEnumerable<Article> GetArticles(int page, int pageSize = MaxPageSize)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return articles
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра по указанному автору.
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticlesByAuthor(Guid authorId, int page, int pageSize = MaxPageSize)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return articles
                .Where(x => x.Authors.Contains(authorId))
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра по указанной категории.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticlesByCategory(Guid categoryId, int page, int pageSize = MaxPageSize)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return articles
                .Where(x => x.Categories.Contains(categoryId))
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Постранично возвращает категории.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление категорий.</returns>
        public IEnumerable<Category> GetCategories(int page, int pageSize = MaxPageSize)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return categories
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Постранично возвращает пользователей.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление пользователей.</returns>
        public IEnumerable<User> GetUsers(int page, int pageSize = MaxPageSize)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return users
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Удаляет статью по указанному идентификатору и возвращает результат удаления в виде булева значения.
        /// </summary>
        /// <param name="id">Идентификатор статьи для удаления.</param>
        /// <returns>Результат удаления статьи.</returns>
        public bool DeleteArticleById(Guid id)
        {
            try
            {
                var article = articles.Where(x => x.Id == id).First();
                return articles.ToList().Remove(article);
            }
            catch (ArgumentNullException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Обновляет параметры статьи по казанному идентификатору и переданным параметрам в JSON формате.
        /// </summary>
        /// <param name="id">Идентификатор статьи.</param>
        /// <param name="articleJson">JSON представление статьи с измененными параметрами.</param>
        /// <returns>Результат обновления статьи.</returns>
        public bool UpdateArticleById(Guid id, Article article)
        {
            article.Id = id;

            articles.Where(x => x.Id == article.Id).FirstOrDefault()?.UpdateValues(article);

            return true;
        }

        /// <summary>
        /// Инициализирует мок объекты.
        /// </summary>
        public void InitializeMockDataBase()
        {
            categories = new List<Category>
            {
                new Category(Guid.NewGuid(), "category1", "category1 description"),
                new Category(Guid.NewGuid(), "category2", "category2 description")
            }; 
            
            users = new List<User>
            {
                new User(Guid.NewGuid(), "user1"),
                new User(Guid.NewGuid(), "user2")
            };

            articles = new List<Article>
            {
                new Article(Guid.NewGuid(),
                    "article1",
                    "preview1",
                    "description1",
                    "content1",
                    new Guid[] { categories.ElementAt(0).Id, categories.ElementAt(1).Id },
                    new Guid[] { users.ElementAt(0).Id },
                    DateTime.Now
                ),
                new Article(Guid.NewGuid(),
                    "article2",
                    "preview2",
                    "description2",
                    "content2",
                    new Guid[] { categories.ElementAt(0).Id},
                    new Guid[] { users.ElementAt(1).Id },
                    DateTime.Now
                ),
                new Article(Guid.NewGuid(),
                    "article3",
                    "preview3",
                    "description3",
                    "content3",
                    new Guid[] { categories.ElementAt(1).Id},
                    new Guid[] { users.ElementAt(0).Id, users.ElementAt(1).Id },
                    DateTime.Now
                )
            };
        }
    }
}