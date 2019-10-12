using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string JobpostCollectionName { get; set; }
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IBookstoreDatabaseSettings
    {
        string JobpostCollectionName { get; set; }
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
