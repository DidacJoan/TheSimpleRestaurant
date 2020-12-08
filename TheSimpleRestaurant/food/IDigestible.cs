using System;
using System.Collections.Generic;
using System.Text;

namespace TheSimpleRestaurant
{
    interface IDigestible
    {
        public int CountCalories();
        public bool IsEasyToDigest();
    }
}
