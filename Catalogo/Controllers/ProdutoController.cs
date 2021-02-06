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
    public class ProdutoController : ControllerBase
    {
        private ContextAPI myDbContext;

        public ProdutoController(ContextAPI context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Produto> GetALL()
        {
            return (this.myDbContext.Produto.ToList());
        }

        [HttpGet("Find/{IdProduto}")]
        public Produto Find(long IdProduto)
        {
            return (this.myDbContext.Produto.FirstOrDefault(x => x.IdProduto == IdProduto));
        }

        [HttpPut]
        public string Update(Produto produto)
        {
            try
            {
                this.myDbContext.Produto.Update(produto);
                this.myDbContext.SaveChanges();
            }
            catch (Exception erro)
            {
                return erro.InnerException.Message.ToString();
            }

            return "{sucesso : true}";
        }

        [HttpDelete("Delete/{IdProduto}")]
        public Object Delete(long IdProduto)
        {
            try
            {
                Produto ProdutoRemover = this.myDbContext.Produto.First(x => x.IdProduto == IdProduto);
                this.myDbContext.Produto.Remove(ProdutoRemover);
                this.myDbContext.SaveChanges();
            }
            catch (Exception erro)
            {
                return erro.InnerException.Message.ToString();
            }

            return "{sucesso : true}";
        }

        [HttpPost]
        public string Add(Produto produto)
        {
            try
            {
                this.myDbContext.Produto.Add(produto);
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
