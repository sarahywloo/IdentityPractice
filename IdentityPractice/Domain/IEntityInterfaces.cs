using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPractice.Domain {
    public interface IDbEntity {
        int Id { get; set; }
    }

    public interface IActivatable {
        bool Active { get; set; }
    }
}
