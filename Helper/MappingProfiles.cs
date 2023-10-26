using AutoMapper;
using SecurityPrincipleWebAPICodeFirst.DTO;
using SecurityPrincipleWebAPICodeFirst.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SecurityPrincipleWebAPICodeFirst.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SecurityPrinciple, SecurityPrincipleDTO>();
            CreateMap<SecurityPrincipleDTO, SecurityPrinciple>();
            CreateMap<GroupMember, GroupMemberDTO>();
            CreateMap<GroupMemberDTO, GroupMember>();
        }
    }
}
