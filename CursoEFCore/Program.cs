using System;
using System.Linq;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      using var db = new Date.ApplicationContext();

      var existe = db.Database.GetPendingMigrations().Any();
      if (existe)
      {

      }

      InserirDados();

      Console.ReadLine();
    }

    private static void InserirDados()
    {
      var produto = new Produto
      {
        Descricao = "Produto de teste I",
        CodigoBarras = "000001",
        Valor = 125.00M,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };

      using var db = new Date.ApplicationContext();
      //db.Produtos.Add(produto); //Mais utilizados
      //db.Set<Produto>().Add(produto); //Mais utilizados
      //db.Entry(produto).State = EntityState.Added;
      db.Add(produto);

      var registros = db.SaveChanges();
      Console.WriteLine($"Total de registro adicionado: {registros}");
    }
  }
}
