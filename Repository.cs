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

namespace Repository
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T FindByID(string id);
        bool Add(T x);
        bool Update(T x);
        bool Remove(T x);
    }


    public class BookRepositoryDB : IRepository<book>
    {
        private string _connectionString;

        public BookRepositoryDB()
        {
            _connectionString = configFile.getSetting("pubsDBConnectionString");
        }

        public bool Add(book x)
        {
            throw new NotImplementedException();
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
                                catch(Exception ex)
                                {
                                    price = 0.0M; 
                                }

                                try
                                {
                                    time = Convert.ToDateTime(dataReader["pubdate"]);
                                }
                                catch(Exception ex)
                                {
                                    time = DateTime.Now; 
                                }

                                book b = new book {
                                    Id = dataReader["title_id"].ToString(),
                                    Title = dataReader["title"].ToString(),
                                    Price = price,
                                    Type = dataReader["type"].ToString(),
                                    PubDate = time
                                };

                                b.Pub = new publisher(); 

                                b.Pub.id = dataReader["p_id"].ToString();
                                b.Pub.name = dataReader["pub_name"].ToString(); ; 

                                books.Add(b);
                            } // end read loop 
                        }// end use reader
                    }// end use command
                }// end use connection 
            }
            catch (SqlException)
            {
                return default(List<book>);
            }

            return books;
        
        }

        public book FindByID(string id)
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

        public bool removeAuthorFromBook(string au_id, string book_id)
        {


            return true;
        }

        public bool addAuthorToBook(string au_id, string book_id)
        {


            return true;
        }
        public List<book> getBooksByAuthor(string au_id)
        {
         
        }
    }

    