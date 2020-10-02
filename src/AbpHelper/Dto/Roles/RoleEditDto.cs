
namespace AbpHelper.Roles.Dto
{
    public class RoleEditDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsStatic { get; set; }
    }
}