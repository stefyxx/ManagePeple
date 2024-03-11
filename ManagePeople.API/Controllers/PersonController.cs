﻿using ManagePeople.API.Models;
using ManagePeople.BLL.Services;
using ManagePeople.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagePeople.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController (PersonServices _personServices) : ControllerBase
    {
        // Test: to get all people into DB
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<Person> people = _personServices.GetAll();
                return Ok(people);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("/search/")]
        public IActionResult Search([FromQuery] PersonDTO dto ) 
        {
            try
            {
                IEnumerable<Person> result = _personServices.Search(dto.lastName,dto.firstName);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Person? person = _personServices.Get(id);
                if(person == null) return NotFound();
                return Ok(person);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
           
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO dto)
        {
            try
            {
                Person added = _personServices.Register(Mappers.ToDAL(dto));
                return Ok(added);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PersonDTO value)
        {
            try
            {
                Person? updated = _personServices.Update(id, value.lastName, value.lastName);
                if(updated == null) return NotFound();
                return Ok(updated);
            }
            catch (Exception ex) { return BadRequest(ex.Message);}
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _personServices.Delete(id);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
