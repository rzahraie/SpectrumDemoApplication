using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App1
{
    public class Notify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void InvokePropertyChanged<T>(string name, T property, T value)
        {
            if (!property.Equals(value))
            {
                property = value;
                this.OnPropertyChanged(name);
            }
        }
    }

    public class DataRepository : Notify
    {
        private ObservableCollection<TransactionData> transactionDataCollection;
        private ObservableCollection<TransactionDataShort> transactionDataCollectionShort;
        private string filtertext = "";
        internal delegate void FilterChanged();
        internal FilterChanged filtertextchanged;

        private void OnFilterTextChanged()
        {
            filtertextchanged();
        }

        public string FilterText
        {
            get { return filtertext; }
            set
            {
                filtertext = value;
                OnFilterTextChanged();
                RaisePropertyChanged("FilterText");
            }
        }
        public bool FilterRecords(object o)
        {
            var item = o as TransactionDataShort;
            string lowerFiltertext = filtertext.ToLower();

            if (item.Date.ToString().ToLower().Contains(filtertext.ToLower()) ||
                item.To.ToLower().Contains(lowerFiltertext) ||
                item.Type.ToLower().Contains(lowerFiltertext) ||
                item.Coins.ToString().ToLower().Contains(lowerFiltertext))
                return true;
            else return false;
        }

        public ObservableCollection<TransactionData> TransactionDataCollection
        {
            get
            {
                if (transactionDataCollection == null)
                {
                    InitiateTransactionData();
                }

                return transactionDataCollection;
            }
            set
            {
                this.transactionDataCollection = value;
                RaisePropertyChanged("TransactionDataCollection");
            }
        }

        public ObservableCollection<TransactionDataShort> TransactionDataCollectionShort
        {
            get
            {
                if (transactionDataCollectionShort == null)
                {
                    InitiateTransactionDataShort();
                }

                return transactionDataCollectionShort;
            }
            set
            {
                this.transactionDataCollectionShort = value;
                RaisePropertyChanged("TransactionDataCollectionShort");
            }
        }

        public MemoryStream LoadResource(String name)
        {
            MemoryStream aMem = new MemoryStream();

            var assm = Assembly.GetExecutingAssembly();

            var path = String.Format("CardView.Resources.drawable.{0}", name);

            try
            {
                var aStream = assm.GetManifestResourceStream(path);
                aStream.CopyTo(aMem);
            }
            catch (System.Exception e)
            {
                string str = e.ToString();
            }

            return aMem;
        }

        public Image ConvertIconToBitmap(string iconName)
        {
            return (Imagehelper.ToUIImage(new ImageMapStream(LoadResource(iconName + ".png").ToArray())));
        }

        private void InitiateTransactionDataShort()
        {
            transactionDataCollectionShort = new ObservableCollection<TransactionDataShort>();

            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,"BTC", "Todd Bittrex", 100.45m,
                "100000", "USD", "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", 0.00029783m,"Success"));
            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,  "ETH", "Jeff Smith", 1.03m,
                "550", "EUR", "0x68d13D1003fe19C028e05406d039E47b3aDA977c", 0.00029783m, "Failed"));
            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,  "XRP", "Steve Johnson", 0.55m,
                "220", "JPY", "r9toHxUoPPBL7VNj1Xik3HJ6kSqiEYppGn", 0.00029783m, "Pending"));
            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,  "ADA", "Tom Joseph", 0.99m, 
                "330", "CHF", "stake1vpu5vlrf4xkxv2qpwngf6cjhtw542ayty80v8dyr49rf5egfu2p0u", 0.00029783m, "Success"));
            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,  "BTC", "Bob Jones", 2.55m, 
                "120000", "GBP", "myvnwkCKH1L1UcBdS6PX5vMX4MNpgnajZo", 0.00029783m, "Failed"));
            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,  "BTC", "Jennifer Givens", 2.56m, 
                "9000", "CNY", "myLickuquAGU7dhno3ofXsAJZk791iiHfD", 0.00029783m, "Pending"));
            transactionDataCollectionShort.Add(new TransactionDataShort(DateTime.Now,  "ETH", "Mary Robins", 12.93m,
                "4500", "USD", "0x4785995Ea11dfd35De6Ec6f3939D6d455e0FF833", 0.00029783m, "Success"));

        }

        private void InitiateTransactionData()
        {
            transactionDataCollection = new ObservableCollection<TransactionData>();

            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "Todd Bittrex", -3.94142104m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 100.45m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "Kraken", -0.50129783m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 55.65m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Received With", ConvertIconToBitmap("ic_call_missed_blue_500_18dp"),
                "1F5zjP6TSssVeyZf36ADcA3qCnX5jLNcuJi", -0.00400000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 25.3m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "1JJR1Xf5uqvsP3zogQb391eiBe2ge4vYoG", -1.20013000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 1.23m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "114R1Xf5uqvsP3zogQb391eiBe2ge4vYoG", -1.20013000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 10.4m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "1PmjFFu5uqvsP3zogQb391eiBe2ge4vYoG", -4.50875000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 34.45m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "1H2eFFu5uqvsP3zogQb391eiBe2ge4vYoG", -1.25000000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 1.09m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "1JRhxqu5uqvsP3zogQb391eiBe2ge4vYoG", -5.51536000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 7.69m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "13wuSqu5uqvsP3zogQb391eiBe2ge4vYoG", -1.25000000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 1.04m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_check_green_light_18dp"),
                "1F5zjP6TSssVeyZf36ADcA3qCnX5jLNcuJi", -1.20013000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 5.56m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "1JJR1Xf5uqvsP3zogQb391eiBe2ge4vYoG", -4.83728000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 12.98m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "114R1Xf5uqvsP3zogQb391eiBe2ge4vYoG", -1.25000000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 10.78m));
            transactionDataCollection.Add(new TransactionData(ConvertIconToBitmap("ic_check_green_light_18dp"),
                DateTime.Now, "Sent to", ConvertIconToBitmap("ic_call_missed_outgoing_blue_500_18dp"),
                "1PmjFFu5uqvsP3zogQb391eiBe2ge4vYoG", -1.20013000m, "3NHauBuw6faZv8bD66QLiZpdYx2HoemdAs", "BTC", -0.501m, -0.00029783m,
                "6664a73ff2b139c7ffad8bf562ef5ca861248dbc74f3aa9b1c9da516961dcb4", 255, "bytes", 1, "3660 confirmations", 9.08m));
        }
    }


    public class TransactionData : Notify
    {
        private Image statusIcon;
        private DateTime date;
        private string type;
        private Image labelStatusIcon;
        private string to;
        private string coins;
        private string amount;
        private string address;
        private string status;
        private string currency;
        private string debit;
        private string transactionFee;
        private string transactionId;
        private string transactionSize;
        private string transactionSizeUnit;
        private string outputSize;


        //public Image StatusIcon { get { return statusIcon; } set { InvokePropertyChanged("StatusIcon", statusIcon, value); } }
        public DateTime Date { get { return date; } set { InvokePropertyChanged("Date", date, value); } }
        public string Type { get { return type; } set { InvokePropertyChanged("Type", type, value); } }
        //public Image LabelStatusIcon { get { return labelStatusIcon; } set { InvokePropertyChanged("LabelStatusIcon", labelStatusIcon, value); } }
        public string To { get { return to; } set { InvokePropertyChanged("To", to, value); } }
        public string Coins { get { return coins; } set { InvokePropertyChanged("Coins", coins, value); } }
        public string Amount { get { return amount; } set { InvokePropertyChanged("Amount", amount, value); } }
        public string Address { get { return address; } set { InvokePropertyChanged("Address", address, value); } }
        public string Currency { get { return currency; } set { InvokePropertyChanged("Currency", currency, value); } }
        public string Debit { get { return debit; } set { InvokePropertyChanged("Debit", debit, value); } }
        public string TransactionFee { get { return transactionFee; } set { InvokePropertyChanged("TransactionFee", transactionFee, value); } }
        public string Status { get { return status; } set { InvokePropertyChanged("Status", status, value); } }
        public string TransactionId { get { return transactionId; } set { InvokePropertyChanged("TransactionId", transactionId, value); } }
        public string TransactionSize { get { return transactionSize; } set { InvokePropertyChanged("TransactionSize", transactionSize, value); } }
        public string TransactionSizeUnit
        {
            get { return transactionSizeUnit; }
            set { InvokePropertyChanged("TransactionSizeUnit", transactionSizeUnit, value); }
        }

        public string OutputSize { get { return outputSize; } set { InvokePropertyChanged("OutputSize", outputSize, value); } }

        public TransactionData(Image statusIcon, DateTime date, string type, Image labelStatusIcon, string to, decimal amount,
            string address, string currency, decimal debit, decimal transactionFee, string transactionId, int transactionSize,
            string transactionSizeUnit, int outputSize, string status, decimal coins)
        {
            this.statusIcon = statusIcon;
            this.date = date;
            this.type = type;
            this.labelStatusIcon = labelStatusIcon;
            this.to = to;
            this.amount = (amount * 7595m).ToString("0.#####");
            this.address = address;
            this.currency = currency;
            this.debit = debit.ToString("0.#####");
            this.transactionFee = transactionFee.ToString("0.#####");
            this.transactionId = transactionId;
            this.transactionSize = System.Convert.ToString(transactionSize);
            this.transactionSizeUnit = System.Convert.ToString(transactionSizeUnit);
            this.outputSize = System.Convert.ToString(outputSize);
            this.status = status;
            this.coins = coins.ToString("0.#####");
        }
    }

    public class TransactionDataShort : Notify
    {
        
        private DateTime date;
        private string type;
        private string to;
        private string coins;
        private string amount;
        private string currency;
        private string address;
        private string transactionFee;
        private string status;

        public (string Currency,string Amount, string Address, string TransactionFee, string
            Status) GetAdditionalData()
        {
            return (currency, amount, address, transactionFee, status);
        }

        public DateTime Date { get { return date; } set { InvokePropertyChanged("Date", date, value); } }
        public string Type { get { return type; } set { InvokePropertyChanged("Type", type, value); } }
        public string To { get { return to; } set { InvokePropertyChanged("To", to, value); } }
        public string Coins { get { return coins; } set { InvokePropertyChanged("Coins", coins, value); } }

        public TransactionDataShort(DateTime date, string type, string to, decimal coins,
            string amount, string currency, string address, decimal transactionFee, string status)
        {
            
            this.date = date;
            this.type = type;
            this.to = to;
            this.coins = coins.ToString("0.#####");
            this.amount = amount;
            this.currency = currency;
            this.address = address;
            this.transactionFee = transactionFee.ToString("0.####");
            this.status = status;

        }

       
    }

    //Custom styler
    public class CustomGridStyle : DataGridStyle
    {
        private int collapseIcon;
        private int expandIcon;
        private ImageSource iCollapseIcon;
        private ImageSource iExpandIcon;

        public CustomGridStyle()
        {
        }

        public CustomGridStyle(int collapseIcon, int expandIcon)
        {
            this.collapseIcon = collapseIcon;
            this.expandIcon = expandIcon;
        }

        public CustomGridStyle(ImageSource iCollapseIcon, ImageSource iExpandIcon)
        {
            this.iCollapseIcon = iCollapseIcon;
            this.iExpandIcon = iExpandIcon;
        }

        public override Color GetRecordBackgroundColor()
        {
            return Color.FromHex("#FFE5E6FA");
        }

        public override Color GetAlternatingRowBackgroundColor()
        {
            return Color.White;
        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.None;
        }

        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#FF778898");
        }

        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromHex("#FFFAD127");
        }

        public override Color GetCaptionSummaryRowBackgroundColor()
        {
            return Color.FromHex("#696969");
        }

        public override Color GetCaptionSummaryRowForegroundColor()
        {
            return Color.White;
        }

        public override Color GetTableSummaryBackgroundColor()
        {
            return Color.FromHex("#bdbdbd");
        }

        public override Color GetTableSummaryForegroundColor()
        {
            return Color.White;
        }

        public override ImageSource GetGroupCollapseIcon()
        {
            return iCollapseIcon;
        }
        public override ImageSource GetGroupExpanderIcon()
        {
            return iExpandIcon;
        }
    }

    public class StatusCell : GridCell
    {
        SfLabel statusText;
        SfImageView statusImage;
        public static int checkIcon;
        public static int circleIcon;
        static int row = 0;

        public StatusCell() : base()
        {
            statusText = new SfLabel();
            statusImage = new SfImageView();
            statusText.HorizontalTextAlignment = TextAlignment.Start;
            statusText.TextColor = Color.FromRgb(51, 51, 51);
            
            
        }

       
        
        //protected override void OnDraw(Canvas canvas)
        //{
        //    statusText.Text = DataColumn.CellValue.ToString();
        //    //if (++row % 2 != 0)
        //    //    statusImage.SetImageResource(checkIcon);
        //    //else
        //    statusImage.SetImageResource(circleIcon);
        //    base.OnDraw(canvas);
        //}

        //protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        //{
        //    statusImage.Layout((int)(15 * Resources.DisplayMetrics.Density), 0, (int)(35 * Resources.DisplayMetrics.Density), Height);
        //    statusText.Layout((int)(35 * Resources.DisplayMetrics.Density), (int)(10 * Resources.DisplayMetrics.Density), Width - 20, Height);
        //}
    }

    public class DataGridUtilities
    {
        public static GridTextColumn CreateTextColumnEx(string columnName, string headerText, string format = "", int width = -1,
            bool hidden = false)
        {
            GridTextColumn column = new GridTextColumn()
            {
                MappingName = columnName,
                HeaderText = headerText
            };

            return column;
        }
        public static GridTextColumn CreateTextColumn(string columnName, string headerText, string format, int width, bool hidden = false,
            TextAlignment gv = TextAlignment.Start)
        {
            GridTextColumn column = new GridTextColumn()
            {
                MappingName = columnName,
                HeaderText = headerText,
                TextAlignment = gv,
                Format = format,
                IsHidden = hidden,
                LoadUIView = true
            };

            if (width != -1) column.Width = width;

            return column;
        }

        public static GridDateTimeColumn CreateDateColumn(string columnName, string headerText, string format, int width, bool hidden = false)
        {
            GridDateTimeColumn column = new GridDateTimeColumn()
            {
                MappingName = columnName,
                HeaderText = headerText,
                TextAlignment = TextAlignment.Start,
                Format = format,
                IsHidden = hidden,
                LoadUIView = true
            };

            if (width != -1) column.Width = width;

            return column;
        }
    }
}
