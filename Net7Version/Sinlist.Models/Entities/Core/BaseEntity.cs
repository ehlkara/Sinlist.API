using System;
namespace Sinlist.Models.Entities.Core
{
	public class BaseEntity
	{
		public BaseEntity()
		{
			this.IsActive = true;
			this.IsDelete = false;
			this.CreatedTime = DateTime.Now;
			this.DeletedTime = null;
			this.UpdatedTime = null;
		}

		public bool IsActive { get; set; }
		public bool IsDelete { get; set; }
		public DateTime? DeletedTime { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
	}
}

