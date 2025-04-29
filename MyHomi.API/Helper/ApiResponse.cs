namespace MyHomi.API.Helper
{
    public class ApiResponse<T>
    {

        #region Constractor

        public ApiResponse(T data = default!, string message = null!, string responseCode = null!)
        {
            Data = data;
            Message = message;
            ResponseCode = responseCode;
        }

        #endregion


        #region Public Properties

        public T Data { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }

        #endregion

    }
}
