using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class BooksDataAccess : IBooksDataAccess
    {
        private BookContext BookContext { get; }
        
        public BooksDataAccess(BookContext bookContext)
        {
            BookContext = bookContext;
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.BookContext.Books
                .ToListAsync(ct);
        }
    }
}