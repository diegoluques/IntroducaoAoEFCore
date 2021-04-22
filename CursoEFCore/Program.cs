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
      //   InserirDadosEmMassa();
      //   ConsultarDados();
      //   CadastrarPedido();
      //   ConsultarPedido();
      AtualizarDados();
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

    private static void ConsultarDados()
    {
      using var db = new Date.ApplicationContext();
      //   var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
      var consultaPorMetodo = db.Clientes
        .Where(c => c.Id > 0)
        .OrderBy(c => c.Id)
        .ToList();

      foreach (var cliente in consultaPorMetodo)
      {
        db.Clientes.FirstOrDefault(c => c.Id == c.Id);
        Console.WriteLine($"Consultando o cliente Id: {cliente.Id}");
      }
    }

    private static void CadastrarPedido()
    {
      using var db = new Date.ApplicationContext();

      var cliente = db.Clientes.FirstOrDefault();
      var produto = db.Produtos.FirstOrDefault();

      var pedido = new Pedido
      {
        ClienteId = cliente.Id,
        IniciadoEm = DateTime.Now,
        FinalizadoEm = DateTime.Now,
        Observacao = "Pedido de Teste I",
        Status = StatusPedido.Analise,
        TipoFrete = TipoFrete.SemFrete,
        Itens = new List<PedidoItem>{
              new PedidoItem{
                ProdutoId = produto.Id,
                Desconto = 0,
                Quantidade = 1,
                Valor = 10,
              }
          }
      };

      db.Pedidos.Add(pedido);
      db.SaveChanges();
    }

    private static void ConsultarPedido()
    {
      using var db = new Date.ApplicationContext();

      var pedidos = db
          .Pedidos
          .Include(p => p.Itens)
              .ThenInclude(p => p.Produto)
          .ToList();
    }

    private static void AtualizarDados()
    {
      using var db = new Date.ApplicationContext();

      //var cliente = db.Clientes.FirstOrDefault(c => c.Id == 1);
      var cliente = db.Clientes.Find(1);
      cliente.Nome = "Diego Luques Atualizado";
      db.SaveChanges(); //Assim altera no banco de dados somente a propriedade que teve alteração

      //db.Clientes.Update(cliente); //Atualiza todas as propriedades como se tivesse alterações
      //db.SaveChanges();
    }
  }
}