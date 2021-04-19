// Programmer: Andrew Newman
// Course: CP240 Lab08
// Description: Rest Api
// Limitations: Windows only

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

using Model;
using restfulRepo;
using ServiceBus;

using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class BookList : Form
    {
        pubsService auService;
        public book _book;
        public sales _sale;
        public short qty;
        public PlaceOrderForm _pof;

        public BookList(PlaceOrderForm pof, sales sale)
        {
            InitializeComponent();

            ActiveControl = bookQuantityUpDown;

            string apiRoot = configFile.getSetting("apiRoot");

            BookRepoREST bookRepo = new BookRepoREST(apiRoot);
            StoreRepoREST storeRepo = new StoreRepoREST(apiRoot);
            SalesRepoREST salesRepo = new SalesRepoREST(apiRoot);
            BookOrderRepoREST bookOrderRepo = new BookOrderRepoREST(apiRoot);

            auService = new pubsService(bookRepo, storeRepo, salesRepo, bookOrderRepo);

            _pof = pof;
            _sale = sale;
        }

        private void BookList_Load(object sender, EventArgs e)
        {
            updatePublisherList();

            publishersList.Width = publishersList.Columns[0].Width + publishersList.Columns[1].Width + publishersList.Columns[2].Width + publishersList.Columns[3].Width + publishersList.Columns[4].Width + publishersList.Columns[5].Width + 121;
            //Places listview headers where they should be
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            qty = (short)bookQuantityUpDown.Value;
            _sale.qty = qty;            
            
            try
            {
                _sale.title_id = publishersList.SelectedItems[0].Tag.ToString();
            }
            catch
            {
                MessageBox.Show("Select book to add followed by the amount.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (bookQuantityUpDown.Value == 0)
            {
                MessageBox.Show("Select amount of books to add.", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (publishersList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select book to add.", "Error", MessageBoxButtons.OK);
                return;
            }

            Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void updatePublisherList()
        {
            try
            {
                publishersList.Clear();

                List<bookViewModel> books = auService.getAllBooks();
                List<bookViewModel> filteredBooks = new List<bookViewModel>();

                foreach(bookViewModel bks in books)
                {
                    filteredBooks.Add(bks);
                }

                foreach(sales sale in _pof.transaction)
                {
                    foreach(bookViewModel fbks in books)
                    {
                        if (sale.title_id == fbks.TitleId)
                        {
                            filteredBooks.Remove(fbks);
                        }
                    }
                    
                }

                if (books.Count == 0)
                {
                    MessageBox.Show("Connection Timed Out.\nPlease check connection string.", "Error", MessageBoxButtons.OK);
                    return;
                }

                ListViewItem lvi = null;

                foreach (bookViewModel b in filteredBooks)
                {
                    lvi = new ListViewItem(b.Title);
                    lvi.Tag = b.TitleId;
                    lvi.SubItems.Add(b.Type);
                    lvi.SubItems.Add(b.pubId);
                    lvi.SubItems.Add(b.pubName);
                    lvi.SubItems.Add(b.Price);
                    lvi.SubItems.Add(b.Date);
                    publishersList.Items.Add(lvi);
                }

                publisherColumnHead();
            }
            catch
            {
                return;
            }            
        }

        public void publisherColumnHead()
        {
            publishersList.Columns.Add(bookTitle.Text);
            publishersList.Columns.Add(bookType.Text);
            publishersList.Columns.Add(bookPublisherId.Text);
            publishersList.Columns.Add(bookPublisherName.Text);
            publishersList.Columns.Add(bookPrice.Text);
            publishersList.Columns.Add(bookPublishedDate.Text);
            publishersList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            publishersList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            publishersList.Columns[0].TextAlign = HorizontalAlignment.Left;
            publishersList.Columns[1].TextAlign = HorizontalAlignment.Left;
            publishersList.Columns[2].TextAlign = HorizontalAlignment.Left;
            publishersList.Columns[3].TextAlign = HorizontalAlignment.Left;
            publishersList.Columns[4].TextAlign = HorizontalAlignment.Left;
            publishersList.Columns[5].TextAlign = HorizontalAlignment.Left;
        }     
    }
}

class configFile
{
    public static string getSetting(string key)
    {
        // adapted from: 
        // https://msdn.microsoft.com/en-us/library/system.configuration.configurationmanager.appsettings(v=vs.110).aspx
        // see app.config file for how to add the setting

        string setting = "";

        try
        {
            var appSettings = ConfigurationManager.AppSettings;

            // if appSettings[key] != null, then appSettings[key], else exception
            setting = appSettings[key] ?? throw new Exception("Key not found");
        }
        catch (ConfigurationErrorsException)
        {
            throw new Exception("Key not found");
        }

        return setting;
    }
}

