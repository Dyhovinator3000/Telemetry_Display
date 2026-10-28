using System.Globalization;
using System.Net;
using System.Text;
using Wospp.QOLStuff;

namespace WTD_V2
{
    public partial class Form1 : Form
    {
        // VARIABLES
        HttpClient client = new HttpClient();
        string url = "http://127.0.0.1:8765/telemetry";
        string rawData = "";
        string[] dataBytes = new string[18];
        bool on = false;
        List<double> satTime = new List<double>();
        List<double> satBattery = new List<double>();
        List<double> satSd1 = new List<double>();
        List<double> satSd2 = new List<double>();
        List<double> satSd3 = new List<double>();
        List<double> satSd4 = new List<double>();
        List<double> satAX = new List<double>();
        List<double> satAY = new List<double>();
        List<double> satAZ = new List<double>();
        List<double> satGX = new List<double>();
        List<double> satGY = new List<double>();
        List<double> satGZ = new List<double>();
        List<double> satMX = new List<double>();
        List<double> satMY = new List<double>();
        List<double> satMZ = new List<double>();
        List<double> satFlywheel = new List<double>();

        public Form1()
        {
            InitializeComponent();
            client.DefaultRequestHeaders.ConnectionClose = true;
            this.Click += Form1_Click;
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                e.Cancel = true;

                try
                {
                    client.CancelPendingRequests();

                    await Task.Delay(100);

                    client.Dispose();
                    client = null;
                }
                catch { }

                this.Close();
            }
        }


