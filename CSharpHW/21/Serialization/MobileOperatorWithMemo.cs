using System;
using System.Collections.Generic;
using System.Linq;
using MobileNetwork;

namespace Serialization
{
    class MobileOperatorWithMemo: MobileOperator
    {
        public MobileOperatorWithMemo(int maxNumber, int minNumber = 0, int callPricing = 0, int smsPricing = 0):
            base(maxNumber, minNumber, callPricing, smsPricing) { }
    }
}
