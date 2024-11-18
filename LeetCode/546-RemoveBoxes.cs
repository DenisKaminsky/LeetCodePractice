namespace LeetCode.Task546
{
    public class Solution
    {
        public int RemoveBoxes(int[] boxes)
        {
            var score = 0;
            var left = 0;
            var right = boxes.Length-1;

            var currentBoxesRange = new BoxesRange(0, 0, 0);
            var maxBoxesRange = new BoxesRange(0, 0, 0);

            while (true)
            {
                var boxesLeft = 0;
                var prevBox = boxes[left];

                //find max range
                currentBoxesRange.Reset(left);
                maxBoxesRange.Reset(left);
                for (var i = left; i <= right; i++)
                {
                    var currentBox = boxes[i];
                    if (currentBox == -1)
                        continue;

                    if (currentBox != prevBox)
                    {
                        currentBoxesRange.EndIndex = i - 1;
                        if (currentBoxesRange.Length > maxBoxesRange.Length)
                            maxBoxesRange.Copy(currentBoxesRange);

                        currentBoxesRange.Reset(i);
                    }

                    currentBoxesRange.Length++;
                    boxesLeft++;
                    prevBox = currentBox;
                }

                //update last item
                currentBoxesRange.EndIndex = right;
                if (currentBoxesRange.Length > maxBoxesRange.Length)
                    maxBoxesRange.Copy(currentBoxesRange);

                //update score
                score += maxBoxesRange.Length * maxBoxesRange.Length;
                boxesLeft -= maxBoxesRange.Length;
                if (boxesLeft <= 0)
                    break;

                //update borders
                if (maxBoxesRange.StartIndex == left)
                    left = maxBoxesRange.EndIndex + 1;
                if (maxBoxesRange.EndIndex == right)
                    right = maxBoxesRange.StartIndex - 1;
                for (var i = maxBoxesRange.StartIndex; i <= maxBoxesRange.EndIndex; i++)
                {
                    boxes[i] = -1;
                }
            }

            return score;
        }
        
        private record struct BoxesRange(int StartIndex, int EndIndex, int Length)
        {
            public void Reset(int startIndex)
            {
                StartIndex = EndIndex = startIndex;
                Length = 0;
            }

            public void Copy(BoxesRange boxesRange)
            {
                StartIndex = boxesRange.StartIndex;
                EndIndex = boxesRange.EndIndex;
                Length = boxesRange.Length;
            }
        }
    }
}
