using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Email.Middlewares;
using Api.Models;

namespace ApiCartaoVirtual.Controllers
{
    [Route("api/cartaovirtual")]
    [ApiController]
    public class CartaoVirtualsController : ControllerBase
    {
        private readonly ApiContext _context;

        public CartaoVirtualsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CartaoVirtuals/email
        [HttpGet]
        [Route("email/{email}")]
        public async Task<ActionResult<List<CartaoVirtual>>> GetCartaoVirtualByEmail(string email)
        {
            var enderecoEmail = new EnderecoEmail(email);
            if(enderecoEmail.valido() == true)
            {
                var cartaoVirtual = await _context.CartaoVirtuals.Where(field => field.Email == email).OrderByDescending(field => field.DataCriacao).AsNoTracking().ToListAsync();
                return cartaoVirtual;
            }
            return NotFound();
        }

        // POST: api/cartaovirtual
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Object>> PostCartaoVirtual(CartaoVirtual cartaoVirtual)
        {
            Random numeroRandomico = new();
            string numeroVirtual = "";
            for (int i = 1; i <= 15; i++)
            {
                numeroVirtual += numeroRandomico.Next(1, 10);
            }
            cartaoVirtual.Id = Guid.NewGuid();
            cartaoVirtual.NumeroCartao = numeroVirtual;
            cartaoVirtual.DataCriacao = DateTime.Now;
            _context.CartaoVirtuals.Add(cartaoVirtual);
            await _context.SaveChangesAsync();
            object data = new { numeroCartao = cartaoVirtual.NumeroCartao };
            return data;
        }
    }
}
