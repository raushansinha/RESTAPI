using Library.API.Entities;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Helpers;

namespace Library.API.Controllers
{
  [Route("api/authors")]
  public class AuthorsControllers : Controller
  {
    private ILibraryRepository _libraryRepository;

    public AuthorsControllers(ILibraryRepository libraryRepository)
    {
      _libraryRepository = libraryRepository;
    }

    [HttpGet()]
    public IActionResult GetAuthors()
    {
      var authorsFromRepo = _libraryRepository.GetAuthors();

      var authors = new List<AuthorDto>();

      foreach (var author in authorsFromRepo)
      {
        authors.Add(new AuthorDto()
        {
          Id = author.Id,
          Name = $"{author.FirstName} {author.LastName}",
          Genre = author.Genre,
          age = author.DateOfBirth.GetCurrentAge()
        });
      }
      
      return new JsonResult(authors);
    }
  }
}
