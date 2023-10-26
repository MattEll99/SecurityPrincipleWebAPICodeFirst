using SecurityPrincipleWebAPICodeFirst.Data;
using SecurityPrincipleWebAPICodeFirst.DTO;
using SecurityPrincipleWebAPICodeFirst.Interfaces;
using SecurityPrincipleWebAPICodeFirst.Models;
using static SecurityPrincipleWebAPICodeFirst.Data.DataContext;

namespace SecurityPrincipleWebAPICodeFirst.Repository
{
    public class SecurityPrincipleRepository : RepositoryBase, ISecurityPrincipleRepository
    {
        public SecurityPrincipleRepository(DataContext Scontext, TDataContext Tcontext) : base(Scontext, Tcontext)
        {

        }

        public SecurityPrinciple GetSecurityPrincipleById(int id, string DbContext)
        {
            return GetDbContext(DbContext).SecurityPrinciples.Where(s => s.Id == id).FirstOrDefault();
        }

        public SecurityPrinciple GetSecurityPrincipleByDisplayName(string displayName, string DbContext)
        {
            return GetDbContext(DbContext).SecurityPrinciples.Where(s => s.DisplayName == displayName).FirstOrDefault();
        }

        public ICollection<SecurityPrinciple> GetSecurityPrinciples(string DbContext)
        {
            var content = GetDbContext(DbContext).SecurityPrinciples.OrderBy(sp => sp.Id).ToList();
            return content;
        }

        public bool SecurityPrincipleExists(int id, string DbContext)
        {
            return GetDbContext(DbContext).SecurityPrinciples.Any(sp => sp.Id == id);
        }

        public bool SecurityPrincipleExists(string displayName, string DbContext)
        {
            bool result = GetDbContext(DbContext).SecurityPrinciples.Any(sp => sp.DisplayName == displayName);
            return GetDbContext(DbContext).SecurityPrinciples.Any(sp => sp.DisplayName == displayName);
        }

        public ICollection<SecurityPrinciple> GetSecurityPrinciplesByType(string type, string DbContext)
        {
            return GetDbContext(DbContext).SecurityPrinciples.Where(s => s.PrincipleType == type).ToList();
        }

        //Create
        public bool CreateSecurityPrinciple(SecurityPrinciple securityPrinciple, string DbContext)
        {
            GetDbContext(DbContext).Add(securityPrinciple);
            return Save(DbContext);
        }

        public bool Save(string DbContext)
        {
            var saved = GetDbContext(DbContext).SaveChanges();
            return saved > 0 ? true : false;
        }

        //Update

        public bool UpdateSecurityPrinciple(SecurityPrinciple securityPrinciple, string DbContext)
        {
            GetDbContext(DbContext).Update(securityPrinciple);
            return Save(DbContext);
        }

        //Delete
        public bool DeleteSecurityPrinciple(SecurityPrinciple securityPrinciple, string DbContext)
        {
            GetDbContext(DbContext).Remove(securityPrinciple);
            return Save(DbContext);
        }

        public bool DeleteSecurityPrincipleByDisplayName(SecurityPrinciple securityPrinciple, string DbContext)
        {
            GetDbContext(DbContext).Remove(securityPrinciple);
            return Save(DbContext);
        }
    }
}
