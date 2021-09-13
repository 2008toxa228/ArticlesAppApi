using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ArticlesAppApi.Entities
{
    /// <summary>
    /// Категория.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id;

        /// <summary>
        /// Название.
        /// </summary>
        public string Name;

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description;

        /// <summary>
        /// Инициализиреут начальные значения переменных.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="name">Название.</param>
        /// <param name="description">Описание.</param>
        public Category(Guid id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Возвращает строковое представление категории.
        /// </summary>
        /// <returns>Строковое представление категории.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}