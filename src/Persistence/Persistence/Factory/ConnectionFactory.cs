/*
 * Created by : Deepak Samantaray
 * Created On : 6th Jan 2021
 * File name : ConnectionFactory
 * Class name : ConnectionFactory (inherited from IConnectionFactory)
 * Description : class with the common function to intialise the connection string and other connection related objects
 */


using MySql.Data.MySqlClient;
using SRIS.Application.Common.Interfaces;
using System.Data;
namespace SRIS.Persistence.Contract
{
    /// <summary>
    /// Class ConnectionFactory.
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        public IDbConnection GetConnection => new MySqlConnection(_connectionString);
    }
}
