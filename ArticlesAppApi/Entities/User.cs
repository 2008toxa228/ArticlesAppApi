using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ArticlesAppApi.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id;

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name;

        /// <summary>
        /// Инициализиреут начальные значения переменных.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="name">Имя пользователя.</param>
        public User(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Возвращает строковое представление пользователя.
        /// </summary>
        /// <returns>Строковое представление пользователя.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}