namespace WTD_V2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toggle = new Button();
            preAmb = new Label();
            time = new Label();
            battery = new Label();
            sd1 = new Label();
            sd2 = new Label();
            sd3 = new Label();
            sd4 = new Label();
            AX = new Label();
            AY = new Label();
            AZ = new Label();
            GX = new Label();
            GY = new Label();
            GZ = new Label();
            MX = new Label();
            MY = new Label();
            MZ = new Label();
            flywheel = new Label();
            postAmb = new Label();
            tabs = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            graph = new ScottPlot.WinForms.FormsPlot();
            dataList = new ListBox();
            urlBox = new TextBox();
            tabs.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // toggle
            // 
            toggle.Location = new Point(12, 12);
            toggle.Name = "toggle";
            toggle.Size = new Size(94, 23);
            toggle.TabIndex = 0;
            toggle.Text = "Включить";
            toggle.UseVisualStyleBackColor = true;
            toggle.Click += toggle_Click;
            // 
            // preAmb
            // 
            preAmb.AutoSize = true;
            preAmb.Location = new Point(9, 6);
            preAmb.Name = "preAmb";
            preAmb.Size = new Size(76, 15);
            preAmb.TabIndex = 1;
            preAmb.Text = "Преамбула: ";
            // 
            // time
            // 
            time.AutoSize = true;
            time.Location = new Point(9, 21);
            time.Name = "time";
            time.Size = new Size(105, 15);
            time.TabIndex = 2;
            time.Text = "Время от запуска:";
            // 
            // battery
            // 
            battery.AutoSize = true;
            battery.Location = new Point(9, 36);
            battery.Name = "battery";
            battery.Size = new Size(49, 15);
            battery.TabIndex = 3;
            battery.Text = "АКБ (v):";
            // 
            // sd1
            // 
            sd1.AutoSize = true;
            sd1.Location = new Point(9, 51);
            sd1.Name = "sd1";
            sd1.Size = new Size(104, 15);
            sd1.TabIndex = 4;
            sd1.Text = "Освещённость 1 :";
            // 
            // sd2
            // 
            sd2.AutoSize = true;
            sd2.Location = new Point(9, 66);
            sd2.Name = "sd2";
            sd2.Size = new Size(104, 15);
            sd2.TabIndex = 5;
            sd2.Text = "Освещённость 2 :";
            // 
            // sd3
            // 
            sd3.AutoSize = true;
            sd3.Location = new Point(9, 81);
            sd3.Name = "sd3";
            sd3.Size = new Size(104, 15);
            sd3.TabIndex = 6;
            sd3.Text = "Освещённость 3 :";
            // 
            // sd4
            // 
            sd4.AutoSize = true;
            sd4.Location = new Point(9, 96);
            sd4.Name = "sd4";
            sd4.Size = new Size(104, 15);
            sd4.TabIndex = 7;
            sd4.Text = "Освещённость 4 :";
            // 
            // AX
            // 
            AX.AutoSize = true;
            AX.Location = new Point(9, 111);
            AX.Name = "AX";
            AX.Size = new Size(100, 15);
            AX.TabIndex = 8;
            AX.Text = "Ускорение X (g) :";
            // 
            // AY
            // 
            AY.AutoSize = true;
            AY.Location = new Point(9, 126);
            AY.Name = "AY";
            AY.Size = new Size(100, 15);
            AY.TabIndex = 9;
            AY.Text = "Ускорение Y (g) :";
            // 
            // AZ
            // 
            AZ.AutoSize = true;
            AZ.Location = new Point(9, 141);
            AZ.Name = "AZ";
            AZ.Size = new Size(100, 15);
            AZ.TabIndex = 10;
            AZ.Text = "Ускорение Z (g) :";
            // 
            // GX
            // 
            GX.AutoSize = true;
            GX.Location = new Point(9, 156);
            GX.Name = "GX";
            GX.Size = new Size(147, 15);
            GX.TabIndex = 11;
            GX.Text = "Угловая скорость X (*/с) :";
            // 
            // GY
            // 
            GY.AutoSize = true;
            GY.Location = new Point(9, 171);
            GY.Name = "GY";
            GY.Size = new Size(147, 15);
            GY.TabIndex = 12;
            GY.Text = "Угловая скорость Y (*/с) :";
            // 
            // GZ
            // 
            GZ.AutoSize = true;
            GZ.Location = new Point(9, 186);
            GZ.Name = "GZ";
            GZ.Size = new Size(147, 15);
            GZ.TabIndex = 13;
            GZ.Text = "Угловая скорость Z (*/с) :";
            // 
            // MX
            // 
            MX.AutoSize = true;
            MX.Location = new Point(9, 201);
            MX.Name = "MX";
            MX.Size = new Size(137, 15);
            MX.TabIndex = 14;
            MX.Text = "Магнитное поле X (Гс) :";
            // 
            // MY
            // 
            MY.AutoSize = true;
            MY.Location = new Point(9, 216);
            MY.Name = "MY";
            MY.Size = new Size(137, 15);
            MY.TabIndex = 15;
            MY.Text = "Магнитное поле Y (Гс) :";
            // 
            // MZ
            // 
            MZ.AutoSize = true;
            MZ.Location = new Point(9, 231);
            MZ.Name = "MZ";
            MZ.Size = new Size(137, 15);
            MZ.TabIndex = 16;
            MZ.Text = "Магнитное поле Z (Гс) :";
            // 
            // flywheel
            // 
            flywheel.AutoSize = true;
            flywheel.Location = new Point(9, 246);
            flywheel.Name = "flywheel";
            flywheel.Size = new Size(62, 15);
            flywheel.TabIndex = 17;
            flywheel.Text = "Маховик :";
            // 
            // postAmb
            // 
            postAmb.AutoSize = true;
            postAmb.Location = new Point(9, 261);
            postAmb.Name = "postAmb";
            postAmb.Size = new Size(81, 15);
            postAmb.TabIndex = 18;
            postAmb.Text = "Постамбула :";
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPage1);
            tabs.Controls.Add(tabPage2);
            tabs.Location = new Point(12, 41);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(483, 310);
            tabs.TabIndex = 19;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(preAmb);
            tabPage1.Controls.Add(postAmb);
            tabPage1.Controls.Add(time);
            tabPage1.Controls.Add(flywheel);
            tabPage1.Controls.Add(battery);
            tabPage1.Controls.Add(MZ);
            tabPage1.Controls.Add(sd1);
            tabPage1.Controls.Add(MY);
            tabPage1.Controls.Add(sd2);
            tabPage1.Controls.Add(MX);
            tabPage1.Controls.Add(sd3);
            tabPage1.Controls.Add(GZ);
            tabPage1.Controls.Add(sd4);
            tabPage1.Controls.Add(GY);
            tabPage1.Controls.Add(AX);
            tabPage1.Controls.Add(GX);
            tabPage1.Controls.Add(AY);
            tabPage1.Controls.Add(AZ);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(475, 282);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Данные";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(graph);
            tabPage2.Controls.Add(dataList);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(475, 282);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Графики данных";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // graph
            // 
            graph.Location = new Point(132, 6);
            graph.Name = "graph";
            graph.Size = new Size(337, 266);
            graph.TabIndex = 1;
            // 
            // dataList
            // 
            dataList.FormattingEnabled = true;
            dataList.Items.AddRange(new object[] { "Время от запуска", "АКБ", "Освещённость 1", "Освещённость 2", "Освещённость 3", "Освещённость 4", "Ускорение X", "Ускорение Y", "Ускорение Z", "Угловая скорость X", "Угловая скорость Z", "Угловая скорость Z", "Магнитное поле X", "Магнитное поле Y", "Магнитное поле Z", "Маховик" });
            dataList.Location = new Point(6, 6);
            dataList.Name = "dataList";
            dataList.Size = new Size(120, 244);
            dataList.TabIndex = 0;
            // 
            // urlBox
            // 
            urlBox.Location = new Point(112, 12);
            urlBox.Name = "urlBox";
            urlBox.PlaceholderText = "URL Телеметрии";
            urlBox.Size = new Size(379, 23);
            urlBox.TabIndex = 20;
            urlBox.KeyDown += urlBox_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 361);
            Controls.Add(urlBox);
            Controls.Add(tabs);
            Controls.Add(toggle);
            Name = "Form1";
            Text = "Wospp's Telemetry Display";
            tabs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button toggle;
        private Label preAmb;
        private Label time;
        private Label battery;
        private Label sd1;
        private Label sd2;
        private Label sd3;
        private Label sd4;
        private Label AX;
        private Label AY;
        private Label AZ;
        private Label GX;
        private Label GY;
        private Label GZ;
        private Label MX;
        private Label MY;
        private Label MZ;
        private Label flywheel;
        private Label postAmb;
        private TabControl tabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox dataList;
        private ScottPlot.WinForms.FormsPlot graph;
        private TextBox urlBox;
    }
}
