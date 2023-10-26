using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityPrincipleWebAPICodeFirst.DTO;
using SecurityPrincipleWebAPICodeFirst.Interfaces;
using SecurityPrincipleWebAPICodeFirst.Models;

namespace SecurityPrincipleWebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IMapper _mapper;

        public GroupMemberController(IGroupMemberRepository groupMemberRepository, IMapper mapper)
        {
            _groupMemberRepository = groupMemberRepository;
            _mapper = mapper;
        }


        //Get and Read.

        [HttpGet("GetAllGroupMembers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupMember>))]
        public IActionResult GetAll(string DbContext)
        {
            var groupmembers = _groupMemberRepository.GetAll(DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(groupmembers);
        }

        [HttpGet("GetGroupMembersByGroupId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupMember>))]
        public IActionResult GetGroupMembersByGroupId([FromQuery] int groupId, string DbContext)
        {
            var groupmembers = _groupMemberRepository.GetGroupMembersByGroupId(groupId, DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(groupmembers);
        }

        [HttpGet("{{securityPrincipleId}}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GroupMember>))]
        public IActionResult GetGroupBySecurityPrincipleId([FromQuery] int securityPrincipleId, string DbContext)
        {
            var groupId = _groupMemberRepository.GetGroupsBySecurityPrincipleId(securityPrincipleId, DbContext);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(groupId);
        }

        //Create
        [HttpPost("CreateGroupMember")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGroupMember([FromQuery] GroupMemberDTO groupMemberCreate, string DbContext)
        {
            if (groupMemberCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var groupMemberMap = _mapper.Map<GroupMember>(groupMemberCreate);

            if (!_groupMemberRepository.CreateGroupMember(groupMemberMap, DbContext))
            {
                ModelState.AddModelError("", "Something went wrong when saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        //Delete

        [HttpDelete("DeleteGroupMember")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGroupMember([FromQuery] int groupId, [FromQuery] int securityPrincipleId, string DbContext)
        {
            var groupMemberToDelete = _groupMemberRepository.GetGroupMembersByGroupId(groupId, DbContext).Where(sp => sp.SecurityPrincipleId == securityPrincipleId).FirstOrDefault();

            if (!_groupMemberRepository.DeleteGroupMember(groupMemberToDelete, DbContext))
            {
                ModelState.AddModelError("", "Something went wrong deleting Security Principle");
            }
            return NoContent();

        }
    }
}
