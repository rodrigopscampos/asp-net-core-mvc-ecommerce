using AspNetCoreMvcEcommerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        AspNetCoreMvcEcommerceContext _ctx;
        UserManager<IdentityUser> _userManager;

        public CheckoutController(AspNetCoreMvcEcommerceContext ctx, UserManager<IdentityUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        // GET: Checkout
        public ActionResult Index(string acao = null, int? produtoId = null)
        {
            var carrinho = PegarCarrinhoDeCompras();

            if (produtoId.HasValue)
            {
                var produto = carrinho.GetItem(produtoId.Value);

                switch (acao)
                {
                    case "incrementar":
                        produto.Quantidade++;
                        carrinho.SetItem(produto);
                        break;

                    case "decrementar":
                        produto.Quantidade--;
                        carrinho.SetItem(produto);

                        if (produto.Quantidade == 0)
                            carrinho.Remove(produtoId.Value);

                        break;

                    case "remover":
                        carrinho.Remove(produtoId.Value);
                        break;

                    default:
                        return StatusCode((int)HttpStatusCode.BadRequest, $"ação '{acao}' inválida");
                }
            }

            ViewBag.CarrinhoDeCompras = carrinho;
            SalvarCarrinhoDeCompras(carrinho);

            return View(carrinho);
        }

        public ActionResult Limpar()
        {
            var carrinho = PegarCarrinhoDeCompras();
            carrinho.Limpar();
            SalvarCarrinhoDeCompras(carrinho);

            return RedirectToAction("Index", "Home", null);
        }

        [Authorize]
        public ActionResult Continuar()
        {
            ViewBag.Estados = new[]
            {
                new SelectListItem { Value = "SP",  Text = "São Paulo", Selected = true },
                new SelectListItem { Value = "RJ",  Text = "Rio de Janeiro" },
                new SelectListItem { Value = "MG",  Text = "Minas Gerais"   }
            };

            var model = new Models.CheckoutDetalhesViewModel()
            {
                CcValidade = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Continuar(Models.CheckoutDetalhesViewModel detalhes)
        {
            if (ModelState.IsValid)
            {
                if (detalhes.CcValidade <= DateTime.Now)
                {
                    ModelState.AddModelError("", "Cartão de crédito expirado");
                }

                if (ModelState.IsValid)
                {
                    var carrinho = PegarCarrinhoDeCompras();

                    var ordem = new Ordem
                    {
                        DataDeCriacao = DateTime.Now,
                        DataDeEntrega = DateTime.Now.AddDays(5),
                        ClienteId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        Endereco = detalhes.Endereco,
                        CEP = detalhes.CEP,
                        CcNumero = detalhes.CcNumero,
                        CcValidade = detalhes.CcValidade,
                        OrdemItems = carrinho.Itens.Values.Select(i => new OrdemItem
                        {
                            Preco = i.PrecoTotal,
                            ProdutoId = i.ProdutoId,
                            Quantidade = i.Quantidade
                        }).ToArray()
                    };

                    _ctx.Ordens.Add(ordem);
                    _ctx.SaveChanges();

                    carrinho.Limpar();
                    SalvarCarrinhoDeCompras(carrinho);

                    return RedirectToAction("CompraRealizadaComSucesso", new { ordemId = ordem.Id });
                }
            }

            var errors = new List<ModelError>();
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    errors.Add(error);
                }
            }

            return View(detalhes);
        }

        public ActionResult CompraRealizadaComSucesso(int ordemId)
        {
            var ordem = _ctx.Ordens
                    .Include(o => o.Cliente)
                    .Include(o => o.OrdemItems.Select(i => i.Produto))
                    .FirstOrDefault(o => o.Id == ordemId);

            return View(ordem);
        }
    }
}