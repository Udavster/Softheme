using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery {
    class Lottery {
        private int lotteryNumLength = 6;
        private int maxLotteryNum;
        private int minLotteryNum;
        private Random random;
        public Lottery(int lotteryNumLength = 6) {
            if ((lotteryNumLength > 9) || (lotteryNumLength < 1)) {
                throw new ArgumentOutOfRangeException("Quantity of lottery numbers should be from 1 to 9");
            }
            this.lotteryNumLength = lotteryNumLength;
            this.maxLotteryNum = (int)Math.Pow(10, this.lotteryNumLength) - 1;
            this.minLotteryNum = (int)Math.Pow(10, this.lotteryNumLength - 1);
            this.random = new Random();
        }
        public int LastWonNum { get; private set; }
        private int this[int num] {
            get {
                do {
                    this.LastWonNum = this.random.Next(0, maxLotteryNum + 1);
                } while (HasZeroInNum(this.LastWonNum));
                return this.LastWonNum;
            }
        }
        private static bool HasZeroInNum(int num) {
            string s = num.ToString();
            return s.Contains("0");
        }
        public bool CheckWin(string snum) {
            int num;
            if ((snum.Length != this.lotteryNumLength) || (!int.TryParse(snum, out num))
                || (HasZeroInNum(num)) || (num < this.minLotteryNum)) {
                throw new ArgumentException(String.Format("Input should be number of {0} digits [1-9]",
                    lotteryNumLength));
            }
            return (this[num] == num);
        }
    }
}
