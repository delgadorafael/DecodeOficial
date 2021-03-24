using DecodeOficial.Application.DTO.Hobby;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DecodeOficial.Application.Query
{
    public class HobbySearchQuery : IRequest<IEnumerable<HobbyDTO>>
    {
        public string Search;
    }
}
