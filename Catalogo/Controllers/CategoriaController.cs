using Catalogo.DataAccess;
using Catalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ContextAPI myDbContext;

        public CategoriaController(ContextAPI context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Categoria> GetALL()
        {
            return (this.myDbContext.Categoria.ToList());
        }

        [HttpGet("Find/{IdCategoria}")]
        public Categoria Find(long IdCategoria)
        {
            return (this.myDbContext.Categoria.FirstOrDefault(x => x.IdCategoria == IdCategoria));
        }

        [HttpPut]
        public string Update(Categoria categoria)
        {
            try
            {
                this.myDbContext.Categoria.Update(categoria);
                this.myDbContext.SaveChanges();
            }catch (Exception erro)
            {
                return erro.InnerException.Message.ToString();
            }

            return "{sucesso : true}";
        }

        [HttpDelete("Delete/{IdCategoria}")]
        public Object Delete(long IdCategoria)
        {
            try
            {
                Categoria CategoriaRemover = this.myDbContext.Categoria.First(x => x.IdCategoria == IdCategoria);
                this.myDbContext.Categoria.Remove(CategoriaRemover);
                this.myDbContext.SaveChanges();
            }
            catch (Exception erro)
            {
                return erro.InnerException.Message.ToString();
            }

            return "{sucesso : true}";
        }

        [HttpPost]
        public string Add(Categoria categoria)
        {
            try
            {
                this.myDbContext.Categoria.Add(categoria);
                this.myDbContext.SaveChanges();
            }
            catch (Exception erro)
            {
                return erro.InnerException.Message.ToString();
            }
            return "{sucesso : true}";
        }
    }
}
