using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Villa.Entity.Entities
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }
    }
}