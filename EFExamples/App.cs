﻿using EFExample.Services;
using EFExamples.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EFExamples
{
    public class App
    {
        private IConfiguration configuration;
        private ICarOwnersService carOwnersService;

        public App(IConfiguration configuration, ICarOwnersService carOwnersService)
        {
            this.configuration = configuration;
            this.carOwnersService = carOwnersService;
        }

        public void PerformOperations()
        {
            carOwnersService.AddPerson();
            carOwnersService.AddPerson();

            List<Person> people = carOwnersService.GetAllPeople();

        }

        public void GlobalQueryFilterTest()
        {
            var people = this.carOwnersService.GetAllPeople();
            foreach (var p in people)
            {
                Console.WriteLine(p.Name);
            }
        }

    }
}
