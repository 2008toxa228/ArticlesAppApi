using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ArticlesAppApi.DataBaseProvider;
using ArticlesAppApi.Entities;
using ArticlesAppApi.Utilities;
using Newtonsoft.Json;

namespace ArticlesAppApi.Controllers
{
    /// <summary>
    /// Контроллер api для работы сайта со статьями.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArticlesController : ApiController
    {
        /// <summary>
        /// Фабрика провайдеров к базе данных.
        /// </summary>
        private static DataBaseProviderFactory dataBaseProviderFactory = new DataBaseProviderFactory();

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление статей.</returns>
        public IEnumerable<Article> GetArticlesPreviews(int page = 0, int pageSize = 10)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetArticles(page, pageSize)
                .Select(x => new Article() 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Preview = x.Preview,
                    Categories = x.Categories,
                    Authors = x.Authors,
                    Date = x.Date
                });
        }

        /// <summary>
        /// Получает статью по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор статьи.</param>
        /// <returns>Статью по указанному идентификатору.</returns>
        public Article GetArticleById(Guid id)
        {
            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetArticleById(id);
        }

        /// <summary>
        /// Получает пользователя по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователя по указанному идентификатору.</returns>
        public User GetUserById(Guid id)
        {
            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetUserById(id);
        }

        /// <summary>
        /// Получает категорию по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор категории.</param>
        /// <returns>Категорию по указанному идентификатору.</returns>
        public Category GetCategoryById(Guid id)
        {
            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetCategoryById(id);
        }

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра по указанной категории.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticlesPreviewsByCategory(Guid categoryId, int page = 0, int pageSize = 10)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetArticlesByCategory(categoryId, page, pageSize)
                .Select(x => new Article()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Preview = x.Preview,
                    Categories = x.Categories,
                    Authors = x.Authors,
                    Date = x.Date
                });
        }

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра по указанному автору.
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns></returns>
        public IEnumerable<Article> GetArticlesPreviewsByAuthor(Guid authorId, int page = 0, int pageSize = 10)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetArticlesByAuthor(authorId, page, pageSize)
                .Select(x => new Article()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Preview = x.Preview,
                    Categories = x.Categories,
                    Authors = x.Authors,
                    Date = x.Date
                });
        }

        /// <summary>
        /// Постранично возвращает категории.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление категорий.</returns>
        public IEnumerable<Category> GetCategories(int page = 0, int pageSize = 10)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetCategories(page, pageSize);
        }

        /// <summary>
        /// Постранично возвращает пользователей.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление пользователей.</returns>
        public IEnumerable<User> GetUsers(int page = 0, int pageSize = 10)
        {
            Validator.Instance.ValidatePageSize(ref pageSize);

            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .GetUsers(page, pageSize);
        }

        /// <summary>
        /// Удаляет статью по указанному идентификатору и возвращает результат удаления в виде булева значения.
        /// </summary>
        /// <param name="id">Идентификатор статьи для удаления.</param>
        /// <returns>Результат удаления статьи.</returns>
        public bool DeleteArticleById(Guid id)
        {
            return dataBaseProviderFactory
                .GetDataBaseProvider()
                .DeleteArticleById(id);
        }

        /// <summary>
        /// Обновляет параметры статьи по казанному идентификатору и переданным параметрам в JSON формате.
        /// </summary>
        /// <returns>Результат обновления статьи.</returns>
        [HttpPost]
        public bool UpdateArticleById()
        {
            // ToDo rewrite catch block.
            try
            {
                var articleJson = Request.Content.ReadAsStringAsync().Result;
                var article = JsonConvert.DeserializeObject<Article>(articleJson);
                var id = article.Id;

                return dataBaseProviderFactory
                    .GetDataBaseProvider()
                    .UpdateArticleById(id, article);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
