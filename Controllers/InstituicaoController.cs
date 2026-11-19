using IES.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace IES.Controllers;

public class InstituicaoController : Controller
{
    private static IList<Instituicao> instituicoes = new List<Instituicao>()
    {
        new Instituicao()
        {
            InstituicaoID = 1,
            Nome = "UniParaná",
            Endereco = "Paraná"
        },
        new Instituicao()
        {
            InstituicaoID = 2,
            Nome = "UniSanta",
            Endereco = "Santa Catarina"
        },
        new Instituicao()
        {
            InstituicaoID = 3,
            Nome = "UniSãoPaulo",
            Endereco = "São Paulo"
        },
        new Instituicao()
        {
            InstituicaoID = 4,
            Nome = "UniSulGrandense",
            Endereco = "Rio Grande do Sul"
        },
        new Instituicao()
        {
            InstituicaoID = 5,
            Nome = "UniCarioca",
            Endereco = "Rio de Janeiro"
        }


    };

    public IActionResult Index()
    {
        return View(instituicoes.OrderBy(i => i.Nome));
    }

    //GET: Instituicao/Create
    public IActionResult Create()
    {
        return View();
    }

    //POST: Instituicao/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Instituicao instituicao)
    {
        instituicao.InstituicaoID = instituicoes.Count > 0 ? instituicoes.Max(i => i.InstituicaoID) + 1 : 1;
        instituicoes.Add(instituicao);
        return RedirectToAction(nameof(Index));
    }

    //GET: Instituicao/Edit/5
    public IActionResult Edit(long id)
    {
        var instituicao = instituicoes.FirstOrDefault(i => i.InstituicaoID == id);
        if (instituicao == null)
        {
            return NotFound();

        }
        return View(instituicao);
    }

    //POST: instituicao/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Instituicao instituicao)
    {
        var inst = instituicoes.FirstOrDefault(i => i.InstituicaoID == instituicao.InstituicaoID);
        if (inst == null)
        {
            return NotFound();
        }
        inst.Nome = instituicao.Nome;
        inst.Endereco = instituicao.Endereco;

        return RedirectToAction(nameof(Index));

    }
}