using SecurityPrincipleWebAPICodeFirst.Models;

namespace SecurityPrincipleWebAPICodeFirst.Interfaces
{
    public interface IvGroupMemberRepository
    {
        //Get and Read.
        public ICollection<VGroupMember> GetVGroupMembers(string DbContext);
        public List<VGroupMember> GetVGroupMembersByGroupName(string groupDisplayName, string DbContext);
    }
}
