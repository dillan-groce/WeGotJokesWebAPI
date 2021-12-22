using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeGotJokes.Models.DadJoke;
using WeGotJokes.Services;

namespace WeGotJokes.WebAPI.Controllers
{
    [Authorize]
    public class DadJokeController : ApiController
    {
        private DadJokeService CreateDadJokeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dadJokeService = new DadJokeService(userId);
            return dadJokeService;
        }
        
        [HttpGet]
        public IHttpActionResult GetAllDadJokes()
        {
            DadJokeService dadJokeService = CreateDadJokeService();
            var dadJokes = dadJokeService.GetDadJokes();
            return Ok(dadJokes);
        }

        [HttpPost]
        public IHttpActionResult CreateDadJoke([FromBody]DadJokeCreate dadJoke)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDadJokeService();

            if (!service.CreateDadJoke(dadJoke))
                return InternalServerError();
            
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetDadJokeById([FromUri] int id)
        {
            DadJokeService dadJokeService = CreateDadJokeService();
            var dadJoke = dadJokeService.GetDadJokeById(id);

            return Ok(dadJoke);
        }

        [HttpPut]
        public IHttpActionResult UpdateDadJoke([FromBody] DadJokeEdit dadJoke)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDadJokeService();

            if (!service.UpdateDadJoke(dadJoke))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDadJoke([FromUri] int id)
        {
            var Service = CreateDadJokeService();

            if (!Service.DeleteDadJoke(id))
                return InternalServerError();

            return Ok();
        }
    }
}
