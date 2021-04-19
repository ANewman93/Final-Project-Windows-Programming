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
        public book book;
        public pubsService bookService;
        public string bookTitle;

        public BookQuantityForm(PlaceOrderForm bklist, sales sale)
        {
            InitializeComponent();

            ActiveControl = editQuantityUpDown;

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
            try
            {
                book = bookService.findBook(_sale.title_id);
                bookToEditTextBox.Text = _sale.title_id + " - " + book.title;
                editQuantityUpDown.Value = _sale.qty;
            }
            catch
            {
                return;
            }            
        }

        private void editQuantityButton_Click(object sender, EventArgs e)
        {
            try
            {
                //updates quantity
                _sale.qty = (short)editQuantityUpDown.Value;

                //if user presses yes, quauntity remains zero
                if(_sale.qty == 0)
                {
                    MessageBox.Show("Enter a number greater than zero", "Error", MessageBoxButtons.OK);
                    return;
                    
                }
            }
            catch
            {
                return;
            }
            
            Dispose();
        }

        private void quantityCancelButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
