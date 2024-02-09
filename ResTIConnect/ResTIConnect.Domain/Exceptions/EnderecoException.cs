namespace ResTIConnect.Domain.Exceptions;

    public class EnderecoException
    {
        public class EnderecoNaoEncontradoException : Exception
        {
            public EnderecoNaoEncontradoException() : base("Endereço não encontrado")
            {
            }
        }

        public class EnderecoJaCadastradoException : Exception
        {
            public EnderecoJaCadastradoException() : base("Endereço já cadastrado")
            {
            }
        }

        public class EnderecoInvalidoException : Exception
        {
            public EnderecoInvalidoException() : base("Endereço inválido")
            {
            }
        }
    };

