using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeOficial.Infrastructure.Data.Repositories
{
    public class RepositoryProfession : RepositoryBase<Profession>, IRepositoryProfession
    {
        private readonly DecodeContext _decodeContext;

        public RepositoryProfession(DecodeContext decodeContext) : base(decodeContext)
        {
            _decodeContext = decodeContext;
        }
    }
}
