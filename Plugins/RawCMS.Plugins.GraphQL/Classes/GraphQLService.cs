﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Min�</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.Extensions.Logging;
using RawCMS.Library.Core;
using RawCMS.Library.Lambdas;
using RawCMS.Library.Schema;
using RawCMS.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RawCMS.Plugins.GraphQL.Classes
{
    public class GraphQLService
    {

        public GraphQLService()
        {
        }

        private ILogger logger;
        public CRUDService CrudService { get; private set; }

        public Dictionary<string, CollectionSchema> Collections { get; private set; }


        private AppEngine appEngine;

        public GraphQLSettings Settings { get; private set; }

        public void SetAppEngine(AppEngine manager)
        {
            appEngine = manager;
            var lambda = manager.Lambdas.Where(x => x.Name == "Entity Validation").First() as EntityValidation;
            Collections = lambda.GetCollections();
        }

        public void SetCRUDService(CRUDService service)
        {
            this.CrudService = service;
        }

        public void SetLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void SetSettings(GraphQLSettings settings)
        {
            Settings = settings;
        }
    }
}