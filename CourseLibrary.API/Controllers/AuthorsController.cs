﻿using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.ResourceParameters;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        //public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery(Name = "mainCategory")] string queryAuthor, string searchQuery)
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(AuthorResourceParameters authorsResourceParameter)
        {
           
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameter);

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }





    }
}
