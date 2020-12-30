using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private ILogger<BooksController> Logger { get; }
        private IBooksDataAccess BooksDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public BooksController(ILogger<BooksController> logger, IBooksDataAccess booksDataAccess, IMapper mapper)
        {
            Logger = logger;
            BooksDataAccess = booksDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Books>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(BooksController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<Books>>(await this.BooksDataAccess.GetAllAsync(ct));
        }
    }
}