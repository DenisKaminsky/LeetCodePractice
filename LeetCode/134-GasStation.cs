namespace LeetCode.Task134
{
    public class GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var i = 0;
            while (i < gas.Length)
            {
                if (gas[i] < cost[i] || gas[i] <= 0)
                {
                    i++;
                    continue;
                }

                var j = (i + 1) % gas.Length;
                var tank = gas[i] - cost[i];
                while (j != i)
                {
                    tank += gas[j] - cost[j];
                    if (tank < 0)
                        break;

                    j = (j + 1) % gas.Length;
                }

                if (i == j)
                    return i;

                if (i > j)
                    break;

                i = j;
            }

            return -1;
        }
    }
}
