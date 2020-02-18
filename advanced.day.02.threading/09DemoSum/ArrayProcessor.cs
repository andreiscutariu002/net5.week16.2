namespace _09DemoSum
{
    using System.Numerics;

    public class ArrayProcessor
    {
        private readonly int[] array;
        private readonly int nrOfElementsToProcess;
        private readonly int startIndex;

        public ArrayProcessor(int[] array, int startIndex, int nrOfElementsToProcess)
        {
            this.Sum = 0;

            this.array = array;
            this.startIndex = startIndex;
            this.nrOfElementsToProcess = nrOfElementsToProcess;
        }

        public BigInteger Sum { get; private set; }

        public void CalculateSum()
        {
            var to = this.startIndex + this.nrOfElementsToProcess;

            for (var i = this.startIndex; i < to; i++)
            {
                this.Sum += this.array[i];
            }
        }
    }
}