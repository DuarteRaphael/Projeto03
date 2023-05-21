using Newtonsoft.Json;
using Projeto03.Entities;
using Projeto03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryJSON : IFornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{fornecedor.IdFornecedor}.json";
            using (var streamWriter = new StreamWriter(path))
            {
                //serealizando
                var json = JsonConvert.SerializeObject(fornecedor);

                //escrevendo o JSON
                streamWriter.WriteLine(json);
            }
        }

        public void Importar(Guid idFornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{idFornecedor}.json";
            using (var streamReader = new StreamReader(path))
            {
                //ler o conteúdo do arquivo
                var conteudo = streamReader.ReadToEnd();

                //deserializar o conteúdo JSON lido do arquivo
                var fornecedor = JsonConvert.DeserializeObject<Fornecedor>(conteudo);

                //imprimindo
                Console.WriteLine("\nDados do Fornecedor\n");
                Console.WriteLine($"Id: {fornecedor.IdFornecedor}");
                Console.WriteLine($"Nome: {fornecedor.Nome}");
                Console.WriteLine($"CNPJ: {fornecedor.CNPJ}");

                foreach (var item in fornecedor.Produtos)
                {
                    Console.WriteLine($"Id: {item.IdProduto}");
                    Console.WriteLine($"Nome: {item.Nome}");
                    Console.WriteLine($"Preço: {item.Preco}");
                    Console.WriteLine($"Quantidade: {item.Quantidade}");
                    Console.WriteLine($"Data de cadastro: {item.DataCompra}");
                    Console.WriteLine();
                }
            }
        }
    }
}
