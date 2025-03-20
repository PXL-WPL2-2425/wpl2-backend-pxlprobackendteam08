using ClassLibTeam08.Data.Framework;
using System.Data;

namespace ClassLibrary08.Data.Framework
{
    public class DeleteResult : BaseResult
    {
        public DataTable DataTable { get; set; }
    }
}
