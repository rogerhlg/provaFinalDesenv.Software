using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Criptomoeda" },
                    new Categoria { CategoriaId = 2, Nome = "NFT" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "GRBE", Preco = 1, Quantidade = 1, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "CRACER", Preco = 2, Quantidade = 2, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "CCAR", Preco = 3, Quantidade = 3, CategoriaId = 1 },
                }
            );
            _context.Pagamentos.AddRange(new Pagamento[]
                {
                    new Pagamento { PagamentoId = 1, Nome = "PIX", Tipo = "A vista" },
                    new Pagamento { PagamentoId = 2, Nome = "Cartao", Tipo = "Credito" },
                    new Pagamento { PagamentoId = 3, Nome = "Boleto", Tipo = "A vista" },
                }
            );

            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}