using SecurityPrincipleWebAPICodeFirst.Data;
using static SecurityPrincipleWebAPICodeFirst.Data.DataContext;

namespace SecurityPrincipleWebAPICodeFirst.Repository
{
    public class RepositoryBase
    {
        private readonly DataContext _Scontext;
        private readonly DataContext _Tcontext;
        public RepositoryBase(DataContext Scontext, TDataContext Tcontext)
        {
            _Scontext = Scontext;
            _Tcontext = Tcontext;
        }
        protected DataContext GetDbContext(string DbName)
        {
            if (DbName.ToUpper() == "S")
            {
                return _Scontext;
            }
            else if (DbName.ToUpper() == "T")
            {
                return _Tcontext;
            }
            else
                throw new Exception($"Invalid DbName {DbName}");
        }
    }
}
