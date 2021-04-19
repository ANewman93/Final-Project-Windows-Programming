// Programmer: Andrew Newman
// Course: CP240 Lab07
// Description: HTML Version of author database
// Limitations: Windows only

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    //public class author
    //{
    //    //ctor
    //    public author()
    //    {

    //    }

    //    public string error { get; set; }

    //    public string au_id { get; set; }
            
    //    public string au_fname { get; set; }
            
    //    public string au_lname { get; set; }
        
    //    public string au_name { get { return au_fname + " " + au_lname; } }
          
    //    public string phone { get; set; }
        
    //    public string address { get; set; }
        
    //    public string city { get; set; }
        
    //    public string state { get; set; }
         
    //    public string zip { get; set; }

    //    public bool contract { get; set; }

    //    public string editAuthWindowTitle { get; set; }

    //}

    public class book
    {
        public book()
        {

        }

        public string title_id{ get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string type { get; set; }
        public DateTime pubdate { get; set; }
        public publisher Pub { get; set; }

    }

    public class publisher
    {
        public publisher()
        {

        }
        public string pub_id { get; set; }
        public string pub_name { get; set; }

    }

    public class store
    {
        public store()
        {

        }
        public string stor_id { get; set; }
        public string stor_name { get; set; }

    }

    public class sales
    {
        public sales()
        {

        }

        public string stor_id { get; set; }
        public string ord_num { get; set; }
        public DateTime ord_date { get; set; }
        public Int16 qty { get; set; }
        public string payterms { get; set; }
        public string title_id { get; set; }
    }

    public class booksOnOrder
    {
        public booksOnOrder()
        {

        }
        public string stor_id { get; set; }
        public string ord_num { get; set; }
        public string title_id { get; set; }
        public string title { get; set; }
        public string qty { get; set; }
        public string payterms { get; set; }
    }
}
