using System;
using Autofac;
using Sinlist.BusinessLogic.Abstract;
using Sinlist.BusinessLogic.SinlistService;
using Sinlist.DataAccess.Abstract;
using Sinlist.DataAccess.Concrete;
using Module = Autofac.Module;

namespace Sinlist.API.Modules
{
	public class RepoServiceModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            //BLL
            builder.RegisterType<TodoListService>().As<ITodoListBLL>().InstancePerLifetimeScope();
            builder.RegisterType<TodoListItemService>().As<ITodoListItemBLL>().InstancePerLifetimeScope();

            //DAL
            builder.RegisterType<TodoListDAL>().As<ITodoListDAL>().InstancePerLifetimeScope();
            builder.RegisterType<TodoListItemDAL>().As<ITodoListItemDAL>().InstancePerLifetimeScope();
        }
    }
}

