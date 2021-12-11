namespace OptionalValues.WithoutOption
{
    public interface IAlpha
    {
        double Value { get; }

        bool IsNone { get => false; }

        double GetValue();
        void SetValue(double val);
    }

    public class Alpha : IAlpha
    {
        public static readonly IAlpha None = new AlphaNone();
        private double _val;

        public Alpha(double val) => _val = val;

        public double Value => _val;

        public double GetValue() => _val;

        public void SetValue(double val) => _val = val;

        private class AlphaNone : IAlpha
        {
            public bool IsNone { get => true; }

            public double Value => 0;

            public double GetValue()
            {
                return 0;
            }

            public void SetValue(double val)
            {
            }
        }
    }
}
