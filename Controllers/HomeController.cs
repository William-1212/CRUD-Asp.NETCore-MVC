using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [RequireHttps]
        public IActionResult Index()
        {
            using(var db=new AgendaSQLITE()){
                return View(db.Agendas.ToList());//exibe tudos os dados
            }
        }   
        public IActionResult alterar(int id)
        {
          using(var db=new AgendaSQLITE()){
                return View(db.Agendas.Where(e => e.id==id).ToList());//exibe tudos os dados
            }
        
        }
        [Route("Home/alterar/altval")]
        public IActionResult altval(int id,string nome,string sobrenome)
        {
              using (var context = new AgendaSQLITE()) //conecta com o banco de dados
              {
                     var alterar = new AgendaModel() //adiciona valores nos campos
                     {
                      id=id,
                      nome = nome,
                      sobrenome = sobrenome
                      };
                 context.Agendas.Update(alterar); 
                 context.SaveChanges(); 
               }
            return RedirectToAction("Index");//retorna  para o inicio
           
            
        }
         
         public IActionResult inserir()
        {
            return View();
        }
        [Route("Home/inserir/redirect")]
         public IActionResult redirect(string nome,string sobrenome)
         {

              using (var context = new AgendaSQLITE()) //conecta com o banco de dados
              {
                     var novo = new AgendaModel() //adiciona valores nos campos
                     {
                      nome = nome,
                      sobrenome = sobrenome
                      };
                 context.Agendas.Add(novo); 
                 context.SaveChanges(); 
               }
            return RedirectToAction("Index");//retorna  para o inicio


         }
         
         public IActionResult excluir(int id)
        {
              using (var context = new AgendaSQLITE()) //conecta com o banco de dados
              {
                     var remover = new AgendaModel() //adiciona valores nos campos
                     {
                      id = id
                      };
                 context.Agendas.Remove(remover); 
                 context.SaveChangesAsync(); 
               }
            return RedirectToAction("Index");//retorna  para o inicio
        }  
            
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