        private async void toggle_Click(object sender, EventArgs e)
        {
            on = !on;
            toggle.Text = on ? "Выключить" : "Включить";

            await Task.Run(GET);
        }
        async Task GET()
        {
            while (on)
            {
                try
                {
                    // HEADERS
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Headers.ConnectionClose = false;

                    // GET
                    HttpResponseMessage responce = await client.SendAsync(request);

                    if (responce.StatusCode == HttpStatusCode.NoContent)
                    {
                        rawData = "НЕТ ДАННЫХ";
                        return;
                    }
                    else
                    {
                        rawData = await responce.Content.ReadAsStringAsync();
                        Console.WriteLine(rawData);
                        dataBytes = rawData.Split(';');

                        // BATTERY
                        double battery = double.Parse(dataBytes[2]);
                        battery = battery / 1000;

                        // AX
                        double ax = double.Parse(dataBytes[7]);
                        ax = ax / 16384;

                        // AY
                        double ay = double.Parse(dataBytes[8]);
                        ay = ay / 16384;

                        // AZ
                        double az = double.Parse(dataBytes[9]);
                        az = az / 16384;

                        // GX
                        double gx = double.Parse(dataBytes[10]);
                        gx = gx / 131.072;

                        // GY
                        double gy = double.Parse(dataBytes[11]);
                        gy = gy / 131.072;

                        // GZ
                        double gz = double.Parse(dataBytes[12]);
                        gz = gz / 131.072;

                        // GX
                        double mx = double.Parse(dataBytes[13]);
                        mx = mx / 1711.6;

                        // GY
                        double my = double.Parse(dataBytes[14]);
                        my = my / 1711.6;

                        // GZ
                        double mz = double.Parse(dataBytes[15]);
                        mz = mz / 1711.6;


                        // LISTS
                        satTime.Add(double.Parse(dataBytes[1]));
                        satBattery.Add(double.Parse(dataBytes[2]));

                        satSd1.Add(double.Parse(dataBytes[3]));
                        satSd2.Add(double.Parse(dataBytes[4]));
                        satSd3.Add(double.Parse(dataBytes[5]));
                        satSd4.Add(double.Parse(dataBytes[6]));

                        satAX.Add(double.Parse(dataBytes[7]));
                        satAY.Add(double.Parse(dataBytes[8]));
                        satAZ.Add(double.Parse(dataBytes[9]));

                        satGX.Add(double.Parse(dataBytes[10]));
                        satGY.Add(double.Parse(dataBytes[11]));
                        satGZ.Add(double.Parse(dataBytes[12]));

                        satMX.Add(double.Parse(dataBytes[13]));
                        satMY.Add(double.Parse(dataBytes[14]));
                        satMZ.Add(double.Parse(dataBytes[15]));

                        satFlywheel.Add(double.Parse(dataBytes[16]));
                    }
                }
                catch
                {
                    for (int i = 0; i < dataBytes.Length; i++)
                    {
                        dataBytes[i] = "НЕТ ДАННЫХ";
                    }
                }
                UpdateGUI();
                Thread.Sleep(60);
            }
        }
        public void UpdateGUI()
        {
            preAmb.Invoke(new Action(() =>
            {
                preAmb.Text = "Преамбула: " + dataBytes[0];
                preAmb.ForeColor = dataBytes[0] == "НЕТ ДАННЫХ" ? Color.Red : Color.Green;
            }));
            time.Invoke(new Action(() =>
            {
                time.Text = "Время от запуска: " + dataBytes[1];
                time.ForeColor = dataBytes[1] == "НЕТ ДАННЫХ" ? Color.Red : Color.Green;
            }));
            battery.Invoke(new Action(() =>
            {
                battery.Text = "АКБ (v): " + dataBytes[2];
                if (dataBytes[2] == "НЕТ ДАННЫХ") { battery.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[2]) / 1000;
                battery.ForeColor = !val.Within(0, 12) ? Color.Yellow : Color.Green;
            }));
            sd1.Invoke(new Action(() =>
            {
                sd1.Text = "Освещённость 1: " + dataBytes[3];
                if (dataBytes[3] == "НЕТ ДАННЫХ") { sd1.ForeColor = Color.Red; return; }

                sd1.ForeColor = !double.Parse(dataBytes[3]).Within(0, 65535) ? Color.Yellow : Color.Green;
            }));
            sd2.Invoke(new Action(() =>
            {
                sd2.Text = "Освещённость 2: " + dataBytes[4];
                if (dataBytes[4] == "НЕТ ДАННЫХ") { sd2.ForeColor = Color.Red; return; }

                sd2.ForeColor = !double.Parse(dataBytes[4]).Within(0, 65535) ? Color.Yellow : Color.Green;
            }));
            sd3.Invoke(new Action(() =>
            {
                sd3.Text = "Освещённость 3: " + dataBytes[5];
                if (dataBytes[5] == "НЕТ ДАННЫХ") { sd3.ForeColor = Color.Red; return; }

                sd3.ForeColor = !double.Parse(dataBytes[5]).Within(0, 65535) ? Color.Yellow : Color.Green;
            }));
            sd4.Invoke(new Action(() =>
            {
                sd4.Text = "Освещённость 4: " + dataBytes[6];
                if (dataBytes[6] == "НЕТ ДАННЫХ") { sd4.ForeColor = Color.Red; return; }

                sd4.ForeColor = !double.Parse(dataBytes[6]).Within(0, 65535) ? Color.Yellow : Color.Green;
            }));
            AX.Invoke(new Action(() =>
            {
                AX.Text = "Ускорение X (g): " + dataBytes[7];
                if (dataBytes[7] == "НЕТ ДАННЫХ") { AX.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[7]) / 16384;
                AX.ForeColor = !val.Within(-2, 2) ? Color.Yellow : Color.Green;
            }));
            AY.Invoke(new Action(() =>
            {
                AY.Text = "Ускорение Y (g): " + dataBytes[8];
                if (dataBytes[8] == "НЕТ ДАННЫХ") { AY.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[8]) / 16384;
                AY.ForeColor = !val.Within(-2, 2) ? Color.Yellow : Color.Green;
            }));
            AZ.Invoke(new Action(() =>
            {
                AZ.Text = "Ускорение Z (g): " + dataBytes[9];
                if (dataBytes[9] == "НЕТ ДАННЫХ") { AZ.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[9]) / 16384;
                AZ.ForeColor = !val.Within(-2, 2) ? Color.Yellow : Color.Green;
            }));
            GX.Invoke(new Action(() =>
            {
                GX.Text = "Угловая скорость X (*/с): " + dataBytes[10];
                if (dataBytes[10] == "НЕТ ДАННЫХ") { GX.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[10]) / 131.072;
                GX.ForeColor = !val.Within(-250, 250) ? Color.Yellow : Color.Green;
            }));
            GY.Invoke(new Action(() =>
            {
                GY.Text = "Угловая скорость Y (*/с): " + dataBytes[11];
                if (dataBytes[11] == "НЕТ ДАННЫХ") { GY.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[11]) / 131.072;
                GY.ForeColor = !val.Within(-250, 250) ? Color.Yellow : Color.Green;
            }));
            GZ.Invoke(new Action(() =>
            {
                GZ.Text = "Угловая скорость Z (*/с): " + dataBytes[12];
                if (dataBytes[12] == "НЕТ ДАННЫХ") { GZ.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[12]) / 131.072;
                GZ.ForeColor = !val.Within(-250, 250) ? Color.Yellow : Color.Green;
            }));
            MX.Invoke(new Action(() =>
            {
                MX.Text = "Магнитное поле X (Гс): " + dataBytes[13];
                if (dataBytes[13] == "НЕТ ДАННЫХ") { MX.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[13]) / 1711.6;
                MX.ForeColor = !val.Within(-16, 16) ? Color.Yellow : Color.Green;
            }));
            MY.Invoke(new Action(() =>
            {
                MY.Text = "Магнитное поле Y (Гс): " + dataBytes[14];
                if (dataBytes[14] == "НЕТ ДАННЫХ") { MY.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[14]) / 1711.6;
                MY.ForeColor = !val.Within(-16, 16) ? Color.Yellow : Color.Green;
            }));
            MZ.Invoke(new Action(() =>
            {
                MZ.Text = "Магнитное поле Z (Гс): " + dataBytes[15];
                if (dataBytes[15] == "НЕТ ДАННЫХ") { MZ.ForeColor = Color.Red; return; }

                double val = double.Parse(dataBytes[15]) / 1711.6;
                MZ.ForeColor = !val.Within(-16, 16) ? Color.Yellow : Color.Green;
            }));
            flywheel.Invoke(new Action(() =>
            {
                flywheel.Text = "Маховик: " + dataBytes[16];
                flywheel.ForeColor = flywheel.Text == "Маховик: НЕТ ДАННЫХ" ? Color.Red : Color.Green;
            }));
            postAmb.Invoke(new Action(() =>
            {
                postAmb.Text = "Постамбула: " + dataBytes[17];
                postAmb.ForeColor = postAmb.Text == "Постамбула: НЕТ ДАННЫХ" ? Color.Red : Color.Green;
            }));
            urlBox.Invoke(new Action(() =>
            {
                url = urlBox.Text;
            }));

            dataList.Invoke(new Action(() =>
            {
                graph.Invoke(new Action(() =>
                {
                    if (satTime == null) return;

                    if (dataList.SelectedIndex == 0)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satTime);
                    }
                    if (dataList.SelectedIndex == 1)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satBattery);
                    }
                    if (dataList.SelectedIndex == 2)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satSd1);
                    }
                    if (dataList.SelectedIndex == 3)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satSd2);
                    }
                    if (dataList.SelectedIndex == 4)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satSd3);
                    }
                    if (dataList.SelectedIndex == 5)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satSd4);
                    }
                    if (dataList.SelectedIndex == 6)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satAX);
                    }
                    if (dataList.SelectedIndex == 7)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satAY);
                    }
                    if (dataList.SelectedIndex == 8)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satAZ);
                    }
                    if (dataList.SelectedIndex == 9)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satGX);
                    }
                    if (dataList.SelectedIndex == 10)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satGY);
                    }
                    if (dataList.SelectedIndex == 11)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satGZ);
                    }
                    if (dataList.SelectedIndex == 12)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satMX);
                    }
                    if (dataList.SelectedIndex == 13)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satMY);
                    }
                    if (dataList.SelectedIndex == 14)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satMZ);
                    }
                    if (dataList.SelectedIndex == 15)
                    {
                        graph.Plot.Clear();
                        graph.Plot.Add.Scatter(satTime, satFlywheel);
                    }
                    graph.Refresh();
                }));
            }));
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        private void urlBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                this.ActiveControl = null;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}