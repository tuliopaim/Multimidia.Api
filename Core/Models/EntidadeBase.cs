using System;

namespace Multimidia.Api.Core.Models
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}