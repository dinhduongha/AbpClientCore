
namespace AbpHelper.Users.Dto
{
    public class ResetPasswordDto
    {
        public string AdminPassword { get; set; }

        public long UserId { get; set; }

        public string NewPassword { get; set; }
    }
}
