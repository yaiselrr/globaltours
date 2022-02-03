using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        // inyectamos nuestro DbContext para la conexion a traves de un contructor
        private readonly ApplicationDbContext _db;
        public LugaresController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        // public ActionResult<List<lugar>> GetLugares(){
        public async Task<ActionResult<List<lugar>>> GetLugares(){ // Asincrono
            var lugares = await _db.Lugar.ToListAsync(); // Va a traerme una lista del modelo Lugar

            return Ok(lugares);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<lugar>> GetLugar(int id){
            return await _db.Lugar.FindAsync(id);
        }
    }
}