using System;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sinlist.Core.Context;
using Sinlist.Models.Errors;

namespace Sinlist.Core.Helpers
{
	public static class MigrationManager
	{
		public static IHost MigrateDatabase(this IHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				using (var sinlistContext = scope.ServiceProvider.GetRequiredService<SinlistDbContext>())
				{
					try
					{
						sinlistContext.Database.Migrate();
					}
					catch (Exception ex)
					{
						throw new UserFriendlyException((int)ErrorCodes.NotWorkMigrate, ErrorMessages.NotWorkMigrate, ex.Message);
					}
				}
			}
			return host;
		}
	}
}

