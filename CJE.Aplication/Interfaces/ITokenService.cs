using CJE.Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Aplication.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(UserExistingDto existingDto);
    }
}
