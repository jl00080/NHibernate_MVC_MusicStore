﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Entities
{
    public abstract class Entity
    {
        public virtual int Id { get;  protected set; }
    }
}