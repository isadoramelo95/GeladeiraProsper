namespace GeladeiraCodeRDIVersity
{
    public class Geladeira
    {
        private List<Andar> _andares;

        public Geladeira(int numAndares = 3)
        {
            _andares = new List<Andar>();

            for (int i = 0; i < numAndares; i++)
                _andares.Add(new Andar(i));
        }

        private Andar ObterAndar(int numAndar)
        {
            if (numAndar < 0 || numAndar >= _andares.Count)
                throw new Exception("Não foi encontrado o numero do andar");

            return _andares[numAndar];
        }

        public void AdicionarItem(int numAndar, int numContainer, int? posicao, List<Item> itens)
        {
            var andar = ObterAndar(numAndar);
            var container = andar.ObterContainer(numContainer);

            if (container == null)
                throw new Exception("Desculpe, número do container é incorreto!");

            if (posicao.HasValue)
            {
                if (itens.Count != 1)
                    throw new ArgumentException("Para adicionar um item específico, a lista de itens deve conter exatamente um item.");

                container.AdicionarItem(posicao.Value, itens[0]);
            }
            else
            {
                if (!container.EstaCheio())
                {
                    container.AdicionarItens(itens);
                }
                else
                {
                    Console.WriteLine("O container não tem espaço suficiente");
                }
            }
        }
        public void RemoverItem(int numAndar, int numContainer, int posicao)
        {
            var container = _andares[numAndar].ObterContainer(numContainer);
            container?.RemoverItemDoConatiner(posicao);
        }

        public void LimparContainer(int numAndar, int numContainer)
        {
            var container = _andares[numAndar].ObterContainer(numContainer);
            container?.EsvaziarGeladeira();
        }

        public void ExibirItens()
        {
            foreach (var andar in _andares)
                andar.ExibirItens();
        }
    }
}
//gerencia os andares
