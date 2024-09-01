using System.ComponentModel.DataAnnotations;

namespace task_Auth.Models
{
	public class User
	{
		[Key]
		[Display(Name ="UserId")]
		public Guid UserId { get; set; }
		[Display(Name = "UserName")]
		public string? UserName { get; set; }
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Display(Name = "CreateAt")]
		public DateTime? CreateAt { get; set; }
		[Display(Name = "IsActive")]
		public bool IsActive { get; set; }
	}
}
