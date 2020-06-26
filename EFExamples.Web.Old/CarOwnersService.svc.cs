//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using EFExamples.Web.Old.DataModels;
using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.Linq.Expressions;

namespace EFExamples.Web.Old
{
    public class CarOwnersService : EntityFrameworkDataService<CarOwnersEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);

            //config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.SetEntitySetAccessRule("People", EntitySetRights.AllRead);
        }


        [QueryInterceptor("People")]
        public Expression<Func<Person, bool>> OnQueryPeople()
        {
            return x => x.Height >= 170;
        }

        [ChangeInterceptor("People")]
        public void OnChangePeople(Person p, UpdateOperations updateOperations)
        {

        }
    }
}
