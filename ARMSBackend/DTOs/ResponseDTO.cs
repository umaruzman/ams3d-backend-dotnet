using System;

namespace ARMSBackend.DTOs
{
    public class ResponseDTO
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }

        public ResponseDTO(bool success)
        {
            this.Success = success;

            if (success)
            {
                this.Message = "Succesfully Completed Request!";
            }
            else
            {
                this.Message = "Request Faled!";
            }

        }

        public ResponseDTO(bool success, string msg)
        {
            this.Success = success;
            this.Message = msg;
        }
    }

    public class ResponseDTO<T> : ResponseDTO
    {
        public T Data { get; set; }

        public ResponseDTO(bool success, T data) : base(success)
        {
            this.Data = data;
        }

        public ResponseDTO(bool success, string msg, T data) : base(success, msg)
        {
            this.Data = data;
        }

    }
}
