using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityPrincipleWebAPICodeFirst.Interfaces;

namespace SecurityPrincipleWebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vGroupMemberController : ControllerBase
    {
        private readonly IvGroupMemberRepository _vGroupMemberRepository;
        private readonly IMapper _mapper;
        public vGroupMemberController(IvGroupMemberRepository vGroupmemberRepository, IMapper mapper)
        {
            _vGroupMemberRepository = vGroupmemberRepository;
            _mapper = mapper;
        }

        [HttpGet("GetVGroupMembers")]
        public IActionResult GetVGroupMembers(string DbContext)
        {
            var vGroupMembers = _vGroupMemberRepository.GetVGroupMembers(DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vGroupMembers);
        }

        [HttpGet("GetVGroupMembersByGroupName")]
        public IActionResult GetVGroupMembersByGroupName(string groupDisplayName, string DbContext)
        {
            var vGroupMembers = _vGroupMemberRepository.GetVGroupMembersByGroupName(groupDisplayName, DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vGroupMembers);
        }
    }
}
