namespace The_end_of_Gydropon.API
{
    public class Message<T>
    {
        public bool IsSuccess { get; set; }
        
        public string ReturnMessage { get; set; }
        
        public T Data { get; set; }
    }
}
