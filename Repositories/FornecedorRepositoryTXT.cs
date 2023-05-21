using Projeto03.Entities;
using Projeto03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryTXT : IFornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{fornecedor.IdFornecedor}.txt";

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine($"Id.......: {fornecedor.IdFornecedor}");
                streamWriter.WriteLine($"Nome.....: {fornecedor.Nome}");
                streamWriter.WriteLine($"CNPJ.....: {fornecedor.CNPJ}");

                foreach (var item in fornecedor.Produtos)
                {
                    streamWriter.WriteLine($"\tId..........: {item.IdProduto}");
                    streamWriter.WriteLine($"\tNome........: {item.Nome}");
                    streamWriter.WriteLine($"\tPreço.......: {item.Preco}");
                    streamWriter.WriteLine($"\tQuantidade..: {item.Quantidade}");
                    streamWriter.WriteLine($"\tData compra.: {item.DataCompra}");
                    streamWriter.WriteLine();
                }
            }
        }

        public void Importar(Guid idFornecedor)
        {
            //caminho do arquivo
            var path = $"c:\\temp\\fornecedor_{idFornecedor}.txt";

            //abrindo o arquivo para leitura.
            using (var streamReader = new StreamReader(path))
            {
                //lendo o arquivo até a útima linha do texto.
                var conteudo = streamReader.ReadToEnd();

                //imprimindo
                Console.WriteLine(conteudo);
            }
        }
    }
}
