using CmcApi.Core.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmcApi.Core.Entities
{
    /// <summary>
    /// Base Entity Properties
    /// </summary>
    public interface IEntity<TPrimaryKey> : IBaseClass
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        TPrimaryKey Id { get; set; }

        Guid Guid { get; set; }

        int? Version { get; set; }
    }

    /// <summary>
    /// A shortcut of <see cref="IEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    public interface IEntity : IEntity<int>
    {

    }
}
