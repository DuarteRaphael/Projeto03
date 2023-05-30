// See https://aka.ms/new-console-template for more information
using Projeto03.Entities;
using Projeto03.Interfaces;
using Projeto03.Repositories;

//criando um objeto Fornecedor utilizando o construtor com entrada de argumentos.
var fornecedor = new Fornecedor(Guid.NewGuid(), "Contoso INC", "74.121.704/0001-59");

//inicializando a lista de produtos do fornecedor.
fornecedor.Produtos = new List<Produto>();

//adicionando produtos na lista
fornecedor.Produtos.Add(new Produto(Guid.NewGuid(), "Notebook Dell G15", 7800, 10, new DateTime(2023, 05, 19)));
fornecedor.Produtos.Add(new Produto(Guid.NewGuid(), "Mochila", 500, 20, new DateTime(2023, 05, 18)));
fornecedor.Produtos.Add(new Produto(Guid.NewGuid(), "Celular", 1000, 15, new DateTime(2023, 05, 17)));

try
{
    Console.Write("Informe o tipo de arquivo desejado (JSON ou TXT: ");
    var tipo = Console.ReadLine();

    IFornecedorRepository fornecedorRepository = null;

    if (tipo.Equals("JSON", StringComparison.OrdinalIgnoreCase))
    {
        fornecedorRepository = new FornecedorRepositoryJSON();
    }
    else if (tipo.Equals("TXT", StringComparison.OrdinalIgnoreCase))
    {
        fornecedorRepository = new FornecedorRepositoryTXT();
    }
    else
    {
        //lançar para o bloco catch
        throw new Exception("Tipo de arquivo inválido!");
    }

    //exportar fornecedor.
    fornecedorRepository.Exportar(fornecedor);
    fornecedorRepository.Importar(fornecedor.IdFornecedor);
    
    //Console.WriteLine("\nOperação realizada com sucesso.");
}
catch (Exception e)
{
    Console.WriteLine($"Erro: {e.Message}");
}

Console.ReadKey();
