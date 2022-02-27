using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHP.CodingChallenge.Backend.Mapping.Data;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace MHP.CodingChallenge.Backend.Mapping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private ILogger<ArticleController> _logger;
        private ArticleService _articleService;

        public ArticleController(ILogger<ArticleController> logger,
            ArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ArticleDto> articleList = _articleService.GetAll();

            return new JsonResult(articleList);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            ArticleDto article = _articleService.GetById(id) as ArticleDto;
            if (article == null)
                return NotFound();
            return new JsonResult(article);
        }

        [HttpPost]
        public IActionResult Create(ArticleDto article)
        {
            return new JsonResult(_articleService.Create(article));
        }
    }
}
