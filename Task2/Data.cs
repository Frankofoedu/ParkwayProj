namespace Task2
{

    public class Data
    {
        public Fee[] Fees { get; set; }
    }

    public class Fee
    {
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int FeeAmount { get; set; }
    }

}
