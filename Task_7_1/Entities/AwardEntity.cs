using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AwardEntity : BaseEntity
    {
        public string Title { get; set; }

        public int AwardId { get; set; }

        public int UserId { get; set; }
    }
}
