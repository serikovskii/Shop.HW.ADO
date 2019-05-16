using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Windows;

namespace ShopApp.DataAccess
{
    public class SaleTableDataService
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;

        public SaleTableDataService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["mainAppConnectionString"]
                .ConnectionString;

            _providerFactory = DbProviderFactories
                .GetFactory(ConfigurationManager
                .ConnectionStrings["mainAppConnectionString"]
                .ProviderName);
        }

        public List<Sale> GetAll()
        {
            var data = new List<Sale>();

            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "select * from Sales";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        int buyerId = (int)dataReader["BuyerId"];
                        int salerId = (int)dataReader["SalerId"];
                        int sum = (int)dataReader["Sum"];
                        DateTime saleDate = (DateTime)dataReader["SaleDate"];

                        data.Add(new Sale
                        {
                            Id = id,
                            BuyerId = buyerId,
                            SalerId = salerId,
                            Sum = sum,
                            SaleDate = saleDate
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
