﻿namespace ApiJwtEFInMemory.DDD.Domain.Entities
{
    public class Produto
    {
        private string _codigoBarras;
        public string CodigoBarras
        {
            get => _codigoBarras;
            set => _codigoBarras = value?.Trim().ToUpper();
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim();
        }

        public double Preco { get; set; }

        //Navigation Property
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
