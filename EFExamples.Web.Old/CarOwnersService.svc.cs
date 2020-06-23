//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using EFExamples.Web.Old.DataModels;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;

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
    }
}
