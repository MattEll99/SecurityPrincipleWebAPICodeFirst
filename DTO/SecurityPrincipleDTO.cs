namespace SecurityPrincipleWebAPICodeFirst.DTO
{
    public class SecurityPrincipleDTO
    {
        //public int? Id { get; set; } = null;
        public required string ApplicationId { get; set; }
        public required string PrincipleType { get; set; }
        public required string DisplayName { get; set; }
    }
}
