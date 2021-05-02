using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification
{
    public class UserAddressSpec : Specification<UserAddress>
    {
        public UserAddressSpec(UserAddressFilter filter)
        {
            Query.OrderBy(x => x.IDUsuario).ThenByDescending(x => x.ID);

        }
    }
}
