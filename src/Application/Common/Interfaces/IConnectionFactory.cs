/*
 * Created by : Deepak Samantaray
 * Created On : 6th Jan 2021
 * File name : IConnectionFactory
 * Interface name : IConnectionFactory
 * Description : interface to create an object of type connection which will be used in other all repository functions. 
 */
using System.Data;

namespace SRIS.Application.Common.Interfaces
{
    /// <summary>
    /// Interface IConnectionFactory
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
