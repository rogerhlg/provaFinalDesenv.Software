using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }
        
        //POST: api/venda/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            var itensVendas = _context.ItensVenda.
                Include(i => i.Produto.Categoria).
                Where(i => i.CarrinhoId == venda.CarrinhoId).
                ToList();
            venda.Itens = itensVendas;
            Pagamento pagamento = _context.Pagamentos.Find(venda.PagamentoId);
            venda.Pagamento = pagamento;

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            return Created("", venda);
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            var vendas = _context.Vendas.
                Include(i => i.Itens).
                Include(i => i.Pagamento).
                ToList();

            foreach (var venda in vendas)
            {
                var itens = venda.Itens;
                foreach (var item in itens)
                {
                    item.Produto = _context.Produtos.Find(item.ProdutoId);
                    item.Produto.Categoria = _context.Categorias.Find(item.Produto.CategoriaId);
                }
            }
            return Ok(vendas);
        }
    }
}