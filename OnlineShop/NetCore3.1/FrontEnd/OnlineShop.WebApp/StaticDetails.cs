﻿namespace OnlineShop.WebApp
{
    public static class StaticDetails
    {
        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}