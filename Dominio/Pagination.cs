using System.Collections.Generic;

namespace Dominio
{
    public abstract class Pagination<T> where T : class
    {
        public List<T> content { get; set; }
        public Pageable pageable { get; set; }
        public bool last { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set; }
        public int size { get; set; }
        public int number { get; set; }
        public Sort sort { get; set; }
        public bool first { get; set; }
        public int numberOfElements { get; set; }
        public bool empty { get; set; }
    }

    public class Pageable
    {
        public Sort sort { get; set; }
        public int offset { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public bool paged { get; set; }
        public bool unpaged { get; set; }
    }

    public class Sort
    {
        public bool empty { get; set; }
        public bool sorted { get; set; }
        public bool unsorted { get; set; }
    }
}
