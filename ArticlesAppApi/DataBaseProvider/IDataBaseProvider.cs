using ArticlesAppApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticlesAppApi.DataBaseProvider
{
    /// <summary>
    /// Провайдер к базе данных.
    /// </summary>
    public interface IDataBaseProvider
    {
        /// <summary>
        /// Создает нвоую статью.
        /// </summary>
        Guid CreateNewArticle(Guid authorId);

        /// <summary>
        /// Получает статью по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор статьи.</param>
        /// <returns>Статью по указанному идентификатору.</returns>
        Article GetArticleById(Guid id);

        /// <summary>
        /// Получает пользователя по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователя по указанному идентификатору.</returns>
        User GetUserById(Guid id);

        /// <summary>
        /// Получает категорию по идентификатору и возвращает ее.
        /// </summary>
        /// <param name="id">Идентификатор категории.</param>
        /// <returns>Категорию по указанному идентификатору.</returns>
        Category GetCategoryById(Guid id);

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление статей.</returns>
        IEnumerable<Article> GetArticles(int page, int pageSize);

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра по указанному автору.
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns></returns>
        IEnumerable<Article> GetArticlesByAuthor(Guid authorId, int page, int pageSize);

        /// <summary>
        /// Постранично возвращает статьи для предварительного просмотра по указанной категории.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns></returns>
        IEnumerable<Article> GetArticlesByCategory(Guid categoryId, int page, int pageSize);

        /// <summary>
        /// Постранично возвращает категории.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление категорий.</returns>
        IEnumerable<Category> GetCategories(int page, int pageSize);

        /// <summary>
        /// Постранично возвращает пользователей.
        /// </summary>
        /// <param name="page">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Перечисление пользователей.</returns>
        IEnumerable<User> GetUsers(int page, int pageSize);

        /// <summary>
        /// Удаляет статью по указанному идентификатору и возвращает результат удаления в виде булева значения.
        /// </summary>
        /// <param name="id">Идентификатор статьи для удаления.</param>
        /// <returns>Результат удаления статьи.</returns>
        bool DeleteArticleById(Guid id);

        /// <summary>
        /// Обновляет параметры статьи по казанному идентификатору и переданным параметрам в JSON формате.
        /// </summary>
        /// <param name="id">Идентификатор статьи.</param>
        /// <param name="articleJson">JSON представление статьи с измененными параметрами.</param>
        /// <returns>Результат обновления статьи.</returns>
        bool UpdateArticleById(Guid id, Article article);
    }
}