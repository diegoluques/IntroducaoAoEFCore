using System;
using System.Collections.Generic;
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

      //   InserirDados();
      InserirDadosEmMassa();

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

    private static void InserirDadosEmMassa()
    {
      var produto = CriarProduto();
      var cliente = CriarCliente();
      List<Cliente> listaClientes = CriarListaDeClientes();

      using var db = new Date.ApplicationContext();
      //   db.AddRange(produto, cliente);
      db.AddRange(listaClientes);

      var registros = db.SaveChanges();
      Console.WriteLine($"Total de registros: {registros}");
    }

    private static List<Cliente> CriarListaDeClientes()
    {
      return new List<Cliente>
      {
            new Cliente
            {
              Nome = "Diego Luques 001",
              Cep = "00000078",
              Cidade = "Cuiabá",
              Estado = "MT",
              Telefone = "65988888888"
            },
            new Cliente
            {
              Nome = "Diego Luques 002",
              Cep = "00000078",
              Cidade = "Cuiabá",
              Estado = "MT",
              Telefone = "65988888888"
            }
      };
    }

    private static Cliente CriarCliente()
    {
      return new Cliente
      {
        Nome = "Diego Luques 000",
        Cep = "00000078",
        Cidade = "Cuiabá",
        Estado = "MT",
        Telefone = "65988888888"
      };
    }

    private static Produto CriarProduto()
    {
      return new Produto
      {
        Descricao = "Produto de teste I",
        CodigoBarras = "000001",
        Valor = 125.00M,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
      };
    }

  }
}