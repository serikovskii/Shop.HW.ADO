using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Windows;

namespace ShopApp.DataAccess
{
    public class SellerTableDataService
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;

        public SellerTableDataService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["mainAppConnectionString"]
                .ConnectionString;

            _providerFactory = DbProviderFactories
                .GetFactory(ConfigurationManager
                .ConnectionStrings["mainAppConnectionString"]
                .ProviderName);
        }

        public List<Seller> GetAll()
        {
            var data = new List<Seller>();

            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "select * from Sellers";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string name = dataReader["Name"].ToString();
                        string surname = dataReader["Surname"].ToString();

                        data.Add(new Seller
                        {
                            Id = id,
                            Name = name,
                            Surname = surname
                        });
                    }

                    dataReader.Close();
                }
                catch (DbException exception)
                {
                    MessageBox.Show(exception.Message);
                    throw;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    throw;
                }
            }

            return data;
        }
    }
}
