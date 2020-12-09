﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyLab.Elastic
{
    /// <summary>
    /// Describes Elasticsearch Indexer
    /// </summary>
    public interface IEsIndexer<TDoc>
        where TDoc : class
    {
        /// <summary>
        /// Index document batch in specified index
        /// </summary>
        Task IndexManyAsync(string indexName, IEnumerable<TDoc> documents);

        /// <summary>
        /// Index document batch in index which bound to document model
        /// </summary>
        Task IndexManyAsync(IEnumerable<TDoc> documents);

        /// <summary>
        /// Index document in specified index
        /// </summary>
        Task IndexAsync(string indexName, TDoc document);

        /// <summary>
        /// Index document in index which bound to document model
        /// </summary>
        Task IndexAsync(TDoc document);

        /// <summary>
        /// Creates index specific indexer
        /// </summary>
        IIndexSpecificEsIndexer<TDoc> ForIndex(string indexName);

        /// <summary>
        /// Update document partially
        /// </summary>
        Task UpdateAsync(string indexName, string docId, Expression<Func<TDoc>> updateExpression,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Update document partially
        /// </summary>
        Task UpdateAsync(string indexName, long docId, Expression<Func<TDoc>> updateExpression,
            CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Index document in specific index
    /// </summary>
    public interface IIndexSpecificEsIndexer<TDoc>
        where TDoc : class
    {
        /// <summary>
        /// Gets specific index name
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// Index document batch in index which bound to document model
        /// </summary>
        Task IndexManyAsync(IEnumerable<TDoc> documents);
        
        /// <summary>
        /// Index document in index which bound to document model
        /// </summary>
        Task IndexAsync(TDoc document);

        /// <summary>
        /// Update document partially
        /// </summary>
        Task UpdateAsync(string docId, Expression<Func<TDoc>> updateExpression,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Update document partially
        /// </summary>
        Task UpdateAsync(long docId, Expression<Func<TDoc>> updateExpression,
            CancellationToken cancellationToken = default);
    }
}