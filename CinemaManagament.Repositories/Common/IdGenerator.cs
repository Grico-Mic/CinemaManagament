using CinemaManagamentAppication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaManagament.Repositories.Common

{
    internal static class IdGenerator
    {
        public static int GenerateId<T>(List<T> entities)  where T : BaseEntity
        {

            {
                var newId = 0;

                if (entities.Count > 0)
                {
                    newId = entities.Max(x => x.Id);

                }
                return newId + 1;
            }
        }
    }
}
