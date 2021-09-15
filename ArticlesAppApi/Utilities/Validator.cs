using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ArticlesAppApi.Utilities
{
    /// <summary>
    ///  Валидатор.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Максимальное число записей на одной странице.
        /// </summary>
        public readonly int MaxPageSize;

        /// <summary>
        /// Инициализирует начальные значения.
        /// </summary>
        private Validator()
        {
            if (!Int32.TryParse(ConfigurationManager.AppSettings["MaxPageSize"], out MaxPageSize))
            {
                MaxPageSize = 100;
            }
        }

        /// <summary>
        /// Геттер экземпляра созданного класса валидатора.
        /// </summary>
        public static Validator Instance 
        { 
            get 
            {
                return instance == null
                    ? instance = new Validator()
                    : instance;               
            } 
        }

        /// <summary>
        /// Валидирует размер страницы.
        /// </summary>
        /// <param name="pageSize">Размер страницы для валидации.</param>
        public void ValidatePageSize(ref int pageSize)
        {
            if (pageSize > MaxPageSize)
            {
                pageSize = MaxPageSize;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }
        }

        /// <summary>
        /// Экзкмпляр класса валидатора.
        /// </summary>
        private static Validator instance;
    }
}