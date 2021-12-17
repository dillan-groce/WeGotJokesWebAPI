using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeGotJokes.Models.AnimalJoke;
using WeGotJokes.Services;

namespace WeGotJokes.WebAPI.Controllers
{
    [Authorize]
    public class AnimalJokeController : ApiController
    {
        private AnimalJokeService CreateAnimalJokeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var animalJokeService = new AnimalJokeService(userId);
            return animalJokeService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            AnimalJokeService animalJokeService = CreateAnimalJokeService();
            var animalJokes = animalJokeService.GetAnimalJokes();
            return Ok(animalJokes);
        }

        [HttpPost]
        public IHttpActionResult Post(AnimalJokeCreate animalJoke)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAnimalJokeService();
            if (!service.CreateAnimalJoke(animalJoke))
                return InternalServerError();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            AnimalJokeService animalJokeService = CreateAnimalJokeService();
            var animalJoke = animalJokeService.GetAnimalJokeById(id);
            return Ok(animalJoke);
        }

        [HttpPut]
        public IHttpActionResult Put(AnimalJokeEdit animalJoke)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAnimalJokeService();
            if (!service.UpdateAnimalJoke(animalJoke))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAnimalJokeService();

            if (!service.DeleteAnimalJoke(id))
                return InternalServerError();
            return Ok();
        }
    }
}
