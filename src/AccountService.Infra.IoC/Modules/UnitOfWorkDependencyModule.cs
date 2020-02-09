﻿using AccountServices.Domain.Interfaces;
using AccountServices.Infra.Data;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public static class UnitOfWorkDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}
