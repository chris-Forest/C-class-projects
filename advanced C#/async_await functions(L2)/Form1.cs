//Submission code 1202_CMPE2800_L02
//Chris Forest

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using static System.Diagnostics.Trace;

namespace chris_async_lab02
{
    public partial class Form1 : Form
    {
        private BindingSource filterSource = new BindingSource();//set a binding source for the datagridvivew that show filter data
        private BindingSource TipSource = new BindingSource();//set a binding source for the datagridvivew that show tip data
        const string url = @"https://thor.net.nait.ca/~demo/cmpe2800/stockWatch.php";// const url for easy calling 
        public Form1()
        {
            InitializeComponent();
            UsernameTextBox.Text = "sly";
            statusLabel.Text = "loading data";
            DGV_Filter.DataSource = filterSource;
            DGV_Tips.DataSource = TipSource;
            SelectedTipButton.Click += SelectedTipButton_Click;
            NewTipButton.Click += NewTipButton_Click;
            HottestTipButton.Click += HottestTipButton_Click;
            AddStockButton.Click += AddStockButton_Click;
            loadData();
        }

        /// <summary>
        /// pre-load filter data into DGV_Filter with empty string to see all data that can be filtered 
        /// </summary>
        private async void loadData()
        {
            MultipartFormDataContent form = new MultipartFormDataContent();

            //setup default data post data web request to load all avalible stocks with empty string
            {
                var postData = new Dictionary<string, string>()
                {
                    {"username","name here" },
                    {"action","stocks" },
                    {"filter","" }
                };

                // Transfer to form to send
                foreach (var item in postData)
                    form.Add(new StringContent(item.Value), item.Key);
            }

            //send POSTdata request to webservice, return and display data in DGV_filter
            using (HttpClient hc = new HttpClient())
            {
                //issuse request
                var postResponse = await hc.PostAsync(url, form);

                //if there is content in request,
                //read it as a string and call a decode method to Deserialized json data
                if (postResponse.Content != null)
                {
                    // Get our response from the Content, decode the data  
                    var stringResp = await postResponse.Content.ReadAsStringAsync();

                    //decode method to Deserialized json data and display to DGV_filter
                    Filterdecode(stringResp);
                    DGV_Filter.AutoResizeColumns();
                }
            }
            statusLabel.Text = "loaded stock data";
        }

        #region filter
        /// <summary>
        /// filter a specfic stock with a key word to find a specifc stock to get tips fpr later on in the program
        /// username must be entered to filter stocks. can also filter with empty string to get all stocks back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FindStocks_Click(object sender, EventArgs e)
        {            
            MultipartFormDataContent form = new MultipartFormDataContent();
            statusLabel.Text = "getting filtered data stocks";

            {
                // have user enter a username(needed to run request) and a filter word or words 
                //to filter for a specifc stock. done with a collection type
                var postData = new Dictionary<string, string>()
                {
                    {"username",UsernameTextBox.Text },
                    {"action","stocks" },
                    {"filter",FilterTextBox.Text }
                };

                // Transfer to form to send
                foreach (var item in postData)
                    form.Add(new StringContent(item.Value), item.Key);
            }

            //send POSTdata request to webservice, return and display data in DGV_filter
            using (HttpClient hc=new HttpClient())
            {
                //issuse request
                var postResponse = await hc.PostAsync(url, form);

                //if there is content in request,
                //read it as a string and call a decode method to Deserialized json data
                if (postResponse.Content!=null)
                {
                    // Get our response from the Content, decode the data  
                    var stringResp = await postResponse.Content.ReadAsStringAsync();

                    //decode method to Deserialized json data and display to DGV_filter
                    Filterdecode(stringResp);
                    DGV_Filter.AutoResizeColumns();
                }
            }            
        }

        /// <summary>
        /// helper method to decode filter/load request to a)pre-load data and
        /// b) issue a filter request based on key word entered
        /// </summary>
        /// <param name="decoder"></param>
        private void Filterdecode(string decoder)
        {
            //decode the JSON encoded response the webservice replied with
            var reply = Newtonsoft.Json.JsonConvert.DeserializeObject<GetFilterData>(decoder);

            //load data to DGV_filter here
            //take Deserialized json data and return it as string data in DGV_filter
            filterSource.DataSource = from filterData in reply.data
                             select new
                             {
                                 Symbol = filterData.symbol,
                                 Company = filterData.company,
                                 AvgVolum = filterData.avgVolume.ToString(),
                                 MarketCap = filterData.marketCap.ToString()
                             };
            //return response if request was successful or not
            statusLabel.Text = reply.status;
        }
        #endregion

