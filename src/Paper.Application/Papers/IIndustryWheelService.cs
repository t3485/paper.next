using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paper.Papers
{
    public interface IIndustryWheelService
    {
        Task<List<IndustryWheelDto>> GetAllIndustryWheel(IndustryWheelRequestDto input);
    }
}
