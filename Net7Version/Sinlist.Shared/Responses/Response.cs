using System;
using System.Text.Json.Serialization;

namespace Sinlist.Shared.Responses
{
	public class Response<T>
	{
        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public ResponseError Error { get; set; }
        public List<ResponseError>? Errors { get; set; }

        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { StatusCode = statusCode, Data = data };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode };
        }

        public static Response<T> Fail(int statusCode, List<ResponseError> errors)
        {
            return new Response<T> { StatusCode = statusCode, Errors = errors };
        }
        public static Response<T> Fail(int statusCode, ResponseError error)
        {
            return new Response<T> { StatusCode = statusCode, Errors = new List<ResponseError> { error } };
        }
    }
}

