﻿using PS.Data.Infrastructure;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public class ServiceAchat : Service<Achat>, IServiceAchat
    {
        public ServiceAchat (IUnitOfWork uow) : base(uow)
        {

        }
    }
}
