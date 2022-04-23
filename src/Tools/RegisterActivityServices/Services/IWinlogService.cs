using RegisterActivityServices.DTO;
using System.Collections.Generic;

namespace RegisterActivityServices.Services
{
    public interface IWinlogService
    {
        List<TimelineEventsDTO> ReadDB(string file);
    }
}