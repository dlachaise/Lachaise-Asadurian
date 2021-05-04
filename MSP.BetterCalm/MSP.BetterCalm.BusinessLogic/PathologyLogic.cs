﻿using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.BusinessLogic.Interface;
using System.Linq;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PathologyLogic : IPathologyLogic
    {

        private IRepository<Pathology> iPathologyR;

        public PathologyLogic(IRepository<Pathology> pathologyR)
        {
            this.iPathologyR = pathologyR;
        }

        public Pathology Get(Guid id)
        {
            Pathology pathology = iPathologyR.Get(id);
            if (pathology != null)
            {
                return pathology;
            }
            else
            {
                throw new Exception("Pathology does not exist");
            }
        }

        public IEnumerable<Pathology> GetAll()
        {
            return this.iPathologyR.GetAll();
        }

    }
}