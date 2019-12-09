using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParameterBinders.Models;
using ParameterBinders.Services;
namespace ParameterBinders.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IService<Player> service;

        public PlayerController(IService<Player> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res = service.GetAsync().Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = service.GetAsync(id).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("PostByFromBody")]
        public IActionResult PostByFromBody([FromBody] Player player)
        {
            try
            {
                var res = service.PostAsync(player).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("PostByParameters")]
        public IActionResult PostByParameters(string playerId, string playerName, string game)
        {
            try
            {
                var player = new Player()
                {
                     PlayerId= playerId,
                     PlayerName = playerName,
                     Game = game
                };
                var res = service.PostAsync(player).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ActionName("PostByFromQuery")]
        public IActionResult PostByFromQuery([FromQuery] Player player)
        {
            try
            {
                var res = service.PostAsync(player).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{playerId}/{playerName}/{game}")]
        [ActionName("PostByFromRoute")]
        public IActionResult PostByFromRoute([FromRoute] Player player)
        {
            try
            {
                var res = service.PostAsync(player).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("PostByFromForm")]
        public IActionResult PostByFromForm([FromForm] Player player)
        {
            try
            {
                var res = service.PostAsync(player).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}