﻿namespace MyLab.Elastic
{
    /// <summary>
    /// Contains options parameters for ES tools
    /// </summary>
    public class ElasticsearchOptions
    {
        /// <summary>
        /// ES address
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Index name which will be used when no index specified for model
        /// </summary>
        public string DefaultIndex { get; set; }
    }
}