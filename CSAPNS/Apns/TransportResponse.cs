﻿using System.Net;

namespace CSAPNS.Apns
{
    public class TransportResponse
    {
        /// <summary>
        /// http status code
        /// </summary>
        public HttpStatusCode TransportCode { get; private set; }

        public TransportResponse(HttpStatusCode httpStatusCode)
        {
            TransportCode = httpStatusCode;
        }
    }
}