        #region selectTIP      
        /// <summary>
        ///  issue a web request for all available stocks tips for the supplied stock symbol. 
        ///  Only submit the request if a stock is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectedTipButton_Click(object sender, EventArgs e)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            statusLabel.Text = "getting selected stock tips ";

            //if selected row is not null run request, 
            //grab the first column value and send it to post data for a request
            if (DGV_Filter.SelectedRows != null)
            {
                //Anonymously set postdata request
                //must have user enter a username(needed to run request)
                //and a stock symbol must be pick to get tip data 
                var postData = new[]
                {
                    new{k="username",v=UsernameTextBox.Text },
                    new{k="action",v="tips"},
                    new{k="symbol",v=DGV_Filter.CurrentRow.Cells[0].Value.ToString()}              
                };

                // Transfer to be sent
                foreach (var item in postData)
                    form.Add(new StringContent(item.v), item.k);
            }
            else
                statusLabel.Text = "error must select a stock";

            //send POSTdata request to webservice, return and display data in DGV_Tips
            using (HttpClient hc = new HttpClient())
            {
                //sends request
                var postResponse = await hc.PostAsync(url, form);                                             

                //if there is content in request,
                //read it as a string and call a decode method to Deserialized json data
                if (postResponse.Content != null)
                {
                    // Get our response from the Content
                    var stringResp = await postResponse.Content.ReadAsStringAsync();

                    //decode method to Deserialized json data and display to DGV_Tips
                    SelectTipDecode(stringResp);
                    DGV_Tips.AutoResizeColumns();
                }
            }
        }

        /// <summary>
        /// take selected row and get first column row value(symbol)
        /// and decode the data and display it in DGV_tips
        /// </summary>
        /// <param name="decoder"></param>
        private void SelectTipDecode(string decoder)
        {
            //set and anonumus vewrsion to populate postData to send to webservice
            var template = new 
            { data = new[] 
                {
                    new 
                    { 
                        symbol = "", 
                        company = "",
                        username = "", 
                        tip = "", 
                        lastModified = "" 
                    } 
                }, status = "" 
            };

            //Deserialize json reply data that was recieved from the post request
            var reply = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(decoder, template);

            //linq expression to bind recived webservice request
            //to DGV_tips datasource to dispaly it in DGV_tips
            TipSource.DataSource = from dt in reply.data select new 
            { 
                Symbol=dt.symbol,
                Company=dt.company,
                Username=dt.username,
                Tip=dt.tip,
                LastModified = dt.lastModified
            };

            //update status
            statusLabel.Text = reply.status;
        }
        #endregion

        #region hotTip

        /// <summary>
        /// issue a web request for all available stock tips
        /// classified as hottest(highest count of tips)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HottestTipButton_Click(object sender, EventArgs e)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            statusLabel.Text = "getting hottest stock tips";

            //Anonymously set postdata request
            //must have user enter a username(needed to run request)
            var postData = new[]
            {
                new{k="username",v=UsernameTextBox.Text },
                new{k="action",v="tips"},
                new{k="flag",v="hottest"}
            };

            // Transfer postdata to be sent
            foreach (var item in postData)
                form.Add(new StringContent(item.v), item.k);

