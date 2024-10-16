using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub_User_Activity.FeaturesEnum
{
    public static class Features
    {
        public enum enFeatures
        {
            getAll = 1,
            getByEventType,
            groupedByEventType
        }

        public static enFeatures features = enFeatures.getAll;
    }
}
