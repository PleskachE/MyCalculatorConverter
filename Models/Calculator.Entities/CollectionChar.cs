using Models.Calculator.Abstraction;

using System.Collections.Generic;

namespace Models.Calculator.Entities
{
    public class CollectionChar : ICollectionChar
    {
        public List<BaseSymbal> Symbals { get; set; }
        public CollectionChar() { Symbals = new List<BaseSymbal>(); }
        public CollectionChar(List<BaseSymbal> symbals) { this.Symbals = symbals; }
    }
}
