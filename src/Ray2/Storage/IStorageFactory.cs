﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ray2.Storage
{
    public interface IStorageFactory
    {
        ISnapshotStorage GetSnapshotStorage(string name);
        IEventStorage GetEventStorage(string name);
    }
}