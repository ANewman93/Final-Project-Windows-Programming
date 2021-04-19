// Programmer: Andrew Newman
// Course: CP240 Lab08
// Description: Rest Api
// Limitations: Windows only

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


using Model;
using System.Configuration;

namespace Repositories
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T Find(string id);
        bool Add(T x);
        bool Update(T x);
        bool Remove(T x);
    }

    /*-----------------*
     * Book Repository *
     *-----------------*/
    public class BookRepositoryDB : IRepository<book>
    {
        private string _connectionString;

        public BookRepositoryDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<book> FindAll()
        {
            List<book> books = new List<book>();

            string sql = "SELECT title_id, title, type, T.pub_id AS p_id, pub_name, price, pubdate FROM titles T ";
            sql += "JOIN publishers P ";
            sql += "ON P.pub_id = T.pub_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read()) // foward only and readonly
                            {
                                DateTime time; //  = Convert.ToDateTime(dataReader["pubdate"]);
                                decimal price; //  = Convert.ToDecimal(dataReader["price"]); 

                                try
                                {
                                    price = Convert.ToDecimal(dataReader["price"]);
                                }
                                catch (Exception)//ex)
                                {
                                    price = 0.0M;
                                }

                                try
                                {
                                    time = Convert.ToDateTime(dataReader["pubdate"]);
                                }
                                catch (Exception)//ex)
                                {
                                    time = DateTime.Now;
                                }

                                book b = new book
                                {
                                    title_id = dataReader["title_id"].ToString(),
                                    title = dataReader["title"].ToString(),
                                    price = price,
                                    type = dataReader["type"].ToString(),
                                    pubdate = time
                                };

                                b.Pub = new publisher();

                                b.Pub.pub_id = dataReader["p_id"].ToString();
                                b.Pub.pub_name = dataReader["pub_name"].ToString();

                                books.Add(b);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return null;
            }

            return books;

        }

        public book Find(string id)
        {

            string sql = "SELECT title_id, title, type, T.pub_id AS p_id, pub_name, price, pubdate FROM titles T ";
            sql += "JOIN publishers P ";
            sql += "ON P.pub_id = T.pub_id ";
            sql += "WHERE title_id = @title_id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@title_id", id));

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                DateTime time; //  = Convert.ToDateTime(dataReader["pubdate"]);
                                decimal price; //  = Convert.ToDecimal(dataReader["price"]); 

                                try
                                {
                                    price = Convert.ToDecimal(dataReader["price"]);
                                }
                                catch (Exception)//ex)
                                {
                                    price = 0.0M;
                                }

                                try
                                {
                                    time = Convert.ToDateTime(dataReader["pubdate"]);
                                }
                                catch (Exception)//ex)
                                {
                                    time = DateTime.Now;
                                }

                                book b = new book
                                {
                                    title_id = dataReader["title_id"].ToString(),
                                    title = dataReader["title"].ToString(),
                                    price = price,
                                    type = dataReader["type"].ToString(),
                                    pubdate = time
                                };

                                b.Pub = new publisher();

                                b.Pub.pub_id = dataReader["p_id"].ToString();
                                b.Pub.pub_name = dataReader["pub_name"].ToString();

                                return b;

                            }// end using reader 
                        }
                    }
                    catch (SqlException)
                    {

                        return null;
                    }
                }// end using command 
            }// end of using connection 

            return null;
        }

        /*-------------------*
         * stubbed Functions *
         *-------------------*/
        public bool Add(book x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(book x)
        {
            throw new NotImplementedException();
        }

        public bool Update(book x)
        {
            throw new NotImplementedException();
        }
    }

    /*------------------*
     * Store Repository *
     *------------------*/
    public class StoreRepositoryDB : IRepository<store>
    {
        string _connectionString;

        public StoreRepositoryDB(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public List<store> FindAll()
        {
            List<store> stores = new List<store>();

            SqlConnectionStringBuilder SB = new SqlConnectionStringBuilder();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM stores", con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                var newStore = new store();
                                newStore.stor_id = reader["stor_id"].ToString();
                                newStore.stor_name = reader["stor_name"].ToString();

                                stores.Add(newStore);
                            }
                        } // reader closed and disposed up here

                    }
                    catch (SqlException)
                    {
                        return null;
                    }

                } // command disposed here
            } //connection closed and disposed here

            return stores;
        }

        public store Find(string stor_id)
        {
            store foundStore = new store();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM stores WHERE stor_id = @stor_id", conn))
                {
                    try
                    {
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@stor_id", stor_id));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var storeSelected = new store();
                                storeSelected.stor_id = reader["stor_id"].ToString();
                                storeSelected.stor_name = reader["stor_name"].ToString();

                                foundStore = storeSelected;
                            }// end using reader 
                        }
                    }
                    catch (SqlException)
                    {
                        return null;
                    }
                }// end using command 
            }// end of using connection 

            return foundStore;
        }

        /*-------------------*
         * stubbed Functions *
         *-------------------*/
        public bool Add(store x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(store x)
        {
            throw new NotImplementedException();
        }

        public bool Update(store x)
        {
            throw new NotImplementedException();
        }
    }

    /*------------------*
     * Sales Repository *
     *------------------*/
    public class SalesRepositoryDB : IRepository<sales>
    {
        string _connectionString;

        public SalesRepositoryDB(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public List<sales> FindAll()
        {
            List<sales> sales = new List<sales>();

            SqlConnectionStringBuilder SB = new SqlConnectionStringBuilder();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT stor_id, ord_num, ord_date, qty, payterms, title_id FROM sales", con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index;
                                DateTime date;

                                index = reader.GetOrdinal("ord_date");
                                date = reader.GetDateTime(index);

                                sales s = new sales
                                {
                                    stor_id = reader["stor_id"].ToString(),
                                    ord_num = reader["ord_num"].ToString(),
                                    ord_date = date,
                                    qty = Convert.ToInt16(reader["qty"]),
                                    payterms = reader["payterms"].ToString(),
                                    title_id = reader["title_id"].ToString()
                                };

                                sales.Add(s);
                            }
                        } // reader closed and disposed up here

                    }
                    catch (SqlException)
                    {
                        return null;
                    }

                } // command disposed here
            } //connection closed and disposed here

            return sales;
        }

        public bool Add(sales newSale)
        {
            int rowCount;

            string sql = "INSERT INTO sales VALUES (@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@stor_id", newSale.stor_id));
                        command.Parameters.Add(new SqlParameter("@ord_num", newSale.ord_num));
                        command.Parameters.Add(new SqlParameter("@ord_date", newSale.ord_date));
                        command.Parameters.Add(new SqlParameter("@qty", newSale.qty));
                        command.Parameters.Add(new SqlParameter("@payterms", newSale.payterms));
                        command.Parameters.Add(new SqlParameter("@title_id", newSale.title_id));

                        rowCount = command.ExecuteNonQuery();

                    }// end using command 
                }
                catch (SqlException)
                {
                    return false;
                }

            }// end of using connection 

            return true;
        }

        /*-------------------*
         * stubbed Functions *
         *-------------------*/

        public sales Find(string ord_num)
        {

            throw new NotImplementedException();
        }

        public bool removeSalesOrder(string ord_num)
        {
            int rowCount;

            string sql = "DELETE FROM sales WHERE ord_num = @ord_num";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@ord_num", ord_num));

                        rowCount = command.ExecuteNonQuery();

                    }// end using command 
                }
                catch (SqlException)
                {
                    return false;
                }

            }// end of using connection 
            return true;
        }

        public bool Remove(sales x)
        {
            throw new NotImplementedException();
        }

        public bool Update(sales x)
        {
            throw new NotImplementedException();
        }
    }

    /*-----------------------*
     * Book Order Repository *
     *-----------------------*/
    public class bookOrderRepositoryDB : IRepository<booksOnOrder>
    {
        string _connectionString;

        public bookOrderRepositoryDB(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public List<booksOnOrder> FindAll()
        {
            List<booksOnOrder> bookOrder = new List<booksOnOrder>();

            string sql = "SELECT S.stor_id, S.ord_num, T.title_id, T.title, S.qty, S.payterms ";
            sql += "FROM sales S ";
            sql += "JOIN titles T ";
            sql += "ON S.title_id = T.title_id ";


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                booksOnOrder b = new booksOnOrder
                                {
                                    stor_id = reader["stor_id"].ToString(),
                                    ord_num = reader["ord_num"].ToString(),
                                    title_id = reader["title_id"].ToString(),
                                    title = reader["title"].ToString(),
                                    qty = reader["qty"].ToString(),
                                    payterms = reader["payterms"].ToString()

                                };

                                bookOrder.Add(b);
                            }
                        } // reader closed and disposed up here

                    }
                    catch (SqlException)
                    {
                        return null;
                    }

                } // command disposed here
            } //connection closed and disposed here

            return bookOrder;
        }

        public List<booksOnOrder> getBooksByOrder(string ord_num)
        {
            List<booksOnOrder> bookOrder = new List<booksOnOrder>();

            string sql = "SELECT S.stor_id, S.ord_num, T.title_id, T.title, S.qty, S.payterms ";
            sql += "FROM sales S ";
            sql += "JOIN titles T ";
            sql += "ON S.title_id = T.title_id ";
            sql += "WHERE S.ord_num = @ord_num";


            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@ord_num", ord_num);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                booksOnOrder b = new booksOnOrder
                                {
                                    stor_id = reader["stor_id"].ToString(),
                                    ord_num = reader["ord_num"].ToString(),
                                    title_id = reader["title_id"].ToString(),
                                    title = reader["title"].ToString(),
                                    qty = reader["qty"].ToString(),
                                    payterms = reader["payterms"].ToString()

                                };

                                bookOrder.Add(b);
                            }
                        } // reader closed and disposed up here

                    }
                    catch (SqlException)
                    {
                        return null;
                    }

                } // command disposed here
            } //connection closed and disposed here

            return bookOrder;
        }

       /*-------------------*
        * stubbed Functions *
        *-------------------*/
        public booksOnOrder Find(string ord_num)
        {

            throw new NotImplementedException();

        }

        public bool Add(booksOnOrder x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(booksOnOrder x)
        {
            throw new NotImplementedException();
        }

        public bool Update(booksOnOrder x)
        {
            throw new NotImplementedException();
        }
    }
}
