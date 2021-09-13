using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ArticlesAppApi.Entities
{
    /// <summary>
    /// СУщность статьи.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Идентификатор статьи.
        /// </summary>
        public Guid Id;

        /// <summary>
        /// Название статьи.
        /// </summary>
        public string Name;

        /// <summary>
        /// Краткое описание статьи.
        /// </summary>
        public string Preview;

        /// <summary>
        /// Описание статьи.
        /// </summary>
        public string Description;

        /// <summary>
        /// Содержание стати.
        /// </summary>
        public string Content;

        /// <summary>
        /// Категрии статьи.
        /// </summary>
        public IEnumerable<Guid> Categories;

        /// <summary>
        /// Авторы статьи.
        /// </summary>
        public IEnumerable<Guid> Authors;

        /// <summary>
        /// Дата создания стати.
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// Флаг обозначающий нахождение стати в избранных.
        /// </summary>
        public bool IsFavorite;

        /// <summary>
        /// Видимость статьи.
        /// </summary>
        public bool IsVisible;

        /// <summary>
        /// Инициализирует значения переменных.
        /// </summary>
        public Article()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Инициализирует значения переменных.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="name">Название.</param>
        /// <param name="preview">Краткое описание.</param>
        /// <param name="description">Описание.</param>
        /// <param name="content">Содержание.</param>
        /// <param name="categories">Категории.</param>
        /// <param name="authors">Авторы.</param>
        /// <param name="date">Дата.</param>
        /// <param name="isFavorite">Флаг обозначающий нахождение стати в избранных.</param>
        public Article(Guid id, string name, string preview, string description, string content, IEnumerable<Guid> categories, IEnumerable<Guid> authors, DateTime date, bool isFavorite = false)
        {
            this.Id = id;
            this.Name = name;
            this.Preview = preview;
            this.Description = description;
            this.Content = content;
            this.Categories = categories;
            this.Authors = authors;
            this.Date = date.ToUniversalTime();
            this.IsFavorite = isFavorite;
            this.IsVisible = true;
        }

        /// <summary>
        /// Инициализирует значения переменных.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="name">Название.</param>
        /// <param name="preview">Краткое описание.</param>
        /// <param name="description">Описание.</param>
        /// <param name="content">Содержание.</param>
        /// <param name="date">Дата.</param>
        /// <param name="isFavorite">Флаг обозначающий нахождение стати в избранных.</param>
        public Article(Guid id, string name, string preview, string description, string content, DateTime date, bool isFavorite = false)
        {
            this.Id = id;
            this.Name = name;
            this.Preview = preview;
            this.Description = description;
            this.Content = content;
            this.Date = date.ToUniversalTime();
            this.IsFavorite = isFavorite;
            this.IsVisible = true;
        }

        /// <summary>
        /// Конвертирует сущность строки в текстовое представление.
        /// </summary>
        /// <returns>Текстовое представление статьив JSON формате.</returns>
        public override string ToString()
        {
            Date = Date.ToUniversalTime();
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Создает экземпляр класса статьи по входной строке JSON формата.
        /// </summary>
        /// <param name="jsonString">JSON представление сущности статьи.</param>
        /// <returns>Экземпляр класса статьи.</returns>
        public static Article GetFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Article>(jsonString);
        }

        /// <summary>
        /// Обновляет параметры статьи по передаваемому экземпляру класса статьи.
        /// </summary>
        /// <param name="article">Экземпляр класса статьи для обновления параметров.</param>
        public void UpdateValues(Article article)
        {
            this.Id = article.Id;
            this.Name = article.Name;
            this.Preview = article.Preview;
            this.Description = article.Description;
            this.Content = article.Content;
            this.Categories = article.Categories;
            this.Authors = article.Authors;
            this.Date = article.Date;
            this.IsFavorite = article.IsFavorite;
            this.IsVisible = article.IsVisible;
        }
    }
}