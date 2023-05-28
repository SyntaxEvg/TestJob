
using Binance.Net.Objects.Models.Spot;
using ExchangeRates;
using TestJob.Enums;
using TestJob.Exchanges;

namespace TestJob
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        private readonly ExchangeRatesService _exchangeRatesService;
        public Form1()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;


            InitializeComponent();
            _exchangeRatesService = new ExchangeRatesService(Combox);

            // Populate the pairs dropdown with BTCUSDT and ETHUSDT
            //combo.Items.Add("BTCUSDT");
            //combo.Items.Add("ETHUSDT");
            //combo.Items.Add("BNBUSDT"); 


            StartTimer();

        }

        /// <summary>
        /// ”правление листом
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="strings"></param>
        public string Combox(Operation operation, List<string> strings)
        {
            switch (operation)
            {
                case Operation.get:

                    if (combo.SelectedIndex == -1)
                    {
                        combo.SelectedIndex = 0;
                    }
                    return combo.SelectedItem as string;

                    ;
                case Operation.add:
                    //combo.Items.Add("BNBUSDT");
                    combo.Items.AddRange(strings.ToArray());
                    // Invoke(new Action(() => combo.Items.AddRange(strings.ToArray())));
                    return null;
                default:
                    break;
            }
            return null;



        }


        private async void StartTimer()
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                await Task.Delay(5000, token).ContinueWith(x => GetPrice());

            }


        }


        private void refreshButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                var pair = combo.SelectedItem.ToString();
                GetPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($" error occurred: {ex.Message}");
            }
        }

        private void GetPrice()
        {
            try
            {


                var exchangeRates = _exchangeRatesService.GetExchangeRates();
                foreach ((string name, string price) in exchangeRates)
                {
                    if (name == nameof(BinanceExchange))
                    {
                        Invoke(new Action(() => lBinance.Text = price));
                    }
                    else if (name == nameof(BybitExchange))
                    {
                        Invoke(new Action(() => lBybit.Text = price));
                    }
                    else if (name == nameof(KucoinExchange))
                    {
                        Invoke(new Action(() => lkucoin.Text = price));
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        //private void combo_SelectedIndexChanged(object sender,
        //System.EventArgs e)
        //{


        //}


        private void button1_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = (string)combo.SelectedItem;
            _exchangeRatesService?.SetSymbol(select);

        }
    }
}