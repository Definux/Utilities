using System;
using System.Collections.Generic;
using System.Linq;

namespace Definux.Utilities.Objects
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int AllItemsCount { get; set; }

        public int ItemsCount => (Items != null) ? Items.Count() : 0;

        public int PagesCount
        {
            get
            {
                if (PageSize == 0)
                {
                    return 1;
                }

                return (int)Math.Ceiling(AllItemsCount / ((double)PageSize));
            }
        }

        public int PageSize { get; set; } = 10;

        public int CurrentPage { get; set; } = 1;

        public int StartRow => (CurrentPage - 1) * PageSize;
    }
}
