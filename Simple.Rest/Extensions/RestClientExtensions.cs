﻿namespace Simple.Rest.Extensions
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Net;

    /// <summary>
    /// Extensions to make RestClient even easier!
    /// </summary>
    public static class RestClientExtensions
    {
        /// <summary>
        /// Adds both gzip &amp; deflate encoding headers.
        /// </summary>
        /// <param name="restClient">The RestClient interface.</param>
        /// <returns>Returns the updated RestClient interface.</returns>
        public static IRestClient WithAnyEncoding(this IRestClient restClient)
        {
            Contract.Requires<ArgumentNullException>(restClient != null);

            return restClient.WithGzipEncoding()
                .WithDeflateEncoding();
        }

        /// <summary>
        /// Adds the gzip to the encoding header.
        /// </summary>
        /// <param name="restClient">The RestClient interface.</param>
        /// <returns>Returns the updated RestClient interface.</returns>
        public static IRestClient WithGzipEncoding(this IRestClient restClient)
        {
            Contract.Requires<ArgumentNullException>(restClient != null);

            if (restClient.Headers["Accept-Encoding"] != null)
            {
                if (!restClient.Headers["Accept-Encoding"].Contains("gzip"))
                {
                    restClient.Headers["Accept-Encoding"] += ", gzip";
                }
            }
            else
            {
                restClient.Headers["Accept-Encoding"] += "gzip";
            }

           return restClient;
        }

        /// <summary>
        /// Adds the deflate to the encoding header.
        /// </summary>
        /// <param name="restClient">The RestClient interface.</param>
        /// <returns>Returns the updated RestClient interface.</returns>
        public static IRestClient WithDeflateEncoding(this IRestClient restClient)
        {
            Contract.Requires<ArgumentNullException>(restClient != null);

            if (restClient.Headers["Accept-Encoding"] != null)
            {
                if (!restClient.Headers["Accept-Encoding"].Contains("deflate"))
                {
                    restClient.Headers["Accept-Encoding"] += ", deflate";
                }
            }
            else
            {
                restClient.Headers["Accept-Encoding"] += "deflate";
            }

            return restClient;
        }

        /// <summary>
        /// Adds the credentials to the RestClient header.
        /// </summary>
        /// <param name="restClient">The RestClient interface.</param>
        /// <param name="credentials">The credentials to be added.</param>
        /// <returns>Returns the updated RestClient interface.</returns>
        public static IRestClient WithCredentials(this IRestClient restClient, ICredentials credentials)
        {
            Contract.Requires<ArgumentNullException>(restClient != null);
            Contract.Requires<ArgumentNullException>(credentials != null);

            restClient.Credentials = credentials;

            return restClient;
        }

        /// <summary>
        /// Add a cookie to the RestClient cookies..
        /// </summary>
        /// <param name="restClient">The RestClient interface.</param>
        /// <param name="cookie">The cookie to be added.</param>
        /// <returns>Returns the updated RestClient interface.</returns>
        public static IRestClient WithCookie(this IRestClient restClient, Cookie cookie)
        {
            Contract.Requires<ArgumentNullException>(restClient != null);
            Contract.Requires<ArgumentNullException>(cookie != null);

            restClient.Cookies.Add(cookie);

            return restClient;
        }

        /// <summary>
        /// Add a cookie to the RestClient cookies..
        /// </summary>
        /// <param name="restClient">The RestClient interface.</param>
        /// <param name="name">The name of the cookie to be added.</param>
        /// <param name="value">The value of the cookie to be added.</param>
        /// <returns>Returns the updated RestClient interface.</returns>
        public static IRestClient WithCookie(this IRestClient restClient, string name, string value)
        {
            Contract.Requires<ArgumentNullException>(restClient != null);
            Contract.Requires<ArgumentNullException>(name != null);
            
            restClient.Cookies.Add(new Cookie(name, value));

            return restClient;
        }
    }
}