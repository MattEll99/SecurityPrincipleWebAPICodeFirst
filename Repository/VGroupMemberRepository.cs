using SecurityPrincipleWebAPICodeFirst.Data;
using SecurityPrincipleWebAPICodeFirst.Interfaces;
using SecurityPrincipleWebAPICodeFirst.Models;
using static SecurityPrincipleWebAPICodeFirst.Data.DataContext;

namespace SecurityPrincipleWebAPICodeFirst.Repository
{
    public class vGroupMembersRepository : RepositoryBase, IvGroupMemberRepository
    {
        public vGroupMembersRepository(DataContext Scontext, TDataContext Tcontext) : base(Scontext, Tcontext)
        {

        }
        public ICollection<VGroupMember> GetVGroupMembers(string DbContext)
        {

            return GetDbContext(DbContext).VGroupMembers.ToList();

            throw new NotImplementedException();
        }

        public List<VGroupMember> GetVGroupMembersByGroupName(string groupDisplayName, string DbContext)
        {
            return GetDbContext(DbContext).VGroupMembers.Where(gdn => gdn.GroupDisplayName == groupDisplayName).ToList();
            throw new NotImplementedException();
        }
    }
}