            //send POSTdata request to webservice, return and display data in DGV_Tips
            using (HttpClient hc = new HttpClient())
            {
                //send post request
                var postResponse = await hc.PostAsync(url, form);

                //if there is content in request,
                //read it as a string and call a decode method to Deserialized json data
                if (postResponse.Content != null)
                {
                    //seriealize content response as a string asynchronously
                    var stringResp = await postResponse.Content.ReadAsStringAsync();

                    //decode method to Deserialized json data and display to DGV_Tips
                    TipDecode(stringResp);
                    DGV_Tips.AutoResizeColumns();
                }
            }
        }
        #endregion

        /// <summary>
        /// shared Anonymous decode method for hot tips and newest tips added
        /// </summary>
        /// <param name="decoder"></param>
        private void TipDecode(string decoder)
        {
            //set and anonumus vewrsion to populate postData to send to webservice
            var Template = new
            {
                data = new[]
                {
                    new
                    {
                        symbol = "",
                        numTips = "",
                        username = "",
                        tip = "",
                        lastModified = ""
                    }
                },
                status = ""
            };

            //Deserialize json reply data that was recieved from the post request
            var reply = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(decoder, Template);

            //linq expression to bind recived webservice request
            //to DGV_tips datasource to dispaly it in DGV_tips
            TipSource.DataSource = from tips in reply.data
                             select new
                             {
                                 Symbol = tips.symbol,
                                 NumTips = tips.numTips,
                                 Username = tips.username,
                                 Tip = tips.tip,
                                 LastModified = tips.lastModified
                             };
            //request resopnse
            statusLabel.Text = reply.status;
        }

        #region newestTips
        /// <summary>
        /// issue a web request for all available stock tips classified as newest ( obvious ).
        /// For ALL stock tips, returns a bunch of the most recent additions ( newest first )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NewTipButton_Click(object sender, EventArgs e)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            statusLabel.Text = "getting newest stock tips";

            //Anonymously set postdata request
            //must have user enter a username(needed to run request)
            var postData = new[]
            {
                new{k="username",v=UsernameTextBox.Text },
                new{k="action",v="tips"},
                new{k="flag",v="newest"}
            };

            // Transfer postdata to be sent
            foreach (var item in postData)
                form.Add(new StringContent(item.v), item.k);

            //send POSTdata request to webservice, return and display data in DGV_filter
            using (HttpClient hc = new HttpClient())
            {
                //send post request
                var postResponse = await hc.PostAsync(url, form);

                //if there is content in request,
                //read it as a string and call a decode method to Deserialized json data
                if (postResponse.Content != null)
                {
                    //seriealize content response as a string asynchronously
                    var stringResp = await postResponse.Content.ReadAsStringAsync();

                    //decode method to Deserialized json data and display to DGV_Tips
                    TipDecode(stringResp);
                    DGV_Tips.AutoResizeColumns();
                }
            }
        }
        #endregion

        #region addStocks
        /// <summary>
        /// issue a web request to add a stock tip for the current username. 
        /// Only submit the request if a stock is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddStockButton_Click(object sender, EventArgs e)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            statusLabel.Text = $"adding stock tip to {DGV_Filter.CurrentRow.Cells[0].Value}";

            //if selected row is not null run request, 
            //grab the first column value and sent it to post data for a request
            if (DGV_Filter.SelectedRows != null)
            {
                //Anonymously set postdata request
                //must have user enter a username(needed to run request)
                //and a stock symbol must be picked to get add tip data   
                var postData = new[]
                {
                    new{k="username",v=UsernameTextBox.Text },
                    new{k="action",v="addtip"},
                    new{k="symbol",v=DGV_Filter.CurrentRow.Cells[0].Value.ToString()},//=DGV_currently_selected_stock_symbol
                    new{k="tip",v=addTipTextBox.Text}
                };

                // Transfer postdata to be sent
                foreach (var item in postData)
                    form.Add(new StringContent(item.v), item.k);
            }
            else
                statusLabel.Text = "error must select a stock";            

            //send POSTdata request to webservice, return and add new tip to  symbol and database
            using (HttpClient hc = new HttpClient())
            {
                //send post request
                var postResponse = await hc.PostAsync(url, form);

                //if there is content in request,
                //read it as a string and call a decode method to Deserialized json data
                if (postResponse.Content != null)
                {
                    //seriealize content response as a string asynchronously
                    var stringResp = await postResponse.Content.ReadAsStringAsync();

                    //decode method to Deserialized json data and display to DGV_Tips
                    AddTipDecode(stringResp);//is this needded for add stocks
                    DGV_Tips.AutoResizeColumns();
                }
            }
        }

        /// <summary>
        /// decode addTips post request and update stauts to tell user for success or not
        /// </summary>
        /// <param name="decoder"></param>
        private void AddTipDecode(string decoder)
        {
            //set and anonumus vewrsion to populate postData to send to webservice
            var Template = new
            {
                data = new[]
                {
                    new
                    {
                        symbol = "",
                        numTips = "",
                        username = "",
                        tip = "",
                        lastModified = ""
                    }
                },
                status = ""
            };

            //Deserialize json reply data that was recieved from the post request
            var reply = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(decoder, Template);

            //clear forws to further show that a stock tip was added
            DGV_Tips.Columns.Clear();

            //request resopnse
            statusLabel.Text = reply.status;
        }
        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            statusLabel.Text = "loading stock data";
        }
    }

    #region filterDataClasses
    public class FilterTags
    {
        public string symbol { get; set; }
        public string company { get; set; }
        public double avgVolume { get; set; }
        public double marketCap { get; set; }
    }

    public class GetFilterData
    {
        public List<FilterTags> data { get; set; }
        public string status { get; set; }
    }
    #endregion
}
