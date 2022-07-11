namespace Models.Output
{
    public class Output<T>
    {
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public IList<string> Messages { get; set; } = new List<String>();
    }
}
