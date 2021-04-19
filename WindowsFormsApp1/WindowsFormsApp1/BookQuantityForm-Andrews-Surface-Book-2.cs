using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Model;
using ServiceBus;
using restfulRepo;

namespace WindowsFormsApp1
{
    public partial class BookQuantityForm : Form
    {
        public PlaceOrderForm _bklist;
        public sales _sale;
        public List<bookViewModel> book;
        public pubsService bookService;
        public string bookTitle;

        public BookQuantityForm(PlaceOrderForm bklist, sales sale)
        {
            InitializeComponent();

            string apiRoot = configFile.getSetting("apiRoot");

            BookRepoREST bookRepo = new BookRepoREST(apiRoot);
            StoreRepoREST storeRepo = new StoreRepoREST(apiRoot);
            SalesRepoREST salesRepo = new SalesRepoREST(apiRoot);
            BookOrderRepoREST bookOrderRepo = new BookOrderRepoREST(apiRoot);

            bookService = new pubsService(bookRepo, storeRepo, salesRepo, bookOrderRepo);

            _bklist = bklist;
            _sale = sale;
        }

        private void BookQuantityForm_Load(object sender, EventArgs e)
        {

            book = bookService.findBook(_sale.title_id);

            foreach(bookViewModel bk in book)
            {
                bookTitle = bk.Title;
            }

            bookToEditTextBox.Text = _sale.title_id + " - " + bookTitle;
            editQuantityUpDown.Value = _sale.qty;
        }
    }
}
