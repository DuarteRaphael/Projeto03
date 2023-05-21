using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Entities
{
    public class Fornecedor
    {
        #region Properties
        public Guid IdFornecedor { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        #endregion

        #region relacionamento
        public List<Produto>? Produtos { get; set; }
        #endregion

        #region Contructors
        public Fornecedor()
        {
            //padrão
        }

        public Fornecedor(Guid idfornecedor, string nome, string cnpj)
        {
            IdFornecedor = idfornecedor;
            Nome = nome;
            CNPJ = cnpj;
        }
        #endregion
    }
}
