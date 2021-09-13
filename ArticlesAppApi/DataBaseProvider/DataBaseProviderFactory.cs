using ArticlesAppApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticlesAppApi.DataBaseProvider
{
    /// <summary>
    /// Фабрика провайдеров к базе данных.
    /// </summary>
    public class DataBaseProviderFactory
    {
        /// <summary>
        /// Провайдер к тестовой базе данных с мок объектами.
        /// </summary>
        MockDataBaseProvider mockDataBaseProvider = new MockDataBaseProvider();

        /// <summary>
        /// Возвращает нужный провайдер к базе данных.
        /// </summary>
        /// <returns>Возвращает нужный провайдер к базе данных.</returns>
        public IDataBaseProvider GetDataBaseProvider()
        {
            return mockDataBaseProvider;
        }
    }
}