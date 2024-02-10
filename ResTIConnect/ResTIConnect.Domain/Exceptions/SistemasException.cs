namespace ResTIConnect.Domain.Exceptions;

public class SistemasException
    {
        public class SistemaNaoEncontradoException : Exception
        {
            public SistemaNaoEncontradoException() : base("Sistema não encontrado")
            {
            }
        }

        public class SistemaJaCadastradoException : Exception
        {
            public SistemaJaCadastradoException() : base("Sistema já cadastrado")
            {
            }
        }

        public class SistemaInvalidoException : Exception
        {
            public SistemaInvalidoException() : base("Sistema inválido")
            {
            }
        }
    };
