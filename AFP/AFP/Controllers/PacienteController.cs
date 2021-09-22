using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly PacienteContext context;
        public PacienteController()
        {
            context = new PacienteContext();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            return context.GetAll();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Paciente p)
        {
            if (ModelState.IsValid)
                context.Add(p);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Paciente p)
        {
            p.Id = id;
            if (ModelState.IsValid)
                context.Update(p);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Delete(id);
        }
    }
}
